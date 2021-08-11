using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Player
    {
        public Player()
        {
        }

        public Player(int id, string name, int teamID)
        {
            this.id = id;
            this.name = name;
            this.teamID = teamID;
        }

        public Player(int id, string name, string region, DateTime dob, int teamID, string position, double physical, double attacking, double defending, double speed, string image, bool isMain)
        {
            this.id = id;
            this.name = name;
            this.region = region;
            this.dob = dob;
            this.teamID = teamID;
            this.position = position;
            this.physical = physical;
            this.attacking = attacking;
            this.defending = defending;
            this.speed = speed;
            this.image = image;
            this.isMain = isMain;
        }

        public Player(int id, string name, int teamID, string image)
        {
            this.id = id;
            this.name = name;
            this.teamID = teamID;
            this.image = image;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public DateTime dob { get; set; }
        public int teamID { get; set; }
        public string position { get; set; }
        public double physical { get; set; }
        public double attacking { get; set; }
        public double defending { get; set; }
        public double speed { get; set; }
        public string image { get; set; }
        public bool isMain { get; set; }

    }
}
