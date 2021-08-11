using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class BUSRequest
    {
        public DataTable getRequestFromME(int teamID)
        {
            return (new DAORequest()).getRequestFromME(teamID);
        }
        public DataTable getAnotherRequest(string playerID, int currentRequestID)
        {
            return (new DAORequest()).getAnotherRequest(playerID, currentRequestID);
        }
        public bool removeAllRequestbyPlayerID(string playerID)
        {
            return (new DAORequest()).removeAllRequestbyPlayerID(playerID);
        }
        public bool removeRequest(int requestID)
        {
            return (new DAORequest()).removeRequest(requestID);
        }
        public bool insertRequest(string playerId, string playerName, string price, string message, int teamIDS, int teamIDR)
        {
            return (new DAORequest()).insertRequest(playerId, playerName, price, message, teamIDS, teamIDR);
        }
        public DataTable getRequestForME(int teamID)
        {
            return (new DAORequest()).getRequestForME(teamID);
        }
    }
}
