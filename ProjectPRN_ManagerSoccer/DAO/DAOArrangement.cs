using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DAOArrangement
    {
        public DataTable getAllLocationPlayer(int teamID)
        {
            string str = "select p.PlayerID, p.PlayerName, l.LocationX, l.LocationY, p.[Image] from Player as p, [Location] as l where p.PlayerID = l.PlayerID and p.TeamID = " + teamID;
            return (new DataProvider()).executeQuery(str);
        }
        public DataTable getPlayerLocation(int playerID)
        {
            string str = "select p.PlayerID, p.PlayerName, l.LocationX, l.LocationY, p.[Image] from Player as p, [Location] as l where p.PlayerID = l.PlayerID and p.PlayerID = " + playerID;
            return (new DataProvider()).executeQuery(str);
        }
        public DataTable getSubPlayer(int teamID)
        {
            string str = "select p.PlayerID, p.PlayerName, p.[Image] from Player as p where p.isMain = 0 and p.TeamID = "+teamID;
            return (new DataProvider()).executeQuery(str);
        }
        public bool deleteLocationbyTeamID(int teamID)
        {
            string str = "delete from [Location] where TeamID = " + teamID;
            return (new DataProvider()).executeNonQuery(str);
        }
        public bool updateIsMain(int playerId, int isMain)
        {
            string str = "update Player set isMain = '"+isMain+"' where PlayerID =  " + playerId;
            return (new DataProvider()).executeNonQuery(str);
        }
        public bool insertLocation(int playerID, int x, int y, int teamID)
        {
            string str = "insert into [Location] values ('"+playerID+"', '"+x+"', '"+y+"', '"+teamID+"')";
            return (new DataProvider()).executeNonQuery(str);
        }
        public DataTable getIsMainPlayer(int teamID)
        {
            string str = "select p.PlayerID, p.PlayerName, p.TeamID, p.[Image] from Player p where p.TeamID = '"+teamID+"' and p.isMain = 1";
            return (new DataProvider()).executeQuery(str);
        }
    }
}
