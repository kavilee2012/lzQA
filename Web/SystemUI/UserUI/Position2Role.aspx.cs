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
using System.Collections.Generic;
using Utility;

public partial class SystemUI_UserUI_Position2Role : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string _name = Request.QueryString["name"].ToString();
            if (_name == "系统管理员")
            {
                UtilityService.AlertAndRedirect(this.Page, "不能修改系统管理员信息！", "PositionMgr.aspx");
            }
        }
    }

    protected void btn_Right_Click(object sender, EventArgs e)
    {
        if (!list_Aim.Items.Contains(list_Source.SelectedItem))
        {
            list_Aim.Items.Add(list_Source.SelectedItem);
            list_Aim.SelectedIndex = list_Aim.Items.Count - 1;
        }
    }

    protected void btn_Left_Click(object sender, EventArgs e)
    {
        list_Aim.Items.Remove(list_Aim.SelectedItem);
        list_Aim.SelectedIndex = list_Aim.Items.Count - 1;
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        if (list_Aim.Items.Count >= 0)
        {
            List<string> all = new List<string>();
            string _posiCode = Request.QueryString["code"].ToString();
            foreach (ListItem li in list_Aim.Items)
            {
                string c = li.Value.ToString();
                all.Add(c);
            }
            int re = new PositionBLL().AddPosi2Role(_posiCode, all);
            if (re > 0)
            {
                UtilityService.Alert(this, "设定完成!");
            }
            else
            {
                UtilityService.Alert(this, "设定失败!");
            }
        }
    }
}
