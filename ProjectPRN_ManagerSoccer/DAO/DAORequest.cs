using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DAORequest
    {
        public DataTable getAnotherRequest(string playerID, int currentRequestID)
        {
            string str = "select * from Request where PlayerID = '"+playerID+"' and RequestID != '"+currentRequestID+"'";
            return (new DataProvider()).executeQuery(str);
        }
        public bool removeAllRequestbyPlayerID(string playerID)
        {
            string str = "Delete from Request where PlayerID = '" + playerID + "'";
            return (new DataProvider()).executeNonQuery(str);
        }
        public bool removeRequest(int requestID)
        {
            string str = "Delete from Request where RequestID = '" + requestID + "'";
            return (new DataProvider()).executeNonQuery(str);
        }
        public bool insertRequest(string playerId, string playerName, string price, string message, int teamIDS, int teamIDR)
        {
            string str = "insert into Request values ('" + playerId + "', '" + playerName + "', '" + price + "', '" + message + "', '" + teamIDS + "', '" + teamIDR + "')";
            return (new DataProvider()).executeNonQuery(str);
        }
        public DataTable getRequestFromME(int teamID)
        {
            string str = "select * from Request where TeamIDSend = '" + teamID + "'";
            return (new DataProvider()).executeQuery(str);
        }
        public DataTable getRequestForME(int teamID)
        {
            string str = "select * from Request where TeamIDReceive = '"+teamID+"'";
            return (new DataProvider()).executeQuery(str);
        }
        
    }
}
