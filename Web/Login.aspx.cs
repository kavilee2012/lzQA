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
using Utility;
using Model;
using BLL;
using System.Collections.Generic;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindOrgan();
            //CreateVerifyCode();
            //ddl_Superior.SelectedIndex = 0;
            //txt_Name.Text = "lz";
            //txt_Pwd.Text = "1";
        }
    }

    private void BindOrgan()
    {
        IList<Organ> ds = new OrganBLL().GetModelList("");
        Organ o = new Organ();
        o.OrganID = 100;
        o.OrganName = "超级管理员";
        ds.Add(o);

        //ddl_Superior.DataSource = ds;
        //ddl_Superior.DataTextField = "OrganName";
        //ddl_Superior.DataValueField = "OrganID";
        //ddl_Superior.DataBind();
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        CreateVerifyCode();
    }

    private void CreateVerifyCode()
    {
        VerifyService vs = new VerifyService();
        string code = vs.CreateVerifyCode();
        lab_Code.Text = code;
    }


    protected void btn_Login_Click(object sender, ImageClickEventArgs e)
    {
        string _userID = txt_Name.Text.Trim();
        string _pwd = txt_Pwd.Text.Trim();
        //string _code = txt_Code.Text.Trim();
        //int _organID = Convert.ToInt32(ddl_Superior.SelectedValue);

        DataTable dt = new LoginBLL().GetLoginUserInfo(_userID,_pwd);

        if (dt == null)
        {
            UtilityService.Alert(this.Page, "登录失败,用户名或密码不正确!");
            return;
        }
        else
        {

            Session["OrganID"] = dt.Rows[0]["OrganID"];
            Session["UserID"] = dt.Rows[0]["UserID"];
            Session["UserName"] = dt.Rows[0]["UserName"];
            Session["UserType"] = dt.Rows[0]["UserType"];

            Session["SubOrganList"] = null;
            Session["FcList"] = null;
            //Session["GroupList"] = null;


            DataTable dtFc = null;
            if (Session["UserType"].ToString().Equals("100"))
            {
                dtFc = new LoginBLL().GetSuperUserFcList();
            }
            else
            {
                dtFc = new LoginBLL().GetLoginUserFcList(Session["UserID"].ToString());
            }
            if (dtFc != null)
            {
                IList<Function> FcList = new List<Function>();
                foreach (DataRow dr in dtFc.Rows)
                {
                    Function f = new Function();
                    f.F_Code = dr["F_Code"].ToString();
                    f.F_Name = dr["F_Name"].ToString();
                    f.FatherCode = dr["FatherCode"].ToString();
                    f.Grade = Convert.ToInt32(dr["Grade"]);
                    f.Status = Convert.ToInt32(dr["Status"]);
                    f.ViewOrder = Convert.ToInt32(dr["ViewOrder"]);
                    f.Url = dr["Url"].ToString();
                    FcList.Add(f);
                }
                Session["FcList"] = FcList;
            }
            

            //IList<string> dtGroup = new LoginBLL().GetLoginUserObjectGroup(Session["UserID"].ToString());
            //if (dtGroup != null)
            //{
            //    string glStr = "";
            //    //List<string> groupList = new List<string>();
            //    foreach (string dr in dtGroup)
            //    {
            //        glStr += "'" + dr + "',";
            //       // groupList.Add(dr["ObjectGroupCode"].ToString());
            //    }
            //    if (glStr.Length > 0)
            //    {
            //        glStr = glStr.TrimEnd(',');
            //        Session["GroupList"] = glStr;
            //    }

            //}

            DataTable dtSubOrgan = new LoginBLL().GetLoginUserSubOrgan((int)Session["OrganID"]);
            if (dtSubOrgan != null)
            {
                //List<string> organList = new List<string>();
                string olStr = "";
                foreach (DataRow dr in dtSubOrgan.Rows)
                {
                    olStr += dr["OrganID"].ToString() + ",";
                    //organList.Add(dr["OrganID"].ToString());
                }
                if (olStr.Length > 0)
                {
                    olStr = olStr.TrimEnd(',');
                    Session["SubOrganList"] = olStr;
                }
            }

            Response.Redirect("Default.aspx");
        }
    }
}
