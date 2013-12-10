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

public partial class SystemUI_UserUI_UserAMV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindOrgan();
            if (Request.QueryString["Type"] != null)
            {

                LoadService();
                if (Request.QueryString["Type"].ToString() == "View")
                {
                    txt_Name.Enabled = false;
                    txt_OpenDate.Enabled = false;
                    txt_UM.Enabled = false;
                    ddl_Organ.Enabled = false;

                    btn_Add.Visible = false;
                    btn_Modity.Visible = false;
                    btn_ResetPwd.Visible = false;
                }
                else
                {
                    if (txt_Name.Text.Trim() == "admin")
                    {
                        //UtilityService.Alert(this.Page, "不能修改管理员信息!");
                        btn_Modity.Enabled = false;
                    }


                    txt_UM.Enabled = false;

                    btn_Add.Visible = false;
                    btn_Modity.Visible = true;
                    btn_ResetPwd.Visible = true;
                }
            }
            else
            {
                btn_Add.Visible = true;
                btn_Modity.Visible = false;
                btn_ResetPwd.Visible = false;
            }
        }
    }



    public void LoadService()
    {
        string uid = Request.QueryString["UID"].ToString();
        Model.User _p = new UserBLL().GetModel(uid);
        if (_p != null)
        {
            txt_UM.Text = _p.UserID;
            txt_Name.Text = _p.UserName;
            ddl_Organ.SelectedValue = _p.OrganID.ToString();
            txt_OpenDate.Text = _p.OpenDate.ToString();
        }
    }

    private void BindOrgan()
    {
        DataSet ds = new OrganBLL().GetAllList();
        ddl_Organ.DataSource = ds.Tables[0];
        ddl_Organ.DataTextField = "OrganName";
        ddl_Organ.DataValueField = "OrganID";
        ddl_Organ.DataBind();
    }


    protected void btn_Add_Click(object sender, EventArgs e)
    {
        if (txt_Name.Text.Trim().ToLower() == "admin")
        {
            UtilityService.Alert(this.Page,"admin是非法用户名，请换一个用户名称！");
            return;
        }
        

        Model.User u = new Model.User();
        u.UserID = txt_UM.Text.Trim();
        u.UserName = txt_Name.Text.Trim();
        //u.Password = txt_Pwd.Text.Trim();
        u.Status = 1;
        u.OrganID = int.Parse(ddl_Organ.SelectedValue.ToString());//(int)Session["OrganID"];
        u.OpenDate = DateTime.Parse(txt_OpenDate.Text);
        u.InputBy = Session["UserID"].ToString();

        DataSet oldU = new UserBLL().GetList(" UserID = '" + u.UserID + "'");
        if (oldU != null && oldU.Tables[0].Rows.Count > 0)
        {
            UtilityService.Alert(this, "该用户名已存在!");
            return;
        }

        int re = new UserBLL().Add(u);
        if (re > 0)
        {
            UtilityService.AlertAndRedirect(this, "添加成功!", "UserMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this, "添加失败!");
        }
    }
    protected void btn_Modity_Click(object sender, EventArgs e)
    {
        Model.User u = new Model.User();
        u.UserID = txt_UM.Text.Trim();
        u.UserName = txt_Name.Text.Trim();
        u.OrganID = int.Parse(ddl_Organ.SelectedValue.ToString());//(int)Session["OrganID"];
        u.Status = 1;
        u.OpenDate = DateTime.Parse(txt_OpenDate.Text);

        bool re = new UserBLL().Update(u);
        if (re)
        {
            UtilityService.AlertAndRedirect(this, "修改成功!", "UserMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this, "修改失败!");
        }
    }
    protected void btn_ResetPwd_Click(object sender, EventArgs e)
    {
        bool re = new UserBLL().UpdatePwd(txt_UM.Text.Trim(), "123456");
        if (re)
        {
            UtilityService.AlertAndRedirect(this, "初始化密码成功!", "UserMgr.aspx");
        }
        else
        {
            UtilityService.Alert(this, "初始化密码失败!");
        }
    }
}
