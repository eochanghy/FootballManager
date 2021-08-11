using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class BUSForgot
    {
        public bool updatePassword(string userName, string pass)
        {
            return (new DAOForgot()).updatePassword(userName, pass);
        }
        public bool checkExistUSerName(string userName)
        {
            DataTable dt = (new DAOForgot()).getAllUserName();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserName"].ToString().Equals(userName))
                {
                    return true;
                }
            }
            return false;
        }
        public Account getAccByUserName(string userName)
        {
            DataTable dt = (new DAOForgot()).getAccByUserName(userName);
            Account acc = new Account();
            acc.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
            acc.UserName = dt.Rows[0]["UserName"].ToString();
            acc.Password = dt.Rows[0]["Password"].ToString();
            acc.Phone = dt.Rows[0]["Phone"].ToString();
            acc.Email = dt.Rows[0]["Email"].ToString();
            acc.PrivateQuesion = dt.Rows[0]["PrivateQuestion"].ToString();
            acc.Answer = dt.Rows[0]["Answer"].ToString();
            acc.TeamID = Convert.ToInt32(dt.Rows[0]["TeamID"].ToString());
            return acc;
        }
    }
}
