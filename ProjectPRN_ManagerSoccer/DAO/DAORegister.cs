using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO;
namespace DAO
{
    public class DAORegister
    {
        public bool Register(string user, string pass, string phone, string email,object ques,string ass)
        {
            DataTable dt = new DataTable();
            string str = "insert into [User] values('"+user+"','"+pass+"','"+phone+"','"+email+ "','"+ques+"','"+ass+"','0')";
            return (new DataProvider()).executeNonQuery(str);
            
        }
        public bool UpdateTeamID(Account acc)
        {
            string str = "update [User] set TeamID = '" + acc.TeamID + "' where UserName = '" + acc.UserName + "'";
            return (new DataProvider()).executeNonQuery(str);
        }
        public bool CreateTeam(string teamName, string region, string logo, string Money)
        {
            string str = "insert into Team values ('"+teamName+"','"+region+"','"+logo+"','"+Money+"')";
            return (new DataProvider()).executeNonQuery(str);
        }
    }
}
