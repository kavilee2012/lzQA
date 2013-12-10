<%@ WebHandler Language="C#" Class="AutoComplete" %>

using System;
using System.Web;

public class AutoComplete : IHttpHandler, System.Web.SessionState.IRequiresSessionState{
    
    public void ProcessRequest (HttpContext context) {
        
    //输出字符串数组 或者 JSON 数组
    //context.Response.Write("[\"粤AXE111\", \"粤AXE222\", \"粤AXE333\", \"粤AXE444\", \"粤AXE555\", \"粤AXE666\"]");  
        context.Response.ContentType = "text/plain";    
        string jsponString = "[";
        string key = "";
        if (context.Request.QueryString["term"] != null)
        {
            key = context.Request.QueryString["term"];
        }

        string strWhere = "VehicleID LIKE'%" + key + "%'";
        if (HttpContext.Current.Session["GroupList"] != null)
        {
            strWhere += " AND  ObjectGroup IN(" + HttpContext.Current.Session["GroupList"].ToString() + ")";
        }
        if (HttpContext.Current.Session["SubOrganList"] != null)
        {
            strWhere += " AND  OrganID IN(" + HttpContext.Current.Session["SubOrganList"].ToString() + ")";
        }
        

        System.Collections.Generic.List<Model.Vehicle> dt = new BLL.VehicleBLL().GetModelList(strWhere);
        if (dt.Count > 0)
        {
            foreach (Model.Vehicle v in dt)
            {
                if (v.VehicleID != string.Empty)
                {
                    jsponString += "\"" + v.VehicleID + "\",";//"{VehicleID:\"" + dt.Tables[0].Rows[i]["VehicleID"].ToString() + "\",FrameNO:\"" + dt.Tables[0].Rows[i]["FrameNO"].ToString() + "\"},";
                }
            }
        }
        jsponString = jsponString.Trim(new char[] { ',' });
        jsponString += "]";

        context.Response.Write(jsponString.ToString());


        //string jsponString = "[\"粤AXE111\", \"粤AXE222\", \"粤AXE333\", \"粤AXE444\", \"粤AXE555\", \"粤AXE666\"]"; //"'粤AXE111,车架号：F114111','AppleScript','Asp','BASIC','川AXE222,车架号：F114222'";

        //System.Text.StringBuilder jsponString = new System.Text.StringBuilder();

        //jsponString.Append("<option value='wangtao'>");

        //jsponString.Append(context.Request.Params["type"].ToString());

        //jsponString.Append("</option>");

 


    //context.Response.End(); 
        
        
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}