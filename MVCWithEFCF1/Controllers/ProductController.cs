using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore;
using MVCWithEFCF1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFCF1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        StoreDBContext storeDBContext = new StoreDBContext();

        public ViewResult DisplayProduct()
        {
         var product = storeDBContext.Products.Include(p => p.category).Where(p => p.Discontinued == false).Single(); 

          return View (product);
        }

        public ViewResult DisplayProductId(int Id)
        {
            Products products = storeDBContext.Products.Include(p=>p.category).Where(p=>p.Id==Id && p.Discontinued==false).Single();
            return View (products);
        }
        public ViewResult AddCategory()
        {
            ViewBag.CategoryId = new SelectList(storeDBContext.Category, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddProduct(Products product, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string DirectoryPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                selectedFile.SaveAs(DirectoryPath + selectedFile.FileName);
                BinaryReader br = new BinaryReader(selectedFile.InputStream);
                product.ProductImage = br.ReadBytes(selectedFile.ContentLength);
                product.ProductImageName = selectedFile.FileName;
            }
            storeDBContext.Products.Add(product);
            storeDBContext.SaveChanges();
            return RedirectToAction("DisplayProduct");


            }

        public ViewResult EditProduct(int Id)
        {
            Products products = storeDBContext.Products.Find(Id);
            TempData["ProductImage"] = products.ProductImage;
            TempData["ProductImageName"]=products.ProductImageName;
            ViewBag.CategoryId=new SelectList(storeDBContext.Category, "CategoryId", "CategoryName",products.CatId);
            return View(products);
        }

        [HttpPost]
        public RedirectToRouteResult UpdateProduct(Products product,HttpPostedFile selectedFile)
        {
            if (selectedFile != null)
            {
                string DirectoryPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                selectedFile.SaveAs(DirectoryPath + selectedFile.FileName);
                BinaryReader br = new BinaryReader(selectedFile.InputStream);
                product.ProductImage = br.ReadBytes(selectedFile.ContentLength);
                product.ProductImageName = selectedFile.FileName;
            }
            else if (TempData["ProductImage"] != null && TempData["ProductImageName"] != null)
            {
                product.ProductImage = (byte[])TempData["ProductImage"];
                product.ProductImageName = (string)TempData["ProductImageName"];
            }
            storeDBContext.Entry(product).State = EntityState.Modified;
            storeDBContext.SaveChanges();
            return RedirectToAction("DisplayProducts");

        }

        public RedirectToRouteResult DeleteProduct(int Id)
        {
            Products product = storeDBContext.Products.Find(Id);
            product.Discontinued = true;
            storeDBContext.Entry(product).State = EntityState.Modified;
            storeDBContext.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}