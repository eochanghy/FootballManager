using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DAOForgot
    {
        public DataTable getAllUserName()
        {
            string str = "select UserName from [User]";
            return (new DataProvider()).executeQuery(str);
        }
        public DataTable getAccByUserName(string userName)
        {
            string str = "select * from [User] where UserName = '"+userName+"'";
            return (new DataProvider()).executeQuery(str);
        }
        public bool updatePassword(string userName, string pass)
        {
            string str = "update [User] set [Password] = '"+pass+"' where UserName = '"+userName+"'";
            return (new DataProvider()).executeNonQuery(str);
        }
    }
}
