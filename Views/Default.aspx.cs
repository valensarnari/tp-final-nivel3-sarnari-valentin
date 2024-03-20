using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MarcaController marcaController = new MarcaController();
                CategoriaController categoriaController = new CategoriaController();
                ArticuloController articuloController = new ArticuloController();

                ListaArticulos = articuloController.ListarTodosLosArticulos();

                if (!IsPostBack)
                {
                    ddlCategoria.DataSource = categoriaController.ListarTodasLasCategorias(true);
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = marcaController.ListarTodasLasMarcas(true);
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlPrecio.Items.Add("Todos los precios");
                    ddlPrecio.Items.Add("Mayor a");
                    ddlPrecio.Items.Add("Menor a");
                    ddlPrecio.Items.Add("Igual a");
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al intentar carga la página [Default], vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void btnBuscarBasico_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloController controller = new ArticuloController();

                ListaArticulos = controller.FiltrarPorNombre(txtFiltroBasico.Text);
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de buscar por nombre, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnResetBasico_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloController controller = new ArticuloController();

                txtFiltroBasico.Text = "";
                ListaArticulos = controller.ListarTodosLosArticulos();

                ddlCategoria.SelectedIndex = 0;
                ddlMarca.SelectedIndex = 0;
                ddlPrecio.SelectedIndex = 0;
                txtPrecio.Text = "";
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de resetear la búsqueda por nombre, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloController controller = new ArticuloController();

                string marca = ddlMarca.SelectedValue;
                string categoria = ddlCategoria.SelectedValue;
                string precioText = txtPrecio.Text;
                string precio;
                if (precioText != "")
                    precio = ddlPrecio.SelectedValue;
                else
                    precio = "Todos los precios";


                ListaArticulos = controller.Filtrar(marca, categoria, precio, precioText);

                txtFiltroBasico.Text = "";
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de usar el filtro avanzado, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnResetAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloController controller = new ArticuloController();

                txtFiltroBasico.Text = "";
                ListaArticulos = controller.ListarTodosLosArticulos();

                ddlCategoria.SelectedIndex = 0;
                ddlMarca.SelectedIndex = 0;
                ddlPrecio.SelectedIndex = 0;
                txtPrecio.Text = "";
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de resetear el filtro avanzado, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}