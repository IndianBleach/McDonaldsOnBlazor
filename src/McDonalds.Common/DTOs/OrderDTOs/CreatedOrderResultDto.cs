using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Common.DTOs.OrderDTOs
{
    public class CreatedOrderResult
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
