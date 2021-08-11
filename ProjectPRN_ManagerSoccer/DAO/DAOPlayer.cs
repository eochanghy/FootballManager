using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DAOPlayer
    {
        public DataTable loadPlayer()
        {
            string str = "select * from Player";
            return (new DataProvider()).executeQuery(str);
        }

        public DataTable loadPlayer(int TeamID)
        {
            string str = "select * from Player WHERE TeamID =" + TeamID;
            return (new DataProvider()).executeQuery(str);
        }

        public DataTable loadDataPlayer(int PlayerID)
        {
            string str = "select * from Player WHERE PlayerID =" + PlayerID;
            return (new DataProvider()).executeQuery(str);
        }
        public bool AddPlayer(string name, string region,DateTime dateOfBirth, int teamid, string position, int physical,int attacking,int defending,int Speed,string image,string isMain)
        {
            string str = "insert into [Player] values('" + name + "','" + region + "',@dob," + teamid + ",'" + position + "'," + physical + "," + attacking + "," + defending + "," + Speed + ",'" + image + "','" + isMain + "')";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@dob", SqlDbType.DateTime);
            parameter[0].Value = dateOfBirth;

            return (new DBContext()).ExecuteSqlWithParameters(str, parameter);
        }

        public bool EditPlayer(int PlayerID,string name, string region, DateTime dateOfBirth, int teamid, string position, int physical, int attacking, int defending, int Speed, string image, string isMain)
        {
            string str = "UPDATE [dbo].[Player] SET[PlayerName] = '" + name + "',[Region] ='" + region + "',[DateOfBirth] =@dob,[TeamID]=" + teamid + ",[Position]='" + position + "',[Physical] =" + physical + ",[Attacking]=" + attacking + ",[Defending]=" + defending + ",[Speed]=" + Speed + ",[Image]='" + image + "',[isMain] ='" + isMain + "' WHERE PlayerID =" +PlayerID;
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@dob", SqlDbType.DateTime);
            parameter[0].Value = dateOfBirth;

            return (new DBContext()).ExecuteSqlWithParameters(str, parameter);

        }
        public bool DeletePlayer(int id)
        {
            DataTable dt = new DataTable();
            string sql = "delete from Player where PlayerID = " + id;
            return (new DataProvider()).executeNonQuery(sql);
        }

        public bool CheckMain(int id)
        {
            string sql = "SELECT isMain from Player where PlayerID = " + id;
            return (new DataProvider()).checkMain(sql);
        }
    }
}
