using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DAOSearch
    {
        public object loadDataP(string rigion, string team, string pos, string name2)
        {
            string str = "select * from [Player] where PlayerName like '%" + name2 + "%'and Position like '%" + pos + "%'and Region like '%" + rigion + "%'";
            Console.WriteLine("\nquery: "+str+"\n");
            return (new DataProvider()).executeQuery(str);
        }
        public void SearchTeam(string team, string name)
        {
            DataTable dt = new DataTable();
            string str = "select * from [Team] where TeamName like '%" + name + "%'";
            dt = (new DataProvider()).executeQuery(str);
        }

        public DataTable loadData(string team, string name)
        {
            string str = "select * from [Team] where TeamName like '%" + name + "%'";
            return (new DataProvider()).executeQuery(str);
        }

        public void SearchPlayer(string player, string name2)
        {
            DataTable dt = new DataTable();
            string str = "select * from [Player] where PlayerName like '%" + name2 + "%'";
            dt = (new DataProvider()).executeQuery(str);
        }


    }
}
