using Dapper;
using McDonaldsOnWeb.Application.Extensions;
using McDonaldsOnWeb.Application.Interfaces;
using McDonaldsOnWeb.Common.DTOs.MenuItemDTOs;
using McDonaldsOnWeb.Common.Entities.ItemEntity;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace McDonaldsOnWeb.Application.Services.MenuItemService
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IDistributedCache _cashe;
        private readonly IApplicationContext _appContext;

        public MenuItemService(IDistributedCache cashe, IApplicationContext appContext)
        {
            _cashe = cashe;
            _appContext = appContext;
        }

        public MenuItemDetailDto? GetItemDetailOrDefault(int? itemId)
        {
            if (!itemId.HasValue) return null;

            MenuItemDetailDto? dto = new MenuItemDetailDto();

            string query = @"select Id, ItemName as Name, ItemDescription as Description, ItemPrice as Price, ItemImage as ImageSrcName
                    from MenuItem where Id = @ItemId;

                    select a.Id, IngredientName as Name, IngredientPrice as Price from OptionIngredientsMenuItems e
	                    inner join OptionIngredients a
	                    on e.IngredientId = a.Id
                    where e.MenuItemId = @ItemId;";

            GridReader reader = _appContext.DbConnection.QueryMultiple(query, new { ItemId = itemId });

            dto = reader.Read<MenuItemDetailDto>().SingleOrDefault();

            dto.OptionIngredients = reader.Read<MenuItemOptionIngredientDto>()
                .ToList();

            _appContext.DbConnection.Close();

            return dto;
        }

        public ICollection<MenuItemDto> GetMenuItemsPerPage()
        {
            ICollection<MenuItemDto> dtos = new List<MenuItemDto>();

            string query = @"select 
	                Id,
	                ItemPrice as Price,
	                ItemImage as ImageSrcName,
	                ItemName as Name,
	                iif ((select count(*) from OptionIngredientsMenuItems e
	                where e.MenuItemId = a.Id) > 0, 'True', 'False') as WithConfigureOptions
                from MenuItem a
                order by Id";

            dtos = _appContext.DbConnection.Query<MenuItemDto>(query)
                .ToList();

            _appContext.DbConnection.Close();

            return dtos;
        }

        public async Task<ICollection<MenuItemDto>> GetPopularItems()
        {
            ICollection<MenuItemDto>? dtos = await _cashe
                .GetRecordAsync<ICollection<MenuItemDto>>("PopularMenuItems");

            if (dtos == null)
            {
                string query = @"select 
	                Id,
	                ItemPrice as Price,
	                ItemImage as ImageSrcName,
	                ItemName as Name
                from MenuItem";

                dtos = _appContext.DbConnection.Query<MenuItemDto>(query)
                    .Take(5)
                    .ToList();

                await _cashe.SetRecordAsync("PopularMenuItems", dtos, TimeSpan.FromMinutes(2));
            }

            return dtos;
        }
    }
}
