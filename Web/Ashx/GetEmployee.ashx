<%@ WebHandler Language="C#" Class="GetEmployee" %>

using System;
using System.Web;

public class GetEmployee : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
        //string _id = context.Request.QueryString["ID"];
        //string re = new BLL.EmployeeBLL().GetList(_id);
        //context.Response.ContentType = "text/plain";
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}