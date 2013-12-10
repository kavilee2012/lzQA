using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SqlServerDAL
{
    public class PositionDAL
    {
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PosiCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Position");
            strSql.Append(" where PosiCode=@PosiCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PosiCode", SqlDbType.VarChar,50)			};
            parameters[0].Value = PosiCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name,int organID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Position");
            strSql.Append(" where PosiName=@name and OrganID = @organID");
            SqlParameter[] parameters = {
					new SqlParameter("@name", name),
                    new SqlParameter("@organID",organID)
                                        };

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Position model)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("insert into Position(");
            //strSql.Append("ID,PosiCode,PosiName,FatherCode,OrganID)");
            //strSql.Append(" values (");
            //strSql.Append("@ID,@PosiCode,@PosiName,@FatherCode,@OrganID)");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@ID", SqlDbType.Int,4),
            //        new SqlParameter("@PosiCode", SqlDbType.VarChar,50),
            //        new SqlParameter("@PosiName", SqlDbType.VarChar,50),
            //        new SqlParameter("@FatherCode", SqlDbType.VarChar,50),
            //        new SqlParameter("@OrganID", SqlDbType.Int,4)};
            //parameters[0].Value = model.ID;
            //parameters[1].Value = model.PosiCode;
            //parameters[2].Value = model.PosiName;
            //parameters[3].Value = model.FatherCode;
            //parameters[4].Value = model.OrganID;

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
					new SqlParameter("@name", model.PosiName),
					new SqlParameter("@fatherCode", model.FatherCode),
                    new SqlParameter("@InputBy", model.InputBy),
					new SqlParameter("@organID", model.OrganID)};
            int re = 0;
            DbHelperSQL.RunProcedure("Proc_AddPosition", parameters, out re);
            if (re > 0)
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
        public bool Update(Position model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Position set ");
            strSql.Append("PosiName=@PosiName,");
            strSql.Append("FatherCode=@FatherCode,");
            strSql.Append("OrganID=@OrganID");
            strSql.Append(" where PosiCode=@PosiCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PosiName",  model.PosiName),
					new SqlParameter("@FatherCode", model.FatherCode),
					new SqlParameter("@OrganID", model.OrganID),
					new SqlParameter("@PosiCode", model.PosiCode)};

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
        public bool Delete(string PosiCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Position ");
            strSql.Append(" where PosiCode=@PosiCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PosiCode", SqlDbType.VarChar,50)			};
            parameters[0].Value = PosiCode;

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
        public bool DeleteList(string PosiCodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Position ");
            strSql.Append(" where PosiCode in (" + PosiCodelist + ")  ");
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
        public Position GetModel(string PosiCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Position ");
            strSql.Append(" where PosiCode=@PosiCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PosiCode", SqlDbType.VarChar,50)			};
            parameters[0].Value = PosiCode;

            Position model = new Position();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PosiCode"] != null && ds.Tables[0].Rows[0]["PosiCode"].ToString() != "")
                {
                    model.PosiCode = ds.Tables[0].Rows[0]["PosiCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PosiName"] != null && ds.Tables[0].Rows[0]["PosiName"].ToString() != "")
                {
                    model.PosiName = ds.Tables[0].Rows[0]["PosiName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FatherCode"] != null && ds.Tables[0].Rows[0]["FatherCode"].ToString() != "")
                {
                    model.FatherCode = ds.Tables[0].Rows[0]["FatherCode"].ToString();
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
        /// 获取编号
        /// </summary>
        /// <param name="posiName"></param>
        /// <param name="organID"></param>
        /// <returns></returns>
        public string GetPosiCode(string posiName,int organID)
        {
            string sql = "SELECT PosiCode FROM Position WHERE PosiName=@name AND OrganID=@organID";
            SqlParameter[] parameters = {
					new SqlParameter("@name", posiName),
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Position ");
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
            strSql.Append(" FROM Position ");
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
            strSql.Append("select count(1) FROM Position ");
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
                strSql.Append("order by T.PosiCode desc");
            }
            strSql.Append(")AS Row, T.*  from Position T ");
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
            parameters[0].Value = "Position";
            parameters[1].Value = "PosiCode";
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
        public DataSet GetPositionObjectGroup(string posiCode)
        {
            string sql = "SELECT * FROM Posi2ObjectGroup A JOIN ObjectGroup B ON A.ObjectGroupCode = B.Code WHERE PosiCode = '" + posiCode + "' AND SubSystemCode = 'S001'";
            return DbHelperSQL.Query(sql);
        }


        /// <summary>
        /// 分配数据组
        /// </summary>
        /// <param name="posiCode"></param>
        /// <param name="groupCodeArr"></param>
        /// <returns></returns>
        public int AddPosi2ObjectGroup(string posiCode,List<string> groupCodeArr)
        {
            ArrayList sqlT = new ArrayList();
            sqlT.Add("DELETE FROM Posi2ObjectGroup WHERE PosiCode='" + posiCode + "';");
            foreach (string c in groupCodeArr)
            {
                string sql = "INSERT INTO Posi2ObjectGroup(PosiCode,ObjectGroupCode) VALUES('" + posiCode + "','" + c + "');";
                sqlT.Add(sql);
            }
            try
            {
                DbHelperSQL.ExecuteSqlTran(sqlT);
            }
            catch (Exception ex)
            {
                string s= ex.Message;
                return 0;
            }
            return 1;
        }


        /// <summary>
        /// 攻取某职位授权的数据对象
        /// </summary>
        /// <param name="posiCode"></param>
        /// <returns></returns>
        public DataSet GetPosition2Role(string posiCode)
        {
            string sql = "SELECT * FROM Posi2Role A JOIN Role B ON A.RoleCode = B.RoleCode WHERE PosiCode = '" + posiCode + "'";
            return DbHelperSQL.Query(sql);
        }


        /// <summary>
        /// 分配数据组
        /// </summary>
        /// <param name="posiCode"></param>
        /// <param name="groupCodeArr"></param>
        /// <returns></returns>
        public int AddPosi2Role(string posiCode, List<string> roleCodeArr)
        {
            ArrayList sqlT = new ArrayList();
            sqlT.Add("DELETE FROM Posi2Role WHERE PosiCode='" + posiCode + "';");
            foreach (string c in roleCodeArr)
            {
                string sql = "INSERT INTO Posi2Role(PosiCode,RoleCode) VALUES('" + posiCode + "','" + c + "');";
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



        /// <summary>
        /// 攻取某职位授权的数据对象
        /// </summary>
        /// <param name="posiCode"></param>
        /// <returns></returns>
        public DataSet GetPosi2User(string userID)
        {
            string sql = "SELECT * FROM Posi2User A JOIN Position B ON A.PosiCode = B.PosiCode WHERE UserID = '" + userID + "'";
            return DbHelperSQL.Query(sql);
        }


        /// <summary>
        /// 分配数据组
        /// </summary>
        /// <param name="posiCode"></param>
        /// <param name="groupCodeArr"></param>
        /// <returns></returns>
        public int AddPosi2User(string userID, List<string> posiCodeArr)
        {
            ArrayList sqlT = new ArrayList();
            sqlT.Add("DELETE FROM Posi2User WHERE UserID='" + userID + "';");
            foreach (string c in posiCodeArr)
            {
                string sql = "INSERT INTO Posi2User(UserID,PosiCode) VALUES('" + userID + "','" + c + "');";
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

        #endregion  Method
    }
}
