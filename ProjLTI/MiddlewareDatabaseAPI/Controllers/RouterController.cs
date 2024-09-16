using System;
using System.Data.SqlClient;
using System.Security.AccessControl;
using MiddlewareDatabaseAPI.Models;
using System.Data;
using System.Web.Http;
using System.Collections.Generic;

namespace MiddlewareDatabaseAPI.Controllers
{
    [RoutePrefix("api/credentials")]
    public class RouterController : ApiController
    {
        private string connStr = Properties.Settings.Default.ConnStr;
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllCredentials()
        {
            List<Router> credentials = new List<Router>();
            string queryString = "SELECT TOP 10 * FROM Routers ORDER BY Id DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, conn);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Router c = new Router
                            {
                                Id = (int)reader["Id"],
                                Ip = (string)reader["Ip"],
                                Model = (string)reader["Model"],
                                Username = (string)reader["Username"],
                                Password = reader["Password"] == DBNull.Value ? "" : (string)reader["Password"],
                            };
                            credentials.Add(c);
                        }
                    }
                }
                return Ok(credentials);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult StoreCredentials([FromBody] Router value)
        {
            string queryString;

            if (value.Password != null) 
            {
                queryString = "INSERT INTO Routers (ip, username, model, password) VALUES (@ip, @username, @model, @password)";
            }
            else
            {
                queryString = "INSERT INTO Routers (ip, username, model) VALUES (@ip, @username, @model)";
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@ip", value.Ip);
                    command.Parameters.AddWithValue("@username", value.Username);
                    command.Parameters.AddWithValue("@model", value.Model);
                    if (value.Password != null) {
                        command.Parameters.AddWithValue("@password", value.Password);
                    }
                    try
                    {
                        command.Connection.Open();
                        if (command.ExecuteNonQuery() == 0)
                        {
                            return NotFound();
                        }
                        else
                        {
                            return Ok();
                        }
                    }
                    catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}