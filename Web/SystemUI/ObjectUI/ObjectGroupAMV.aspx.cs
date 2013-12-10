using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Model;
using BLL;
using Utility;

public partial class SystemUI_ObjectUI_ObjectGroupAMV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindType();
            if (Request.QueryString["Type"] != null)
            {
                LoadService();
                if (Request.QueryString["Type"].ToString() == "View")
                {
                    txt_Name.ReadOnly = true;
                    ddl_Type.Enabled = false;

                    btn_Add.Visible = false;
                    btn_Modity.Visible = false;
                }
                else
                {
                    btn_Add.Visible = false;
                    btn_Modity.Visible = true;
                }
            }
            else
            {
                btn_Add.Visible = true;
                btn_Modity.Visible = false;
            }
        }
    }

    private void BindType()
    {
        DataTable dt = new CommonBLL().GetObjectType();
        ddl_Type.DataSource = dt;
        ddl_Type.DataTextField = "TypeName";
        ddl_Type.DataValueField = "TypeCode";
        ddl_Type.DataBind();
    }

    public void LoadService()
    {
        string code = Request.QueryString["Code"].ToString();
        ObjectGroup _p = new ObjectGroupBLL().GetModel(code);
        if (_p != null)
        {
            lab_Code.Text = _p.Code;
            txt_Name.Text = _p.Name;
            ddl_Type.SelectedValue = _p.TypeCode;
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {

        ObjectGroup r = new ObjectGroup();
        r.Name = txt_Name.Text.Trim();
        r.TypeCode = ddl_Type.SelectedValue.ToString();
        r.OrganID = (int)Session["OrganID"];
        r.InputBy = Session["UserID"].ToString();

        int re = new ObjectGroupBLL().Add(r);
        if (re > 0)
        {
            UtilityService.AlertAndRedirect(this, "添加成功!", "ObjectGroupMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this, "添加失败!");
        }

    }
    protected void btn_Modity_Click(object sender, EventArgs e)
    {
        ObjectGroup r = new ObjectGroup();
        r.Code = lab_Code.Text.Trim();
        r.Name = txt_Name.Text.Trim();
        r.TypeCode = ddl_Type.SelectedValue.ToString();

        bool re = new ObjectGroupBLL().Update(r);
        if (re)
        {
            UtilityService.AlertAndRedirect(this, "修改成功!", "ObjectGroupMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this, "修改失败!");
        }
    }
}
