using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Application.Services.QueueNotifyService
{
    public interface IQueueHubService
    {
        void AppendItemToQueue();
        void RemoveItemFromQueue();
        void GetQueue();
    }
}
