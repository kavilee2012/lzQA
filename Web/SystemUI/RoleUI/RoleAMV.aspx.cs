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
using BLL;
using Utility;

public partial class SystemUI_RoleUI_RoleAMV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Type"] != null)
            {
                LoadService();
                if (Request.QueryString["Type"].ToString() == "View")
                {
                    txt_Name.ReadOnly = true;

                    btn_Add.Visible = false;
                    btn_Modity.Visible = false;
                }
                else
                {
                    if (txt_Name.Text.Trim() == "系统管理员" || txt_Name.Text.Trim() == "超级管理员" || hind_OrganID.Value=="0")
                    {
                        btn_Modity.Enabled = false;
                    }
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

    public void LoadService()
    {
        string code = Request.QueryString["Code"].ToString();
        Model.Role _p = new RoleBLL().GetModel(code);
        if (_p != null)
        {
            lab_Code.Text = _p.RoleCode;
            txt_Name.Text = _p.RoleName;
            hind_OrganID.Value = _p.OrganID.ToString();
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        if (txt_Name.Text.Trim() == "系统管理员" || txt_Name.Text.Trim() == "超级管理员")
        {
            UtilityService.Alert(this.Page, "该名称是非法名，请换一个角色名称！");
            return;
        }

        Model.Role r = new Model.Role();
        r.RoleName = txt_Name.Text.Trim();
        r.OrganID = (int)Session["OrganID"];
        r.InputBy = Session["UserID"].ToString();

        int re = new RoleBLL().Add(r);
        if (re > 0)
        {
            UtilityService.AlertAndRedirect(this, "添加成功!", "RoleMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this, "添加失败!");
        }

    }
    protected void btn_Modity_Click(object sender, EventArgs e)
    {
        if (txt_Name.Text.Trim() == "系统管理员" || txt_Name.Text.Trim() == "超级管理员")
        {
            UtilityService.Alert(this.Page, "该名称是非法名，请换一个角色名称！");
            return;
        }

        Model.Role r = new Model.Role();
        r.RoleCode = lab_Code.Text;
        r.RoleName = txt_Name.Text.Trim();

        bool re = new RoleBLL().Update(r);
        if (re)
        {
            UtilityService.AlertAndRedirect(this, "修改成功!", "RoleMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this, "修改失败!");
        }
    }
}
