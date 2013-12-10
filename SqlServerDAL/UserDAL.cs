using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SqlServerDAL
{
    public class UserDAL
    {
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [User]");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50)			};
            parameters[0].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName, int OrganID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [User]");
            strSql.Append(" where UserName=@UserName AND OrganID = @OrganID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", UserName),
                    new SqlParameter("@OrganID",OrganID)};

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("if(not exists(select id from [User] WHERE UserID = @uid)) insert into [User](");
            strSql.Append("UserID,Password,OrganID,UserName,Status,InputBy,OpenDate)");
            strSql.Append(" values (");
            strSql.Append("@uid,@pwd,@organID,@userName,1,@InputBy,@openDate)");
            strSql.Append(";select @@IDENTITY");

            SqlParameter[] parameters = {
                    new SqlParameter("@uid", model.UserID),
					new SqlParameter("@userName", model.UserName),
					new SqlParameter("@pwd", "123456"),
                    new SqlParameter("@InputBy", model.InputBy),
                    new SqlParameter("@openDate", model.OpenDate),
					new SqlParameter("@organID", model.OrganID)};

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

            //SqlParameter[] parameters = {
            //        new SqlParameter("@uid", model.UserID),
            //        new SqlParameter("@userName", model.UserName),
            //        new SqlParameter("@pwd", "123456"),
            //        new SqlParameter("@InputBy", model.InputBy),
            //        new SqlParameter("@openDate", model.OpenDate),
            //        new SqlParameter("@organID", model.OrganID)};
            //int re = 0;
            //DbHelperSQL.RunProcedure("Proc_AddUser", parameters, out re);
            //return re;



        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("OrganID=@OrganID,");
            strSql.Append("OpenDate=@OpenDate,");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", model.UserName),
                    new SqlParameter("@OrganID", model.OrganID),
                    new SqlParameter("@OpenDate", model.OpenDate),
					new SqlParameter("@UserID", model.UserID)};

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePwd(string userID,string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set ");
            strSql.Append("Password=@Password");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@Password", pwd),
					new SqlParameter("@UserID", userID)};

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [User] ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [User] ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50)			};
            parameters[0].Value = UserID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [User] ");
            strSql.Append(" where UserID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public User GetModel(string uID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from [User] ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", uID)
			};

            User model = new User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrganID"] != null && ds.Tables[0].Rows[0]["OrganID"].ToString() != "")
                {
                    model.OrganID = int.Parse(ds.Tables[0].Rows[0]["OrganID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenDate"] != null && ds.Tables[0].Rows[0]["OpenDate"].ToString() != "")
                {
                    model.OpenDate =DateTime.Parse(ds.Tables[0].Rows[0]["OpenDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,UserID,UserName,Password,OrganID,Status ");
            strSql.Append(" FROM [User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from [User] T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "User";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 攻取某职位授权的数据对象
        /// </summary>
        /// <param name="posiCode"></param>
        /// <returns></returns>
        public DataSet GetRole2User(string userID)
        {
            string sql = "SELECT * FROM Role2User A JOIN Role B ON A.RoleCode = B.RoleCode WHERE UserID = '" + userID + "'";
            return DbHelperSQL.Query(sql);
        }


        /// <summary>
        /// 分配数据组
        /// </summary>
        /// <param name="posiCode"></param>
        /// <param name="groupCodeArr"></param>
        /// <returns></returns>
        public int AddRole2User(string userID, List<string> roleCodeArr)
        {
            ArrayList sqlT = new ArrayList();
            sqlT.Add("DELETE FROM Role2User WHERE UserID='" + userID + "';");
            foreach (string c in roleCodeArr)
            {
                string sql = "INSERT INTO Role2User(UserID,RoleCode) VALUES('" + userID + "','" + c + "');";
                sqlT.Add(sql);
            }
            try
            {
                DbHelperSQL.ExecuteSqlTran(sqlT);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return 0;
            }
            return 1;
        }



        public string GetUserID(string userName, int organID)
        {
            string sql = "SELECT UserID FROM [User] WHERE UserName = @userName AND OrganID = @OrganID ";
            SqlParameter[] parameters = {
					new SqlParameter("@userName", userName),
	                new SqlParameter("@OrganID",organID)
                                        };
            object re = DbHelperSQL.GetSingle(sql,parameters);
            if (re == null || re == DBNull.Value)
            {
                return "";
            }
            else
            {
                return re.ToString();
            }
        }

        #endregion  Method
    }
}
