using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace SQL_Test_Project.aspx
{
    public partial class dashboard : System.Web.UI.Page
    {
        SQLData SQLData1 = new SQLData();
        SQLData SQLData2 = new SQLData();

        string curDeleteID;
        string curEventID;

        [System.Web.UI.Themeable(false)]
        public virtual string DefaultButton { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                BindData2();

                AdminUpdate(); 
            }
        }
        public void AdminUpdate()
        {
            // Not used, but might be usefull at some point...
            if (Admin.AdminVars.confirmDelete)
            {
                // Add code...
                Admin.AdminVars.confirmDelete = false;
            }
            // Reset some values...
            Admin.AdminVars.curEventID = 0;
            Admin.AdminVars.curParticipantID = 0;
            Admin.AdminVars.userMode = false;
        }

        /// <summary>
        /// GRIDVIEW 1 (New Events)
        /// </summary>
        public void BindData()
        {
            //string sqlquery = "SELECT * FROM [dbo].[ThisEvent]"; // Maybe you made some changes to the past events, use this line for quick fixes.
            string sqlquery = "SELECT * FROM [dbo].[ThisEvent] WHERE Upcoming=1";
            SQLData1.BindDataToGridView(sqlquery, GridView1);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SQLData1.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString);
            SQLData1.cmd.Connection = SQLData1.con;

            Label curLabelDeleteID = (Label)GridView1.Rows[e.RowIndex].FindControl("lbleid");
            curDeleteID = curLabelDeleteID.Text;

            // Transfer temporary data to Admin.AdminVars class
            Admin.AdminVars.curDeleteID = int.Parse(curDeleteID);

            // do something then call modal
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#deleteModal').modal('toggle');</script>");
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SQLData1.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString);
            Label lbleid = (Label)GridView1.Rows[e.RowIndex].FindControl("lbleid");
            TextBox txtpcnt = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtpcnt");
            TextBox txteventname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txteventname");
            TextBox txteventdate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txteventdate");
            TextBox txteventlocation = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txteventlocation");
            //TextBox txtaddinfo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaddinfo");
            //Label lblupcoming = (Label)GridView1.Rows[e.RowIndex].FindControl("lblupcoming");
            string sqlquery = "UPDATE [dbo].[ThisEvent] SET pCNT='" + txtpcnt.Text + "',EventName='" + txteventname.Text + "',EventDate='" + txteventdate.Text + "',EventLocation='" + txteventlocation.Text + "' WHERE eID='" + lbleid.Text + "'";
            using (SQLData1.cmd)
            {
                SQLData1.cmd.Connection = SQLData1.con;
                SQLData1.cmd.CommandText = sqlquery;
                SQLData1.cmd.Connection.Open();
                SQLData1.cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                BindData();
                SQLData1.con.Close();
            }
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdAddParticipant")
            {
                //e.CommandSource();
                LinkButton lb = (LinkButton)e.CommandSource;
                GridViewRow gr = (GridViewRow) lb.NamingContainer;
                int rowIndex = gr.RowIndex;
                Label curLabelID = (Label)GridView1.Rows[rowIndex].FindControl("lbleid");
                curEventID = curLabelID.Text;

                // Transfer temporary data to Admin.AdminVars class
                Admin.AdminVars.curEventID = int.Parse(curEventID);

                Response.Redirect("addparticipant.aspx");
            }
            else if (e.CommandName == "cmdRemoveEvent")
            {
                // optional (maybe we can specify a special case entry deletion here at some point?)
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SQLData1.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString);
            SQLData1.cmd.Connection = SQLData1.con;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Sice we added a Return key fix/hack, we had to hide the extra button somehow... (done on html side by seting the size to 0px!)
                //ImageButton test = (ImageButton)e.Row.FindControl("ImageButtonSubmit");
                //test.Visible = false;
            }
        }

        /// <summary>
        /// GRIDVIEW 2 (Past Events)
        /// </summary>
        public void BindData2()
        {
            string sqlquery = "SELECT * FROM [dbo].[ThisEvent] WHERE Upcoming=0";
            SQLData2.BindDataToGridView(sqlquery, GridView2);
        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindData2();
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SQLData2.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString);
            SQLData2.cmd.Connection = SQLData2.con;

            if (e.CommandName == "cmdAddParticipant")
            {
                //e.CommandSource();
                LinkButton lb = (LinkButton)e.CommandSource;
                GridViewRow gr = (GridViewRow)lb.NamingContainer;
                int rowIndex = gr.RowIndex;
                Label curLabelID = (Label)GridView2.Rows[rowIndex].FindControl("lbleid");
                curEventID = curLabelID.Text;

                // Transfer temporary data to Admin.AdminVars class
                Admin.AdminVars.curEventID = int.Parse(curEventID);
                Admin.AdminVars.userMode = false;   // This is not a ideal solution, but due to time concerns I am taking the risk. Afterall this is a bug fix / hack for now!
                                                    // The variable is enabled on addparticipant.aspx.cs with 'GridView3_RowDeleting' method

                Response.Redirect("addparticipant.aspx");
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SQLData2.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString);
            SQLData2.cmd.Connection = SQLData2.con;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // TODO
            }
        }
        protected void Submit_Click1(object sender, EventArgs e)
        {
            // TODO
        }
        protected void Reset_Click1(object sender, EventArgs e)
        {
            // TODO
        }
        protected void btnOsavotjad_Click(object sender, EventArgs e)
        {
            //Response.Redirect("addparticipant.aspx");
        }
        protected void btnRemove_Click(object sender, GridViewCommandEventArgs e)
        {
            // reload the page
            Response.Redirect(Request.Path);
        }
        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("addevent.aspx");
        }
    }
}