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
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!IsPostBack)
				{
                    string id = txtId.Text = Request.QueryString["id"];

                    ArticuloController controller = new ArticuloController();
                    Articulo articulo = controller.FiltrarPorId(id);

                    if (id != null)
                    {
                        txtId.Text = id;
                        txtCodigo.Text = articulo.Codigo;
                        txtNombre.Text = articulo.Nombre;
                        txtDescripcion.Text = articulo.Descripcion;
                        txtMarca.Text = articulo.Marca.Descripcion;
                        txtCategoria.Text = articulo.Categoria.Descripcion;
                        txtPrecio.Text = articulo.Precio.ToString();
                        txtUrl.Text = articulo.ImagenUrl;
                        imgArticulo.ImageUrl = articulo.ImagenUrl;

                        FavoritoController favoritoController = new FavoritoController();
                        if (!favoritoController.EsFavorito(articulo, (User)Session["user"]) || !Helper.SesionActiva(Session["user"]))
                        {
                            btnAgregarFavorito.Visible = true;
                            btnQuitarFavorito.Visible = false;
                        }
                        else
                        {
                            btnAgregarFavorito.Visible = false;
                            btnQuitarFavorito.Visible = true;
                        }
                    }
                    else
                    {
                        Session.Add("error", "No se seleccionó un artículo para ver su detalle, vuelva a intentar.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
			}
			catch (Exception)
			{
                Session.Add("error", "Ocurrió un error al intentar cargar la página [Detalle], vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Helper.SesionActiva(Session["user"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    string id = txtId.Text = Request.QueryString["id"];
                    ArticuloController controllerArticulo = new ArticuloController();
                    Articulo articulo = controllerArticulo.FiltrarPorId(id);
                    FavoritoController controller = new FavoritoController();
                    controller.AgregarFavorito(articulo, (User)Session["user"]);
                    Response.Redirect("Favoritos.aspx", false);
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al intentar agregar como favorito un artículo, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnQuitarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Helper.SesionActiva(Session["user"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    string id = txtId.Text = Request.QueryString["id"];
                    ArticuloController controllerArticulo = new ArticuloController();
                    Articulo articulo = controllerArticulo.FiltrarPorId(id);
                    FavoritoController controller = new FavoritoController();
                    controller.QuitarFavorito(articulo, (User)Session["user"]);
                    Response.Redirect("Favoritos.aspx", false);
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al intentar quitar como favorito un artículo, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}