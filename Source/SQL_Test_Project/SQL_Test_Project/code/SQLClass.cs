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
    public class SQLData
    {
        public SqlDataAdapter da;
        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlCommand cmd = new SqlCommand();

        public SQLData()
        {
            //Constructor
        }

        public void BindDataToGridView(string sqlquery, GridView gridView)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;

            con = new SqlConnection(mainconn);
            //string sqlquery = "SELECT * FROM [dbo].[ThisEvent] WHERE Upcoming=1";
            cmd.CommandText = sqlquery;
            cmd.Connection = con;
            using (cmd)
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Open();

                /*
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0).ToLower() == table.ToLower())
                    {
                        // The Table exists.
                    }
                }
                reader.Close();
                */

                if(ds.Tables.Count>0)
                {
                    cmd.ExecuteNonQuery();
                    gridView.DataSource = ds;
                    gridView.DataBind();
                }

                con.Close();
            }
        }
    }
    public static class SQLClass
    {
        public static class AddEvent
        {
            public static TextBox txtEventName;
            public static TextBox txtEventDate;
            public static TextBox txtEventLocation;
            public static TextBox txtEventInfo;
        }
        public static class AddParticipant
        {
            public static TextBox txtParticipantFirstname;
            public static TextBox txtParticipantLastname;
            public static TextBox txtParticipantIdcode;
            public static TextBox txtParticipantInfo;
        }
        public static void SQLNewTable(string tableName, int iCharCount=1500)
        {
            // SQL
            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            //IF OBJECT_ID('model.dbo.Certifications') IS NOT NULL
            string sqlquery = "IF OBJECT_ID('"+ tableName + "') IS NULL CREATE TABLE " + tableName +
                            "(ID int," +
                            "FirstName varchar(50)," +
                            "LastName varchar(50)," +
                            "PersonCount int," +
                            "Code bigint," +
                            "Payment int," +
                            "AddInfo varchar("+ iCharCount + ")" +
                            ")";

            SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
            using (cmd)
            {
                sqlconn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                sqlconn.Close();
            }
        }
        public static void SQLDeleteTable(string tableName)
        {
            // SQL
            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            //string sqlquery = "DROP TABLE "+ tableName;
            string sqlquery = "IF OBJECT_ID('"+ tableName + "') IS NOT NULL DROP TABLE "+ tableName;

            SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
            using (cmd)
            {
                sqlconn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                // check if not null
                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
        public static void DeleteDataAtID(SQLData data, string tableName, string sid)
        {
            data.cmd.CommandText = "DELETE from "+ tableName + " where eID='" + sid + "'";
            using (data.cmd)
            {
                data.con.Open();
                data.cmd.ExecuteNonQuery();
                data.con.Close();
            }
            // also check for the event name and delete the table
            //SQLDeleteTable("[dbo].[Participants_@eventName]");
        }
        public static void SQLDeleteAtID(string tableName, string idstr, int rowID)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "DELETE FROM " + tableName + " WHERE "+ idstr + " = @Id";
            using (var sqlcmd = new SqlCommand(sqlquery, sqlconn))
            {
                sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = rowID;
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
        public static void SQLUpdateParticipantTable(string tableName, int id)
        {
            // SQL
            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            // Requires the data to be stored via modal first!
            string participantName = Admin.AdminVars.Participant.curParticipantName;
            string participantLastname = Admin.AdminVars.Participant.curParticipantLastname;
            string participantIdcode = Admin.AdminVars.Participant.curParticipantCode;
            string participantInfo = Admin.AdminVars.Participant.curParticipantInfo;

            //string tableName = Admin.AdminVars.curTableName;
            // Debug
            Admin.Debug.Log(string.Format("SQLClass.SQLUpdateParticipantTable -> tableName: {0}, participantName {1}", tableName, participantName));
            string sqlquery = "UPDATE " + tableName + " SET FirstName='" + participantName + "',LastName='" + participantLastname + "',Code='" + participantIdcode + "',AddInfo='" + participantInfo + "' WHERE ID='" + id.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
            using (cmd)
            {
                cmd.Connection = sqlconn;
                cmd.CommandText = sqlquery;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                //GridView3.EditIndex = -1;
                //BindData3();
                sqlconn.Close();
            }
        }
        public static string SQLGetField(string tableName, string fieldName, string idLbl, string idStr)
        {
            string result = "?SQLGetField"; // because this is a tricky task, we leave a placeholder name for debuging purposes...

            // SQL
            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            string sqlquery = "SELECT " + fieldName + " FROM " + tableName + " Where " + idLbl + " = '" + idStr + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
            using (cmd)
            {
                sqlconn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                foreach (DataRow dr in dt.Rows)
                {
                    string[] rstr = new string[dt.Columns.Count];
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataColumn dc = dt.Columns[i];
                        rstr[i] = dr[dc.ColumnName].ToString();
                        result = rstr[0];
                    }
                }
                sqlconn.Close();
            }
            return result;
        }

        public static string[] SQLFunc(string tableName, string idLbl,string idStr)
        {
            string[] result = new string[0];

            // SQL
            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            string sqlquery = "SELECT * FROM "+tableName+"Where "+ idLbl + " = '" + idStr + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
            using (cmd)
            {
                sqlconn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmd.ExecuteNonQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    result = new string[dt.Columns.Count];
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataColumn dc = dt.Columns[i];
                        string str = dr[dc.ColumnName].ToString();
                        result[i] = str;
                    }
                }

                sqlconn.Close();
            }
            return result;
        }
        public static void SQLAddEvent()
        {
            int rowID = 1000 + (SQLCountEntrys("[dbo].[ThisEvent]") + 1);   // not the best method for ID's but its okay for now...
                                                                            // it causes an issue, where you can have the same ID for multiple instances. I will fix this later.

            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "INSERT INTO [dbo].[ThisEvent](eID, pCNT, EventName, EventDate, EventLocation, AddInfo, Upcoming )  values(@eID,@pCNT,@eventName,@eventDate,@eventLocation,@info,@upcoming)";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlconn);

            //sqlcmd.CommandText = sqlquery;
            //sqlcmd.Connection = mainconn;

            using (sqlcmd)
            {
                sqlconn.Open();
                sqlcmd.Parameters.AddWithValue("@eID", rowID);
                sqlcmd.Parameters.AddWithValue("@pCNT", 0);
                sqlcmd.Parameters.AddWithValue("@eventName", AddEvent.txtEventName.Text);
                sqlcmd.Parameters.AddWithValue("@eventDate", (AddEvent.txtEventDate.Text.Length < 1) ? DateTime.Now.ToString() : AddEvent.txtEventDate.Text);
                sqlcmd.Parameters.AddWithValue("@eventLocation", AddEvent.txtEventLocation.Text);
                sqlcmd.Parameters.AddWithValue("@info", AddEvent.txtEventInfo.Text);

                // Auto check if the event is in past...
                DateTime dt1 = AddEvent.txtEventDate.Text.Length>1 ? DateTime.Parse(AddEvent.txtEventDate.Text) : DateTime.Now;
                DateTime dt2 = DateTime.Now;
                int upcoming = (dt1.Date >= dt2.Date) ? 1 : 0;

                sqlcmd.Parameters.AddWithValue("@upcoming", upcoming);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }

            // add a participant table to it
            SQLNewTable("[dbo].[Participants_"+AddEvent.txtEventName.Text+"]");
        }

        public static void SQLAddParticipantToEvent(string tableName)
        {
            //string tableName = "[dbo].[Participants_@eventName]";

            int rowID = (SQLCountEntrys(tableName) + 1);   // not the best method for ID's but its okay for now...
                                                                              // it causes an issue, where you can have the same ID for multiple instances. I will fix this later.

            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "INSERT INTO "+ tableName + "(ID, FirstName, LastName, PersonCount, Code, Payment, AddInfo )  values(@ID,@firstName,@lastName,@personCount,@code,@payment,@info)";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlconn);

            //sqlcmd.CommandText = sqlquery;
            //sqlcmd.Connection = mainconn;

            using (sqlcmd)
            {
                sqlconn.Open();
                sqlcmd.Parameters.AddWithValue("@ID", rowID);
                sqlcmd.Parameters.AddWithValue("@firstName", AddParticipant.txtParticipantFirstname.Text);
                sqlcmd.Parameters.AddWithValue("@lastName", AddParticipant.txtParticipantLastname.Text);
                sqlcmd.Parameters.AddWithValue("@personCount", 0);
                sqlcmd.Parameters.AddWithValue("@code", AddParticipant.txtParticipantIdcode.Text);
                sqlcmd.Parameters.AddWithValue("@payment", 0);
                sqlcmd.Parameters.AddWithValue("@info", AddParticipant.txtParticipantInfo.Text);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        // Prototype
        public static void SQLAddParticipant()
        {
            int rowID = 1000 + (SQLCountEntrys("[dbo].[Participant]") + 1);   // not the best method for ID's but its okay for now...
                                                                            // it causes an issue, where you can have the same ID for multiple instances. I will fix this later.

            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "INSERT INTO [dbo].[Participant](pID, eID, FirstName, LastName, Code, Payment, AddInfo )  values(@pID,@eID,@firstName,@lastName,@code,@payment,@info)";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlconn);

            //sqlcmd.CommandText = sqlquery;
            //sqlcmd.Connection = mainconn;

            using (sqlcmd)
            {
                sqlconn.Open();
                sqlcmd.Parameters.AddWithValue("@pID", rowID);
                sqlcmd.Parameters.AddWithValue("@eID", 0);
                sqlcmd.Parameters.AddWithValue("@firstName", AddParticipant.txtParticipantFirstname.Text);
                sqlcmd.Parameters.AddWithValue("@lastName", AddParticipant.txtParticipantLastname.Text);
                sqlcmd.Parameters.AddWithValue("@code", AddParticipant.txtParticipantIdcode.Text);
                sqlcmd.Parameters.AddWithValue("@payment", 0);
                sqlcmd.Parameters.AddWithValue("@info", AddParticipant.txtParticipantInfo.Text);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
        public static int SQLCountEntrys(string tableName)
        {
            int result = -1;

            string mainconn = ConfigurationManager.ConnectionStrings["ThisConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "SELECT COUNT(*) AS counter FROM "+tableName;
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlconn);

            using (sqlcmd)
            {
                sqlconn.Open();
                result = Convert.ToInt32(sqlcmd.ExecuteScalar());
                sqlconn.Close();
            }

            return result;
        }
    }
}