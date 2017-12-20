using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace DataListInASPMVCWithPaging.Models
{
    public class PagingModel
    {
        public PagingModel()
        {
            Size = 24;
            Page = 1;
        }

        public int Page { get; set; }
        public int Size { get; set; }
    }

    public class IndexModel
    {
        public PagingModel PageModel { get; set; }

        public IndexModel(PagingModel pageModel)
        {
            Products = new PagedList<ProductViewModel>(new List<ProductViewModel>(), 1, pageModel.Size);
            PageModel = pageModel;
        }

        public IPagedList<ProductViewModel> Products { get; set; }
    }
}