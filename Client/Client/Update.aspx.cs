using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Update1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 01; i <= 12; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
                for (int i = 00; i < 60; i++)
                {
                    DropDownList2.Items.Add(i.ToString());
                }
                DropDownList3.Items.Add("Birthday");
                DropDownList3.Items.Add("Tour");
                DropDownList3.Items.Add("Seminar");
                DropDownList3.Items.Add("Meeting");
            }
            //Label2.Text = DateTime.Parse(Session["date"].ToString()).Date.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userid = Session["userid"].ToString();
            // DateTime date = DateTime.Parse(Session["date"].ToString());
            DateTime date = Calendar1.SelectedDate;
            date = date.Date;
            string eventId = Session["eventid"].ToString();
            string time = DropDownList1.SelectedValue.ToString() + ":" + DropDownList2.SelectedValue.ToString();
            string eventType = DropDownList3.SelectedValue.ToString();
            string desciption = TextBox1.Text;
            Console.WriteLine(userid + eventId + time + eventType + desciption);
            ReminderReference.ReminderClient client = new ReminderReference.ReminderClient("BasicHttpBinding_IReminder");
            string output = client.updateReminder(userid,date,time,eventType,desciption,eventId);
            Label1.Text = output;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}