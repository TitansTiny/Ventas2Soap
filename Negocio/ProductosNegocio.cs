using AccesoADatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductosNegocio
    {
        ProductoDatos productos;
        public ProductosNegocio()
        {
            productos = new ProductoDatos();
        }
        public List<Productos> All()
        {
            return productos.Listar();
        }
        public Productos ById(int id)
        {
            return productos.Listar().Where(p => p.idproducto == id).SingleOrDefault();
        }
        public bool insertarProducto(Productos productoNuevo)
        {
            return productos.Nuevo(productoNuevo);
        }
        public bool actualizarProducto(Productos producto)
        {
            return productos.Actualizar(producto);
        }
        public bool eliminarProducto(int id)
        {
            return productos.Eliminar(id);
        }
    }
}
