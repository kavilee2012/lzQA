<%@ WebHandler Language="C#" Class="Validate" %>

using System;
using System.Web;

public class Validate : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string id = context.Request.QueryString["ID"].ToString();
        string re = new BLL.VehicleBLL().GetFrameNO(id);
        context.Response.ContentType = "text/plain";

        context.Response.Write(re);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}