using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class BUSManageAcc
    {
        public bool updateAcc(string pass, string phone, string email, string ques, string ans, int userID)
        {
            return (new DAOManageAcc()).updateAcc(pass, phone, email, ques, ans, userID);
        }
        public Account getAccByID(int userID)
        {
            DataTable dt = (new DAOManageAcc()).getAccByID(userID);
            Account acc = new Account();
            acc.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
            acc.UserName = dt.Rows[0]["UserName"].ToString();
            acc.Password = dt.Rows[0]["Password"].ToString();
            acc.Phone = dt.Rows[0]["Phone"].ToString();
            acc.Email = dt.Rows[0]["Email"].ToString();
            acc.PrivateQuesion = dt.Rows[0]["PrivateQuestion"].ToString();
            acc.Answer = dt.Rows[0]["Answer"].ToString();
            return acc;
        }
    }
}
