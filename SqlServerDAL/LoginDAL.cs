using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDAL
{
    public class LoginDAL
    {
        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetLoginUserInfo(string userID,string pwd)
        {
            string sql = "SELECT TOP 1 * FROM [User] A JOIN Organ B ON A.OrganID = B.OrganID WHERE A.UserID = @UserID AND Password = @pwd";
            //if (organID == 100)
            //{
            //    sql = "SELECT TOP 1 * FROM [User] A JOIN Organ B ON A.OrganID = B.OrganID  WHERE UserType = 100 AND UserID = @UserID AND Password = @pwd";
            //}


            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", userID),
                    new SqlParameter("@pwd", pwd)
                                        };
            DataSet ds = DbHelperSQL.Query(sql,parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取登录功能权限
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetLoginUserFcList(string userID)
        {
            //string sql = "SELECT distinct D.* FROM Posi2User A JOIN  Posi2Role B ON A.PosiCode = B.PosiCode JOIN Role2Function C ON B.RoleCode = C.RoleCode JOIN [Function] D ON C.FunCode = D.F_Code  WHERE A.UserID = @UserID";

            string sql = "SELECT distinct D.* FROM Role2User A JOIN Role2Function C ON A.RoleCode = C.RoleCode JOIN [Function] D ON C.FunCode = D.F_Code  WHERE A.UserID = @UserID";

            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", userID)
                                        };
            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取超级管理员功能权限
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetSuperUserFcList()
        {
            string sql = "SELECT * from [Function]  WHERE Status = 0 or f_Code='F1'";
            //SqlParameter[] parameters = {
            //        new SqlParameter("@UserID", userID)
            //                            };
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        IList<string> codeList = new List<string>();
        /// <summary>
        /// 获取登录数据权限
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public IList<string> GetLoginUserObjectGroup(string userID)
        {
            codeList = new List<string>();
            //string sql = "SELECT PosiCode FROM Posi2User A  WHERE A.UserID = @UserID";
            string sql = "SELECT B.ObjectGroupCode FROM Posi2User A JOIN Posi2ObjectGroup B ON A.PosiCode=B.PosiCode WHERE A.UserID = @UserID"
                        + " UNION"
                        + " SELECT Code FROM ObjectGroup WHERE OrganID IN (SELECT OrganID FROM Organ WHERE Superior = substring(@UserID,3,4) AND OrganID <> substring(@UserID,3,4))";
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", userID)
                                        };
            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //ReturnGroupCode(dr["PosiCode"].ToString());
                    //GetUserObjectGroup(dr["PosiCode"].ToString());
                    codeList.Add(dr["ObjectGroupCode"].ToString());
                }
                return codeList;
            }
            else
            {
                return null;
            }
        }

        
        //public void GetUserObjectGroup(string posiCode)
        //{
        //    string sql = "SELECT * FROM Position WHERE FatherCode = '" + posiCode + "'";
        //    DataSet ds = DbHelperSQL.Query(sql);
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            GetUserObjectGroup(dr["PosiCode"].ToString());
        //            ReturnGroupCode(dr["PosiCode"].ToString());
        //        }
        //    }
        //}

        //private void ReturnGroupCode(string posiCode)
        //{
        //    string sql = "SELECT ObjectGroupCode From Posi2ObjectGroup WHERE PosiCode = '" + posiCode + "'";
        //    DataSet ds = DbHelperSQL.Query(sql);
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            string code = dr["ObjectGroupCode"].ToString();
        //            if (!codeList.Contains(code))
        //            {
        //                codeList.Add(code);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 获取登录用户下级机构
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetLoginUserSubOrgan(int organID)
        {
            string sql = "SELECT OrganID FROM Organ WHERE Superior = @organID OR OrganID = @organID";
            SqlParameter[] parameters = {
                    new SqlParameter("@organID", organID)
                                        };
            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
}
