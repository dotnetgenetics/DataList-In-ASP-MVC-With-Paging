using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataListInASPMVCWithPaging.Models;
using PagedList;
using PagedList.Mvc;

namespace DataListInASPMVCWithPaging.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository repository;
        private IndexModel model;

        public ProductController()
        {
            repository = new ProductRepository();
        }
        
        // GET: Product
        public ActionResult Index(PagingModel pageModel)
        {
            model = new IndexModel(pageModel);
            model.Products = repository.GetProducts().ToPagedList(pageModel.Page, pageModel.Size);
            return View(model);
        }
    }
}