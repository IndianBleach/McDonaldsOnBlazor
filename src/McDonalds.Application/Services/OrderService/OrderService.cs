using McDonaldsOnWeb.Common.DTOs.BasketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Application.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public void OrderPayment(ICollection<BasketItemDto> basketItems, string uniqueOrderGuid)
        {
            // send queue to all users
            // startCooking

            foreach (var item in basketItems)
            {

            }



            throw new NotImplementedException();
        }
    }
}
