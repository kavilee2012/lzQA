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
using Model;
using BLL;

public partial class SystemUI_OrganUI_OrganAdd : System.Web.UI.Page
{

    OrganBLL organBLL = new OrganBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindSuperior();
        }
    }

    private void BindSuperior()
    {
        DataSet ds = organBLL.GetAllList();
        ddl_Superior.DataSource = ds.Tables[0];
        ddl_Superior.DataTextField = "OrganName";
        ddl_Superior.DataValueField = "OrganID";
        ddl_Superior.DataBind();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Organ organ = new Organ();
        //organ.OrganID = int.Parse(txt_ID.Text.Trim());
        organ.OrganName = txt_Name.Text.Trim();
        organ.Superior = Convert.ToInt32(ddl_Superior.SelectedValue);
        organ.Level = int.Parse(ddl_Level.SelectedValue.ToString());
        organ.Remark = txt_Remark.Text;
        organ.InputBy = Session["UserID"].ToString();
        

        bool re = organBLL.Add(organ);
        if (re)
        {
            Response.Write("添加成功!");
            Response.Redirect("OrganMgr.aspx");
        }
        else
        {
            Response.Write("添加失败!");
        }

    }
}
