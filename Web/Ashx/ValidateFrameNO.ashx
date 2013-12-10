<%@ WebHandler Language="C#" Class="ValidateFrameNO" %>

using System;
using System.Web;
using System.Web.SessionState;

public class ValidateFrameNO : IHttpHandler,IRequiresSessionState{
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        string result = "N";
        Model.Vehicle re = null;
        
        string id = context.Request.QueryString["ID"].ToString();

        string gpList = "", organList = "";
        if (HttpContext.Current.Session["GroupList"] != null)
        {
            gpList = HttpContext.Current.Session["GroupList"].ToString();
        }
        if (HttpContext.Current.Session["SubOrganList"] != null)
        {
            organList = HttpContext.Current.Session["SubOrganList"].ToString();
        }
        
        if (id.Substring(0, 2) == "0_")
        {
            //车牌号
            re = new BLL.VehicleBLL().GetModel_Type(id.Substring(2),0,gpList,organList);
        }
        else
        { 
            //车架号
            re = new BLL.VehicleBLL().GetModel_Type(id.Substring(2),1, gpList, organList);
        }
        if (re != null)
        {
            result = "Y";
            HttpContext.Current.Session["FilterFrameNO"] = re.FrameNO;
            HttpContext.Current.Session["FilterVehicleID"] = re.VehicleID;
        }


        context.Response.ContentType = "text/plain";
        context.Response.Write(result);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}