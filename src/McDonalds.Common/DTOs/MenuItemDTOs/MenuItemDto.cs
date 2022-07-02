using McDonaldsOnWeb.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Common.Entities.ItemEntity
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string ImageSrcName { get; set; }
        public string Name { get; set; }
        public bool WithConfigureOptions { get; set; }        
    } 
}
