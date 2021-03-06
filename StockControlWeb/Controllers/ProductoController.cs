﻿using Newtonsoft.Json;
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
            List<Categoria> DepList = db.Categoria.ToList();
            ViewBag.ListCategoria = new SelectList(DepList, "IdCategoria", "CategoriaName");

            return View();
        }

        public JsonResult GetProductoList()
        {
            List<ProductoViewModel> ProductoList = db.Producto.Select(x => new ProductoViewModel
            {
                IdProducto = x.IdProducto,
                Codigo = x.Codigo,
                ProductoName = x.ProductoName,
                PrecioVenta = x.PrecioVenta,
                //PrecioCompra = x.PrecioCompra,
                Cantidad = x.Cantidad,
                //CategoriaName = x.Categoria.CategoriaName,
                Stock = x.Stock
            }).ToList();

            return Json(ProductoList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductoById(int IdProducto)
        {
            Producto model = db.Producto.Where(x => x.IdProducto == IdProducto).SingleOrDefault();
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
                if (model.IdProducto > 0)
                {
                    Producto producto = db.Producto.SingleOrDefault(x => x.Activo == 0 && x.IdProducto == model.IdProducto);
                    producto.Codigo = model.Codigo;
                    producto.ProductoName = model.ProductoName;
                    producto.PrecioVenta = model.PrecioVenta;
                    //producto.PrecioCompra = model.PrecioCompra;
                    producto.Cantidad = model.Cantidad;
                    producto.Stock = model.Stock;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Producto producto = new Producto();
                    producto.Codigo = model.Codigo;
                    producto.ProductoName = model.ProductoName;
                    producto.PrecioVenta = model.PrecioVenta;
                    //producto.PrecioCompra = model.PrecioCompra;
                    producto.Cantidad = model.Cantidad;
                    producto.Activo = 1;
                    producto.Stock = model.Stock;
                    producto.IdCategoria = model.IdCategoria;
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
        public JsonResult DeleteCategoria(int IdProducto)
        {
            bool result = false;

            Producto producto = db.Producto.SingleOrDefault(x => x.IdProducto == IdProducto);
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