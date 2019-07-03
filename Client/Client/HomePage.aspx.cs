using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReminderReference.ReminderClient client = new ReminderReference.ReminderClient("BasicHttpBinding_IReminder");
            List<ReminderReference.ReminderDetail> data = client.getAllReminders(TextBox1.Text).ToList();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["userid"] = TextBox1.Text;
            Session["date"] = GridView1.SelectedRow.Cells[1].Text;
            Session["time"] = GridView1.SelectedRow.Cells[5].Text;
            Session["eventtype"] = GridView1.SelectedRow.Cells[4].Text;
            Session["description"] = GridView1.SelectedRow.Cells[2].Text;
            Session["eventid"] = GridView1.SelectedRow.Cells[3].Text;
           // Label2.Text = Session["eventid"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["userid"] = TextBox1.Text;
            Response.Redirect("Insert.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["userid"] = TextBox1.Text;
            Session["date"] = GridView1.SelectedRow.Cells[1].Text;
            Session["time"] = GridView1.SelectedRow.Cells[5].Text;
            Session["eventtype"] = GridView1.SelectedRow.Cells[4].Text;
            Session["description"] = GridView1.SelectedRow.Cells[2].Text;
            Session["eventid"] = GridView1.SelectedRow.Cells[3].Text;

            Response.Redirect("Update.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string userId = TextBox1.Text;
            string eventId = GridView1.SelectedRow.Cells[3].Text;
            ReminderReference.ReminderClient client = new ReminderReference.ReminderClient("BasicHttpBinding_IReminder");
            string output = client.deleteReminder(userId,eventId);
            
            List<ReminderReference.ReminderDetail> data = client.getAllReminders(TextBox1.Text).ToList();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
}