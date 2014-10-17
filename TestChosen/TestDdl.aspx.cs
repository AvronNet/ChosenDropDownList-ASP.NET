using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestDdl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<ListItem> data = new List<ListItem>();
            data.Add(new ListItem());
            data.Add(new ListItem { Text = "opcija 1", Value = "1" });
            data.Add(new ListItem { Text = "opcija 2", Value = "2" });
            data.Add(new ListItem { Text = "opcija 3", Value = "3" });
            data.Add(new ListItem { Text = "opcija 4", Value = "4" });
            data.Add(new ListItem { Text = "opcija 5", Value = "5" });
            ddlTest.DataSource = data;
            ddlTest.DataTextField = "Text";
            ddlTest.DataValueField = "Value";
            ddlTest.DataBind();


            List<ListItem> dataCopy = data.ToList();
            cddl.DataSource = dataCopy;
            cddl.DataTextField = "Text";
            cddl.DataValueField = "Value";
            cddl.DataBind();
        }
    }

    protected void cddlTest_DataBinding(object sender, EventArgs e)
    {

    }
    protected void btnAction_Click(object sender, EventArgs e)
    {

    }
}