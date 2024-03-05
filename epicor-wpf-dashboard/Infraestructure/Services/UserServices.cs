
using Core.Models;
using Infraestructure.Data;
using Infraestructure.Interfaces;
using Infraestructure.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructure.Services
{
    public class UserServices : IUserServices
    {
        public List<UsersReports> TotalOpenReportsByUsers()
        {
            List<UsersReports> _list = new List<UsersReports>();
            SqlConnection con = new SqlConnection(DbContext.ConnectionString());
            try
            {
                SqlCommand cmd = new SqlCommand(UsersStringQuery.TOTAL_ACTIVE_BY_USERS);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader =cmd.ExecuteReader();

                while (reader.Read())
                {
                    _list.Add(
                        new UsersReports(reader["UserName"].ToString(),
                        int.Parse(reader["Total"].ToString())
                        ));
                }
                reader.Close();
                return _list;
            }
            catch
            {
                _list = null;
            }
            finally
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return _list;
        }
    }
}
