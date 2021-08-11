using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DTO;
namespace DAO
{
    public class DAOTransfer
    {
        public bool updateMoney(double newMoney, int teamId)
        {
            string str = "update Team set [Money] = '"+newMoney+"' where TeamID = '"+teamId+"'";
            return (new DataProvider()).executeNonQuery(str);
        }
        public bool removeFromTransfer(string id, int teamID)
        {
            string str = "UPDATE Player SET TeamID = '"+teamID+"' WHERE PlayerID = '" + id + "';\ndelete from Transfer where PlayerID = '"+id+"'";
            return (new DataProvider()).executeNonQuery(str);
        }
        public DataTable getMoney(int teamID)
        {
            string str = "select [Money] from Team where TeamID = '"+teamID+"'";
            return (new DataProvider()).executeQuery(str);
        }
        public DataTable getMyPlayerOnTransfer(int teamID)
        {
            string str = "select * from Transfer where TeamID = '"+teamID+"'";
            return (new DataProvider()).executeQuery(str);
        }
        public DataTable getTransferPlayerr(Account acc)
        {
            string str = "select * from Player where isMain = 'false' and TeamID = '"+acc.TeamID+"'";
            return (new DataProvider()).executeQuery(str);
        }

        public DataTable getTransferMark()
        {
            string str = "select * from Transfer";
            return (new DataProvider()).executeQuery(str);
        }
        public bool updateAfterSell(int id)
        {
            string str = "UPDATE Player SET TeamID = 0 WHERE PlayerID = '" + id + "'";
            return (new DataProvider()).executeNonQuery(str);
        }
        public bool addTransfer(Player a, double price)
        {
 
            DateTime current = DateTime.Now;
            string str = "insert into Transfer values ('" + a.id + "','" + a.name + "'," +
                "(select TeamName from Team where TeamID = '" + a.teamID + "'),'" + price + "',@date,'"+a.teamID+"')";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parameter[0].Value = current;

            return (new DBContext()).ExecuteSqlWithParameters(str, parameter);
        }
    }
}
