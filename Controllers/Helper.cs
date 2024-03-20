using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Image = System.Drawing.Image;
using Models;

namespace Controllers
{
    public static class Helper
    {
        public static string ImagenExiste(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "HEAD";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return url;
                    }
                    else
                    {
                        return "https://www.svgrepo.com/show/508699/landscape-placeholder.svg";
                    }
                }
            }
            catch (WebException) { return "https://www.svgrepo.com/show/508699/landscape-placeholder.svg"; }
            catch
            {
                return "https://www.svgrepo.com/show/508699/landscape-placeholder.svg";
            }
        }
        public static bool SesionActiva(object user)
        {
            User activo = user != null ? (User)user : null;
            if (activo != null && activo.Id != 0)
                return true;
            else
                return false;
        }
        public static bool EsAdmin(object user)
        {
            User admin = user != null ? (User)user : null;
            return admin != null ? admin.Admin : false;
        }
    }
}
