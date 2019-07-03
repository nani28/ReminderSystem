using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReminderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IReminder
    {
        [OperationContract]
        List<ReminderDetail> getAllReminders(string UserId);

        [OperationContract]
        string insertReminder(string UserId, DateTime date, string time, string eventType, string description);

        [OperationContract]
        string updateReminder(string UserId, DateTime date, string time, string eventType, string description, string eventId);

        [OperationContract]
        string deleteReminder(string UserId, string eventId);

        [OperationContract]
        Boolean authenticate(string userid, string password);

        [OperationContract]
        string registerUser(string userid, string password,string email);



    }
    [DataContract]
    public class ReminderDetail
    {
        string userId;
        DateTime date;
        string time;
        string eventType;
        string description;
        string eventId;
        

        [DataMember]
        public string EventId
        {
            get { return eventId; }
            set { eventId = value; }
        }
        [DataMember]
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        [DataMember]
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        [DataMember]
        public string EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}