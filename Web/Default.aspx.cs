using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lab_OrganID.Text = new OrganBLL().GetModel((int)Session["OrganID"]).OrganName;
            lab_UserName.Text = Session["UserName"].ToString();
            lab_Time.Text = DateTime.Today.Year + "年" + DateTime.Today.Month + "月" + DateTime.Today.Day + "日";
        }

    }
    protected void btn_Exit_Click(object sender, EventArgs e)
    {
        Session["OrganID"] = null;
        Session["UserID"] = null;
        Session["UserName"] = null;
        Session["FcList"] = null;
        Response.Redirect("Login.aspx");
    }
}
