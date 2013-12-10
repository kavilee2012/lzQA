using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///NewPage 的摘要说明
/// </summary>
public class NewPage : Page
{
    public NewPage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (Session["LoginName"] == "")
        {
            Page.RegisterStartupScript("1","<script>alert('登录信息已失效,请重新登录!')</script>");
            Response.Redirect("~//Login.aspx");
        }
        
    }
}
