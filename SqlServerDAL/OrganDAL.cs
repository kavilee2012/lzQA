using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SqlServerDAL
{
    public class OrganDAL
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("OrganID", "Organ");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OrganID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Organ");
            strSql.Append(" where OrganID=@OrganID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrganID", SqlDbType.Int,4)			};
            parameters[0].Value = OrganID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Organ model)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("insert into Organ(OrganID,OrganName,Remark,Superior,Level)");
            //strSql.Append(" SELECT (Max(OrganID)+1),@OrganName,@Remark,@Superior,@Level FROM Organ ");

            //SqlParameter[] parameters = {
            //        new SqlParameter("@OrganName", model.OrganName),
            //        new SqlParameter("@Remark", model.Remark == null ? "" : model.Remark),
            //        new SqlParameter("@Superior", model.Superior == null ? 0 : model.Superior),
            //        new SqlParameter("@Level", model.Level)
            //                            };

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


            SqlParameter[] parameters = {
					new SqlParameter("@OrganName", model.OrganName),
					new SqlParameter("@Remark", model.Remark == null ? "" : model.Remark),
					new SqlParameter("@Superior", model.Superior == null ? 0 : model.Superior),
					new SqlParameter("@Level", model.Level),
                    new SqlParameter("@InputBy",model.InputBy)
                                        };
            int re = 0;
            DbHelperSQL.RunProcedure("Proc_AddOrgan", parameters, out re);
            return (re>0);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Organ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Organ set ");
            strSql.Append("OrganName=@OrganName,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Superior=@Superior,");
            strSql.Append("Level=@Level");
            strSql.Append(" where OrganID=@OrganID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrganName", model.OrganName),
					new SqlParameter("@Remark", model.Remark == null ? "" : model.Remark),
					new SqlParameter("@Superior", model.Superior == null ? 0 : model.Superior),
					new SqlParameter("@Level", model.Level),
					new SqlParameter("@OrganID", model.OrganID)};

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
        public bool Delete(int OrganID)
        {
            ArrayList sqlT = new ArrayList();
            sqlT.Add("delete from Organ where OrganID=" + OrganID);
            sqlT.Add("delete from [Role] where substring(RoleCode,3,4) = " + OrganID);
            sqlT.Add("delete from [User] where substring(UserID,3,4) = " + OrganID);
            sqlT.Add("delete from Role2Function where substring(RoleCode,3,4) = " + OrganID);
            sqlT.Add("delete from Role2User where substring(RoleCode,3,4) = " + OrganID);

            try
            {
                DbHelperSQL.ExecuteSqlTran(sqlT);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string OrganIDlist)
        {
            ArrayList sqlT = new ArrayList();
            sqlT.Add("delete from Organ where OrganID in (" + OrganIDlist + ")");
            sqlT.Add("delete from [Role] where substring(RoleCode,3,4) in (" + OrganIDlist + ")");
            sqlT.Add("delete from [User] where substring(UserID,3,4) in (" + OrganIDlist + ")");
            sqlT.Add("delete from Role2Function where substring(RoleCode,3,4) in (" + OrganIDlist + ")");
            sqlT.Add("delete from Role2User where substring(RoleCode,3,4) in (" + OrganIDlist + ")");

            try
            {
                DbHelperSQL.ExecuteSqlTran(sqlT);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Organ GetModel(int OrganID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrganID,OrganName,Remark,Superior,Level from Organ ");
            strSql.Append(" where OrganID=@OrganID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrganID", SqlDbType.Int,4)			};
            parameters[0].Value = OrganID;

            Organ model = new Organ();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrganID"] != null && ds.Tables[0].Rows[0]["OrganID"].ToString() != "")
                {
                    model.OrganID = int.Parse(ds.Tables[0].Rows[0]["OrganID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrganName"] != null && ds.Tables[0].Rows[0]["OrganName"].ToString() != "")
                {
                    model.OrganName = ds.Tables[0].Rows[0]["OrganName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Superior"] != null && ds.Tables[0].Rows[0]["Superior"].ToString() != "")
                {
                    model.Superior = int.Parse(ds.Tables[0].Rows[0]["Superior"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"] != null && ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
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
            strSql.Append("select OrganID,OrganName,Remark,Superior,Level ");
            strSql.Append(" FROM Organ ");
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
            strSql.Append(" OrganID,OrganName,Remark,Superior,Level ");
            strSql.Append(" FROM Organ ");
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
            strSql.Append("select count(1) FROM Organ ");
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
                strSql.Append("order by T.OrganID desc");
            }
            strSql.Append(")AS Row, T.*  from Organ T ");
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
            parameters[0].Value = "Organ";
            parameters[1].Value = "OrganID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

    }
}
