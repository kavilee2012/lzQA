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

public partial class SystemUI_OrganUI_OrganAMV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] == null)
        {
            dv_Organ.ChangeMode(DetailsViewMode.Insert);
        }
        else if (Request.QueryString["Type"].ToString() == "View")
        {
            dv_Organ.ChangeMode(DetailsViewMode.ReadOnly);
            dv_Organ.AutoGenerateEditButton = false;
            dv_Organ.AutoGenerateInsertButton = false;
        }
        else
        {
            dv_Organ.ChangeMode(DetailsViewMode.Edit);
        }

        if (!Page.IsPostBack)
        {
            //if (dv_Organ.CurrentMode == DetailsViewMode.ReadOnly) return;
            //PageCommonService.AddRequiredFieldValidator(dv_Organ, 1);
            //PageCommonService.AddRegularExpressionValidator(dv_Organ,1,RegexPattern.Mobile);
            //PageCommonService.AddRequiredFieldValidator(dv_Organ, 3);
            //PageCommonService.AddRegularExpressionValidator(dv_Organ, 3, RegexPattern.Number);
            //AddRequiredFieldValidator(1, "填写手机号码,作为登录帐号", "^(13|15)[0-9]{9}$");
            //AddRequiredFieldValidator(3, "密码长度为6-12号", @"^[\S]{6,12}$");
            //AddRequiredFieldValidator(4, "你太有创意了", "^(男|女)$");
            //AddRequiredFieldValidator(1, "日期格式错误,例:1983-7-21", @"\d{4}-\d{1,2}-\d{1,2}");
            //DetailsViewRow row = dv_Organ.Rows[0];
            //DataControlFieldCell cell = row.Cells[1] as DataControlFieldCell;
            //cell.Controls.Add(new TextBox());
            //Text = "dsfads";
        }

       
    }




    protected void dv_Organ_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        DropDownList mydl = (DropDownList)dv_Organ.FindControl("ddl_Superior");
        if (mydl != null)
        {
            e.Values["Superior"] = mydl.Items[mydl.SelectedIndex].Value;
        }
    }
    protected void sourceDV_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {


        //for (int i = 0; i < e.InputParameters.Count; i++)
        //{
        //    if (e.InputParameters[i] == null)
        //    {
        //        e.InputParameters[i] = DBNull.Value;
        //    }
        //}
    }
}
