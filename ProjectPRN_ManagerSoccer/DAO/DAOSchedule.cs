using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO
{
    public class DAOSchedule
    {

        public DataTable loadSchedule(int TeamID)
        {
            string str = "select * from Schedule WHERE TeamID =" + TeamID;
            return (new DataProvider()).executeQuery(str);
        }

        public DataTable loadDataSchedule(int ScheduleID)
        {
            string str = "select * from Schedule WHERE ScheduleID =" + ScheduleID;
            return (new DataProvider()).executeQuery(str);
        }

        public bool AddSchedule(string content, string start, string end, DateTime date, int teamid)
        {
            string str = "insert into [Schedule] values('" + content + "','" + start + "','" + end + "',@date," + teamid + ")";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parameter[0].Value = date;
            return (new DBContext()).ExecuteSqlWithParameters(str, parameter);
        }

        public bool EditSchedule(int id, string content, string start, string end, DateTime date, int teamid)
        {
            string str = "UPDATE [dbo].[Schedule] SET[Content] = '" + content + "',[TimeStart] ='" + start + "',[TimeEnd] ='" + end + "',[Date]='" + date + "',[TeamID]=" + teamid + "WHERE ScheduleID =" + id;
            return (new DataProvider()).executeNonQuery(str);

        }
        public bool DeleteSchedule(int id)
        {
            string sql = "delete from Schedule where ScheduleID = " + id;
            return (new DataProvider()).executeNonQuery(sql);
        }
    }
}
