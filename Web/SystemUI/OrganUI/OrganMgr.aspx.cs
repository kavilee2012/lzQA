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
using System.Web.UI.MobileControls;
using Utility;
using System.Collections.Generic;

public partial class SystemUI_OrganUI_OrganMgr : System.Web.UI.Page
{
    private void FuncCheck()
    {
        

        //string pages = "F1_1&F1_1_1&F1_1_2&F1_1_3";
        //Hashtable fc = RightChecker.GetPageFuncHT(pages.Split('&'),Session["UserID"].ToString());

        //btn_Add.Visible = (bool)fc["F1_1_1"];
        //btn_Delete.Visible = (bool)fc["F1_1_3"];


   
    }
    
   

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int userType = Convert.ToInt32(Session["UserType"]);//是否是超级管理员
            if (userType != 100)
            {
                UtilityService.Alert(this.Page,"权限不足 !");
                return;
            }

            //FuncCheck();

            BindGV();
        }
    }


    private void BindGV()
    {
        OrganBLL organBLL = new OrganBLL();
        IList<Organ> ds = organBLL.GetModelList("");
        foreach (Organ o in ds)
        {
            Organ oa = organBLL.GetModel(o.Superior);
            if (oa == null)
                o.SuperiorName = "无";
            else
                o.SuperiorName = oa.OrganName;
        }
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        

    }
    protected void btn_Modity_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow dr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)dr.FindControl("chk");
            if (chk != null && chk.Checked)
            {
                int _id = Convert.ToInt32((dr.Cells[1].Text));
                string _url = "OrganModity.aspx?ID=" + _id;
                Response.Redirect(_url);
            }
        }
    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {

    }

    protected void chk_All_CheckedChanged1(object sender, EventArgs e)
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            ((CheckBox)GridView1.Rows[i].FindControl("chk")).Checked =
                ((CheckBox)this.GridView1.HeaderRow.FindControl("chk_All")).Checked;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("js", "<script>window.showModalDialog('OrganAdd.aspx','','dialogHeight:300px; dialogWidth:300px;status:no;scroll:no;menubar=no ');</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void btn_Delete_Click(object sender, ImageClickEventArgs e)
    {
        string idList = string.Empty;
        foreach (GridViewRow dr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)dr.FindControl("chk");
            if (chk.Checked)
            {
                int _id = Convert.ToInt32((dr.Cells[1].Text));
                idList += _id + ",";
            }

        }
        if (idList.Length > 0)
        {
            if (idList.Contains("1000"))
            {
                UtilityService.Alert(this.Page, "不能删除总公司信息!");
                return;
            }
            OrganBLL organBLL = new OrganBLL();
            idList = idList.TrimEnd(',');
            bool re = organBLL.DeleteList(idList);
            if (re)
            {
                UtilityService.AlertAndRedirect(this.Page, "删除成功!", "OrganMgr.aspx");
            }
            else
            {
                UtilityService.Alert(this.Page, "删除失败!");
            }
        }
    }
    protected void btn_Delete0_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("../LoadUser.aspx");
    }
}
