using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CategoryManagement
{
    public class TableCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set;}
        public string ParentId { get; set; }
    }
}
