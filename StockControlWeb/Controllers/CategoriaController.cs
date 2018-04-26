using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using StockControlWeb.Models;

namespace StockControlWeb.Controllers
{
    public class CategoriaController : Controller
    {
        STOCKDBEntities db = new STOCKDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategoriaList()
        {
            List<CategoriaViewModel> CategoriaList = db.Categoria.Select(x => new CategoriaViewModel
            {
                IdCategoria = x.IdCategoria,
                CategoriaName = x.CategoriaName
            }).ToList();

            return Json(CategoriaList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoriaById(int IdCategoria)
        {
            Categoria model = db.Categoria.Where(x => x.IdCategoria == IdCategoria).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(CategoriaViewModel model)
        {
            var result = false;

            try

            {
                if (model.IdCategoria > 0)
                {
                    Categoria categoria = db.Categoria.SingleOrDefault(x => x.IdCategoria == model.IdCategoria);
                    categoria.CategoriaName = model.CategoriaName;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Categoria categoria = new Categoria();
                    categoria.CategoriaName = model.CategoriaName;
                    db.Categoria.Add(categoria);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategoria(int IdCategoria)
        {
            bool result = false;

            Categoria categoria = db.Categoria.SingleOrDefault(x => x.IdCategoria == IdCategoria);
            if (categoria != null)
            {
                db.Categoria.Remove(categoria);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}