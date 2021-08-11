using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Team
    {
        public Team()
        {
        }
        public Team(int id, string name, string region, string logo, float monney)
        {
            this.id = id;
            this.name = name;
            this.region = region;
            this.logo = logo;
            this.monney = monney;
        }
       


        public int id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string logo { get; set; }
        public float monney { get; set; }


    }
}
