using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using Model;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string sql = "select MT_ID,MT_name from ModuleTopInfo";
            //SqlDbHelper db = new SqlDbHelper();//SqlHelper类你懂得
            //Repeater1.DataSource = new FunctionBLL().GetChildFunctionList("0",false); //db.ExecuteDataTable(sql);
            //Repeater1.DataBind();
        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //string id = ((Function)e.Item.DataItem).F_Code;
            //Repeater rpt = (Repeater)e.Item.FindControl("Repeater2");
            //rpt.DataSource = new FunctionBLL().GetChildFunctionList(id,false);
            //rpt.DataBind();
        //    string sql = "select MI_ID,MI_page,MI_name from ModuleInfo where MT_ID=@id";
        //    SqlParameter[] parameters = new SqlParameter[] {
        //new SqlParameter("@id",id)
        //};
            //SqlDbHelper db = new SqlDbHelper();
            //DataTable dt = new DataTable();
            //dt = db.ExecuteDataTable(sql, CommandType.Text, parameters);
            //if (rpt != null)
            //{
            //    rpt.DataSource = dt;
            //    rpt.DataBind();
            //}
        }
    }
}
