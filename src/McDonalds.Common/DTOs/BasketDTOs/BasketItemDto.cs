using McDonaldsOnWeb.Common.Entities.ItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Common.DTOs.BasketDTOs
{
    public class SelectedItemOptionIngredientDto
    {
        public int Id { get; set; }
        public bool IsAppendToMenuItem { get; set; }
    }

    public class BasketItemDto
    {
        public MenuItemDto MenuItem { get; set; }
        public ICollection<SelectedItemOptionIngredientDto> OptionIngredients { get; set; }
    }
}
