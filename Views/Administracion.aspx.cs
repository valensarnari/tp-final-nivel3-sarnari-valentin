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
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloController controller = new ArticuloController();

                dgvArticulos.DataSource = controller.ListarTodosLosArticulos();
                dgvArticulos.DataBind();

                if (!IsPostBack)
                {
                    ddlCampo.Items.Add("Precio");
                    ddlCampo.Items.Add("Código");
                    ddlCampo.Items.Add("Nombre");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                    ddlCriterio.Items.Add("Igual a");
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de cargar la página [Administracion], vuelva a intentar");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = dgvArticulos.SelectedDataKey.Value.ToString();
                Response.Redirect("Alta.aspx?id=" + id, false);
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de seleccionar un artículo, vuelva a intentar");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                string criterio = ddlCriterio.SelectedItem.ToString();
                if (criterio == "Comienza con" || criterio == "Termina con" || criterio == "Contiene")
                {
                    ddlCampo.SelectedIndex = 1;
                }
                else
                {
                    ddlCampo.SelectedIndex = 0;
                    
                }
                ddlCriterio.SelectedIndex = 0;
                txtFiltro.Text = "";

                ArticuloController controller = new ArticuloController();

                dgvArticulos.DataSource = controller.ListarTodosLosArticulos();
                dgvArticulos.DataBind();
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de resetear los filtros, vuelva a intentar");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloController controller = new ArticuloController();

                string campo = ddlCampo.SelectedItem.ToString();
                string criterio = ddlCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;

                List<Articulo> listaArticulosFiltrada = controller.ListarTodosLosArticulos();
                if (filtro != "")
                    listaArticulosFiltrada = controller.Filtrar(campo, criterio, filtro);
                dgvArticulos.DataSource = listaArticulosFiltrada;
                dgvArticulos.DataBind();
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de filtrar, vuelva a intentar");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCriterio.Items.Clear();

                if (ddlCampo.SelectedItem.ToString() == "Precio")
                {
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                    ddlCriterio.Items.Add("Igual a");
                }
                else
                {
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                    ddlCriterio.Items.Add("Contiene");
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de cargar los criterios, vuelva a intentar");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}