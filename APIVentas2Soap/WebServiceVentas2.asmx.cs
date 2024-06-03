using AccesoADatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace APIVentas2Soap
{
    /// <summary>
    /// Summary description for WebServiceVentas2
    /// </summary>
    // NOMBRE APELLIDOS: Alexis Vargas
    // PARALELO: P3228
    // SI – INTEGRACIÓN DE SISTEMAS 
    // FECHA: 03/06/2024
    // PRÁCTICA No. #7
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceVentas2 : System.Web.Services.WebService
    {
        ProductosNegocio productos = new ProductosNegocio();

        [WebMethod]
        public List<Productos> ListarProductos()
        {
            return productos.All();
        }
    }
}
