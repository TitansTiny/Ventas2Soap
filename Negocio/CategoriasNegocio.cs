using AccesoADatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriasNegocio
    {
        CategoriaDatos categorias;
        public CategoriasNegocio()
        {
            categorias = new CategoriaDatos();
        }
        public List<Categorias> All()
        {
            return categorias.Listar();
        }
        public Categorias ById(int id)
        {
            return categorias.Listar().Where(c => c.idcategoria == id).SingleOrDefault();
        }
        public bool insertarCategoria(Categorias categoriaNuevo)
        {
            return categorias.Nuevo(categoriaNuevo);
        }
        public bool actualizarCategoria(Categorias categoria)
        {
            return categorias.Actualizar(categoria);
        }
        public bool eliminarCategoria(int id)
        {
            return categorias.Eliminar(id);
        }
    }
}
