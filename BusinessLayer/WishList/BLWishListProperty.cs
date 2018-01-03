using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.WishList
{
    public class BLWishListProperty
    {
        public int id { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public int quantity { get; set; }
        public string proName { get; set; }
        public string proUrl { get; set; }
    }
}
