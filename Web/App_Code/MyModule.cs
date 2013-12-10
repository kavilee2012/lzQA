using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Reflection;

/// <summary>
///MyModule 的摘要说明
/// </summary>
public class MyModule:IHttpModule
{
    public void Init(HttpApplication application)
    {
        application.AcquireRequestState += (new
        EventHandler(this.Application_AcquireRequestState));
    }

    private void Application_AcquireRequestState(Object source, EventArgs e)
    {
        HttpApplication Application = (HttpApplication)source;
        string url = Application.Context.Request.Path;
        if (Application.Context.Session!=null)
        {
            if (!url.ToLower().Contains("login.aspx"))
            {
                if(Application.Context.Session["UserID"] == null)
                    Application.Context.Server.Transfer("Login.aspx");
                //User user = (User)Application.Context.Session["User"];  //获取User

                //////获取客户访问的页面
                //Function func = new Function(); //根据url得到所在的模块
                //func.Url = url;
                //if (!RightChecker.HasRight(user, func))
                //    Application.Context.Server.Transfer("ErrorView.aspx");
                //如果没有权限，引导到错误处理的页面
            }
        }
    }


    public void Dispose()
    {
    }
}
