using McDonaldsOnWeb.Common.DTOs.BasketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Common.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public ICollection<BasketItemDto> Items { get; set; }
        public string DateCreated { get; set; }
    }
}
