using BrainstormingFoodTek.DTOs.ItemsDTOs.Response;
using BrainstormingFoodTek.Helpers.ItemsValidation;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BrainstormingFoodTek.Helpers.UserValidation;

namespace BrainstormingFoodTek.Services
{
    public class ItemsService:IItems
    {
        private readonly RestaurantDbContext _foodtekDbContext;
        private readonly ItemsValidation _itemsValidation;
        private readonly ValidateUserExist _userValidation;
        public ItemsService(RestaurantDbContext foodtekDbContext, ItemsValidation itemsValidation,
            ValidateUserExist validateUserExist)
        {
            _foodtekDbContext = foodtekDbContext;
            _itemsValidation = itemsValidation;
            _userValidation = validateUserExist;
        }

        public async Task<List<TopRatedItemsResponseDTO>> GetTopRatedItems()
        {
            try
            {
                var topRatedItems = await _foodtekDbContext.Items
                .Select(item => new
                {
                    Item = item,
                    AverageRate = _foodtekDbContext.RatingsAndReviews
                        .Where(r => r.ItemId == item.ItemId)
                        .Average(r => (double?)r.RatingValue) ?? 0
                })
                  .OrderBy(x => x.AverageRate)
                  .Take(10)
                  .Select(x => new TopRatedItemsResponseDTO
                  {
                      Id = x.Item.ItemId,
                      EnglishName = x.Item.EnglishName,
                      ArabicName = x.Item.ArabicName,
                      EnglishDescription = x.Item.DescriptionEn,
                      ArabicDescription = x.Item.DescriptionAr,
                      Price = x.Item.Price,
                      Image = x.Item.ImagePath,
                      Rate = x.AverageRate
                  })
                  .ToListAsync();

                return topRatedItems;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TopRecommendedItemDTO>> TopRecommendedItems()
        {
            try
            {
                var topItems = await _foodtekDbContext.OrderItems
            .GroupBy(oi => oi.ItemId)
            .Select(group => new
            {
                ItemId = group.Key,
                OrderCount = group.Sum(x => x.Quantity)
            })
                 .OrderByDescending(x => x.OrderCount)
                 .Take(10)
                 .Join(_foodtekDbContext.Items,
                 g => g.ItemId,
                 i => i.ItemId,
                 (g, i) => new TopRecommendedItemDTO
                 {
                     Id = i.ItemId,
                     EnglishName = i.EnglishName,
                     ArabicName = i.ArabicName,
                     EnglishDescription = i.DescriptionEn,
                     ArabicDescription = i.DescriptionAr,
                     Price = i.Price,
                     Image = i.ImagePath
                 }).ToListAsync();

                return topItems;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ItemByCategoryDTO>> GetItemByCategory(int categoryId)
        {
            try
            {
                if (_itemsValidation.IsItemValid(categoryId) == false)
                {
                    throw new Exception();
                }
                else
                {
                    var items = await _foodtekDbContext.Items
                    .Where(i => i.CategoryId == categoryId)
                    .Select(i => new ItemByCategoryDTO
                    {
                        Id = i.ItemId,
                        EnglishName = i.EnglishName,
                        ArabicName = i.ArabicName,
                        EnglishDescription = i.DescriptionEn,
                        ArabicDescription = i.DescriptionAr,
                        Price = i.Price,
                        Image = i.ImagePath,

                    })
                    .ToListAsync();
                    return items;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FavoriteItemDTO>> GetFavoriteItemByUserId(int UserId)
        {
            try
            {
                if (_userValidation.IsUserValid(UserId)==false)
                {
                    throw new Exception();
                }
                var query = await (from fav in _foodtekDbContext.FavoriteItems
                                   join
                                   i in _foodtekDbContext.Items
                                   on fav.ItemId equals i.ItemId
                                   where (fav.ClientId == UserId)
                                   select new FavoriteItemDTO
                                   {
                                       Id = fav.ItemId,
                                       EnglishName = i.EnglishName,
                                       ArabicName = i.ArabicName,
                                       EnglishDescription = i.DescriptionEn,
                                       ArabicDescription = i.DescriptionAr,
                                       Price = i.Price,
                                       CreationDate = fav.CreationDate
                                   }).ToListAsync();

                return query;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ItemDTO> GetOneItem(int ItemId)
        {
            try
            {
                if (_itemsValidation.IsItemValid(ItemId)==true)
                {
                    var existing = await _foodtekDbContext.Items.FindAsync(ItemId);
                    var itemDTO = new ItemDTO
                    {
                        NameAr = existing.ArabicName,
                        NameEn = existing.EnglishName,
                        DescriptionAr = existing.DescriptionAr,
                        DescriptionEn = existing.DescriptionEn,
                        Price = Convert.ToSingle(existing.Price)
                    };

                    return itemDTO;
                }
                throw new Exception();
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }
    }
}
