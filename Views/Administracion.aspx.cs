﻿using Controllers;
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
            ArticuloController controller = new ArticuloController();

            dgvArticulos.DataSource = controller.ListarTodosLosArticulos();
            dgvArticulos.DataBind();
        }
    }
}