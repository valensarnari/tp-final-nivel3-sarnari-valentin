using Microsoft.Win32;
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
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // cargo en la cabecera la imagen de perfil
            if (!Helper.SesionActiva(Session["user"]))
                imgPerfil.ImageUrl = "https://media.istockphoto.com/id/1337144146/vector/default-avatar-profile-icon-vector.jpg?s=612x612&w=0&k=20&c=BIbFwuv7FxTWvh5S3vB6bkT0Qv8Vn8N5Ffseq84ClGI=";
            else
            {
                User user = (User)Session["user"];
                if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                    imgPerfil.ImageUrl = "~/Images/" + user.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                else
                    imgPerfil.ImageUrl = "https://media.istockphoto.com/id/1337144146/vector/default-avatar-profile-icon-vector.jpg?s=612x612&w=0&k=20&c=BIbFwuv7FxTWvh5S3vB6bkT0Qv8Vn8N5Ffseq84ClGI=";
            }

            // establezco las paginas que tiene acceso un NO usuario
            if (!(Page is Default || Page is Login || Page is Signup || Page is Error || Page is Detalle))
            {
                if (!Helper.SesionActiva(Session["user"]))
                {
                    Response.Redirect("Login.aspx", false);
                }

                // establezco que paginas puede ver un usuario normal
                if ((Page is Favoritos || Page is MiPerfil) && !Helper.SesionActiva(Session["user"]))
                {
                    Response.Redirect("Login.aspx", false);
                }

                // establezco que paginas puede ver un usuario admin
                if ((Page is Alta || Page is Administracion) && !Helper.EsAdmin(Session["user"]))
                {
                    Session.Add("error", "No tenés permisos para ingresar a esta página.");
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}