using Newtonsoft.Json;
using StockControlWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StockControlWeb.Controllers
{
    public class ProductoController : Controller
    {
        STOCKDBEntities db = new STOCKDBEntities();

        public ActionResult Index()
        {
            List<Producto> DepList = db.Producto.ToList();
            ViewBag.ListOfDepartament = new SelectList(DepList, "CategoriaId", "Nombre");

            return View();
        }

        public JsonResult GetProductoList()
        {
            List<ProductoViewModel> ProductoList = db.Producto.Select(x => new ProductoViewModel
            {
                ProductoId = x.ProductoId,
                ProductoName = x.ProductoName,
                Precio = x.Precio,
                Cantidad = x.Cantidad,
                CategoriaName = x.Categoria.CategoriaName

            }).ToList();


            return Json(ProductoList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductoById(int ProductoId)
        {
            Producto model = db.Producto.Where(x => x.ProductoId == ProductoId).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(ProductoViewModel model)
        {
            var result = false;

            try

            {
                if (model.ProductoId > 0)
                {
                    Producto producto = db.Producto.SingleOrDefault(x => x.ProductoId == model.ProductoId);
                    producto.ProductoName = model.ProductoName;
                    producto.Precio = model.Precio;
                    producto.Cantidad = model.Cantidad;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Producto producto = new Producto();
                    producto.ProductoName = model.ProductoName;
                    producto.Precio = model.Precio;
                    producto.Cantidad = model.Cantidad;
                    db.Producto.Add(producto);
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

        public JsonResult DeleteCategoria(int ProductoId)
        {
            bool result = false;

            Producto producto = db.Producto.SingleOrDefault(x => x.ProductoId == ProductoId);
            if (producto != null)
            {
                db.Producto.Remove(producto);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}