using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopping.Core.Interface;
using Shopping.Core.ViewModels;
using Shopping.Database.Classes;
using Shopping.Database.Context;
using Shopping.Database.Model;

namespace Shopping.Core.Service;

public class CommodityService : ICommodity
{
    string CommodityImgPath = "wwwroot/Images/Commodity";

    string CommodityAlbumImgPath = "wwwroot/Images/Commodity/CommodityAlbum";

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
    public async Task<bool> AddCommodity(Commodity commodity, IFormFile CommodityImg)
    {
        try
        {
            int imgCode = new Random().Next(10000, 100000);
            string imgName = imgCode + CommodityImg.FileName;

            if (!Directory.Exists(CommodityImgPath))
                Directory.CreateDirectory(CommodityImgPath);
            string savePath = Path.Combine(CommodityImgPath, imgName);

            using (Stream Stream = new FileStream(savePath, FileMode.Create))
            {
                await CommodityImg.CopyToAsync(Stream);
            }

            // add product to database(products table)
            commodity.ProductImg = imgName;

            Commodity FinalCommo = new Commodity()
            {
                Id = commodity.Id,
                BrandId = commodity.BrandId,
                GroupId = commodity.GroupId,
                ProductFaName = commodity.ProductFaName,
                ProductEnName = commodity.ProductEnName,
                ProductImg = imgName,
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

            if (!Directory.Exists(CommodityAlbumImgPath))
                Directory.CreateDirectory(CommodityAlbumImgPath);
            string savePath = Path.Combine(CommodityAlbumImgPath, imgName);

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
        if (album.Count>0)
        {
            return await Task.FromResult(album);
        }
        return null;
        
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
                var CommodityImg = commodity.ProductImg;
                string ExitingCommodityFile = Path.Combine(CommodityImgPath, CommodityImg);
                System.IO.File.Delete(ExitingCommodityFile);
                _context.Commodities.Remove(commodity);
                

                foreach (var item in album)
                {
                    var CommodityAlbum = item.CommodityImg;
                    string ExitingAlbumFile = Path.Combine(CommodityAlbumImgPath, CommodityAlbum);
                    System.IO.File.Delete(ExitingAlbumFile);
                }

               

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

    


    #region Not Working For Edit Commodity

    //public async Task<bool> EditCommodity(Commodity commodity)
    //{
    //    try
    //    {
    //        Commodity FinalCommo = new Commodity()
    //        {
    //            Id = commodity.Id,
    //            BrandId = commodity.BrandId,
    //            GroupId = commodity.GroupId,
    //            ProductFaName = commodity.ProductFaName,
    //            ProductEnName = commodity.ProductEnName,
    //            ProductImg = commodity.ProductImg,
    //            Price = commodity.Price,
    //            Discount = commodity.Discount,
    //            Inventory = commodity.Inventory,
    //            Introduction = commodity.Introduction,
    //            NotShow = commodity.NotShow,
    //            RegisterDate = commodity.RegisterDate,
    //            UpdateDate = await new DateAndTime().GetPersianDate(),
    //            //Brand = commodity.Brand,
    //            //CommodityAlbums=commodity.CommodityAlbums,
    //        };
    //        _context.Commodities.Update(FinalCommo);
    //        await _context.SaveChangesAsync();
    //        return await Task.FromResult(true);
    //    }
    //    catch (Exception)
    //    {
    //        return await Task.FromResult(false);
    //        //throw;
    //    }
    //}




    //public async Task<bool> EditCommodityImg(EditCommodityViewModel viewModel, IFormFile CommodityImg)
    //{
    //    try
    //    {
    //        int imgCode = new Random().Next(10000, 1000000);
    //        string imgName = imgCode + CommodityImg.FileName;

    //        if (!Directory.Exists(CommodityImgPath))
    //            Directory.CreateDirectory(CommodityImgPath);
    //        string savePath = Path.Combine(CommodityImgPath, imgName);

    //        using (Stream Stream = new FileStream(savePath, FileMode.Create))
    //        {
    //            await CommodityImg.CopyToAsync(Stream);
    //        }

    //        viewModel.ProductImg = imgName;

    //        // add product to database(products table)

    //        Commodity commodity = new Commodity()
    //        {
    //            Id = viewModel.Id,
    //            BrandId = viewModel.BrandId,
    //            GroupId = viewModel.GroupId,
    //            ProductFaName = viewModel.ProductFaName,
    //            ProductEnName = viewModel.ProductEnName,
    //            ProductImg = viewModel.ProductImg,
    //            Price = viewModel.Price,
    //            Discount = viewModel.Discount,
    //            Inventory = viewModel.Inventory,
    //            Introduction = viewModel.Introduction,
    //            NotShow = viewModel.NotShow,
    //            RegisterDate = viewModel.RegisterDate,
    //            UpdateDate = viewModel.UpdateDate,
    //        };

    //        _context.Commodities.Update(commodity);
    //        await _context.SaveChangesAsync();
    //        return await Task.FromResult(true);
    //    }
    //    catch (Exception)
    //    {
    //        return await Task.FromResult(true);
    //        //throw;
    //    }
    //}

    #endregion

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

    public async Task<bool> EditCommodity(EditCommodityViewModel commodity, IFormFile? CommodityImg)
    {
        try
        {
            if (CommodityImg!=null)
            {
                int imgCode = new Random().Next(10000, 1000000);
                string imgName = imgCode + CommodityImg.FileName;

                if (!Directory.Exists(CommodityImgPath))
                    Directory.CreateDirectory(CommodityImgPath);
                string savePath = Path.Combine(CommodityImgPath, imgName);

                using (Stream Stream = new FileStream(savePath, FileMode.Create))
                {
                    await CommodityImg.CopyToAsync(Stream);
                }

                commodity.ProductImg = imgName;

            }

            // add product to database(products table)

            Commodity Commodity = new Commodity()
            {
                Id = commodity.Id,
                BrandId = commodity.BrandId,
                GroupId = commodity.GroupId,
                ProductFaName = commodity.ProductFaName,
                ProductEnName = commodity.ProductEnName,
                ProductImg = commodity.ProductImg,
                Price = commodity.Price,
                Discount = commodity.Discount,
                Inventory = commodity.Inventory,
                Introduction = commodity.Introduction,
                NotShow = commodity.NotShow,
                RegisterDate = commodity.RegisterDate,
                UpdateDate = await new DateAndTime().GetPersianDate(),
            };

            _context.Commodities.Update(Commodity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(true);
            //throw;
        }
    }

    //public async Task<List<CommodityFeature>> GetCommodityFeatures()
    //{
    //    var commodityFeatures=await _context.CommodityFeatures.Include(f=>f.Commodity).ToListAsync();
    //    return await Task.FromResult(commodityFeatures);
    //}
}
