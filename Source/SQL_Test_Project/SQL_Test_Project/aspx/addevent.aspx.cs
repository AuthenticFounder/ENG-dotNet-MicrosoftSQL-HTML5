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
    public partial class addevent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }
        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            // Store vars so that SQLClass knows what to do
            SQLClass.AddEvent.txtEventName = txtEventName;
            SQLClass.AddEvent.txtEventDate = txtEventDate;
            SQLClass.AddEvent.txtEventLocation = txtEventLocation;
            SQLClass.AddEvent.txtEventInfo = txtEventInfo;

            SQLClass.SQLAddEvent();
        }
    }
}