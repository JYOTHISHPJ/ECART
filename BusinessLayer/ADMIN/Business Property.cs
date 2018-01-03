using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Business_Property
    {
        public string product_id { get; set; }
        public string category_id { get; set; }
        public string product_name { get; set; }
        public string brand_name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string product_image { get; set; }
        public string slider_image { get; set; }
        public string date { get; set; }
        public string details { get; set; }
        public int TS_SLIDER_ID { get; set; }
        public string admin_user { get; set; }
        public string admin_pass { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
    }
}
