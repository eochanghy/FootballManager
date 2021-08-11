using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class BUSTransfer
    {
        public bool updateMoney(double newMoney, int teamId)
        {
            return (new DAOTransfer()).updateMoney(newMoney, teamId);
        }
        public bool removeFromTransfer(string id, int teamID)
        {
            return (new DAOTransfer()).removeFromTransfer(id, teamID);
        }
        public string getMoney(int teamID)
        {
            DataTable dt = (new DAOTransfer()).getMoney(teamID);
            return dt.Rows[0]["Money"].ToString();
            
        }
        public DataTable getMyPlayer(int teamID)
        {
            return (new DAOTransfer()).getMyPlayerOnTransfer(teamID);
        }
        public DataTable getTransferPlayer(Account acc)
        {
            return (new DAOTransfer()).getTransferPlayerr(acc);
        }

        public DataTable getTransferMark()
        {
            return (new DAOTransfer()).getTransferMark();
        }
        public bool updateAfterSell(int id)
        {
            return (new DAOTransfer()).updateAfterSell(id);                                     
        }
        public bool addTransfer(Player a, double price)
        {
            return (new DAOTransfer()).addTransfer(a, price);
        }
    }
}
