using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopping.Core.Interface;
using Shopping.Database.Classes;
using Shopping.Database.Context;
using Shopping.Database.Model;

namespace Shopping.Core.Service;

public class CommodityService : ICommodity
{
    string imgPath = "wwwroot/Images/Commodity";
    private readonly DatabaseContext _context;
    public CommodityService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Commodity>> NoDupCommodities(Guid? DupId1 = null, Guid? DupId2 = null, Guid? DupId3 = null, Guid? DupId4 = null,  /*Guid? ClassificationId,*/ bool? notShow = null)
    {
        var commodity = await _context.Commodities.Include(f=>f.Group).Include(f=>f.Brand).Include(f=>f.CommodityAlbums).FirstOrDefaultAsync(f=>f.Id==DupId1);
        var NoDupcommodities = await _context.Commodities.Where(f=>f.NotShow==notShow).Where(f => f.Id != DupId1).Where(f => f.Id != DupId2).Where(f => f.Id != DupId3).Where(f => f.Id != DupId4).Where(f => f.GroupId == commodity.GroupId).ToListAsync(); 
        var commodities = await _context.Commodities.Include(c => c.Brand).Include(c => c.Group).Include(f => f.CommodityAlbums).ToListAsync();
        //if (notShow != null)
        //{
        //    return await Task.FromResult(commodities.Where(c => c.NotShow == notShow).ToList());
        //}
        //if (ClassificationId != null)
        //{
        //    return await Task.FromResult(commodities.Where(c => c.Group.Id == ClassificationId).ToList());
        //}
        return await Task.FromResult(NoDupcommodities);
    }

    public async Task<Commodity> GetCommodity(Guid? CommodityId)
    {
        var commodity = await _context.Commodities.Include(c => c.Group).Include(c => c.Brand).Include(c => c.CommodityAlbums).FirstOrDefaultAsync(c => c.Id == CommodityId);
        return await Task.FromResult(commodity);
    }
    public async Task<bool> AddCommodity(Commodity commodity)
    {
        try
        {
            Commodity FinalCommo = new Commodity()
            {
                Id = commodity.Id,
                BrandId = commodity.BrandId,
                GroupId = commodity.GroupId,
                ProductFaName = commodity.ProductFaName,
                ProductEnName = commodity.ProductEnName,
                Price = commodity.Price,
                Discount = commodity.Discount,
                Inventory = commodity.Inventory,
                Introduction = commodity.Introduction,
                NotShow = commodity.NotShow,
                RegisterDate = await new DateAndTime().GetPersianDate(),
                UpdateDate = null,
                Brand = commodity.Brand,
            };
            await _context.Commodities.AddAsync(FinalCommo);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(true);
            //throw;
        }
    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<bool> AddAlbum(CommodityAlbum Album, IFormFile CommodityImg)
    {
        try
        {
            int imgCode = new Random().Next(10000, 100000);
            string imgName = imgCode + CommodityImg.FileName;

            if (!Directory.Exists(imgPath))
                Directory.CreateDirectory(imgPath);
            string savePath = Path.Combine(imgPath, imgName);

            using (Stream Stream = new FileStream(savePath, FileMode.Create))
            {
                await CommodityImg.CopyToAsync(Stream);
            }

            // add product to database(products table)
            Album.CommodityImg = imgName;
            await _context.CommoditiesAlbum.AddAsync(Album);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<List<CommodityAlbum>> GetCommodityAlbums(Guid CommodityId)
    {
        var album = await _context.CommoditiesAlbum.Include(c => c.Commodity).Where(c => c.CommodityId == CommodityId).ToListAsync();
        return await Task.FromResult(album);
    }

    public async Task<CommodityAlbum> GetCommodityAlbum(Guid CommodityId)
    {
        var commodityAlbum = await _context.CommoditiesAlbum.Include(c => c.Commodity).FirstOrDefaultAsync(c => c.Id == CommodityId);
        return await Task.FromResult(commodityAlbum);
    }

    public async Task<bool> DeleteCommodityAlbum(Guid CommodityId)
    {
        try
        {
            var commodityAlbum = await _context.CommoditiesAlbum.Include(c => c.Commodity).FirstOrDefaultAsync(c => c.Id == CommodityId);
            if (commodityAlbum != null)
            {
                _context.CommoditiesAlbum.Remove(commodityAlbum);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<bool> DeleteCommodity(Guid CommodityId)
    {
        try
        {
            var commodity = await _context.Commodities.Include(c => c.CommodityAlbums).Include(c => c.Brand).FirstOrDefaultAsync(c => c.Id == CommodityId);
            var album = commodity.CommodityAlbums;
            if (commodity != null)
            {
                _context.Commodities.Remove(commodity);
                await _context.SaveChangesAsync();

                foreach (var item in album)
                {
                    var file = item.CommodityImg;
                    string ExitingFile = Path.Combine(imgPath, file);
                    System.IO.File.Delete(ExitingFile);
                }

                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<bool> EditCommodity(Commodity commodity)
    {
        try
        {
            Commodity FinalCommo = new Commodity()
            {
                Id = commodity.Id,
                BrandId = commodity.BrandId,
                GroupId = commodity.GroupId,
                ProductFaName = commodity.ProductFaName,
                ProductEnName = commodity.ProductEnName,
                Price = commodity.Price,
                Discount = commodity.Discount,
                Inventory = commodity.Inventory,
                Introduction = commodity.Introduction,
                NotShow = commodity.NotShow,
                RegisterDate = commodity.RegisterDate,
                UpdateDate = await new DateAndTime().GetPersianDate(),
                //Brand = commodity.Brand,
                //CommodityAlbums=commodity.CommodityAlbums,
            };
            _context.Commodities.Update(FinalCommo);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<List<Commodity>> GetClassificationCommodities(Guid ClassificationId)
    {
        var commodity = await _context.Commodities.Include(c => c.CommodityAlbums).Include(c => c.Brand).Include(c => c.Group).Where(c => c.Group.Id == ClassificationId).ToListAsync();
        return await Task.FromResult(commodity);
    }

    public async Task<List<Commodity>> GetCommodities(bool? notShow = null)
    {
        var commodities = await _context.Commodities.Include(c => c.Brand).Include(c => c.Group).Include(f => f.CommodityAlbums).ToListAsync();
        if (notShow != null)
        {
            return await Task.FromResult(commodities.Where(c => c.NotShow == notShow).ToList());
        }
        //if (ClassificationId != null)
        //{
        //    return await Task.FromResult(commodities.Where(c => c.Group.Id == ClassificationId).ToList());
        //}
        return await Task.FromResult(commodities);
    }
}
