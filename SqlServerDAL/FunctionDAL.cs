using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using System.Data.SqlClient;
using System.Collections;

namespace SqlServerDAL
{
   public class FunctionDAL
    {

       public IList<Function> GetAllFunctionList()
       {
           string strSql = "SELECT * FROM [Function]";
           return GetManyModel(strSql);
       }

       public IList<Function> GetChildFunctionList(string fatherCode,bool isSuperAdmin)
       {
           string strSql = "SELECT * FROM [Function] WHERE FatherCode = @fathercode";
           if (!isSuperAdmin)
           {
               strSql += " AND Status = 1";
           }
           SqlParameter[] parameters = {
					new SqlParameter("@fathercode",fatherCode)
			};


           return GetManyModel(strSql, parameters);

       }


       public int SetRole2Function(string roleCode, List<string> funcList)
       {
           ArrayList sqlT = new ArrayList();
           sqlT.Add("DELETE FROM Role2Function WHERE RoleCode = '" + roleCode + "';");
           foreach (string s in funcList)
           {
               sqlT.Add("INSERT INTO Role2Function(RoleCode,FunCode) VALUES('" + roleCode + "','" + s + "')");
           }
           try
           {
               DbHelperSQL.ExecuteSqlTran(sqlT);
               return 1;
           }
           catch (Exception ex)
           {
               string msg = ex.Message;
               return 0;
           }
       }

       public List<string> GetRole2Function(string roleCode)
       {
           List<string> funcList = new List<string>();
           string sql = "SELECT * FROM Role2Function WHERE RoleCode = '" + roleCode + "'";
           DataSet ds = DbHelperSQL.Query(sql);
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   string f = ds.Tables[0].Rows[i]["FunCode"].ToString() ;
                   funcList.Add(f);
               }
           }
           return funcList;

       }

       private static IList<Function> GetManyModel(string strSql, params SqlParameter[] parameters)
       {
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               IList<Function> modelList = new List<Function>();

               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   Function model = new Function();
                   if (ds.Tables[0].Rows[i]["ID"] != null && ds.Tables[0].Rows[i]["ID"].ToString() != "")
                   {
                       model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                   }
                   if (ds.Tables[0].Rows[i]["F_Code"] != null && ds.Tables[0].Rows[i]["F_Code"].ToString() != "")
                   {
                       model.F_Code = (string)ds.Tables[0].Rows[i]["F_Code"];
                   }
                   if (ds.Tables[0].Rows[i]["F_Name"] != null && ds.Tables[0].Rows[i]["F_Name"].ToString() != "")
                   {
                       model.F_Name = (string)ds.Tables[0].Rows[i]["F_Name"];
                   }
                   if (ds.Tables[0].Rows[i]["Grade"] != null && ds.Tables[0].Rows[i]["Grade"].ToString() != "")
                   {
                       model.Grade = int.Parse(ds.Tables[0].Rows[i]["Grade"].ToString());
                   }
                   if (ds.Tables[0].Rows[i]["Status"] != null && ds.Tables[0].Rows[i]["Status"].ToString() != "")
                   {
                       model.Status = int.Parse(ds.Tables[0].Rows[i]["Status"].ToString());
                   }
                   if (ds.Tables[0].Rows[i]["ViewOrder"] != null && ds.Tables[0].Rows[i]["ViewOrder"].ToString() != "")
                   {
                       model.ViewOrder = int.Parse(ds.Tables[0].Rows[i]["ViewOrder"].ToString());
                   }
                   if (ds.Tables[0].Rows[i]["FatherCode"] != null && ds.Tables[0].Rows[i]["FatherCode"].ToString() != "")
                   {
                       model.FatherCode = (string)ds.Tables[0].Rows[i]["FatherCode"];
                   }
                   if (ds.Tables[0].Rows[i]["Url"] != null && ds.Tables[0].Rows[i]["Url"].ToString() != "")
                   {
                       model.Url = (string)ds.Tables[0].Rows[i]["Url"];
                   }
                   if (ds.Tables[0].Rows[i]["F_Type"] != null && ds.Tables[0].Rows[i]["F_Type"].ToString() != "")
                   {
                       model.F_Type = int.Parse(ds.Tables[0].Rows[i]["F_Type"].ToString());
                   }
                   modelList.Add(model);
               }
               return modelList;
           }
           else
           {
               return null;
           }
       }

       public Function GetFunctionByCode(string code)
       {
           string strSql = "SELECT * FROM [Function] WHERE F_Code = @code";

           SqlParameter[] parameters = {
					new SqlParameter("@code", code)
			};

           return GetOneModel(strSql, parameters);

       }

       private static Function GetOneModel(string strSql, params SqlParameter[] parameters)
       {
           Function model = new Function();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
               {
                   model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
               }
               if (ds.Tables[0].Rows[0]["F_Code"] != null && ds.Tables[0].Rows[0]["F_Code"].ToString() != "")
               {
                   model.F_Code = (string)ds.Tables[0].Rows[0]["F_Code"];
               }
               if (ds.Tables[0].Rows[0]["F_Name"] != null && ds.Tables[0].Rows[0]["F_Name"].ToString() != "")
               {
                   model.F_Name = (string)ds.Tables[0].Rows[0]["F_Name"];
               }
               if (ds.Tables[0].Rows[0]["Grade"] != null && ds.Tables[0].Rows[0]["Grade"].ToString() != "")
               {
                   model.Grade = int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
               }
               if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
               {
                   model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ViewOrder"] != null && ds.Tables[0].Rows[0]["ViewOrder"].ToString() != "")
               {
                   model.ViewOrder = int.Parse(ds.Tables[0].Rows[0]["ViewOrder"].ToString());
               }
               if (ds.Tables[0].Rows[0]["FatherCode"] != null && ds.Tables[0].Rows[0]["FatherCode"].ToString() != "")
               {
                   model.FatherCode = (string)ds.Tables[0].Rows[0]["FatherCode"];
               }
               if (ds.Tables[0].Rows[0]["Url"] != null && ds.Tables[0].Rows[0]["Url"].ToString() != "")
               {
                   model.Url = (string)ds.Tables[0].Rows[0]["Url"];
               }
               if (ds.Tables[0].Rows[0]["F_Type"] != null && ds.Tables[0].Rows[0]["F_Type"].ToString() != "")
               {
                   model.F_Type = int.Parse(ds.Tables[0].Rows[0]["F_Type"].ToString());
               }
               return model;
           }
           else
           {
               return null;
           }
       }


       public List<string> GetUserFunctionList(string userID)
       {
           List<string> funcList = new List<string>();
           string sql = "SELECT DISTINCT(FunCode),Grade FROM Posi2User A JOIN Posi2Role B ON A.PosiCode = B.PosiCode JOIN Role2Function C ON B.RoleCode = C.RoleCode JOIN [Function] D ON C.FunCode = D.F_Code";
           DataSet dt = DbHelperSQL.Query(sql);
           if (dt != null)
           {
               foreach (DataRow dr in dt.Tables[0].Rows)
               {
                   string s = dr["FunCode"].ToString();
                   funcList.Add(s);
               }
           }
           return funcList;
       }

    }
}
