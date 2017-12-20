using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DataListInASPMVCWithPaging.Models;

namespace DataListInASPMVCWithPaging.Helpers
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {
        ProductRepository repository;

        public ImageHandler()
        {
            repository = new ProductRepository();
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["ProductID"] != null)
            {
                ProductViewModel product = repository.Product(Convert.ToInt32(context.Request.QueryString["ProductID"]));
                if (product != null)
                {
                    Byte[] bytes = product.Image;
                    Bitmap image = GetImage(bytes);

                    context.Response.Buffer = true;
                    context.Response.Charset = "";
                    context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    context.Response.ContentType = "image/jpeg";
                    image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    context.Response.Flush();
                    context.Response.End();
                }
            }
        }

        private Bitmap GetImage(Byte[] bytes)
        {
            Image originalImage;
            Bitmap originalBmp;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                originalImage = Image.FromStream(ms);
            }

            originalBmp = new Bitmap(originalImage);
            Bitmap tempBitmap = new Bitmap(originalBmp.Width, originalBmp.Height);
            using(Graphics g = Graphics.FromImage(tempBitmap))
            {
                // Draw the original bitmap onto the graphics of the new bitmap
                g.DrawImage(originalBmp, 0, 0);
                Rectangle Box = new Rectangle(0, 0, tempBitmap.Size.Width, tempBitmap.Size.Height);
                g.DrawRectangle(Pens.White, Box);
            }
            
            return tempBitmap;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}