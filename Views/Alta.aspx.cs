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
    public partial class Alta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    CategoriaController controllerCategoria = new CategoriaController();
                    MarcaController controllerMarca = new MarcaController();

                    ddlCategoria.DataSource = controllerCategoria.ListarTodasLasCategorias();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = controllerMarca.ListarTodasLasMarcas();
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    string id = txtId.Text = Request.QueryString["id"];
                    if (id != null)
                    {
                        btnAgregar.Visible = false;
                        btnModificar.Visible = true;
                        btnEliminar.Visible = true;

                        ArticuloController controllerArticulo = new ArticuloController();
                        Articulo articulo = controllerArticulo.FiltrarPorId(id);

                        txtId.Text = id;
                        txtCodigo.Text = articulo.Codigo;
                        txtNombre.Text = articulo.Nombre;
                        txtDescripcion.Text = articulo.Descripcion;
                        ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
                        txtPrecio.Text = articulo.Precio.ToString();
                        txtImagenUrl.Text = articulo.ImagenUrl;
                        imgArticulo.ImageUrl = articulo.ImagenUrl;
                    }
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al intentar cargar la página [Alta], vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloController controller = new ArticuloController();
                Articulo articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Precio = Decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtImagenUrl.Text;

                controller.AgregarArticulo(articulo);
                Response.Redirect("Administracion.aspx", false);
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al intentar agregar el artículo, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloController controller = new ArticuloController();
                Articulo articulo = new Articulo();

                articulo.Id = int.Parse(txtId.Text);
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Precio = Decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtImagenUrl.Text;

                controller.ModificarArticulo(articulo);
                Response.Redirect("Administracion.aspx", false);
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al intentar modificar el artículo, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}