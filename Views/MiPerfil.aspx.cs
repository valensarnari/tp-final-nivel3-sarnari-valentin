using Models;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Enabled = false;

            try
            {
                if (!IsPostBack && Helper.SesionActiva(Session["user"]))
                {
                    User user = (User)Session["user"];

                    txtEmail.Text = user.Email;
                    txtApellido.Text = user.Apellido;
                    txtNombre.Text = user.Nombre;

                    if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                        imgMiPerfil.ImageUrl = "~/Images/" + user.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de cargar la página [MiPerfil], vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                UserController userNegocio = new UserController();
                User user = (User)Session["user"];

                // escribir
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.UrlImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                userNegocio.Actualizar(user);

                // leer
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/Images/" + user.UrlImagenPerfil;

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al momento de actualizar el User, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}