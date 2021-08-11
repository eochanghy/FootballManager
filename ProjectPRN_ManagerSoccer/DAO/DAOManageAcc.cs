using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DAOManageAcc
    {
        public DataTable getAccByID(int userID)
        {
            string str = "select * from [User] where UserID = '" + userID + "'";
            return (new DataProvider()).executeQuery(str);
        }
        public bool updateAcc(string pass, string phone, string email, string ques, string ans, int userID)
        {
            string str = "update [User] set [Password] = '"+pass+"', Phone='"+phone+"', Email = '"+email+"', PrivateQuestion = '"+ques+"', Answer = '"+ans+ "' where UserID = '"+userID+"'";
            return (new DataProvider()).executeNonQuery(str);
        }
    }
}
