using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos : IDatos<Productos>
    {
        ventasBDEntities contexto;
        public ProductoDatos()
        {
            contexto = new ventasBDEntities();
        }

        public bool Nuevo(Productos producto)
        {
            if (contexto.Productos.Add(producto) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Productos> Listar()
        {
            return contexto.Productos.ToList();
        }

        public Productos ById(int id)
        {
            return contexto.Productos.Where(p => p.idproducto == id).FirstOrDefault();
        }
        public bool Actualizar(Productos item)
        {
            Productos temp = ById(item.idproducto);
            //temp.idProducto = item.idProducto;
            temp.name = item.name;
            temp.pvp = item.pvp;
            temp.impuesto = item.impuesto;
            temp.estado = item.estado;
            temp.marca = item.marca;
            contexto.SaveChanges();
            return true;
        }

        public bool Eliminar(int id)
        {
            Productos temp = contexto.Productos.Where(p => p.idproducto == id).FirstOrDefault();
            if (temp != null)
            {
                contexto.Productos.Remove(temp);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
