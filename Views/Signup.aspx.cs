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
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                UserController controller = new UserController();
                User user = new User();

                if (txtEmail.Text == "")
                {
                    throw new Exception("El campo Email no puede estar vacío.");
                }

                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;

                if (controller.Signup(user))
                {
                    controller.Login(user);
                    Session.Add("user", user);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "El Email ya está registrado.");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception)
            {
                Session.Add("error", "Ocurrió un error al intentar el Signup, verifique bien los datos y vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}