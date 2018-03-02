using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Supermercado.Models;

namespace Supermercado.Controllers
{
    public class ClaseApiController : ApiController
    {
        SupermercadoEntities db = new SupermercadoEntities();

        [HttpPost]
        [Route("api/crearProductos")]
        public List<SpCrearProductos_Result> Post(TblProductos productos)
        {
            //db.TblProductos.Add(productos);
            //db.SaveChanges();

            //var list = (from A in db.TblProductos.AsEnumerable()
            //            select new TblProductos
            //            {
            //                Prod_Existencias = A.Prod_Existencias,
            //                Prod_IdProducto = A.Prod_IdProducto,
            //                Prod_NombreProducto = A.Prod_NombreProducto,
            //                Prod_Precio = A.Prod_Precio
            //            }).ToList();

            var list = (db.SpCrearProductos(productos.Prod_NombreProducto, productos.Prod_Precio, productos.Prod_Existencias)).ToList();

            return list;
        }
    }
}