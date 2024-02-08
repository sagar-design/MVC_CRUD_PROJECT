using MVC_CRUD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace MVC_CRUD_PROJECT.Repository
{
    // Data Access Layer (DAL)
    public class DAL
    {
        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
        public List<UserRegModel> GetDatalist()
        {
            List<UserRegModel> userList = new List<UserRegModel>();
            SqlCommand cmd = new SqlCommand("sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;

            using (DataTable dt = new DataTable())
            {
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    userList.Add(new UserRegModel
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Emailid = Convert.ToString(dr["emailid"]),
                        Password = Convert.ToString(dr["password"]),
                        Name = Convert.ToString(dr["name"])
                    });
                }
            }

            return userList;
        }

        public bool InsertData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.Id);
            cmd.Parameters.AddWithValue("@email", ur.Emailid);
            cmd.Parameters.AddWithValue("@pwd", ur.Password);
            cmd.Parameters.AddWithValue("@nm", ur.Name);

            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.Id);
            cmd.Parameters.AddWithValue("@email", ur.Emailid);
            cmd.Parameters.AddWithValue("@pwd", ur.Password);
            cmd.Parameters.AddWithValue("@nm", ur.Name);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.Id);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
