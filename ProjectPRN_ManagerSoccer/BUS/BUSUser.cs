using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class BUSUser
    {
        public Account checkUser(string account, string password)
        {
            DataTable dt = (new DAOUser()).checkUser(account, password);
            Account acc = new Account();
            if(dt.Rows.Count > 0)
            {
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
            
            return null;
        }
        public Account getAccwithouTeamID(string account, string password)
        {
            DataTable dt = (new DAOUser()).checkUser(account, password);
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
        public bool checkExistedAcc(string txtName)
        {
            DataTable dt = (new DAOUser()).getAllAcc();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserName"].ToString().ToLower().Equals(txtName.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
