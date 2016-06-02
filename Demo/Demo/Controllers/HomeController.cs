using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string title = "What's a shame!";
            string message = "Can't join the DataBase server! Verify your check list!";
            try
            {
                System.Data.SqlClient.SqlConnection cnx = new System.Data.SqlClient.SqlConnection();
                cnx.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBModelContainer"].ConnectionString;
                SqlCommand command = new SqlCommand("SELECT * FROM HomeSet;",cnx);
                cnx.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        title = reader.GetString(1);
                        message = reader.GetString(2);
                        
                    }
                }
                reader.Close();
            }
            catch 
            {
            }
            ViewBag.Title = title;
            ViewBag.Message = message;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}