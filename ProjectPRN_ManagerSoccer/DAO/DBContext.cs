using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DBContext
    {
        
        public bool ExecuteSqlWithParameters(string sql, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(parameters);
            command.Connection.Open();
            int count = command.ExecuteNonQuery();
            command.Connection.Close();
            
            return count>0?true:false;
        }
        public static SqlConnection GetConnection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBConnect"].ToString();
            return new SqlConnection(conStr);
        }
        public DataTable GetDataBySqlWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
