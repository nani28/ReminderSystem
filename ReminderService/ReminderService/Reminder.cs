using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace ReminderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Reminder : IReminder
    {
      
        public List<ReminderDetail> getAllReminders(string UserId)
        {
            List<ReminderDetail> rDetail = new List<ReminderDetail>();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QC12O4I\SQLEXPRESS;Initial Catalog=ReminderData;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText="select userId,date,time,eventType,description,eventid from ReminderTable where userId=@userid";
            cmd.Parameters.AddWithValue("@userId",UserId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            ReminderDetail temp;
            while (rdr.Read())
            {
                temp = new ReminderDetail();
                temp.UserId = rdr.GetString(0);
                temp.Date = rdr.GetDateTime(1);
                temp.Time = rdr.GetString(2);
                temp.EventType = rdr.GetString(3);
                temp.Description = rdr.GetString(4);
                temp.EventId = rdr.GetString(5);
                rDetail.Add(temp);
            }
            con.Close();
            return rDetail;
        }
        public string insertReminder(string UserId, DateTime date,string time,string eventType, string description)
        {
     
            long ticks = DateTime.Now.Ticks;
            byte[] bytes = BitConverter.GetBytes(ticks);
            string EventId = Convert.ToBase64String(bytes)
                                    .Replace('+', '_')
                                    .Replace('/', '-')
                                    .TrimEnd('=');
            date = date.Date;
            string insertString ="INSERT INTO ReminderTable(userId,date,time,eventType,description,eventid) VALUES (@UserId,@date,@time,@eventType,@description,@eventid)";
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QC12O4I\SQLEXPRESS;Initial Catalog=ReminderData;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand(insertString,con);
            cmd.Parameters.AddWithValue("@Userid",UserId);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@eventType", eventType);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@eventid", EventId);
            int added = 0;
                con.Open();
                added = cmd.ExecuteNonQuery();
                con.Close();
            if (added != 0)
            {
                return "Reminder set successfully !";
            }
            else
            {
                return "So Sorry Please Try Again";
            }
            
        }
        public string updateReminder(string UserId, DateTime date, string time, string eventType, string description, string eventId)
        {

            date = date.Date;
            string updateString = "UPDATE ReminderTable Set date=@date,time=@time,eventType=@eventType,description=@description WHERE userId=@userId and eventid=@eventId";
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QC12O4I\SQLEXPRESS;Initial Catalog=ReminderData;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand(updateString, con);
            cmd.Parameters.AddWithValue("@userId", UserId);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@eventType", eventType);
            cmd.Parameters.AddWithValue("@description", description);
            
            cmd.Parameters.AddWithValue("@eventId", eventId);
            int updated = 0;
            con.Open();
            updated = cmd.ExecuteNonQuery();
            con.Close();
            if (updated != 0)
            {
                return "Reminder Updated Successfully";
            }
            else
            {
                return "So Sorry Please Try Again";
            }

        }
        public string deleteReminder(string UserId,string eventId)
        {
            
            string deleteString = "DELETE FROM ReminderTable WHERE userId=@userId and eventid=@eventId";
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QC12O4I\SQLEXPRESS;Initial Catalog=ReminderData;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand(deleteString, con);
            cmd.Parameters.AddWithValue("@Userid", UserId);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            int deleted = 0;
            con.Open();
            deleted = cmd.ExecuteNonQuery();
            if (deleted != 0)
            {
                return "Reminder Deleted Successfully !";

            }
            else
            {
                return "So Sorry Please Try Again";
            }
        }

        public bool authenticate(string userid, string password)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QC12O4I\SQLEXPRESS;Initial Catalog=ReminderData;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from UserData where userid=@userid and password=@password";
            cmd.Parameters.AddWithValue("@userid",userid);
            cmd.Parameters.AddWithValue("@password",password);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            
            if (rdr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string registerUser(string userid, string password, string email)
        {
            string insertString = "INSERT INTO UserData(userid,password,email) VALUES (@userid,@password,@email)";
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QC12O4I\SQLEXPRESS;Initial Catalog=ReminderData;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand(insertString, con);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("email",email);
            int added = 0;
            con.Open();
            added = cmd.ExecuteNonQuery();
            con.Close();
            if (added != 0)
            {
                return "Register successfully !";
            }
            else
            {
                return "Registration Failure";
            }
        }
    }
}
