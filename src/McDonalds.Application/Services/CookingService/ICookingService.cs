using McDonaldsOnWeb.Common.DTOs.CookingQueueDto;
using McDonaldsOnWeb.Common.Entities.ItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Application.Services.CookingQueueService
{   
    //redis
    public interface ICookingService
    {
        void CookingOrderItems();
        void NotifyItemDone();
    }
}
