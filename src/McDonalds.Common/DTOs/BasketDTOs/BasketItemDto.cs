using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Common.DTOs.BasketDTOs
{
    public class SelectedMenuItemDto
    {
        public int Id { get; set; }
    }

    public class SelectedItemOptionIngredientDto
    {
        public int Id { get; set; }
    }

    public class BasketItemDto
    {
        public SelectedMenuItemDto MenuItem { get; set; }
        public ICollection<SelectedItemOptionIngredientDto> OptionIngredients { get; set; }
    }
}
