using ProductManagement.Business.Manager.Interface;
using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    [CustomAuthenticationFilter]
    public class ProductController : Controller
    {
        IProductManager manager;
        public ProductController(IProductManager _manager)
        {
            manager = _manager;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(manager.GetAllProduct());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(manager.GetById(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel product, HttpPostedFileBase file)
        {
            try
            {
                product.UserId = Convert.ToInt32(Session["UserId"].ToString());
                if (file != null)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(file.InputStream))
                    {
                        bytes = br.ReadBytes(file.ContentLength);
                        product.ImageData = bytes;
                        product.ImageName = Path.GetFileName(file.FileName);
                        product.ImageContentType = file.ContentType;

                    }

                }
                else
                    return View(product);

                if (ModelState.IsValid)
                {                    
                    if (manager.Create(product))
                        return RedirectToAction("Index");
                    return View(product);
                }
                // TODO: Add insert logic here
                return View(product);
            }
            catch
            {
                return View(product);
                throw;
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(manager.GetById(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductViewModel product, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(file.InputStream))
                    {
                        bytes = br.ReadBytes(file.ContentLength);
                        product.ImageData = bytes;
                        product.ImageName = Path.GetFileName(file.FileName);
                        product.ImageContentType = file.ContentType;

                    }

                }
                if (ModelState.IsValid)
                {
                    if (manager.Edit(product))
                        return RedirectToAction("Index");
                    return View(product);
                }
                // TODO: Add insert logic here
                return View(product);
            }
            catch
            {
                return View(product);
                throw;
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {            
            manager.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult MultipleDelete(FormCollection formCollection)
        {
            try
            {
                string[] ids = formCollection["ID"].Split(new char[] { ',' });
                if(ids != null)
                {
                    foreach (string id in ids)
                    {
                        manager.Delete(Convert.ToInt32(id));
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
                throw;
            }
            
        }

        [HttpGet]
        public ActionResult GetAllCatrgory()
        {
            List<ProductCategoryViewModel> category = manager.GetAllCategory();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckError()
        {
            try
            {
                manager.Create(new ProductViewModel());
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

    }
}
