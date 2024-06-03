using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CategoriaDatos : IDatos<Categorias>
    {
        ventasBDEntities contexto;
        public CategoriaDatos()
        {
            contexto = new ventasBDEntities();
        }
        public bool Nuevo(Categorias item)
        {
            if (contexto.Categorias.Add(item) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Categorias> Listar()
        {
            return contexto.Categorias.ToList();
        }
        public Categorias ById(int id)
        {
            return contexto.Categorias.Where(c => c.idcategoria == id).FirstOrDefault();
        }
        public bool Actualizar(Categorias item)
        {
            Categorias temp = ById(item.idcategoria);
            temp.nombrecategoria = item.nombrecategoria;
            temp.observacioncategoria = item.observacioncategoria;
            contexto.SaveChanges();
            return true;
        }

        public bool Eliminar(int id)
        {
            Categorias temp = contexto.Categorias.Where(c => c.idcategoria == id).FirstOrDefault();
            if (temp != null)
            {
                contexto.Categorias.Remove(temp);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
