using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Model;
using BLL;

public partial class SystemUI_OrganUI_OrganView : System.Web.UI.Page
{
    OrganBLL organBLL = new OrganBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindSuperior();
            string id = Request.QueryString["OrganID"].ToString();
            Organ organ = organBLL.GetModel(int.Parse(id));
            if (organ != null)
            {
                txt_ID.Text = organ.OrganID.ToString();
                txt_Name.Text = organ.OrganName;
                txt_Remark.Text = organ.Remark;
                ddl_Level.SelectedValue = organ.Level.ToString();
                ddl_Superior.SelectedValue = organ.Superior.ToString();
            }

            txt_ID.ReadOnly = true;
            txt_Name.ReadOnly = true;
            txt_Remark.ReadOnly = true;
            ddl_Level.Enabled = false;
            ddl_Superior.Enabled = false;
        }
    }

    private void BindSuperior()
    {
        DataSet ds = organBLL.GetAllList();
        ddl_Superior.DataSource = ds.Tables[0];
        ddl_Superior.DataTextField = "OrganName";
        ddl_Superior.DataValueField = "OrganID";
        ddl_Superior.DataBind();
    }
}
