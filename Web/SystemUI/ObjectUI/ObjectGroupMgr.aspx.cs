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
using Utility;
using BLL;
using Model;
using System.Collections.Generic;

public partial class SystemUI_ObjectUI_ObjectGroupMgr : System.Web.UI.Page
{
    private void FuncCheck()
    {
        string pages = "F1_5&F1_5_1&F1_5_2&F1_5_3";
        
        Hashtable fc = RightChecker.GetPageFuncHT(pages.Split('&'), (IList<Function>)Session["FcList"]);

        btn_Add.Visible = (bool)fc["F1_5_1"];
        btn_Delete.Visible = (bool)fc["F1_5_3"];

        if (!(bool)fc["F1_5_2"])
        {
            GridView1.Columns[6].Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FuncCheck();
        }
    }
    protected void btn_Add_Click(object sender, EventArgs e)
    {

    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        string idList = string.Empty;
        foreach (GridViewRow dr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)dr.FindControl("chk_XX");
            if (chk!=null && chk.Checked)
            {
                string _id = "'" + dr.Cells[1].Text.Trim() + "'";
                idList += _id + ",";
            }

        }
        if (idList.Length > 0)
        {
            idList = idList.TrimEnd(',');
            bool re = new ObjectGroupBLL().DeleteList(idList);
            if (re)
            {
                UtilityService.AlertAndRedirect(this.Page, "删除成功!", "ObjectGroupMgr.aspx");
            }
            else
            {
                UtilityService.Alert(this.Page, "删除失败!");
            }
        }
    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {

    }
}
