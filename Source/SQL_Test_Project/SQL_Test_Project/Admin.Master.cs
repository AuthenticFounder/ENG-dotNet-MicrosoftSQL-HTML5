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

namespace SQL_Test_Project
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public static class AdminVars
        {
            public static int curDeleteID;
            public static int curEventID;
            public static int curParticipantID;
            public static string curDeleteName;
            public static string curTableName;
            public static bool confirmDelete;

            public static bool userMode;
            public static bool debugMode;

            public static class Participant
            {
                public static int ID;
                public static string curParticipantName;
                public static string curParticipantLastname;
                public static string curParticipantCode;
                public static string curParticipantInfo;
            }
        }

        public static class Debug
        {
            public static bool isEnabled = false;        // mõistlik...
            public static string debugString;

            public static void Log(string input)
            {
                debugString = isEnabled ? "Debug: " + input : "";
                //debugString = "Debug: " + input;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UpdateParticipantModal();
            }
            // Temporary debug solution (prints on a field @ the page)
            myDataID.Text = Debug.debugString;
        }
        public void UpdateParticipantModal()
        {
            txtParticipantNameModal.Text = AdminVars.Participant.curParticipantName;
            txtParticipantLastnameModal.Text = AdminVars.Participant.curParticipantLastname;
            txtParticipantIDCODEModal.Text = AdminVars.Participant.curParticipantCode;
            txtParticipantInfoModal.Text = AdminVars.Participant.curParticipantInfo;
        }
        public void StoreParticipantInfo()
        {
            AdminVars.Participant.curParticipantName = txtParticipantNameModal.Text;
            AdminVars.Participant.curParticipantLastname = txtParticipantLastnameModal.Text;
            AdminVars.Participant.curParticipantCode = txtParticipantIDCODEModal.Text;
            AdminVars.Participant.curParticipantInfo = txtParticipantInfoModal.Text;
        }
        protected void UpdateEventParticipantsTable()
        {
            //int id = AdminVars.curParticipantID; // this is causing the modal to break in one way or the other...
            int id = AdminVars.Participant.ID; // this is causing the modal to break in one way or the other...

            StoreParticipantInfo();
            SQLClass.SQLUpdateParticipantTable(AdminVars.curTableName, id);

            //Debug.Log(string.Format("UpdateEventParticipantsTable -> AdminVars.Participant.ID: {0} AdminVars.Participant.curParticipantName: {1}", id, AdminVars.Participant.curParticipantName));
        }
        protected void RemoveFromDatabase()
        {
            int id = AdminVars.curDeleteID;

            // This is not a ideal solution, but works for now...
            if (!AdminVars.userMode)
            {
                string result = SQLClass.SQLGetField("[dbo].[ThisEvent]", "EventName", "eID", id.ToString());
                SQLClass.SQLDeleteTable("[dbo].[Participants_" + result + "]");
                AdminVars.curDeleteName = result;
                // Debug delete procedure...
                Debug.Log(string.Format("Admin.RemoveFromDatabase()(Event) -> AdminVars.curDeleteName: {0}, AdminVars.curDeleteID: {1}", AdminVars.curDeleteName, AdminVars.curDeleteID));
                SQLClass.SQLDeleteAtID("[dbo].[ThisEvent]", "eID", id);
            }
            else
            {
                int eid = AdminVars.curEventID;
                string result = "[dbo].[Participants_" + SQLClass.SQLGetField("[dbo].[ThisEvent]", "EventName", "eID", eid.ToString())+"]";
                AdminVars.curTableName = result;
                // Debug delete procedure...
                Debug.Log(string.Format("Admin.RemoveFromDatabase()(User) -> AdminVars.curDeleteName: {0}, AdminVars.curDeleteID: {1}, AdminVars.curTableName: {2}", AdminVars.curDeleteName, AdminVars.curDeleteID,AdminVars.curTableName));
                SQLClass.SQLDeleteAtID(result, "ID", id);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEventParticipantsTable();
            // reload the page
            Response.Redirect(Request.Path);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // This is the Delete Modal confirmation

            /*
            Button btn = (Button)sender;
            // Should we use a switch?
            switch (btn.CommandName)
            {
                case "RemoveEvent":
                    // EVENTS 
                    //RemoveEventAndItsTable()
                    break;
                case "RemoveUser":
                    // USERS
                    //RemoveUser();
                    break;
            }
            */

            RemoveFromDatabase();

            // reload the page
            Response.Redirect(Request.Path);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Path);
        }
    }
}