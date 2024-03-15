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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserController controller = new UserController();

                string email = txtEmail.Text;
                string pass = txtPass.Text;
                
                User user = new User();
                user.Email = email;
                user.Pass = pass;

                user = controller.Login(user);

                if (user != null)
                {
                    Session.Add("user", user);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Email o Contraseña incorrectos.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al intentar el Login, vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}