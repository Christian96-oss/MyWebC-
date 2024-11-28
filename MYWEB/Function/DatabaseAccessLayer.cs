using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYWEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace MYWEB.Function
{
    public class DatabaseAccessLayer
    {
        public string ConnectionString = "Data Source=LAPTOP-NVGOC9AO\\SQLEXPRESS02;Initial Catalog=MYWEB;Integrated Security=True;" + "MultipleActiveResultSets=True";

        public bool AddUser(string usr_sesa, string usr_name, string usr_password, string usr_level, string usr_plant, string usr_email, string dept, string apps, string stm_qa)
        {
            if (usr_password == null || usr_password == "")
            {
                usr_password = "123";
            }

            var hashpassword = new Authentication();
            string passwordHash = hashpassword.MD5Hash(usr_password);
            try
            {
                string query = $"INSERT INTO [MYWEB].[dbo].[mst_users] (usr_sesa, usr_name, usr_password, usr_level, usr_plant, usr_record_date, usr_email, dept, apps, stm_qa) VALUES (@usr_sesa, @usr_name, @usr_password, @usr_level, @usr_plant, GETDATE(), @usr_email, @dept, @apps, @stm_qa)";

                Console.WriteLine("Add User query:\n" + query);

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@usr_sesa", usr_sesa);
                        cmd.Parameters.AddWithValue("@usr_name", usr_name);
                        cmd.Parameters.AddWithValue("@usr_password", passwordHash);
                        cmd.Parameters.AddWithValue("@usr_level", usr_level);
                        cmd.Parameters.AddWithValue("@usr_plant", usr_plant);
                        cmd.Parameters.AddWithValue("@usr_email", usr_email);
                        cmd.Parameters.AddWithValue("@dept", dept);
                        cmd.Parameters.AddWithValue("@apps", apps);
                        cmd.Parameters.AddWithValue("@stm_qa", stm_qa);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return false;
            }
        }

        public void DeleteUser(string usr_id, string usr_sesa)
        {
            try
            {
                string query = $"DELETE FROM [MYWEB].[dbo].[mst_users] WHERE usr_id = '{usr_id}' AND usr_sesa = '{usr_sesa}'";

                Console.WriteLine("DELETE User query:\n" + query);

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public bool UpdateUserr(string usr_id, string usr_password)
        {
            try
            {
                Authentication hashpassword = new Authentication();
                string hashedPassword = hashpassword.MD5Hash(usr_password);

                UserModel user = new UserModel
                {

                    usr_id = usr_id, // Ubah sesuai tipe data yang sesuai dengan kolom di database
                    usr_password = hashedPassword
                };

                // Lakukan operasi update ke database menggunakan model pengguna
                UpdateUserInDatabase(user);

                Console.WriteLine("User Updated Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        private void UpdateUserInDatabase(UserModel user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    string query = $"UPDATE [MYWEB].[dbo].[mst_users] SET usr_password = '{user.usr_password}' " +
                                   $"WHERE usr_id = {user.usr_id}";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Handle exception, log, or throw if necessary
            }
        }
        public bool UpdateUser(string usr_sesa, string usr_name, string usr_level, string usr_plant, string usr_id, string usr_email, string dept, string apps, string stm_qa)
        {
            try
            {
                string query = $"UPDATE [MYWEB].[dbo].[mst_users] SET usr_sesa = '{usr_sesa}', usr_name = '{usr_name}', usr_level = '{usr_level}', usr_plant = '{usr_plant}', usr_email = '{usr_email}', dept = '{dept}', apps = '{apps}', stm_qa = '{stm_qa}'" +
                $"WHERE usr_id = '{usr_id}'";

                Console.WriteLine("Update User query:\n" + query);

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}
