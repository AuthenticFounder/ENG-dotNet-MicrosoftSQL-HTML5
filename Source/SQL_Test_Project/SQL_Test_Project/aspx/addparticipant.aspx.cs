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

namespace SQL_Test_Project.participants
{
    public partial class addparticipant : System.Web.UI.Page
    {
        SQLData SQLData3 = new SQLData();

        string curDeleteID;
        string curParticipantID;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Modal hack ... this should be solved!
            if (Admin.AdminVars.curParticipantID > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "ShowPopup()", true);
            }

            if (!Page.IsPostBack)
            {
                LoadSQLInfo();

                BindData3();

                // Since this causes some issues with the modal, we have to use a secondary ID for user modal updates. Confusing, I know.
                // it is stored in LoadSQLInfoEventParticipants() method as Admin.AdminVars.Participant.ID and used in the modal for information updates.
                Admin.AdminVars.curParticipantID = 0;
            }
        }

        protected void LoadSQLInfo()
        {
            int inputEventID = Admin.AdminVars.curEventID;
            string inputEventIDstr = inputEventID.ToString();

            string[] str = SQLClass.SQLFunc("[dbo].[ThisEvent]","eID", inputEventIDstr);
            //string eventParticipantCount = str.Length >0 ? str[1] : "";
            string eventName = str.Length >0 ? str[2] : "";
            string eventDate = str.Length > 0 ? str[3] : "";
            string eventLocation = str.Length > 0 ? str[4] : "";
            //string eventInfo = str.Length >0 ? str[5] : "";
            //string eventUpcoming = str.Length >0 ? str[6] : "";

            lblEventName.Text = eventName;
            lblEventDate.Text = eventDate;
            lblEventLocation.Text = eventLocation;
            //lblEventInfo.Text = eventInfo;
            //lblEventUpcoming.Text = eventUpcoming;
        }
        // Old model.
        protected void LoadSQLInfoParticipant()
        {
            int inputParticipantID = Admin.AdminVars.curParticipantID;
            string inputParticipantIDstr = inputParticipantID.ToString();

            string[] str = SQLClass.SQLFunc("[dbo].[Participant]","pID", inputParticipantIDstr);
            //string participantEvent = str[1];
            string participantFName = str[2];
            string participantLName = str[3];
            string participantIdcode = str[4];
            //string participantPayment = str[5];
            string participantInfo = str[6];

            Admin.AdminVars.Participant.curParticipantName = participantFName;
            Admin.AdminVars.Participant.curParticipantLastname = participantLName;
            Admin.AdminVars.Participant.curParticipantCode = participantIdcode;
            Admin.AdminVars.Participant.curParticipantInfo = participantInfo;
        }
        protected void LoadSQLInfoEventParticipants(string tableName)
        {
            int inputParticipantID = Admin.AdminVars.curParticipantID;
            string inputParticipantIDstr = inputParticipantID.ToString();

            string[] str = SQLClass.SQLFunc(tableName, "ID", inputParticipantIDstr);
            string participantFName = str[1];
            string participantLName = str[2];
            string participantCount = str[3];
            string participantIdcode = str[4];
            //string participantPayment = str[5];
            string participantInfo = str[6];

            Admin.AdminVars.Participant.ID = inputParticipantID;
            Admin.AdminVars.Participant.curParticipantName = participantFName;
            Admin.AdminVars.Participant.curParticipantLastname = participantLName;
            Admin.AdminVars.Participant.curParticipantCode = participantIdcode;
            Admin.AdminVars.Participant.curParticipantInfo = participantInfo;

        }

        /// <summary>
        /// GRIDVIEW 3 (Participants)
        /// </summary>
        public void BindData3()
        {
            //string sqlquery = "SELECT * FROM [dbo].[Participant]"; //  WHERE Upcoming=0
            //string sqlquery = "SELECT * FROM [dbo].[Participant]  WHERE eID="+Admin.AdminVars.curEventID; //

            int id = Admin.AdminVars.curEventID;

            string result = SQLClass.SQLGetField("[dbo].[ThisEvent]", "EventName", "eID", id.ToString());

            string tableName = "[dbo].[Participants_" + result + "]";
            //string sqlquery = "SELECT * FROM "+ tableName;
            string sqlquery = "IF OBJECT_ID('"+ tableName + "') IS NOT NULL SELECT * FROM " + tableName;

            SQLData3.BindDataToGridView(sqlquery, GridView3);
        }

        // This is not used, because we use a modal to update the data.
        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SQLData3.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString);
            SQLData3.cmd.Connection = SQLData3.con;

            Label curLabelDeleteID = (Label)GridView3.Rows[e.RowIndex].FindControl("lblpid");
            curDeleteID = curLabelDeleteID.Text;

            // Transfer temporary data to Admin.AdminVars class
            Admin.AdminVars.curDeleteID = int.Parse(curDeleteID);
            Admin.AdminVars.userMode = true;

            // do something then call modal
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#deleteModal').modal('toggle');</script>");
        }
        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            BindData3();
        }
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SQLData3.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString);
            SQLData3.cmd.Connection = SQLData3.con;

            if (e.CommandName == "cmdViewParticipant")
            {
                LinkButton lb = (LinkButton)e.CommandSource;
                GridViewRow gr = (GridViewRow)lb.NamingContainer;
                int rowIndex = gr.RowIndex;
                Label curLabelID = (Label)GridView3.Rows[rowIndex].FindControl("lblpid");
                curParticipantID = curLabelID.Text;

                // Transfer temporary data to Admin.AdminVars class
                Admin.AdminVars.curParticipantID = int.Parse(curParticipantID);
                //Admin.AdminVars.Participant.curParticipantName = curParticipantID;

                int eid = Admin.AdminVars.curEventID;

                string result = SQLClass.SQLGetField("[dbo].[ThisEvent]", "EventName", "eID", eid.ToString());

                string tableName = "[dbo].[Participants_" + result + "]";

                Admin.AdminVars.curTableName = tableName;   // Required for the modal to finish the task!

                Admin.Debug.Log(string.Format("Admin.GridView3_RowCommand()(cmdViewParticipant) -> Admin.AdminVars.curEventID: {0}, Admin.AdminVars.curTableName: {1}, curParticipantID: {2}", eid, tableName, curParticipantID));

                LoadSQLInfoEventParticipants(tableName);   // print the info to the modal

                Response.Redirect(Request.Path);
            }
        }
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            SQLData3.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString);
            SQLData3.cmd.Connection = SQLData3.con;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // TODO
            }
        }        
        protected void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            // TODO
        }
        protected void btnAddParticipant_Click(object sender, EventArgs e)
        {            
            // Store vars so that SQLClass knows what to do
            SQLClass.AddParticipant.txtParticipantFirstname = txtParticipantFirstName;
            SQLClass.AddParticipant.txtParticipantLastname = txtParticipantLastName;
            SQLClass.AddParticipant.txtParticipantIdcode = txtParticipantIdcode;
            SQLClass.AddParticipant.txtParticipantInfo = txtParticipantInfo;

            int eid = Admin.AdminVars.curEventID;

            string result = SQLClass.SQLGetField("[dbo].[ThisEvent]", "EventName", "eID", eid.ToString());

            string tableName = "[dbo].[Participants_" + result + "]";

            SQLClass.SQLNewTable(tableName); // maybe the table does not exist?
            SQLClass.SQLAddParticipantToEvent(tableName);

            // Refresh the table
            BindData3();
        }
    }
}