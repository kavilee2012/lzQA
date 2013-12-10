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
using BLL;
using Model;
using Utility;

public partial class SystemUI_OrganUI_OrganModity : System.Web.UI.Page
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Organ organ = new Organ();
        organ.OrganID = int.Parse(txt_ID.Text.Trim());
        organ.OrganName = txt_Name.Text.Trim();
        organ.Remark = txt_Remark.Text.Trim();
        organ.Superior = Convert.ToInt32(ddl_Superior.SelectedValue);
        organ.Level = Convert.ToInt32(ddl_Level.SelectedValue);
        bool re = organBLL.Update(organ);
        if (re)
        {
            UtilityService.Alert(this.Page, "修改成功!");
            Response.Redirect("OrganMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this.Page, "修改失败!");
        }
;    }
}
