using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Collections;
using BLL;

/// <summary>
///RightChecker 的摘要说明
/// </summary>
public class RightChecker
{
    public RightChecker()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //

  
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fcList"></param>
    /// <param name="user"></param>
    /// <param name="fc"></param>
    /// <returns></returns>
    public static bool HasRight(IList<Function> fcList,Function fc)
    {
        foreach (Function f in fcList)
        {
            if (fc.Url.ToLower().Contains(f.Url.ToLower()))
            {
                return true;
            }
        }
        return false;
    }


    public static Hashtable GetPageFuncHT(string[] pageFuncs,IList<Function> userFcList)
    {
        Hashtable fc = new Hashtable();
        List<string> pageList = new List<string>();
        foreach (string s in pageFuncs)
        {
            fc.Add(s, false);
            pageList.Add(s);
        }

        //string userID = new HttpApplication().Session["UserID"].ToString();
        List<string> userList = new List<string>();
        foreach (Function f in userFcList)
        {
            userList.Add(f.F_Code);
        }

        foreach (string s in pageList)
        {
            if (userList.Contains(s))
            {
                fc[s] = true;
            }
        }
        return fc;
    }
}
