using ClosedXML.Excel;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MYWEB.Function;
using MYWEB.Function.Data;
using MYWEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Dynamic;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Drawing.Charts;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;
using DocumentFormat.OpenXml.Office2019.Presentation;
using System.Drawing;
using Newtonsoft.Json;
using System.Globalization;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Win32.SafeHandles;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace MYWEB.Controllers
{
    public class AdminController : Controller
    {
        private string DbConnection()
        {
            var dbAccess = new DatabaseAccessLayer();
            string dbString = dbAccess.ConnectionString;
            return dbString;
        }
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;
        private IHttpContextAccessor _httpContextAccessor;
        private object fileName;
        private SafeFileHandle filePathaf;
        private static readonly object lockObject = new object();

        public string ConnectionString { get; private set; }

        public AdminController(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            this._context = context;
            hostingEnvironment = environment;
            _httpContextAccessor = httpContextAccessor;

        }
        public IActionResult Index()
        {
            return View();
        }

        public static string InterpretAsUTF8(string value)
        {
            byte[] rawData = Encoding.Default.GetBytes(value);
            string reencoded = Encoding.UTF8.GetString(rawData);
            return reencoded;
        }

        public IActionResult Dash()
        {
            if (HttpContext.Session.GetString("level") == "admin" || HttpContext.Session.GetString("level") == "user")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult RoleRoadmap()
        {
            if (HttpContext.Session.GetString("level") == "admin" || HttpContext.Session.GetString("level") == "user")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult SkillRoadmap()
        {
            if (HttpContext.Session.GetString("level") == "admin" || HttpContext.Session.GetString("level") == "user")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult BestPractices()
        {
            if (HttpContext.Session.GetString("level") == "admin" || HttpContext.Session.GetString("level") == "user")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult LamaranHistory()
        {
            if (HttpContext.Session.GetString("level") == "admin" || HttpContext.Session.GetString("level") == "user")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Certificate()
        {
            if (HttpContext.Session.GetString("level") == "admin" || HttpContext.Session.GetString("level") == "user")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult ProjectHistory()
        {
            if (HttpContext.Session.GetString("level") == "admin" || HttpContext.Session.GetString("level") == "user")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult PlatformMasterData()
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult FrontendMasterData()
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult BackendMasterData()
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult DatabasesMasterData()
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult CategoryMasterData()
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult LokerbyMasterData()
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult SendcvbyMasterData()
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // start certificate
        public IActionResult GETCERTI(string item, string type, string cert_by, string year, string datefrom, string dateto)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<CertiModel> dataAdmin = new List<CertiModel>();

                var query = "GET_CERTI";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (item == null) { cmd.Parameters.AddWithValue("@item", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@item", item); }

                    if (type == null) { cmd.Parameters.AddWithValue("@type", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@type", type); }

                    if (cert_by == null) { cmd.Parameters.AddWithValue("@cert_by", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@cert_by", cert_by); }

                    if (year == null) { cmd.Parameters.AddWithValue("@year", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@year", year); }

                    if (datefrom == null) { cmd.Parameters.AddWithValue("@datefrom", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@datefrom", datefrom); }

                    if (dateto == null) { cmd.Parameters.AddWithValue("@dateto", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@dateto", dateto); }

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new CertiModel();
                                data_list.id_certi = int.Parse(reader["id_certi"].ToString());
                                data_list.item = reader["item"].ToString();
                                data_list.type = reader["type"].ToString();
                                data_list.cert_by = reader["cert_by"].ToString();
                                data_list.year = reader["year"].ToString();
                                DateTime? dateFromDatabase = reader["expire"] as DateTime?;
                                if (dateFromDatabase.HasValue)
                                {
                                    data_list.expire = dateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                data_list.certificate = reader["certificate"].ToString();
                                DateTime? recordateFromDatabase = reader["record_date"] as DateTime?;
                                if (recordateFromDatabase.HasValue)
                                {
                                    data_list.record_date = recordateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                DateTime? lastupdateFromDatabase = reader["last_update"] as DateTime?;
                                if (lastupdateFromDatabase.HasValue)
                                {
                                    data_list.last_update = lastupdateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataAdmin.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableCerti", dataAdmin);

            }
        }

        public async Task<JsonResult> AddCerti(IFormFile file, string item, string type, string cert_by, string year, string expire)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    string fileName = null;
                    if (file != null && file.Length > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine("wwwroot", "certi", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }

                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddCerti", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@item", item);
                            cmd.Parameters.AddWithValue("@type", type);
                            cmd.Parameters.AddWithValue("@cert_by", cert_by);
                            cmd.Parameters.AddWithValue("@year", year);
                            cmd.Parameters.AddWithValue("@expire", expire);
                            cmd.Parameters.AddWithValue("@certificate", fileName != null ? fileName : (object)DBNull.Value);
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                // Insert log into tbl_log if data added successfully
                                var id_user = HttpContext.Session.GetString("id");
                                if (id_user != null)
                                {
                                    string actionMessage = $"Adding New Certificate {item}";
                                    string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                                    using (SqlCommand logCmd = new SqlCommand(logQuery, con))
                                    {
                                        logCmd.Parameters.AddWithValue("@id_user", id_user);
                                        logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                        logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                        logCmd.ExecuteNonQuery(); // Execute log insertion
                                    }
                                }

                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        public IActionResult UpdateCerti(int id_certi, string item, string type, string cert_by, string year, string expire, IFormFile file)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string fileName = null;
                if (file != null)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/certi", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }

                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    string query = @"UPDATE tbl_certificate SET 
                item = @item, 
                type = @type, 
                cert_by = @cert_by, 
                year = @year, 
                expire = @expire,
                last_update = GETDATE()";

                    if (fileName != null)
                    {
                        query += ", certificate = @certificate";
                    }

                    query += " WHERE id_certi = @id_certi";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_certi", id_certi);
                    cmd.Parameters.AddWithValue("@item", item);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@cert_by", cert_by);
                    cmd.Parameters.AddWithValue("@year", year);

                    if (string.IsNullOrEmpty(expire))
                    {
                        cmd.Parameters.AddWithValue("@expire", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@expire", expire);
                    }

                    if (fileName != null)
                    {
                        cmd.Parameters.AddWithValue("@certificate", fileName);
                    }

                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        var id_user = HttpContext.Session.GetString("id");
                        if (id_user != null)
                        {
                            string actionMessage = $"Updating Certificate {item}";
                            string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                            using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                            {
                                logCmd.Parameters.AddWithValue("@id_user", id_user);
                                logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                logCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        public IActionResult DeleteCerti(string id_certi)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string getItemQuery = "SELECT item FROM tbl_certificate WHERE id_certi = @id_certi";
                    string item = null;

                    // Retrieve the item name first
                    using (SqlCommand getItemCmd = new SqlCommand(getItemQuery, conn))
                    {
                        getItemCmd.Parameters.AddWithValue("@id_certi", id_certi);
                        using (SqlDataReader reader = getItemCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                item = reader["item"].ToString();
                            }
                        }
                    }

                    // Proceed with deletion
                    string deleteQuery = @"DELETE FROM tbl_certificate WHERE id_certi = @id_certi";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@id_certi", id_certi);
                    rowsAffected = cmd.ExecuteNonQuery();

                    // Insert log into tb_log if deletion successful
                    if (rowsAffected > 0 && item != null)
                    {
                        var id_user = HttpContext.Session.GetString("id");
                        if (id_user != null)
                        {
                            string actionMessage = $"Deleting Certificate {item}";
                            string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                            using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                            {
                                logCmd.Parameters.AddWithValue("@id_user", id_user);
                                logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                logCmd.ExecuteNonQuery(); // Execute log insertion
                            }
                        }
                    }

                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected1")]
        public IActionResult Delete_selected1([FromBody] CertiModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string getItemQuery = "SELECT item FROM tbl_certificate WHERE id_certi = @id_certi";
                    string deleteQuery = "DELETE FROM tbl_certificate WHERE id_certi = @id_certi";

                    for (int i = 0; i < input.Length; i++)
                    {
                        string item = null;

                        // Retrieve the item name first
                        using (SqlCommand getItemCmd = new SqlCommand(getItemQuery, conn))
                        {
                            getItemCmd.Parameters.AddWithValue("@id_certi", input[i].id_certi);
                            using (SqlDataReader reader = getItemCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    item = reader["item"].ToString();
                                }
                            }
                        }

                        // Proceed with deletion
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@id_certi", input[i].id_certi);

                        try
                        {
                            rowsAffected = deleteCmd.ExecuteNonQuery();

                            // Insert log into tb_log if deletion successful
                            if (rowsAffected > 0 && item != null)
                            {
                                var id_user = HttpContext.Session.GetString("id");
                                if (id_user != null)
                                {
                                    string actionMessage = $"Deleting Certificate {item}";
                                    string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                                    using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                                    {
                                        logCmd.Parameters.AddWithValue("@id_user", id_user);
                                        logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                        logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                        logCmd.ExecuteNonQuery(); // Execute log insertion
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        // end certificate

        // start filtering certificate
        [HttpGet]
        public IActionResult GetCertItem0(string family)
        {
            List<CertiModel> data = new List<CertiModel>();
            string query = "SELECT DISTINCT item as item FROM tbl_certificate WHERE item LIKE '%" + family + "%' ORDER BY item ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new CertiModel();
                            data_list.Text = reader["item"].ToString();
                            data_list.Id = reader["item"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetCertType0(string family)
        {
            List<CertiModel> data = new List<CertiModel>();
            string query = "SELECT DISTINCT type as type FROM tbl_certificate WHERE type LIKE '%" + family + "%' ORDER BY type ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new CertiModel();
                            data_list.Text = reader["type"].ToString();
                            data_list.Id = reader["type"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetCertBy0(string family)
        {
            List<CertiModel> data = new List<CertiModel>();
            string query = "SELECT DISTINCT cert_by as cert_by FROM tbl_certificate WHERE cert_by LIKE '%" + family + "%' ORDER BY cert_by ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new CertiModel();
                            data_list.Text = reader["cert_by"].ToString();
                            data_list.Id = reader["cert_by"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetCertYear0(string family)
        {
            List<CertiModel> data = new List<CertiModel>();
            string query = "SELECT DISTINCT year as year FROM tbl_certificate WHERE year LIKE '%" + family + "%' ORDER BY year ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new CertiModel();
                            data_list.Text = reader["year"].ToString();
                            data_list.Id = reader["year"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }
        // end filtering certificate

        // start platform master data
        [HttpGet]
        public IActionResult GetPlatformMst(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT platform FROM mst_platform WHERE platform LIKE '" + family + "%' ORDER BY platform ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["platform"].ToString();
                            data_list.Id = reader["platform"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }

            return Json(new { items = data });
        }

        public IActionResult GET_PLATFORM(string platform)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<PlatformModel> dataADMIN = new List<PlatformModel>();

                var query = "SELECT * FROM mst_platform";
                if (platform != null)
                {
                    query = query + " WHERE platform = @platformxx";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (platform == null) { cmd.Parameters.AddWithValue("@platformxx", DBNull.Value); }
                    else
                    { cmd.Parameters.AddWithValue("@platformxx", platform); }
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new PlatformModel();
                                data_list.id = int.Parse(reader["id"].ToString());
                                data_list.platform = reader["platform"].ToString();
                                data_list.user_id = reader["user_id"].ToString();
                                DateTime? planDateFromDatabase = reader["record_date"] as DateTime?;
                                if (planDateFromDatabase.HasValue)
                                {
                                    data_list.record_date = planDateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataADMIN.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TablePlatform", dataADMIN);
            }
        }

        [HttpPost]
        public JsonResult AddPlatform(string platform)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddPlatform", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@platform", platform);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        [HttpPost]
        public IActionResult DeletePlatform(string id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = @"DELETE FROM mst_platform WHERE id = @id;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected2")]
        public IActionResult Delete_selected2([FromBody] PlatformModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;
                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = "DELETE FROM mst_platform WHERE id = @id";
                    for (int i = 0; i < input.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id",input[i].id)
                        });
                        try
                        {
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public IActionResult UpdatePlatform(string platform, int id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string queryCheck = @"SELECT COUNT(*) FROM mst_platform WHERE platform = @platform AND id != @id";

                using (SqlConnection conCheck = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck))
                    {
                        cmdCheck.Connection = conCheck;
                        cmdCheck.Parameters.AddWithValue("@platform", platform);
                        cmdCheck.Parameters.AddWithValue("@id", id);
                        conCheck.Open();

                        // Periksa apakah ada duplikasi
                        int count = (int)cmdCheck.ExecuteScalar();

                        conCheck.Close();

                        if (count > 0)
                        {
                            // Data dengan nilai yang sama sudah ada
                            return Json(-1); 
                        }
                    }
                }

                // Setelah memastikan tidak ada duplikasi, lanjutkan dengan perintah UPDATE
                int rowsAffected = 0;
                string queryUpdate = @"UPDATE mst_platform SET platform = @platform, user_id = @user_id WHERE id = @id";

                using (SqlConnection con = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(queryUpdate))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@platform", platform);
                        cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return Json(rowsAffected); 
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadPlatform(IFormFile myExcelData)
        {
            if (myExcelData.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                filePath = Path.Combine(filePath, fileName + ".xlsx");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await myExcelData.CopyToAsync(fileStream);
                }

                XLWorkbook xLWorkbook = new XLWorkbook(filePath);
                int row = 2;
                int rowsAffected = 0;
                List<string> importedBOXs = new List<string>(); // Untuk melacak data yang diimpor

                // Loop excel rows and get data on each cell
                while (xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    string platform = xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString();

                    // Periksa apakah data sudah ada dalam tabel
                    if (!IsPlatformExistsInTable(platform))
                    {
                        using (SqlConnection conn = new SqlConnection(DbConnection()))
                        {
                            string query = "INSERT INTO mst_platform(platform, user_id) VALUES(@platform, @user_id)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@platform", platform);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            conn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        importedBOXs.Add(platform); // Tambahkan data yang diimpor ke daftar
                    }

                    row++;
                }

                return Json(new { success = true, message = "Imported " + importedBOXs.Count + " BoXs." });
            }
            else
            {
                return Json(new { success = false, message = "Please Upload an excel File (.xslx)" });
            }
        }

        private bool IsPlatformExistsInTable(string platform)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT COUNT(*) FROM mst_platform WHERE platform = @platform";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@platform", platform);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        [HttpGet]
        public IActionResult ExportPlatform(string platformxx)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                wb.Worksheets.Add(this.GetPlatform(platformxx).Tables[0]);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MYWEB - Platform Master Data " + formattedDateTime + ".xlsx");
                }
            }
        }

        private DataSet GetPlatform(string platformxx)
        {
            string query = "";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                if (platformxx == null)
                {
                    query = $"SELECT platform FROM mst_platform";
                }
                else
                {
                    query = $"SELECT platform FROM mst_platform WHERE platform LIKE '" + platformxx + "'";
                }

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return ds;
        }
        // end platform master data

        // start frontend master data
        [HttpGet]
        public IActionResult GetFrontendMst(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT frontend FROM mst_frontend WHERE frontend LIKE '" + family + "%' ORDER BY frontend ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["frontend"].ToString();
                            data_list.Id = reader["frontend"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }

            return Json(new { items = data });
        }
        public IActionResult GET_FRONTEND(string frontend)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<FrontendModel> dataADMIN = new List<FrontendModel>();

                var query = "SELECT * FROM mst_frontend";
                if (frontend != null)
                {
                    query = query + " WHERE frontend = @frontendxx";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (frontend == null) { cmd.Parameters.AddWithValue("@frontendxx", DBNull.Value); }
                    else
                    { cmd.Parameters.AddWithValue("@frontendxx", frontend); }
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new FrontendModel();
                                data_list.id = int.Parse(reader["id"].ToString());
                                data_list.frontend = reader["frontend"].ToString();
                                data_list.user_id = reader["user_id"].ToString();
                                DateTime? planDateFromDatabase = reader["record_date"] as DateTime?;
                                if (planDateFromDatabase.HasValue)
                                {
                                    data_list.record_date = planDateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataADMIN.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableFrontend", dataADMIN);
            }
        }

        [HttpPost]
        public JsonResult AddFrontend(string frontend)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddFrontend", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@frontend", frontend);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        [HttpPost]
        public IActionResult DeleteFrontend(string id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = @"DELETE FROM mst_frontend WHERE id = @id;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected3")]
        public IActionResult Delete_selected3([FromBody] FrontendModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;
                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = "DELETE FROM mst_frontend WHERE id = @id";
                    for (int i = 0; i < input.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id",input[i].id)
                        });
                        try
                        {
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public IActionResult UpdateFrontend(string frontend, int id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string queryCheck = @"SELECT COUNT(*) FROM mst_frontend WHERE frontend = @frontend AND id != @id";

                using (SqlConnection conCheck = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck))
                    {
                        cmdCheck.Connection = conCheck;
                        cmdCheck.Parameters.AddWithValue("@frontend", frontend);
                        cmdCheck.Parameters.AddWithValue("@id", id);
                        conCheck.Open();

                        // Periksa apakah ada duplikasi
                        int count = (int)cmdCheck.ExecuteScalar();

                        conCheck.Close();

                        if (count > 0)
                        {
                            // Data dengan nilai yang sama sudah ada
                            return Json(-1);
                        }
                    }
                }

                // Setelah memastikan tidak ada duplikasi, lanjutkan dengan perintah UPDATE
                int rowsAffected = 0;
                string queryUpdate = @"UPDATE mst_frontend SET frontend = @frontend, user_id = @user_id WHERE id = @id";

                using (SqlConnection con = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(queryUpdate))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@frontend", frontend);
                        cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadFrontend(IFormFile myExcelData)
        {
            if (myExcelData.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                filePath = Path.Combine(filePath, fileName + ".xlsx");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await myExcelData.CopyToAsync(fileStream);
                }

                XLWorkbook xLWorkbook = new XLWorkbook(filePath);
                int row = 2;
                int rowsAffected = 0;
                List<string> importedBOXs = new List<string>(); // Untuk melacak data yang diimpor

                // Loop excel rows and get data on each cell
                while (xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    string frontend = xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString();

                    // Periksa apakah data sudah ada dalam tabel
                    if (!IsFrontendExistsInTable(frontend))
                    {
                        using (SqlConnection conn = new SqlConnection(DbConnection()))
                        {
                            string query = "INSERT INTO mst_frontend(frontend, user_id) VALUES(@frontend, @user_id)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@frontend", frontend);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            conn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        importedBOXs.Add(frontend); // Tambahkan data yang diimpor ke daftar
                    }

                    row++;
                }

                return Json(new { success = true, message = "Imported " + importedBOXs.Count + " BoXs." });
            }
            else
            {
                return Json(new { success = false, message = "Please Upload an excel File (.xslx)" });
            }
        }

        private bool IsFrontendExistsInTable(string frontend)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT COUNT(*) FROM mst_frontend WHERE frontend = @frontend";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@frontend", frontend);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        [HttpGet]
        public IActionResult ExportFrontend(string frontendxx)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                wb.Worksheets.Add(this.GetFrontend(frontendxx).Tables[0]);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MYWEB - Platform Master Data " + formattedDateTime + ".xlsx");
                }
            }
        }

        private DataSet GetFrontend(string frontendxx)
        {
            string query = "";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                if (frontendxx == null)
                {
                    query = $"SELECT frontend FROM mst_frontend";
                }
                else
                {
                    query = $"SELECT frontend FROM mst_frontend WHERE frontend LIKE '" + frontendxx + "'";
                }

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return ds;
        }
        // end frontend master data

        // start backend master data
        [HttpGet]
        public IActionResult GetBackendMst(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT backend FROM mst_backend WHERE backend LIKE '" + family + "%' ORDER BY backend ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["backend"].ToString();
                            data_list.Id = reader["backend"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }

            return Json(new { items = data });
        }
        public IActionResult GET_BACKEND(string backend)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<BackendModel> dataADMIN = new List<BackendModel>();

                var query = "SELECT * FROM mst_backend";
                if (backend != null)
                {
                    query = query + " WHERE backend = @backendxx";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (backend == null) { cmd.Parameters.AddWithValue("@backendxx", DBNull.Value); }
                    else
                    { cmd.Parameters.AddWithValue("@backendxx", backend); }
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new BackendModel();
                                data_list.id = int.Parse(reader["id"].ToString());
                                data_list.backend = reader["backend"].ToString();
                                data_list.user_id = reader["user_id"].ToString();
                                DateTime? planDateFromDatabase = reader["record_date"] as DateTime?;
                                if (planDateFromDatabase.HasValue)
                                {
                                    data_list.record_date = planDateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataADMIN.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableBackend", dataADMIN);
            }
        }

        [HttpPost]
        public JsonResult AddBackend(string backend)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddBackend", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@backend", backend);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        [HttpPost]
        public IActionResult DeleteBackend(string id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = @"DELETE FROM mst_backend WHERE id = @id;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected4")]
        public IActionResult Delete_selected4([FromBody] BackendModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;
                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = "DELETE FROM mst_backend WHERE id = @id";
                    for (int i = 0; i < input.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id",input[i].id)
                        });
                        try
                        {
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public IActionResult UpdateBackend(string backend, int id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string queryCheck = @"SELECT COUNT(*) FROM mst_backend WHERE backend = @backend AND id != @id";

                using (SqlConnection conCheck = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck))
                    {
                        cmdCheck.Connection = conCheck;
                        cmdCheck.Parameters.AddWithValue("@backend", backend);
                        cmdCheck.Parameters.AddWithValue("@id", id);
                        conCheck.Open();

                        // Periksa apakah ada duplikasi
                        int count = (int)cmdCheck.ExecuteScalar();

                        conCheck.Close();

                        if (count > 0)
                        {
                            // Data dengan nilai yang sama sudah ada
                            return Json(-1);
                        }
                    }
                }

                // Setelah memastikan tidak ada duplikasi, lanjutkan dengan perintah UPDATE
                int rowsAffected = 0;
                string queryUpdate = @"UPDATE mst_backend SET backend = @backend, user_id = @user_id WHERE id = @id";

                using (SqlConnection con = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(queryUpdate))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@backend", backend);
                        cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadBackend(IFormFile myExcelData)
        {
            if (myExcelData.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                filePath = Path.Combine(filePath, fileName + ".xlsx");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await myExcelData.CopyToAsync(fileStream);
                }

                XLWorkbook xLWorkbook = new XLWorkbook(filePath);
                int row = 2;
                int rowsAffected = 0;
                List<string> importedBOXs = new List<string>(); // Untuk melacak data yang diimpor

                // Loop excel rows and get data on each cell
                while (xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    string backend = xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString();

                    // Periksa apakah data sudah ada dalam tabel
                    if (!IsBackendExistsInTable(backend))
                    {
                        using (SqlConnection conn = new SqlConnection(DbConnection()))
                        {
                            string query = "INSERT INTO mst_backend(backend, user_id) VALUES(@backend, @user_id)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@backend", backend);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            conn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        importedBOXs.Add(backend); // Tambahkan data yang diimpor ke daftar
                    }

                    row++;
                }

                return Json(new { success = true, message = "Imported " + importedBOXs.Count + " BoXs." });
            }
            else
            {
                return Json(new { success = false, message = "Please Upload an excel File (.xslx)" });
            }
        }

        private bool IsBackendExistsInTable(string backend)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT COUNT(*) FROM mst_backend WHERE backend = @backend";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@backend", backend);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        [HttpGet]
        public IActionResult ExportBackend(string backendxx)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                wb.Worksheets.Add(this.GetBackend(backendxx).Tables[0]);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MYWEB - Backend Master Data " + formattedDateTime + ".xlsx");
                }
            }
        }

        private DataSet GetBackend(string backendxx)
        {
            string query = "";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                if (backendxx == null)
                {
                    query = $"SELECT backend FROM mst_backend";
                }
                else
                {
                    query = $"SELECT backend FROM mst_backend WHERE backend LIKE '" + backendxx + "'";
                }

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return ds;
        }
        // end backend master data

        // start databases master data
        [HttpGet]
        public IActionResult GetDatabasesMst(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT databases FROM mst_databases WHERE databases LIKE '" + family + "%' ORDER BY databases ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["databases"].ToString();
                            data_list.Id = reader["databases"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }

            return Json(new { items = data });
        }
        public IActionResult GET_DATABASES(string databases)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<DatabasesModel> dataADMIN = new List<DatabasesModel>();

                var query = "SELECT * FROM mst_databases";
                if (databases != null)
                {
                    query = query + " WHERE databases = @databasesxx";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (databases == null) { cmd.Parameters.AddWithValue("@databasesxx", DBNull.Value); }
                    else
                    { cmd.Parameters.AddWithValue("@databasesxx", databases); }
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new DatabasesModel();
                                data_list.id = int.Parse(reader["id"].ToString());
                                data_list.databases = reader["databases"].ToString();
                                data_list.user_id = reader["user_id"].ToString();
                                DateTime? planDateFromDatabase = reader["record_date"] as DateTime?;
                                if (planDateFromDatabase.HasValue)
                                {
                                    data_list.record_date = planDateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataADMIN.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableDatabases", dataADMIN);
            }
        }

        [HttpPost]
        public JsonResult AddDatabases(string databases)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddDatabases", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@databases", databases);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        [HttpPost]
        public IActionResult DeleteDatabases(string id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = @"DELETE FROM mst_databases WHERE id = @id;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected5")]
        public IActionResult Delete_selected5([FromBody] DatabasesModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;
                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = "DELETE FROM mst_databases WHERE id = @id";
                    for (int i = 0; i < input.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id",input[i].id)
                        });
                        try
                        {
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public IActionResult UpdateDatabases(string databases, int id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string queryCheck = @"SELECT COUNT(*) FROM mst_databases WHERE databases = @databases AND id != @id";

                using (SqlConnection conCheck = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck))
                    {
                        cmdCheck.Connection = conCheck;
                        cmdCheck.Parameters.AddWithValue("@databases", databases);
                        cmdCheck.Parameters.AddWithValue("@id", id);
                        conCheck.Open();

                        // Periksa apakah ada duplikasi
                        int count = (int)cmdCheck.ExecuteScalar();

                        conCheck.Close();

                        if (count > 0)
                        {
                            // Data dengan nilai yang sama sudah ada
                            return Json(-1);
                        }
                    }
                }

                // Setelah memastikan tidak ada duplikasi, lanjutkan dengan perintah UPDATE
                int rowsAffected = 0;
                string queryUpdate = @"UPDATE mst_databases SET databases = @databases, user_id = @user_id WHERE id = @id";

                using (SqlConnection con = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(queryUpdate))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@databases", databases);
                        cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadDatabases(IFormFile myExcelData)
        {
            if (myExcelData.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                filePath = Path.Combine(filePath, fileName + ".xlsx");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await myExcelData.CopyToAsync(fileStream);
                }

                XLWorkbook xLWorkbook = new XLWorkbook(filePath);
                int row = 2;
                int rowsAffected = 0;
                List<string> importedBOXs = new List<string>(); // Untuk melacak data yang diimpor

                // Loop excel rows and get data on each cell
                while (xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    string databases = xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString();

                    // Periksa apakah data sudah ada dalam tabel
                    if (!IsDatabasesExistsInTable(databases))
                    {
                        using (SqlConnection conn = new SqlConnection(DbConnection()))
                        {
                            string query = "INSERT INTO mst_databases(databases, user_id) VALUES(@databases, @user_id)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@databases", databases);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            conn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        importedBOXs.Add(databases); // Tambahkan data yang diimpor ke daftar
                    }

                    row++;
                }

                return Json(new { success = true, message = "Imported " + importedBOXs.Count + " BoXs." });
            }
            else
            {
                return Json(new { success = false, message = "Please Upload an excel File (.xslx)" });
            }
        }

        private bool IsDatabasesExistsInTable(string databases)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT COUNT(*) FROM mst_databases WHERE databases = @databases";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@databases", databases);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        [HttpGet]
        public IActionResult ExportDatabases(string databasesxx)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                wb.Worksheets.Add(this.GetDatabases(databasesxx).Tables[0]);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MYWEB - Backend Master Data " + formattedDateTime + ".xlsx");
                }
            }
        }

        private DataSet GetDatabases(string databasesxx)
        {
            string query = "";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                if (databasesxx == null)
                {
                    query = $"SELECT databases FROM mst_databases";
                }
                else
                {
                    query = $"SELECT databases FROM mst_databases WHERE databases LIKE '" + databasesxx + "'";
                }

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return ds;
        }
        // end databases master data

        // start project
        public IActionResult GETPROJECT(string pj_name, string made_by, string platform, string frontend, string backend, string databases, string datefrom, string dateto)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<ProjectModel> dataAdmin = new List<ProjectModel>();

                var query = "GET_PROJECT";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (pj_name == null) { cmd.Parameters.AddWithValue("@pj_name", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@pj_name", pj_name); }

                    if (made_by == null) { cmd.Parameters.AddWithValue("@made_by", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@made_by", made_by); }

                    if (platform == null) { cmd.Parameters.AddWithValue("@platform", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@platform", platform); }

                    if (frontend == null) { cmd.Parameters.AddWithValue("@frontend", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@frontend", frontend); }

                    if (backend == null) { cmd.Parameters.AddWithValue("@backend", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@backend", backend); }

                    if (databases == null) { cmd.Parameters.AddWithValue("@databases", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@databases", databases); }

                    if (datefrom == null) { cmd.Parameters.AddWithValue("@datefrom", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@datefrom", datefrom); }

                    if (dateto == null) { cmd.Parameters.AddWithValue("@dateto", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@dateto", dateto); }

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new ProjectModel();
                                data_list.id_pj = int.Parse(reader["id_pj"].ToString());
                                data_list.pj_name = reader["pj_name"].ToString();
                                DateTime? dateFromDatabase = reader["pj_date"] as DateTime?;
                                if (dateFromDatabase.HasValue)
                                {
                                    data_list.pj_date = dateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                data_list.duration = reader["duration"].ToString();
                                data_list.platform = reader["platform"].ToString();
                                data_list.frontend = reader["frontend"].ToString();
                                data_list.backend = reader["backend"].ToString();
                                data_list.databases = reader["databases"].ToString();

                                data_list.made_by = reader["made_by"].ToString();
                                data_list.pj_yt = reader["pj_yt"].ToString();
                                data_list.pj_gd = reader["pj_gd"].ToString();
                                data_list.keterangan = reader["keterangan"].ToString();
                                data_list.ref_by = reader["ref_by"].ToString();
                                data_list.pj_zip = reader["pj_zip"].ToString();
                                DateTime? recorddateFromDatabase = reader["record_date"] as DateTime?;
                                if (recorddateFromDatabase.HasValue)
                                {
                                    data_list.record_date = recorddateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                DateTime? lastupdateFromDatabase = reader["last_update"] as DateTime?;
                                if (lastupdateFromDatabase.HasValue)
                                {
                                    data_list.last_update = lastupdateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataAdmin.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableProject", dataAdmin);

            }
        }

        public async Task<JsonResult> AddProject(IFormFile file, string pj_name, string pj_date, string duration, string platform, string frontend, string backend, string databases, string made_by, string pj_yt, string pj_gd, string keterangan, string ref_by)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    string fileName = null;
                    if (file != null && file.Length > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine("wwwroot", "project", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }

                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddProject", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pj_name", pj_name);
                            cmd.Parameters.AddWithValue("@pj_date", pj_date);
                            cmd.Parameters.AddWithValue("@duration", duration);
                            cmd.Parameters.AddWithValue("@platform", platform);
                            cmd.Parameters.AddWithValue("@frontend", frontend);
                            cmd.Parameters.AddWithValue("@backend", backend);
                            cmd.Parameters.AddWithValue("@databases", databases);
                            cmd.Parameters.AddWithValue("@made_by", made_by);
                            cmd.Parameters.AddWithValue("@pj_yt", pj_yt);
                            cmd.Parameters.AddWithValue("@pj_gd", pj_gd);
                            cmd.Parameters.AddWithValue("@keterangan", keterangan);
                            cmd.Parameters.AddWithValue("@ref_by", ref_by);
                            cmd.Parameters.AddWithValue("@pj_zip", fileName != null ? fileName : (object)DBNull.Value);
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                // Insert log into tbl_log if data added successfully
                                var id_user = HttpContext.Session.GetString("id");
                                if (id_user != null)
                                {
                                    string actionMessage = $"Adding New Project {pj_name}";
                                    string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                                    using (SqlCommand logCmd = new SqlCommand(logQuery, con))
                                    {
                                        logCmd.Parameters.AddWithValue("@id_user", id_user);
                                        logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                        logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                        logCmd.ExecuteNonQuery(); // Execute log insertion
                                    }
                                }

                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        // Filter edit
        public IActionResult GetProjPlatform(string platform)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                var submittedPlatform = ProjPlatformFromDatabase(platform);
                var result = new
                {
                    platform = submittedPlatform
                };
                return Json(result);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        private string ProjPlatformFromDatabase(string platform)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT platform FROM tbl_project WHERE platform = @platform";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@platform", platform);
                conn.Open();
                var submittedPlatform = (string)cmd.ExecuteScalar();
                conn.Close();
                return submittedPlatform;
            }
        }

        public IActionResult GetProjFrontend(string frontend)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                var submittedFrontend = ProjFrontendFromDatabase(frontend);
                var result = new
                {
                    Frontend = submittedFrontend
                };
                return Json(result);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        private string ProjFrontendFromDatabase(string frontend)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT frontend FROM tbl_project WHERE frontend = @frontend";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@frontend", frontend);
                conn.Open();
                var submittedFrontend = (string)cmd.ExecuteScalar();
                conn.Close();
                return submittedFrontend;
            }
        }

        public IActionResult GetProjBackend(string backend)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                var submittedBackend = ProjBackendFromDatabase(backend);
                var result = new
                {
                    backend = submittedBackend
                };
                return Json(result);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        private string ProjBackendFromDatabase(string backend)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT backend FROM tbl_project WHERE backend = @backend";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@backend", backend);
                conn.Open();
                var submittedBackend = (string)cmd.ExecuteScalar();
                conn.Close();
                return submittedBackend;
            }
        }

        public IActionResult GetProjDatabases(string databases)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                var submittedDatabases = ProjDatabasesFromDatabase(databases);
                var result = new
                {
                    databases = submittedDatabases
                };
                return Json(result);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        private string ProjDatabasesFromDatabase(string databases)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT databases FROM tbl_project WHERE databases = @databases";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@databases", databases);
                conn.Open();
                var submittedDatabases = (string)cmd.ExecuteScalar();
                conn.Close();
                return submittedDatabases;
            }
        }
        public IActionResult UpdateProject(int id_pj, string pj_name, string pj_date, string duration, string platform, string frontend, string backend, string databases, string made_by, string pj_yt, string pj_gd, string keterangan, string ref_by, IFormFile file)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string fileName = null;
                if (file != null)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }

                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    string query = @"UPDATE tbl_project SET 
        pj_name = @pj_name, 
        pj_date = @pj_date, 
        duration = @duration, 
        platform = @platform, 
        frontend = @frontend,
        backend = @backend, 
        databases = @databases, 
        made_by = @made_by, 
        pj_yt = @pj_yt, 
        pj_gd = @pj_gd,
        keterangan = @keterangan, 
        ref_by = @ref_by,
        last_update = GETDATE()";

                    if (fileName != null)
                    {
                        query += ", pj_zip = @pj_zip";
                    }

                    query += " WHERE id_pj = @id_pj";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_pj", id_pj);
                    cmd.Parameters.AddWithValue("@pj_name", pj_name);
                    cmd.Parameters.AddWithValue("@pj_date", pj_date);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@platform", platform);
                    cmd.Parameters.AddWithValue("@frontend", frontend);
                    cmd.Parameters.AddWithValue("@backend", backend);
                    cmd.Parameters.AddWithValue("@databases", databases);
                    cmd.Parameters.AddWithValue("@made_by", made_by);
                    cmd.Parameters.AddWithValue("@pj_yt", string.IsNullOrEmpty(pj_yt) ? DBNull.Value : pj_yt);
                    cmd.Parameters.AddWithValue("@pj_gd", string.IsNullOrEmpty(pj_gd) ? DBNull.Value : pj_gd);
                    cmd.Parameters.AddWithValue("@keterangan", string.IsNullOrEmpty(keterangan) ? DBNull.Value : keterangan);
                    cmd.Parameters.AddWithValue("@ref_by", string.IsNullOrEmpty(ref_by) ? DBNull.Value : ref_by);

                    if (fileName != null)
                    {
                        cmd.Parameters.AddWithValue("@pj_zip", fileName);
                    }

                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        var id_user = HttpContext.Session.GetString("id");
                        if (id_user != null)
                        {
                            string actionMessage = $"Updating Project {pj_name}";
                            string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                            using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                            {
                                logCmd.Parameters.AddWithValue("@id_user", id_user);
                                logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                logCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        public IActionResult DeleteProject(string id_pj)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string getItemQuery = "SELECT pj_name FROM tbl_project WHERE id_pj = @id_pj";
                    string pj_name = null;

                    // Retrieve the item name first
                    using (SqlCommand getItemCmd = new SqlCommand(getItemQuery, conn))
                    {
                        getItemCmd.Parameters.AddWithValue("@id_pj", id_pj);
                        using (SqlDataReader reader = getItemCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pj_name = reader["pj_name"].ToString();
                            }
                        }
                    }

                    // Proceed with deletion
                    string deleteQuery = @"DELETE FROM tbl_project WHERE id_pj = @id_pj";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@id_pj", id_pj);
                    rowsAffected = cmd.ExecuteNonQuery();

                    // Insert log into tb_log if deletion successful
                    if (rowsAffected > 0 && pj_name != null)
                    {
                        var id_user = HttpContext.Session.GetString("id");
                        if (id_user != null)
                        {
                            string actionMessage = $"Deleting Project {pj_name}";
                            string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                            using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                            {
                                logCmd.Parameters.AddWithValue("@id_user", id_user);
                                logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                logCmd.ExecuteNonQuery(); // Execute log insertion
                            }
                        }
                    }

                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected6")]
        public IActionResult Delete_selected6([FromBody] ProjectModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string getItemQuery = "SELECT pj_name FROM tbl_project WHERE id_pj = @id_pj";
                    string deleteQuery = "DELETE FROM tbl_project WHERE id_pj = @id_pj";

                    for (int i = 0; i < input.Length; i++)
                    {
                        string pj_name = null;

                        // Retrieve the item name first
                        using (SqlCommand getItemCmd = new SqlCommand(getItemQuery, conn))
                        {
                            getItemCmd.Parameters.AddWithValue("@id_pj", input[i].id_pj);
                            using (SqlDataReader reader = getItemCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    pj_name = reader["pj_name"].ToString();
                                }
                            }
                        }

                        // Proceed with deletion
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@id_pj", input[i].id_pj);

                        try
                        {
                            rowsAffected = deleteCmd.ExecuteNonQuery();

                            // Insert log into tb_log if deletion successful
                            if (rowsAffected > 0 && pj_name != null)
                            {
                                var id_user = HttpContext.Session.GetString("id");
                                if (id_user != null)
                                {
                                    string actionMessage = $"Deleting Project {pj_name}";
                                    string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                                    using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                                    {
                                        logCmd.Parameters.AddWithValue("@id_user", id_user);
                                        logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                        logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                        logCmd.ExecuteNonQuery(); // Execute log insertion
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        // end project

        // start filtering project
        [HttpGet]
        public IActionResult GetPjname0(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT pj_name as pj_name FROM tbl_project WHERE pj_name LIKE '%" + family + "%' ORDER BY pj_name ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["pj_name"].ToString();
                            data_list.Id = reader["pj_name"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetMade0(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT made_by as made_by FROM tbl_project WHERE made_by LIKE '%" + family + "%' ORDER BY made_by ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["made_by"].ToString();
                            data_list.Id = reader["made_by"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetPlatform0(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT platform as platform FROM tbl_project WHERE platform LIKE '%" + family + "%' ORDER BY platform ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["platform"].ToString();
                            data_list.Id = reader["platform"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetFrontend0(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT frontend as frontend FROM tbl_project WHERE frontend LIKE '%" + family + "%' ORDER BY frontend ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["frontend"].ToString();
                            data_list.Id = reader["frontend"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetBackend0(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT backend as backend FROM tbl_project WHERE backend LIKE '%" + family + "%' ORDER BY backend ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["backend"].ToString();
                            data_list.Id = reader["backend"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetDatabases0(string family)
        {
            List<ProjectModel> data = new List<ProjectModel>();
            string query = "SELECT DISTINCT databases as databases FROM tbl_project WHERE databases LIKE '%" + family + "%' ORDER BY databases ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new ProjectModel();
                            data_list.Text = reader["databases"].ToString();
                            data_list.Id = reader["databases"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }
        // end filtering project

        // start category master data
        [HttpGet]
        public IActionResult GetCategoryMst(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT category FROM mst_category WHERE category LIKE '" + family + "%' ORDER BY category ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["category"].ToString();
                            data_list.Id = reader["category"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }

            return Json(new { items = data });
        }
        public IActionResult GET_CATEGORY(string category)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<CategoryModel> dataADMIN = new List<CategoryModel>();

                var query = "SELECT * FROM mst_category";
                if (category != null)
                {
                    query = query + " WHERE category = @categoryxx";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (category == null) { cmd.Parameters.AddWithValue("@categoryxx", DBNull.Value); }
                    else
                    { cmd.Parameters.AddWithValue("@categoryxx", category); }
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new CategoryModel();
                                data_list.id = int.Parse(reader["id"].ToString());
                                data_list.category = reader["category"].ToString();
                                data_list.user_id = reader["user_id"].ToString();
                                DateTime? planDateFromDatabase = reader["record_date"] as DateTime?;
                                if (planDateFromDatabase.HasValue)
                                {
                                    data_list.record_date = planDateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataADMIN.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableCategory", dataADMIN);
            }
        }

        [HttpPost]
        public JsonResult AddCategory(string category)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddCategory", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        [HttpPost]
        public IActionResult DeleteCategory(string id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = @"DELETE FROM mst_category WHERE id = @id;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected7")]
        public IActionResult Delete_selected7([FromBody] CategoryModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;
                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = "DELETE FROM mst_category WHERE id = @id";
                    for (int i = 0; i < input.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id",input[i].id)
                        });
                        try
                        {
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public IActionResult UpdateCategory(string category, int id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string queryCheck = @"SELECT COUNT(*) FROM mst_category WHERE category = @category AND id != @id";

                using (SqlConnection conCheck = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck))
                    {
                        cmdCheck.Connection = conCheck;
                        cmdCheck.Parameters.AddWithValue("@category", category);
                        cmdCheck.Parameters.AddWithValue("@id", id);
                        conCheck.Open();

                        // Periksa apakah ada duplikasi
                        int count = (int)cmdCheck.ExecuteScalar();

                        conCheck.Close();

                        if (count > 0)
                        {
                            // Data dengan nilai yang sama sudah ada
                            return Json(-1);
                        }
                    }
                }

                // Setelah memastikan tidak ada duplikasi, lanjutkan dengan perintah UPDATE
                int rowsAffected = 0;
                string queryUpdate = @"UPDATE mst_category SET category = @category, user_id = @user_id WHERE id = @id";

                using (SqlConnection con = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(queryUpdate))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadCategory(IFormFile myExcelData)
        {
            if (myExcelData.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                filePath = Path.Combine(filePath, fileName + ".xlsx");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await myExcelData.CopyToAsync(fileStream);
                }

                XLWorkbook xLWorkbook = new XLWorkbook(filePath);
                int row = 2;
                int rowsAffected = 0;
                List<string> importedBOXs = new List<string>(); // Untuk melacak data yang diimpor

                // Loop excel rows and get data on each cell
                while (xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    string category = xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString();

                    // Periksa apakah data sudah ada dalam tabel
                    if (!IsCategoryExistsInTable(category))
                    {
                        using (SqlConnection conn = new SqlConnection(DbConnection()))
                        {
                            string query = "INSERT INTO mst_category(category, user_id) VALUES(@category, @user_id)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            conn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        importedBOXs.Add(category); // Tambahkan data yang diimpor ke daftar
                    }

                    row++;
                }

                return Json(new { success = true, message = "Imported " + importedBOXs.Count + " BoXs." });
            }
            else
            {
                return Json(new { success = false, message = "Please Upload an excel File (.xslx)" });
            }
        }

        private bool IsCategoryExistsInTable(string category)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT COUNT(*) FROM mst_category WHERE category = @category";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@category", category);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        [HttpGet]
        public IActionResult ExportCategory(string categoryxx)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                wb.Worksheets.Add(this.GetCategory(categoryxx).Tables[0]);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MYWEB - Category Master Data " + formattedDateTime + ".xlsx");
                }
            }
        }

        private DataSet GetCategory(string categoryxx)
        {
            string query = "";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                if (categoryxx == null)
                {
                    query = $"SELECT category FROM mst_category";
                }
                else
                {
                    query = $"SELECT category FROM mst_category WHERE category LIKE '" + categoryxx + "'";
                }

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return ds;
        }
        // end category master data

        // start lokerby master data
        [HttpGet]
        public IActionResult GetLokerbyMst(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT loker_by FROM mst_lokerby WHERE loker_by LIKE '" + family + "%' ORDER BY loker_by ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["loker_by"].ToString();
                            data_list.Id = reader["loker_by"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }

            return Json(new { items = data });
        }
        public IActionResult GET_LOKERBY(string loker_by)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<LokerbyModel> dataADMIN = new List<LokerbyModel>();

                var query = "SELECT * FROM mst_lokerby";
                if (loker_by != null)
                {
                    query = query + " WHERE loker_by = @lokerbyxx";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (loker_by == null) { cmd.Parameters.AddWithValue("@lokerbyxx", DBNull.Value); }
                    else
                    { cmd.Parameters.AddWithValue("@lokerbyxx", loker_by); }
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new LokerbyModel();
                                data_list.id = int.Parse(reader["id"].ToString());
                                data_list.loker_by = reader["loker_by"].ToString();
                                data_list.user_id = reader["user_id"].ToString();
                                DateTime? planDateFromDatabase = reader["record_date"] as DateTime?;
                                if (planDateFromDatabase.HasValue)
                                {
                                    data_list.record_date = planDateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataADMIN.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableLokerby", dataADMIN);
            }
        }

        [HttpPost]
        public JsonResult AddLokerby(string loker_by)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddLokerby", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@loker_by", loker_by);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        [HttpPost]
        public IActionResult DeleteLokerby(string id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = @"DELETE FROM mst_lokerby WHERE id = @id;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected8")]
        public IActionResult Delete_selected8([FromBody] LokerbyModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;
                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = "DELETE FROM mst_lokerby WHERE id = @id";
                    for (int i = 0; i < input.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id",input[i].id)
                        });
                        try
                        {
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public IActionResult UpdateLokerby(string loker_by, int id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string queryCheck = @"SELECT COUNT(*) FROM mst_lokerby WHERE loker_by = @loker_by AND id != @id";

                using (SqlConnection conCheck = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck))
                    {
                        cmdCheck.Connection = conCheck;
                        cmdCheck.Parameters.AddWithValue("@loker_by", loker_by);
                        cmdCheck.Parameters.AddWithValue("@id", id);
                        conCheck.Open();

                        // Periksa apakah ada duplikasi
                        int count = (int)cmdCheck.ExecuteScalar();

                        conCheck.Close();

                        if (count > 0)
                        {
                            // Data dengan nilai yang sama sudah ada
                            return Json(-1);
                        }
                    }
                }

                // Setelah memastikan tidak ada duplikasi, lanjutkan dengan perintah UPDATE
                int rowsAffected = 0;
                string queryUpdate = @"UPDATE mst_lokerby SET loker_by = @loker_by, user_id = @user_id WHERE id = @id";

                using (SqlConnection con = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(queryUpdate))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@loker_by", loker_by);
                        cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadLokerby(IFormFile myExcelData)
        {
            if (myExcelData.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                filePath = Path.Combine(filePath, fileName + ".xlsx");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await myExcelData.CopyToAsync(fileStream);
                }

                XLWorkbook xLWorkbook = new XLWorkbook(filePath);
                int row = 2;
                int rowsAffected = 0;
                List<string> importedBOXs = new List<string>(); // Untuk melacak data yang diimpor

                // Loop excel rows and get data on each cell
                while (xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    string loker_by = xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString();

                    // Periksa apakah data sudah ada dalam tabel
                    if (!IsLokerbyExistsInTable(loker_by))
                    {
                        using (SqlConnection conn = new SqlConnection(DbConnection()))
                        {
                            string query = "INSERT INTO mst_lokerby(loker_by, user_id) VALUES(@loker_by, @user_id)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@loker_by", loker_by);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            conn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        importedBOXs.Add(loker_by); // Tambahkan data yang diimpor ke daftar
                    }

                    row++;
                }

                return Json(new { success = true, message = "Imported " + importedBOXs.Count + " BoXs." });
            }
            else
            {
                return Json(new { success = false, message = "Please Upload an excel File (.xslx)" });
            }
        }

        private bool IsLokerbyExistsInTable(string loker_by)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT COUNT(*) FROM mst_lokerby WHERE loker_by = @loker_by";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@loker_by", loker_by);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        [HttpGet]
        public IActionResult ExportLokerby(string lokerbyxx)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                wb.Worksheets.Add(this.GetLokerby(lokerbyxx).Tables[0]);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MYWEB - Lokerby Master Data " + formattedDateTime + ".xlsx");
                }
            }
        }

        private DataSet GetLokerby(string lokerbyxx)
        {
            string query = "";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                if (lokerbyxx == null)
                {
                    query = $"SELECT loker_by FROM mst_lokerby";
                }
                else
                {
                    query = $"SELECT loker_by FROM mst_lokerby WHERE loker_by LIKE '" + lokerbyxx + "'";
                }

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return ds;
        }
        // end lokerby master data

        // start sendcvby master data
        [HttpGet]
        public IActionResult GetSendcvbyMst(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT sendcv_by FROM mst_sendcvby WHERE sendcv_by LIKE '" + family + "%' ORDER BY sendcv_by ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["sendcv_by"].ToString();
                            data_list.Id = reader["sendcv_by"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }

            return Json(new { items = data });
        }
        public IActionResult GET_SENDCVBY(string sendcv_by)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<SendcvbyModel> dataADMIN = new List<SendcvbyModel>();

                var query = "SELECT * FROM mst_sendcvby";
                if (sendcv_by != null)
                {
                    query = query + " WHERE sendcv_by = @sendcvbyxx";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (sendcv_by == null) { cmd.Parameters.AddWithValue("@sendcvbyxx", DBNull.Value); }
                    else
                    { cmd.Parameters.AddWithValue("@sendcvbyxx", sendcv_by); }
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new SendcvbyModel();
                                data_list.id = int.Parse(reader["id"].ToString());
                                data_list.sendcv_by = reader["sendcv_by"].ToString();
                                data_list.user_id = reader["user_id"].ToString();
                                DateTime? planDateFromDatabase = reader["record_date"] as DateTime?;
                                if (planDateFromDatabase.HasValue)
                                {
                                    data_list.record_date = planDateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataADMIN.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableSendcvby", dataADMIN);
            }
        }

        [HttpPost]
        public JsonResult AddSendcvby(string sendcv_by)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddSendcvby", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sendcv_by", sendcv_by);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        [HttpPost]
        public IActionResult DeleteSendcvby(string id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = @"DELETE FROM mst_sendcvby WHERE id = @id;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected9")]
        public IActionResult Delete_selected9([FromBody] SendcvbyModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;
                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string query = "DELETE FROM mst_sendcvby WHERE id = @id";
                    for (int i = 0; i < input.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id",input[i].id)
                        });
                        try
                        {
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public IActionResult UpdateSendcvby(string sendcv_by, int id)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string queryCheck = @"SELECT COUNT(*) FROM mst_sendcvby WHERE sendcv_by = @sendcv_by AND id != @id";

                using (SqlConnection conCheck = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck))
                    {
                        cmdCheck.Connection = conCheck;
                        cmdCheck.Parameters.AddWithValue("@sendcv_by", sendcv_by);
                        cmdCheck.Parameters.AddWithValue("@id", id);
                        conCheck.Open();

                        // Periksa apakah ada duplikasi
                        int count = (int)cmdCheck.ExecuteScalar();

                        conCheck.Close();

                        if (count > 0)
                        {
                            // Data dengan nilai yang sama sudah ada
                            return Json(-1);
                        }
                    }
                }

                // Setelah memastikan tidak ada duplikasi, lanjutkan dengan perintah UPDATE
                int rowsAffected = 0;
                string queryUpdate = @"UPDATE mst_sendcvby SET sendcv_by = @sendcv_by, user_id = @user_id WHERE id = @id";

                using (SqlConnection con = new SqlConnection(DbConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(queryUpdate))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@sendcv_by", sendcv_by);
                        cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadSendcv_by(IFormFile myExcelData)
        {
            if (myExcelData.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                filePath = Path.Combine(filePath, fileName + ".xlsx");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await myExcelData.CopyToAsync(fileStream);
                }

                XLWorkbook xLWorkbook = new XLWorkbook(filePath);
                int row = 2;
                int rowsAffected = 0;
                List<string> importedBOXs = new List<string>(); // Untuk melacak data yang diimpor

                // Loop excel rows and get data on each cell
                while (xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    string sendcv_by = xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString();

                    // Periksa apakah data sudah ada dalam tabel
                    if (!IsSendcvbyExistsInTable(sendcv_by))
                    {
                        using (SqlConnection conn = new SqlConnection(DbConnection()))
                        {
                            string query = "INSERT INTO mst_sendcvby(sendcv_by, user_id) VALUES(@sendcv_by, @user_id)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@sendcv_by", sendcv_by);
                            cmd.Parameters.AddWithValue("@user_id", HttpContext.Session.GetString("user_id"));
                            conn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        importedBOXs.Add(sendcv_by); // Tambahkan data yang diimpor ke daftar
                    }

                    row++;
                }

                return Json(new { success = true, message = "Imported " + importedBOXs.Count + " BoXs." });
            }
            else
            {
                return Json(new { success = false, message = "Please Upload an excel File (.xslx)" });
            }
        }

        private bool IsSendcvbyExistsInTable(string sendcv_by)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT COUNT(*) FROM mst_sendcvby WHERE sendcv_by = @sendcv_by";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sendcv_by", sendcv_by);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        [HttpGet]
        public IActionResult ExportSendcvby(string sendcvbyxx)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                wb.Worksheets.Add(this.GetSendcvby(sendcvbyxx).Tables[0]);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MYWEB - Lokerby Master Data " + formattedDateTime + ".xlsx");
                }
            }
        }

        private DataSet GetSendcvby(string sendcvbyxx)
        {
            string query = "";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                if (sendcvbyxx == null)
                {
                    query = $"SELECT sendcv_by FROM mst_sendcvby";
                }
                else
                {
                    query = $"SELECT sendcv_by FROM mst_sendcvby WHERE sendcv_by LIKE '" + sendcvbyxx + "'";
                }

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return ds;
        }
        // end sendcvby master data

        // start lamaran
        public IActionResult GETLAMARAN(string position, string category, string loker_by, string sendcv_by, string response_prshn, string prepare, string datefrom, string dateto)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                List<LamaranModel> dataAdmin = new List<LamaranModel>();

                var query = "GET_LAMARAN";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (position == null) { cmd.Parameters.AddWithValue("@position", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@position", position); }

                    if (category == null) { cmd.Parameters.AddWithValue("@category", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@category", category); }

                    if (loker_by == null) { cmd.Parameters.AddWithValue("@loker_by", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@loker_by", loker_by); }

                    if (sendcv_by == null) { cmd.Parameters.AddWithValue("@sendcv_by", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@sendcv_by", sendcv_by); }

                    if (response_prshn == null) { cmd.Parameters.AddWithValue("@response_prshn", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@response_prshn", response_prshn); }

                    if (prepare == null) { cmd.Parameters.AddWithValue("@prepare", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@prepare", prepare); }

                    if (datefrom == null) { cmd.Parameters.AddWithValue("@datefrom", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@datefrom", datefrom); }

                    if (dateto == null) { cmd.Parameters.AddWithValue("@dateto", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@dateto", dateto); }

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data_list = new LamaranModel();
                                data_list.id_lmrn = int.Parse(reader["id_lmrn"].ToString());
                                data_list.position = reader["position"].ToString();
                                DateTime? lmrndateFromDatabase = reader["lmrn_date"] as DateTime?;
                                if (lmrndateFromDatabase.HasValue)
                                {
                                    data_list.lmrn_date = lmrndateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                data_list.nama_prshn = reader["nama_prshn"].ToString();
                                data_list.category = reader["category"].ToString();
                                data_list.no_prshn = reader["no_prshn"].ToString();
                                data_list.loker_by = reader["loker_by"].ToString();
                                data_list.sendcv_by = reader["sendcv_by"].ToString();
                                data_list.lmrn_doc = reader["lmrn_doc"].ToString();
                                data_list.ket_lmrn = reader["ket_lmrn"].ToString();
                                data_list.response_prshn = reader["response_prshn"].ToString();
                                data_list.response_date = reader["response_date"].ToString();
                                data_list.prepare = reader["prepare"].ToString();
                                DateTime? recorddateFromDatabase = reader["record_date"] as DateTime?;
                                if (recorddateFromDatabase.HasValue)
                                {
                                    data_list.record_date = recorddateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                DateTime? lastupdateFromDatabase = reader["last_update"] as DateTime?;
                                if (lastupdateFromDatabase.HasValue)
                                {
                                    data_list.last_update = lastupdateFromDatabase.Value.Date.ToString("yyyy-MM-dd");
                                }
                                dataAdmin.Add(data_list);
                            }
                        }
                    }
                }
                return PartialView("_TableLamaran", dataAdmin);

            }
        }

        public async Task<JsonResult> AddLamaran(IFormFile file, string position, string lmrn_date, string nama_prshn, string no_prshn, string category, string loker_by, string sendcv_by, string ket_lmrn)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                try
                {
                    string fileName = null;
                    if (file != null && file.Length > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine("wwwroot", "lamaran", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }

                    using (SqlConnection con = new SqlConnection(DbConnection()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("AddLamaran", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@position", position);
                            cmd.Parameters.AddWithValue("@lmrn_date", lmrn_date);
                            cmd.Parameters.AddWithValue("@nama_prshn", nama_prshn);
                            cmd.Parameters.AddWithValue("@no_prshn", no_prshn);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@loker_by", loker_by);
                            cmd.Parameters.AddWithValue("@sendcv_by", sendcv_by);
                            cmd.Parameters.AddWithValue("@ket_lmrn", ket_lmrn);
                            cmd.Parameters.AddWithValue("@lmrn_doc", fileName != null ? fileName : (object)DBNull.Value);
                            var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                            returnParam.Direction = ParameterDirection.ReturnValue;

                            cmd.ExecuteNonQuery();

                            int result = (int)returnParam.Value;

                            if (result == 1)
                            {
                                // Insert log into tbl_log if data added successfully
                                var id_user = HttpContext.Session.GetString("id");
                                if (id_user != null)
                                {
                                    string actionMessage = $"Adding New Lamaran {position}";
                                    string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                                    using (SqlCommand logCmd = new SqlCommand(logQuery, con))
                                    {
                                        logCmd.Parameters.AddWithValue("@id_user", id_user);
                                        logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                        logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                        logCmd.ExecuteNonQuery(); // Execute log insertion
                                    }
                                }

                                return Json(new { success = true, message = "Data berhasil ditambahkan." });
                            }
                            else if (result == -1)
                            {
                                return Json(new { success = false, message = "Data sudah ada." });
                            }
                            else
                            {
                                return Json(new { success = false, message = "Terjadi kesalahan saat menambahkan data." });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan: " + ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Anda tidak memiliki izin." });
            }
        }

        // filter edit lamaran
        public IActionResult GetLmrnCategory(string category)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                var submittedCategory = CategoryFromDatabase(category);
                var result = new
                {
                    category = submittedCategory
                };
                return Json(result);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        private string CategoryFromDatabase(string category)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT category FROM tbl_lamaran WHERE category = @category";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@category", category);
                conn.Open();
                var submittedCategory = (string)cmd.ExecuteScalar();
                conn.Close();
                return submittedCategory;
            }
        }

        public IActionResult GetLmrnLokerby(string loker_by)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                var submittedLokerby = LokerbyFromDatabase(loker_by);
                var result = new
                {
                    loker_by = submittedLokerby
                };
                return Json(result);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        private string LokerbyFromDatabase(string loker_by)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT loker_by FROM tbl_lamaran WHERE loker_by = @loker_by";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@loker_by", loker_by);
                conn.Open();
                var submittedLokerby = (string)cmd.ExecuteScalar();
                conn.Close();
                return submittedLokerby;
            }
        }

        public IActionResult GetLmrnSendcvby(string sendcv_by)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                var submittedSendcvby = SendcvbyFromDatabase(sendcv_by);
                var result = new
                {
                    sendcv_by = submittedSendcvby
                };
                return Json(result);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        private string SendcvbyFromDatabase(string sendcv_by)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                string query = "SELECT sendcv_by FROM tbl_lamaran WHERE sendcv_by = @sendcv_by";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sendcv_by", sendcv_by);
                conn.Open();
                var submittedSendcvby = (string)cmd.ExecuteScalar();
                conn.Close();
                return submittedSendcvby;
            }
        }
        public IActionResult UpdateLamaran(int id_lmrn, string position, string lmrn_date, string nama_prshn, string no_prshn, string category, string loker_by, string sendcv_by, string ket_lmrn, string response_prshn, string response_date, string prepare, IFormFile file)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                string fileName = null;
                if (file != null)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/lamaran", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }

                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    string query = @"UPDATE tbl_lamaran SET 
        position = @position, 
        lmrn_date = @lmrn_date, 
        nama_prshn = @nama_prshn, 
        no_prshn = @no_prshn, 
        category = @category,
        loker_by = @loker_by, 
        sendcv_by = @sendcv_by, 
        ket_lmrn = @ket_lmrn, 
        response_prshn = @response_prshn, 
        response_date = @response_date,
        prepare = @prepare, 
        last_update = GETDATE()";

                    if (fileName != null)
                    {
                        query += ", lmrn_doc = @lmrn_doc";
                    }

                    query += " WHERE id_lmrn = @id_lmrn";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_lmrn", id_lmrn);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@lmrn_date", lmrn_date);
                    cmd.Parameters.AddWithValue("@nama_prshn", nama_prshn);
                    cmd.Parameters.AddWithValue("@no_prshn", no_prshn);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@loker_by", loker_by);
                    cmd.Parameters.AddWithValue("@sendcv_by", sendcv_by);
                    cmd.Parameters.AddWithValue("@ket_lmrn", string.IsNullOrEmpty(ket_lmrn) ? DBNull.Value : ket_lmrn);
                    cmd.Parameters.AddWithValue("@response_prshn", string.IsNullOrEmpty(response_prshn) ? DBNull.Value : response_prshn);
                    cmd.Parameters.AddWithValue("@response_date", string.IsNullOrEmpty(response_date) ? DBNull.Value : response_date);
                    cmd.Parameters.AddWithValue("@prepare", string.IsNullOrEmpty(prepare) ? DBNull.Value : prepare);

                    if (fileName != null)
                    {
                        cmd.Parameters.AddWithValue("@lmrn_doc", fileName);
                    }

                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        var id_user = HttpContext.Session.GetString("id");
                        if (id_user != null)
                        {
                            string actionMessage = $"Updating Lamaran {position}";
                            string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                            using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                            {
                                logCmd.Parameters.AddWithValue("@id_user", id_user);
                                logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                logCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        public IActionResult DeleteLamaran(string id_lmrn)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string getItemQuery = "SELECT position FROM tbl_lamaran WHERE id_lmrn = @id_lmrn";
                    string position = null;

                    // Retrieve the item name first
                    using (SqlCommand getItemCmd = new SqlCommand(getItemQuery, conn))
                    {
                        getItemCmd.Parameters.AddWithValue("@id_lmrn", id_lmrn);
                        using (SqlDataReader reader = getItemCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                position = reader["position"].ToString();
                            }
                        }
                    }

                    // Proceed with deletion
                    string deleteQuery = @"DELETE FROM tbl_lamaran WHERE id_lmrn = @id_lmrn";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@id_lmrn", id_lmrn);
                    rowsAffected = cmd.ExecuteNonQuery();

                    // Insert log into tb_log if deletion successful
                    if (rowsAffected > 0 && position != null)
                    {
                        var id_user = HttpContext.Session.GetString("id");
                        if (id_user != null)
                        {
                            string actionMessage = $"Deleting Lamaran {position}";
                            string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                            using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                            {
                                logCmd.Parameters.AddWithValue("@id_user", id_user);
                                logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                logCmd.ExecuteNonQuery(); // Execute log insertion
                            }
                        }
                    }

                    conn.Close();
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }

        [HttpPost]
        [Route("Delete_selected10")]
        public IActionResult Delete_selected10([FromBody] LamaranModel[] input)
        {
            if (HttpContext.Session.GetString("level") == "admin")
            {
                int rowsAffected = -1;

                using (SqlConnection conn = new SqlConnection(DbConnection()))
                {
                    conn.Open();
                    string getItemQuery = "SELECT position FROM tbl_lamaran WHERE id_lmrn = @id_lmrn";
                    string deleteQuery = "DELETE FROM tbl_lamaran WHERE id_lmrn = @id_lmrn";

                    for (int i = 0; i < input.Length; i++)
                    {
                        string position = null;

                        // Retrieve the item name first
                        using (SqlCommand getItemCmd = new SqlCommand(getItemQuery, conn))
                        {
                            getItemCmd.Parameters.AddWithValue("@id_lmrn", input[i].id_lmrn);
                            using (SqlDataReader reader = getItemCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    position = reader["position"].ToString();
                                }
                            }
                        }

                        // Proceed with deletion
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@id_lmrn", input[i].id_lmrn);

                        try
                        {
                            rowsAffected = deleteCmd.ExecuteNonQuery();

                            // Insert log into tb_log if deletion successful
                            if (rowsAffected > 0 && position != null)
                            {
                                var id_user = HttpContext.Session.GetString("id");
                                if (id_user != null)
                                {
                                    string actionMessage = $"Deleting Lamaran {position}";
                                    string logQuery = "INSERT INTO tbl_log (id_user, record_date, actions) VALUES (@id_user, @record_date, @actions)";
                                    using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                                    {
                                        logCmd.Parameters.AddWithValue("@id_user", id_user);
                                        logCmd.Parameters.AddWithValue("@record_date", DateTime.Now);
                                        logCmd.Parameters.AddWithValue("@actions", actionMessage);
                                        logCmd.ExecuteNonQuery(); // Execute log insertion
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                }

                return Json(rowsAffected);
            }
            else
            {
                return RedirectToAction("SignOut", "Login");
            }
        }
        // end lamaran

       // start filtering lamaran
       [HttpGet]
        public IActionResult GetPosition0(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT position as position FROM tbl_lamaran WHERE position LIKE '%" + family + "%' ORDER BY position ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["position"].ToString();
                            data_list.Id = reader["position"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetCategory0(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT category as category FROM tbl_lamaran WHERE category LIKE '%" + family + "%' ORDER BY category ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["category"].ToString();
                            data_list.Id = reader["category"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetLokerby0(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT loker_by as loker_by FROM tbl_lamaran WHERE loker_by LIKE '%" + family + "%' ORDER BY loker_by ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["loker_by"].ToString();
                            data_list.Id = reader["loker_by"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetSendby0(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT sendcv_by as sendcv_by FROM tbl_lamaran WHERE sendcv_by LIKE '%" + family + "%' ORDER BY sendcv_by ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["sendcv_by"].ToString();
                            data_list.Id = reader["sendcv_by"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetResponse0(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT response_prshn as response_prshn FROM tbl_lamaran WHERE response_prshn LIKE '%" + family + "%' ORDER BY response_prshn ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["response_prshn"].ToString();
                            data_list.Id = reader["response_prshn"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }

        [HttpGet]
        public IActionResult GetPrepare0(string family)
        {
            List<LamaranModel> data = new List<LamaranModel>();
            string query = "SELECT DISTINCT prepare as databases FROM tbl_lamaran WHERE prepare LIKE '%" + family + "%' ORDER BY prepare ASC";
            using (SqlConnection conn = new SqlConnection(DbConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data_list = new LamaranModel();
                            data_list.Text = reader["prepare"].ToString();
                            data_list.Id = reader["prepare"].ToString();
                            data.Add(data_list);
                        }
                    }
                    conn.Close();
                }
            }
            return Json(new { items = data });
        }
        // end filtering lamaran



    }
}
