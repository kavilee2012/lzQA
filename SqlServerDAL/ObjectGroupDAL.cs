using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Data;

namespace SqlServerDAL
{
    public class ObjectGroupDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ObjectGroup");
            strSql.Append(" where Code=@Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20)			};
            parameters[0].Value = Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ObjectGroup model)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("insert into ObjectGroup(");
            //strSql.Append("Code,Name,TypeCode,OrganID)");
            //strSql.Append(" values (");
            //strSql.Append("@Code,@Name,@TypeCode,@OrganID)");
            //strSql.Append(";select @@IDENTITY");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@name", model.Name),
            //        new SqlParameter("@typeCode", model.TypeCode),
            //        new SqlParameter("@organID", model.OrganID)};
            //parameters[0].Value = model.Code;
            //parameters[1].Value = model.Name;
            //parameters[2].Value = model.TypeCode;
            //parameters[3].Value = model.OrganID;

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
					new SqlParameter("@name", model.Name),
					new SqlParameter("@typeCode", model.TypeCode),
                    new SqlParameter("@InputBy", model.InputBy),
					new SqlParameter("@organID", model.OrganID)};
            int re=0;
            DbHelperSQL.RunProcedure("Proc_AddObjectGroup", parameters,out re);
            return re;


        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ObjectGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ObjectGroup set ");
            strSql.Append("Name=@Name,");
            strSql.Append("TypeCode=@TypeCode");
            strSql.Append(" where Code=@Code");
            SqlParameter[] parameters = {
					new SqlParameter("@Name",model.Name),
					new SqlParameter("@TypeCode", model.TypeCode),
					new SqlParameter("@Code",model.Code)};

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
            strSql.Append("delete from ObjectGroup ");
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
        public bool Delete(string Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ObjectGroup ");
            strSql.Append(" where Code=@Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20)			};
            parameters[0].Value = Code;

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
            strSql.Append("delete from ObjectGroup ");
            strSql.Append(" where Code in (" + IDlist + ")  ");
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
        public ObjectGroup GetModel(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from ObjectGroup");
            strSql.Append(" where Code=@Code");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20)
			};
            parameters[0].Value = code;

            ObjectGroup model = new ObjectGroup();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Code"] != null && ds.Tables[0].Rows[0]["Code"].ToString() != "")
                {
                    model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TypeCode"] != null && ds.Tables[0].Rows[0]["TypeCode"].ToString() != "")
                {
                    model.TypeCode = ds.Tables[0].Rows[0]["TypeCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrganID"] != null && ds.Tables[0].Rows[0]["OrganID"].ToString() != "")
                {
                    model.OrganID = int.Parse(ds.Tables[0].Rows[0]["OrganID"].ToString());
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
            strSql.Append(" FROM ObjectGroup ");
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
            strSql.Append(" FROM ObjectGroup ");
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
            strSql.Append("select count(1) FROM ObjectGroup ");
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
            strSql.Append(")AS Row, T.*  from ObjectGroup T ");
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
            parameters[0].Value = "ObjectGroup";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        public string GetObjectGroupCode(string name, int organID)
        {
            string sql = "SELECT Code FROM ObjectGroup WHERE Name = '" + name + "' AND OrganID =" + organID;
            object re = DbHelperSQL.GetSingle(sql);
            if (re == null || re == DBNull.Value)
            {
                return "";
            }
            else
            {
                return re.ToString();
            }
        }
    }
}
