using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Utility;

public partial class SystemUI_UserUI_UpdatePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Sure_Click(object sender, EventArgs e)
    {
        UserBLL uBLL = new UserBLL();
        string userID = Session["UserID"].ToString();
        string oldPwd = txt_Old.Text.Trim();
        string newPwd = txt_New.Text.Trim();

        //判断旧密码是否正确
        Model.User user = uBLL.GetModel(userID);
        if (user.Password != oldPwd)
        {
            UtilityService.Alert(this.Page,"旧密码不正确,请重新输入");
            txt_Old.Focus();
            return;
        }

        bool re = new UserBLL().UpdatePwd(userID, newPwd);
        if (re)
        {
            UtilityService.Alert(this.Page, "修改成功");
            //Session["OrganID"] = null;
            //Session["UserID"] = null;
            //Session["UserName"] = null;
            //Session["FcList"] = null;
            ////Response.Redirect("UpdatePwd.aspx");
        }
        else
        {
            UtilityService.Alert(this.Page, "修改失败!");
        }
    }
}
