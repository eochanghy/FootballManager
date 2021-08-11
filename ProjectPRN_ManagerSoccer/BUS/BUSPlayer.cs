using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;

namespace BUS
{
    public class BUSPlayer
    {
        public DataTable loadPlayer()
        {
            return (new DAOPlayer()).loadPlayer();
        }
        public DataTable loadPlayer(int TeamID)
        {
            return (new DAOPlayer()).loadPlayer(TeamID);
        }

        public DataTable loadSchedule(int TeamID)
        {
            return (new DAOSchedule()).loadSchedule(TeamID);
        }

        public DataTable loadDataPlayer(int PlayerID)
        {
            return (new DAOPlayer()).loadDataPlayer(PlayerID);
        }

        public DataTable loadDataSchedult(int ScheduleID)
        {
            return (new DAOSchedule()).loadDataSchedule(ScheduleID);
        }

        public DataTable loadRegion()
        {
            return (new DataProvider()).executeQuery("SELECT DISTINCT Region FROM Player");
        }

        public DataTable loadPositon()
        {
            return (new DataProvider()).executeQuery("SELECT DISTINCT Position FROM Player");
        }

        public bool AddPlayer(string name, string region,DateTime dateOfBirth, int teamid, string position, int physical,int attacking,int defending,int Speed,string image,string isMain)
        {

            return (new DAOPlayer()).AddPlayer(name, region, dateOfBirth, teamid, position, physical, attacking, defending, Speed, image, isMain);
        }

        public bool AddSchedule(string content, string start, string end, DateTime date, int teamid)
        {

            return (new DAOSchedule()).AddSchedule(content,start,end,date,teamid);
        }

        public bool EditPlayer(int PlayerID,string name, string region, DateTime dateOfBirth, int teamid, string position, int physical, int attacking, int defending, int Speed, string image, string isMain)
        {

            return (new DAOPlayer()).EditPlayer(PlayerID,name, region, dateOfBirth, teamid, position, physical, attacking, defending, Speed, image, isMain);
        }

        public bool EditSchedule(int ID,string content, string start, string end, DateTime date, int teamid)
        {

            return (new DAOSchedule()).EditSchedule(ID,content, start, end, date, teamid);
        }

        public bool CheckMain(int PlayerID)
        {
            return (new DAOPlayer()).CheckMain(PlayerID);
        }

        public bool DeletePlayer(int playerID)
        {

            return (new DAOPlayer()).DeletePlayer(playerID);
        }

        public bool DeleteSchedule(int ID)
        {

            return (new DAOSchedule()).DeleteSchedule(ID);
        }
    }
}
