using McDonaldsOnWeb.Common.DTOs.MenuItemDTOs;
using McDonaldsOnWeb.Common.Entities.ItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Application.Services.MenuItemService
{

    public interface IMenuItemService
    {
        //redis
        public Task<ICollection<MenuItemDto>> GetPopularItems();

        public MenuItemDetailDto? GetItemDetailOrDefault(int? itemId);
        public ICollection<MenuItemDto> GetMenuItemsPerPage();
    }
}
