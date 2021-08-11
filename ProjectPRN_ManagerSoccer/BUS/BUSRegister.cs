using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class BUSRegister
    {
        public bool Register(string user, string pass, string phone, string email,string ques ,string ass)
        {
            
            return (new DAORegister()).Register(user, pass, phone, email,ques,ass);
        }
        public bool updateTeamID(Account acc)
        {
            return (new DAORegister()).UpdateTeamID(acc); 
        }
        public bool CreateTeam(string teamName, string region, string logo, string Money)
        {
            return (new DAORegister()).CreateTeam(teamName, region, logo, Money);
        }
    }
}
