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
using System.Collections.Generic;

public partial class SystemUI_UserUI_PositionAMV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindPositionDLL();

            if (Request.QueryString["Type"] != null)
            {
                LoadService();
                if (Request.QueryString["Type"].ToString() == "View")
                {
                    //lab_Code.ReadOnly = true;
                    txt_Name.ReadOnly = true;
                    ddl_Father.Enabled = false;

                    btn_Add.Visible = false;
                    btn_Modity.Visible = false;
                }
                else
                {
                    if (txt_Name.Text.Trim() == "系统管理员")
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

    private void BindPositionDLL()
    {
        string strWhere = " OrganID = " + Session["OrganID"].ToString();
        IList<Position> dt = new PositionBLL().GetModelList(strWhere);

        Position p = new Position();
        p.PosiCode = "0";
        p.PosiName = "无";
        if (dt != null)
        {
            dt.Add(p);
        }

        ddl_Father.DataSource = dt;
        ddl_Father.DataValueField = "PosiCode";
        ddl_Father.DataTextField = "PosiName";
        ddl_Father.DataBind();

        ddl_Father.SelectedIndex = dt.Count - 1;
    }

    public void LoadService()
    {
        string code = Request.QueryString["Code"].ToString();
        Position _p = new PositionBLL().GetModel(code);
        if (_p != null)
        {
            lab_Code.Text = _p.PosiCode;
            txt_Name.Text = _p.PosiName;
            ddl_Father.SelectedValue = _p.FatherCode;

        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        if (txt_Name.Text.Trim() == "系统管理员")
        {
            UtilityService.Alert(this.Page, "该名称是非法名，请换一个职位名称！");
            return;
        }

        Position p = new Position();
        p.PosiName = txt_Name.Text.Trim();
        p.FatherCode = ddl_Father.SelectedValue.ToString();
        p.OrganID = (int)Session["OrganID"];
        p.InputBy = Session["UserID"].ToString();

        bool re = new PositionBLL().Add(p);
        if (re)
        {
            UtilityService.AlertAndRedirect(this,"添加成功!", "PositionMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this,"添加失败!");
        }
    }

    protected void btn_Modity_Click(object sender, EventArgs e)
    {

        if (txt_Name.Text.Trim() == "系统管理员")
        {
            UtilityService.Alert(this.Page, "该名称是非法名，请换一个职位名称！");
            return;
        }

        Position p = new Position();
        p.PosiCode = lab_Code.Text.Trim();
        p.PosiName = txt_Name.Text.Trim();
        p.FatherCode = ddl_Father.SelectedValue.ToString();
        p.OrganID = (int)Session["OrganID"];

        bool re = new PositionBLL().Update(p);
        if (re)
        {
            UtilityService.AlertAndRedirect(this,"修改成功!", "PositionMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this,"修改失败!");
        }
    }
}
