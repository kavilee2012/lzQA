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
using System.Collections.Generic;
using Model;

public partial class SystemUI_UserUI_PositionMgr : System.Web.UI.Page
{

    private void FuncCheck()
    {
        string pages = "F1_4&F1_4_1&F1_4_2&F1_4_3&F1_4_4&F1_4_5";
        Hashtable fc = RightChecker.GetPageFuncHT(pages.Split('&'), (IList<Function>)Session["FcList"]);

        btn_Add.Visible = (bool)fc["F1_4_1"];
        btn_Delete.Visible = (bool)fc["F1_4_3"];
        

        if (!(bool)fc["F1_4_2"])
        {
            GridView1.Columns[5].Visible = false;
        }
        if (!(bool)fc["F1_4_4"])
        {
            GridView1.Columns[7].Visible = false;
        }
        if (!(bool)fc["F1_4_5"])
        {
            GridView1.Columns[8].Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //FuncCheck();
            BindGV();
        }
    }
    private void BindGV()
    {
        PositionBLL organBLL = new PositionBLL();
        IList<Position> ds = organBLL.GetModelList(" OrganID = " + (int)Session["OrganID"]);
        foreach (Position o in ds)
        {
            Position oa = organBLL.GetModel(o.FatherCode);
            if (oa == null)
                o.FatherCodeName = "无";
            else
                o.FatherCodeName = oa.PosiName;
        }
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {

    }

    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < this.GridView1.Rows.Count; i++)
        //{
        //    ((CheckBox)GridView1.Rows[i].FindControl("chk")).Checked =
        //        ((CheckBox)this.GridView1.HeaderRow.FindControl("chk_All")).Checked;
        //}
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
                if (_name == "系统管理员")
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
            bool re = new PositionBLL().DeleteList(idList);
            if (re)
            {
                UtilityService.AlertAndRedirect(this.Page, "删除成功!", "PositionMgr.aspx");
            }
            else
            {
                UtilityService.Alert(this.Page, "删除失败!");
            }
        }
    }
}
