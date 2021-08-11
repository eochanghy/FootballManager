using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class MPlayer
    {
        public MPlayer()
        {
        }

        public MPlayer(int playerID, string playerName, int playerX, int playerY, string image)
        {
            this.playerID = playerID;
            this.playerName = playerName;
            this.playerX = playerX;
            this.playerY = playerY;
            this.image = image;
        }

        public int playerID { get; set; }
        public string playerName { get; set; }
        public int playerX { get; set; }
        public int playerY { get; set; }
        public string image { get; set; }
    }
    

}
