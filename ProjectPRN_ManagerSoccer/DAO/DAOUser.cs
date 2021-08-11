using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DAOUser
    {
        public DataTable checkUser(string account, string password)
        {
            DataTable dt = new DataTable();
            string str = "select * from [User] where UserName='" + account + "'and Password='" + password + "'";
            return  (new DataProvider()).executeQuery(str);          
        }
        public DataTable getAllAcc()
        {
            string str = "select * from [User]";
            return (new DataProvider()).executeQuery(str);
        }
    }
}
