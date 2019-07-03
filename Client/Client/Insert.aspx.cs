using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 01; i <= 12; i++)
                {
                    DropDownList3.Items.Add(i.ToString());
                }
                for (int i = 00; i < 60; i++)
                {
                    DropDownList2.Items.Add(i.ToString());
                }
                DropDownList4.Items.Add("Birthday");
                DropDownList4.Items.Add("Tour");
                DropDownList4.Items.Add("Seminar");
                DropDownList4.Items.Add("Meeting");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            DateTime date = Calendar1.SelectedDate;
            string time = DropDownList2.SelectedValue.ToString() + ":" + DropDownList3.SelectedValue.ToString()+":00";
            string eventType = DropDownList4.SelectedValue.ToString();
            string description = TextBox1.Text;
            string userId = Session["userid"].ToString();
            date = date.Date;
            ReminderReference.ReminderClient client = new ReminderReference.ReminderClient("BasicHttpBinding_IReminder");
            string output = client.insertReminder(userId,date,time,eventType,description);
            Label1.Text = output;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}