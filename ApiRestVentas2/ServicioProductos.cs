using AccesoADatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiRestVentas2
{
    public class ServicioProductos : ApiController
    {
        ProductosNegocio productoNegocio = new ProductosNegocio();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = productoNegocio.All();
            return Ok(respuesta);
        }
        //Get/Id
        public IHttpActionResult Get(int id)
        {
            Productos producto = productoNegocio.ById(id);
            if (producto != null)
            {
                return Ok(producto);
            }
            return NotFound();
        }
        //Post
        public IHttpActionResult Post(Productos producto)
        {
            try
            {
                productoNegocio.insertarProducto(producto);
                return Ok("Insertado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Put
        public IHttpActionResult Put(int id, Productos producto)
        {
            // Obtener el producto existente por su ID
            Productos productoExistente = productoNegocio.ById(id);
            if (productoExistente == null)
            {
                return BadRequest("El producto no existe.");
            }

            // Actualizar los valores del producto existente con los valores del producto recibido
            productoExistente.name = producto.name;
            productoExistente.pvp = producto.pvp;
            productoExistente.impuesto = producto.impuesto;
            productoExistente.estado = producto.estado;
            productoExistente.marca = producto.marca;

            // Guardar los cambios en la base de datos
            if (productoNegocio.actualizarProducto(productoExistente))
            {
                return Ok("Producto actualizado correctamente.");
            }
            else
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Productos productoEliminar = productoNegocio.ById(id);
                if (productoEliminar == null)
                {
                    return NotFound();
                }
                productoNegocio.eliminarProducto(productoEliminar.idproducto);
                return Ok("Producto Eliminado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}