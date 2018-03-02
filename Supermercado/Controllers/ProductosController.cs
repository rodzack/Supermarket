using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supermercado.Models;

namespace Supermercado.Controllers
{
    public class ProductosController : Controller
    {
        SupermercadoEntities db = new SupermercadoEntities();
        // GET: Productos

        public ActionResult Index()
        {
            ViewBag.listaProductos = db.SpListarProductos();
            return View();
        }

        // GET: Productos/Details/5
        public ActionResult Modificar(int Prod_IdProducto)
        {
            var Producto = db.SpListarProductoEditar(Prod_IdProducto).FirstOrDefault();
            return View(Producto);
        }

        [HttpPost]
        public ActionResult Modificar(TblProductos productos)
        {
            db.SpEditarProductos(productos.Prod_IdProducto,productos.Prod_NombreProducto,productos.Prod_Precio,productos.Prod_Existencias);
            return RedirectToAction("Index");
        }

        // GET: Productos/Create
        public ActionResult Eliminar(int Prod_IdProducto)
        {
            //db.Entry(productos).State = EntityState.Deleted;
            //db.SaveChanges();
            db.SpEliminarProductos(Prod_IdProducto);
            return RedirectToAction("Index");
        }
       
    }
}
