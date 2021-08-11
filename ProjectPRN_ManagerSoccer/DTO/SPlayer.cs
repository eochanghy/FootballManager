using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class SPlayer
    {
        public SPlayer()
        {
        }

        public SPlayer(int playerId, string playerName, string image)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.image = image;
        }

        public int playerId { get; set; }
        public string playerName { get; set; }
        public string image { get; set; }

    }
}
