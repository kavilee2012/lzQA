using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class MyControl_Menu : System.Web.UI.UserControl
{
    IList<Function> userFuc = new List<Function>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            userFuc = (IList<Function>)Session["FcList"];

            IList<Function> bindFuc = GetBindFuclist("0");

            Repeater1.DataSource = bindFuc; 
            Repeater1.DataBind();
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string id = ((Function)e.Item.DataItem).F_Code;
            Repeater rpt = (Repeater)e.Item.FindControl("Repeater2");

            IList<Function> bindFuc = GetBindFuclist(id);
            rpt.DataSource = bindFuc;
            rpt.DataBind();
        }
    }

    private IList<Function> GetBindFuclist(string id)
    {
        int userType=Convert.ToInt32(Session["UserType"]);
        IList<Function> allChildFuc = new FunctionBLL().GetChildFunctionList(id, userType.Equals(100));
        /**************测试时关闭********************/
        IList<Function> bindFuc = new List<Function>();
        foreach (Function f in allChildFuc)
        {
            if (userFuc != null)
            {
                if (userFuc.FirstOrDefault<Function>(X => X.F_Code == f.F_Code) != null && f.F_Type == 0)
                {
                    bindFuc.Add(f);
                }
            }
        }
        return bindFuc;
        //return allChildFuc;
    }
}
