using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Account
    {
        public Account()
        {
        }

        public Account(int userID, string userName, string password, string phone, string email, string privateQuesion, string answer, int teamID)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Phone = phone;
            Email = email;
            PrivateQuesion = privateQuesion;
            Answer = answer;
            TeamID = teamID;
        }

        public Account(int userID, string userName, string password, string phone, string email, string privateQuesion, string answer)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Phone = phone;
            Email = email;
            PrivateQuesion = privateQuesion;
            Answer = answer;
        }

        public Account(string userName, string password, string phone, string email, string privateQuesion, string answer)
        {
            UserName = userName;
            Password = password;
            Phone = phone;
            Email = email;
            PrivateQuesion = privateQuesion;
            Answer = answer;
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PrivateQuesion { get; set; }
        public string Answer { get; set; }
        public int TeamID { get; set; }


    }
}
