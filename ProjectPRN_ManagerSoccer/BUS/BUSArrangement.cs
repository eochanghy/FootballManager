using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO;
using DAO;
namespace BUS
{
    public class BUSArrangement
    {
        public List<MPlayer> getAllPlayerLocation(int teamID)
        {
            List<MPlayer> mainPlayer = new List<MPlayer>();
            DataTable dt = (new DAOArrangement()).getAllLocationPlayer(teamID);
            foreach (DataRow dr in dt.Rows)
            {
                mainPlayer.Add(new MPlayer(Convert.ToInt32(dr["PlayerID"].ToString()), dr["PlayerName"].ToString(), Convert.ToInt32( dr["LocationX"].ToString()), Convert.ToInt32(dr["LocationY"].ToString()), dr["Image"].ToString()));
            }
            return mainPlayer;
        }

        public MPlayer getPlayerLocation(int playerID)
        {
            MPlayer mainPlayer = new MPlayer();
            DataTable dt = (new DAOArrangement()).getPlayerLocation(playerID);
            mainPlayer.playerID = Convert.ToInt32(dt.Rows[0]["PlayerID"].ToString());
            mainPlayer.playerName = dt.Rows[0]["PlayerName"].ToString();
            mainPlayer.playerX = Convert.ToInt32(dt.Rows[0]["LocationX"]);
            mainPlayer.playerY = Convert.ToInt32(dt.Rows[0]["LocationY"]);
            mainPlayer.image = dt.Rows[0]["Image"].ToString();
            return mainPlayer;
        }
        public List<SPlayer> getSubPlayer(int teamID)
        {
            List<SPlayer> listS = new List<SPlayer>();
            DataTable dt = (new DAOArrangement()).getSubPlayer(teamID);
            foreach (DataRow item in dt.Rows)
            {
                listS.Add(new SPlayer(Convert.ToInt32(item["PlayerID"].ToString()), item["PlayerName"].ToString(), item["Image"].ToString()));
            }
            return listS;
        }
        public void deletePostion(int teamID)
        {
            bool run = (new DAOArrangement()).deleteLocationbyTeamID(teamID);
        }
        public void updateIsMain(int playerID, int isMain)
        {
            bool run = (new DAOArrangement()).updateIsMain(playerID, isMain);
        }
        public void insertLocation(int playerID, int x, int y, int teamID)
        {
            bool run = (new DAOArrangement()).insertLocation(playerID, x, y, teamID);    
        }
        public List<Player> getIsMainPlayer(int teamID)
        {
            List<Player> listP = new List<Player>();
            DataTable dt = (new DAOArrangement()).getIsMainPlayer(teamID);
            foreach (DataRow dr in dt.Rows)
            {
                listP.Add(new Player(Convert.ToInt32(dr["PlayerID"].ToString()), dr["PlayerName"].ToString(), Convert.ToInt32(dr["TeamID"].ToString()), dr["Image"].ToString()));
            }
            return listP;
        }
    }

}
