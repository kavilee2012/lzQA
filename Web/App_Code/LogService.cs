using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
/// <summary>
///LogService 的摘要说明
/// </summary>
public class LogService
{
    public LogService()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static void WriteError(string errorMessage)
    {
        try
        {
            string path = "~/Error/" + DateTime.Today.ToString("yyMMdd") + ".txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                w.WriteLine(errorMessage);
                w.WriteLine("________________________________________________________");
                w.Flush();
                w.Close();
            }
        }
        catch (Exception ex)
        {
            WriteError(ex.Message);
        }
    }

}
