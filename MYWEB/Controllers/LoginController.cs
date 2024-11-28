using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYWEB.Models;
using System.Data.SqlClient;
using MYWEB.Function;

namespace MYWEB.Controllers
{
    public class LoginController : Controller {
              
        public IActionResult SignOut()
        {
            if (HttpContext.Session != null)
            {
                HttpContext.Session.Clear();
            }
            return View("Index");
        }

        public IActionResult Index()
        {
            string data = HttpContext.Session.GetString("user_id");

            return View();           
            
        }


        private string DbConnection()
        {
            var dbAccess = new MYWEB.Function.DatabaseAccessLayer();
            string dbString = dbAccess.ConnectionString;
            return dbString;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginModel user)
        {
            var hashpassword = new Authentication();

            if (ModelState.IsValid)
            {
                List<LoginModel> userInfo = new List<LoginModel>();
                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    string passwordHash = hashpassword.MD5Hash(user.password);
                    string query = "SELECT * FROM mst_users WHERE user_id = '" + user.user_id + "' AND password = '" + passwordHash + "' ";
                    string update_loginID_query = "UPDATE mst_users SET login_id= (REPLACE(convert(varchar, getdate(),112),'/','') + replace(convert(varchar, getdate(),108),':','')) WHERE user_id = '" + user.user_id + "' ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        ViewData["Message"] = "HAS DATA";
                        while (reader.Read())
                        {
                            var loginUser = new LoginModel();
                            loginUser.id = Convert.ToInt32(reader["id_user"]);
                            loginUser.name = reader["name"].ToString();
                            loginUser.user_id = reader["user_id"].ToString();
                            loginUser.level = reader["level"].ToString();
                            loginUser.apps = reader["apps"].ToString();
                            userInfo.Add(loginUser);
                            
                            HttpContext.Session.SetString("id", loginUser.id.ToString());
                            HttpContext.Session.SetString("user_id", loginUser.user_id);
                            HttpContext.Session.SetString("name", loginUser.name);
                            HttpContext.Session.SetString("level", loginUser.level);
                            HttpContext.Session.SetString("apps", loginUser.apps);
                        }

                        if (HttpContext.Session.GetString("level") == "admin")
                        {
                            return RedirectToAction("Dash", "Admin");
                        }
                        else if (HttpContext.Session.GetString("level") == "user")
                        {
                            return RedirectToAction("Dash", "Admin");
                        }
                        else if (HttpContext.Session.GetString("level") == "first aider")
                        {
                            return RedirectToAction("Dash", "Admin");
                        }
                        else if (HttpContext.Session.GetString("level") == "ope")
                        {
                            return RedirectToAction("Dash", "Admin");
                        }
                    }
                    else
                    {
                        ViewData["Message"] = "User and Password not Registered !";
                    }
                    conn.Close();

                }
            }

            return View("Index");
        }
    }

  

}
