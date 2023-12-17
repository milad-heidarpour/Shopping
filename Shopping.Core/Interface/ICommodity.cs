

using Microsoft.AspNetCore.Http;
using Shopping.Database.Model;

namespace Shopping.Core.Interface;

public interface ICommodity:IDisposable
{
    Task<List<Commodity>> GetCommodities(/*Guid? ClassificationId,*/bool? notShow = null);
    Task<bool> AddCommodity(Commodity commodity);
    Task<Commodity> GetCommodity(Guid CommodityId);
    Task<bool> AddAlbum(CommodityAlbum commodityAlbum, IFormFile CommodityImg);
    Task<List<CommodityAlbum>> GetCommodityAlbums(Guid CommodityId);
    Task<CommodityAlbum> GetCommodityAlbum(Guid CommodityId);
    Task<bool> DeleteCommodityAlbum(Guid CommodityId);
    Task<bool> DeleteCommodity(Guid CommodityId);
    Task<bool> EditCommodity(Commodity commodity);
    Task<List<Commodity>> GetClassificationCommodities(Guid ClassificationId);
}
