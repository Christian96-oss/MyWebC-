using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MYWEB.Function;
using MYWEB.Models;
using MYWEB.Function;
using MYWEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SERE.Controllers
{
    public class HomeController : Controller
    {
        private string DbConnection()
        {
            var dbAccess = new DatabaseAccessLayer();
            string dbString = dbAccess.ConnectionString;
            return dbString;
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult GetPlantFilter()
        //{
        //    List<UserModel> data = new List<UserModel>();
        //    using (SqlConnection conn = new SqlConnection(DbConnection()))
        //    {
        //        string query = "SELECT plant from mst_users where plant =  @plant and sesa_id = @sesa_id";

        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Parameters.AddWithValue("@sesa_id", HttpContext.Session.GetString("sesa_id"));
        //            cmd.Parameters.AddWithValue("@plant", HttpContext.Session.GetString("plant"));
        //            cmd.Connection = conn;
        //            conn.Open();

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {

        //                    var data_list = new UserModel();
        //                    data_list.Text = reader["plant"].ToString();
        //                    data_list.Id = reader["plant"].ToString();
        //                    data.Add(data_list);
        //                }
        //            }
        //            conn.Close();
        //        }
        //    }

        //    return PartialView("_OptionPlant", data);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
