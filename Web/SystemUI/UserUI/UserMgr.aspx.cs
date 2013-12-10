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
using Utility;
using System.Collections.Generic;
using Model;

public partial class SystemUI_UserUI_UserMgr : System.Web.UI.Page
{
    private void FuncCheck()
    {
        string pages = "F1_2&F1_2_1&F1_2_2&F1_2_3&F1_2_4";
        Hashtable fc = RightChecker.GetPageFuncHT(pages.Split('&'), (IList<Function>)Session["FcList"]);

        btn_Add.Visible = (bool)fc["F1_2_1"];
        btn_Delete.Visible = (bool)fc["F1_2_3"];

        if (!(bool)fc["F1_2_2"])
        {
            GridView1.Columns[7].Visible = false;
        }
        if (!(bool)fc["F1_2_4"])
        {
            GridView1.Columns[9].Visible = false;
        }
    }

  
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            BindOrgan();
            Session["SelOrganID"] = 0;
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

    }

    protected void btn_Delete_Click(object sender, ImageClickEventArgs e)
    {
        string idList = string.Empty;
        foreach (GridViewRow dr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)dr.FindControl("chk");
            if (chk != null && chk.Checked)
            {
                string _id = "'" + dr.Cells[1].Text.Trim() + "'";

                string _name = dr.Cells[2].Text.Trim();

                if (_name == "admin")
                {
                    UtilityService.Alert(this.Page, "禁止删除系统管理员");
                    return;
                }

                idList += _id + ",";
            }

        }
        if (idList.Length > 0)
        {
            
            idList = idList.TrimEnd(',');
            bool re = new UserBLL().DeleteList(idList);
            if (re)
            {
                UtilityService.AlertAndRedirect(this.Page, "删除成功!", "UserMgr.aspx");
            }
            else
            {
                UtilityService.Alert(this.Page, "删除失败!");
            }
        }
    }
    protected void ddl_Organ_SelectedIndexChanged(object sender, EventArgs e)
    {
        int organID = int.Parse(ddl_Organ.SelectedValue.ToString());
        Session["SelOrganID"] = organID;
        GridView1.DataBind();
    }
}
