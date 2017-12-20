using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataListInASPMVCWithPaging.Models;

namespace DataListInASPMVCWithPaging.Models
{
    public class ProductRepository
    {
        AdventureWorks2012Entities context;

        public ProductRepository()
        {
            context = new AdventureWorks2012Entities();
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            products = (from prod in context.Products
                       join productProductPhoto in context.ProductProductPhotoes on prod.ProductID equals productProductPhoto.ProductID
                       join productPhoto in context.ProductPhotoes on productProductPhoto.ProductPhotoID equals productPhoto.ProductPhotoID
                       where prod.ListPrice > 0
                       select new ProductViewModel()
                       {
                            ProductID = prod.ProductID,
                            ProductName = prod.Name,
                            ProductNumber = prod.ProductNumber,
                            ListPrice = prod.ListPrice,
                            Image = productPhoto.LargePhoto
                       }).ToList();            
            return products;
        }

        public ProductViewModel Product(int productId)
        {
            ProductViewModel product = new ProductViewModel();
            product = (from prod in context.Products
                       join productProductPhoto in context.ProductProductPhotoes on prod.ProductID equals productProductPhoto.ProductID
                       join productPhoto in context.ProductPhotoes on productProductPhoto.ProductPhotoID equals productPhoto.ProductPhotoID
                       where productId == prod.ProductID
                       select new ProductViewModel()
                       {
                           Image = productPhoto.ThumbNailPhoto
                       }).FirstOrDefault();

            return product;
        }
    }
}