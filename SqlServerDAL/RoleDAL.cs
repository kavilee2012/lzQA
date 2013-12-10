using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDAL
{
    public class RoleDAL
    {
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Role");
            strSql.Append(" where RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleCode", SqlDbType.VarChar,20)			};
            parameters[0].Value = RoleCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name, int organID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Role");
            strSql.Append(" where RoleName=@name and OrganID = @organID");
            SqlParameter[] parameters = {
					new SqlParameter("@name", name),
                    new SqlParameter("@organID",organID)
                                        };

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Role model)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("insert into Role(");
            //strSql.Append("RoleCode,RoleName,Status,IsAdmin,OrganID,SubSystemCode)");
            //strSql.Append(" values (");
            //strSql.Append("@RoleCode,@RoleName,@Status,@IsAdmin,@OrganID,@SubSystemCode)");
            //strSql.Append(";select @@IDENTITY");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@RoleCode", SqlDbType.VarChar,20),
            //        new SqlParameter("@RoleName", SqlDbType.NChar,50),
            //        new SqlParameter("@Status", SqlDbType.Int,4),
            //        new SqlParameter("@IsAdmin", SqlDbType.Bit,1),
            //        new SqlParameter("@OrganID", SqlDbType.Int,4),
            //        new SqlParameter("@SubSystemCode", SqlDbType.VarChar,10)};
            //parameters[0].Value = model.RoleCode;
            //parameters[1].Value = model.RoleName;
            //parameters[2].Value = model.Status;
            //parameters[3].Value = model.IsAdmin;
            //parameters[4].Value = model.OrganID;
            //parameters[5].Value = model.SubSystemCode;

            //object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            //if (obj == null)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}

            SqlParameter[] parameters = {
					new SqlParameter("@name", model.RoleName),
					new SqlParameter("@subSystemCode", "S001"),
                    new SqlParameter("@isAdmin",false),
                    new SqlParameter("@InputBy", model.InputBy),
					new SqlParameter("@organID", model.OrganID)};
            int re = 0;
            DbHelperSQL.RunProcedure("Proc_AddRole", parameters, out re);
            return re;


        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Role set ");
            strSql.Append("RoleName=@RoleName");
            strSql.Append(" where RoleCode=@RoleCode");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", model.RoleName),
					new SqlParameter("@RoleCode", model.RoleCode)};

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
            strSql.Append("delete from Role ");
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
        public bool Delete(string RoleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Role ");
            strSql.Append(" where RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleCode", SqlDbType.VarChar,20)			};
            parameters[0].Value = RoleCode;

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
            strSql.Append("delete from Role ");
            strSql.Append(" where RoleCode in (" + IDlist + ")  ");
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
        public Role GetModel(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Role ");
            strSql.Append(" where RoleCode=@Code");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", code)
			};

            Role model = new Role();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleCode"] != null && ds.Tables[0].Rows[0]["RoleCode"].ToString() != "")
                {
                    model.RoleCode = ds.Tables[0].Rows[0]["RoleCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RoleName"] != null && ds.Tables[0].Rows[0]["RoleName"].ToString() != "")
                {
                    model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsAdmin"] != null && ds.Tables[0].Rows[0]["IsAdmin"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsAdmin"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsAdmin"].ToString().ToLower() == "true"))
                    {
                        model.IsAdmin = true;
                    }
                    else
                    {
                        model.IsAdmin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["OrganID"] != null && ds.Tables[0].Rows[0]["OrganID"].ToString() != "")
                {
                    model.OrganID = int.Parse(ds.Tables[0].Rows[0]["OrganID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubSystemCode"] != null && ds.Tables[0].Rows[0]["SubSystemCode"].ToString() != "")
                {
                    model.SubSystemCode = ds.Tables[0].Rows[0]["SubSystemCode"].ToString();
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
            strSql.Append(" FROM Role ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM Role ");
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
            strSql.Append("select count(1) FROM Role ");
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
            strSql.Append(")AS Row, T.*  from Role T ");
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
            parameters[0].Value = "Role";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="posiName"></param>
        /// <param name="organID"></param>
        /// <returns></returns>
        public string GetRoleCode(string name, int organID)
        {
            string sql = "SELECT RoleCode FROM Role where RoleName=@name AND OrganID=@organID";
            SqlParameter[] parameters = {
					new SqlParameter("@name", name),
	                new SqlParameter("@organID",organID)
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
