using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataListInASPMVCWithPaging.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public decimal ListPrice { get; set; }
        public byte[] Image { get; set; }
    }
}