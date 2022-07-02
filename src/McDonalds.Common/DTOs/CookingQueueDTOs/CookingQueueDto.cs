using McDonaldsOnWeb.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Common.DTOs.CookingQueueDto
{
    public class CookingQueueItem
    {
        public CookingQueueItemStatus Status { get; set; }
        public string OrderNumber { get; set; }
    }
}
