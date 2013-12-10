using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Utility;
using System.Web.UI;

/// <summary>
///CommonService 的摘要说明
/// </summary>
public class PageCommonService
{
    public PageCommonService()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private readonly static string INT = @"^-?[1-9]\d*$";
    private readonly static string INT_MSG = "整数格式不正确!";
    private readonly static string NUMBER = @"^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$";
    private readonly static string NUMBER_MSG = "数据格式不正确";
    private readonly static string DATE = @"\d{4}-\d{1,2}-\d{1,2}";
    private readonly static string DATE_MSG = "日期格式不正确";
    private readonly static string MONEY = "";
    private readonly static string MONEY_MSG = "";
    private readonly static string MOBILE = @"(86)*0*13\d{9}";
    private readonly static string MOBILE_MSG = "手机号码格式不正确";
    private readonly static string EMAIL = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
    private readonly static string EMAIL_MSG = "电子邮箱格式不正确";



    public static void AddRegularExpressionValidator(DetailsView view, int rowIndex, RegexPattern type)
    {
        string msg = "", patter = "";
        if (type == RegexPattern.Number)
        {
            patter = NUMBER;
            msg = NUMBER_MSG;
        }
        else if (type == RegexPattern.Date)
        {
            patter = DATE;
            msg = DATE_MSG;
        }
        else if (type == RegexPattern.Mobile)
        {
            patter = MOBILE;
            msg = MOBILE_MSG;
        }

        DetailsViewRow row = view.Rows[rowIndex];
        DataControlFieldCell cell = row.Cells[1] as DataControlFieldCell;
        string ctlID = cell.Controls[0].UniqueID;
        string clientID = cell.Controls[0].ClientID;
        int pos = clientID.LastIndexOf("_");
        if (pos > 0)
        {
            RegularExpressionValidator Reg = new RegularExpressionValidator();
            Reg.Text = String.Format("<p style='margin:0;'>{0}</p>", msg);
            Reg.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
            Reg.ControlToValidate = ctlID.Substring((pos + 1));
            Reg.ValidationExpression = patter;
            cell.Controls.Add(Reg);
        }
    }


    public static void AddRequiredFieldValidator(DetailsView view, int rowIndex)
    {
        DetailsViewRow row = view.Rows[rowIndex];
        DataControlFieldCell cell = row.Cells[1] as DataControlFieldCell;
        string ctlID = "";
        foreach (Control c in cell.Controls)
        {
            if (c is TextBox)
            {
                int pos = c.UniqueID.LastIndexOf("$");
                ctlID = c.UniqueID.Substring((pos + 1));
                break;
            }
        }
        RequiredFieldValidator Reg = new RequiredFieldValidator();
        Reg.Text = String.Format("{0}", "*");
        Reg.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
        if (ctlID != string.Empty)
        {
            Reg.ControlToValidate = ctlID;
            cell.Controls.Add(Reg);
        }
    }
}
