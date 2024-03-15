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
            if (!(Page is Default || Page is Login || Page is Signup || Page is Error))
            {
                if (!Helper.SesionActiva(Session["user"]))
                {
                    Response.Redirect("Login.aspx", false);
                }

                if ((Page is Favoritos || Page is MiPerfil) && !Helper.SesionActiva(Session["user"]))
                {
                    Response.Redirect("Login.aspx", false);
                }

                if ((Page is Alta || Page is Administracion) && !Helper.EsAdmin(Session["user"]))
                {
                    Session.Add("error", "No tenés permisos para ingresar a esta página.");
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}