using McDonaldsOnWeb.Common.DTOs.BasketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Application.Services.OrderService
{
    public interface IOrderService
    {
        void OrderPayment(ICollection<BasketItemDto> basketItems, string uniqueOrderGuid);
    }
}
