using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;
namespace BUS
{
    public class BUSSearch
    {
        public object loadDataP(string rigion, string team, string pos, string name2)
        {
            return (new DAOSearch()).loadDataP(rigion, team, pos, name2);
        }
        public void SearchTeam(string team, string name)
        {
            (new DAOSearch()).SearchTeam(team, name);
        }

        public DataTable loadDataT(string team, string name)
        {
            return (new DAOSearch()).loadData(team, name);
        }

        public void SearchPlayer(string player, string name2)
        {
            (new DAOSearch()).SearchPlayer(player, name2);
        }


    }
}
