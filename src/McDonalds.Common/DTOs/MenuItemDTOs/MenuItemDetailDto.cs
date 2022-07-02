using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Common.DTOs.MenuItemDTOs
{
    public class MenuItemDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSrcName { get; set; }
        public int Price { get; set; }
        public ICollection<MenuItemOptionIngredientDto> OptionIngredients { get; set; }
    }
}
