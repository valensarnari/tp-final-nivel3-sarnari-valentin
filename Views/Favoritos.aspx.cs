using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Controllers;

namespace Views
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                ArticuloController controller = new ArticuloController();
                ListaArticulos = controller.ListarTodosLosArticulos();
			}
			catch (Exception)
			{
                Session.Add("error", "Ocurrió un error al intentar cargar la página [Favoritos], vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}