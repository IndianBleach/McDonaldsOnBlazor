using McDonaldsOnWeb.Common.DTOs.CookingQueueDto;
using McDonaldsOnWeb.Common.Entities.ItemEntity;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Application.Services.CookingQueueService
{
    public class CookingService : ICookingService
    {
        private readonly IDistributedCache _cashe;
        public CookingService(IDistributedCache cashe)
        {
            _cashe = cashe;
        }

        public ICollection<CookingQueueItem> GetCookingQueue()
        {
            throw new NotImplementedException();
        }

        public void PushNumberToQueue()
        {
            throw new NotImplementedException();
        }

        public void RemoveNumberFromQueue()
        {
            throw new NotImplementedException();
        }
    }
}
