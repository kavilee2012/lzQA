using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using System.Data.SqlClient;

namespace SqlServerDAL
{
    public class EmployeeDAL
    {
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EmployeeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Employee");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.VarChar,50)			};
            parameters[0].Value = EmployeeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName, int OrganID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Employee]");
            strSql.Append(" where [Name]=@UserName AND OrganID = @OrganID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", UserName),
                    new SqlParameter("@OrganID",OrganID)};

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Employee model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID", model.OrganID),
                    new SqlParameter("@Name", model.Name),
                    new SqlParameter("@JoinDate", model.JoinDate==null?DBNull.Value:(object)model.JoinDate),
                    new SqlParameter("@LeaveDate", model.LeaveDate==null?DBNull.Value:(object)model.LeaveDate),
                    new SqlParameter("@InputBy", model.InputBy),
                    new SqlParameter("@IsPrivate", model.IsPrivate)
                    //new SqlParameter("@Sex", model.Sex),
                    //new SqlParameter("@Nation", model.Nation),
                    //new SqlParameter("@Native", model.Native==null?"":model.Native),
                    //new SqlParameter("@Education", model.Education),
                    //new SqlParameter("@PersonID", model.PersonID),
                    //new SqlParameter("@BirthDate", model.LeaveDate),
                    //new SqlParameter("@Address", model.Address==null?"":model.Address),
                    //new SqlParameter("@Telephone", model.Telephone==null?"":model.Telephone),
                    //new SqlParameter("@Mobile", model.Mobile==null?"":model.Mobile),
                    //new SqlParameter("@position", model.position==null?"":model.position),
                    //new SqlParameter("@JoinDate", model.JoinDate),
                    //new SqlParameter("@Photo", model.Photo==null?"":model.Photo),
                    //new SqlParameter("@DriveLicenseNO", model.DriveLicenseNO==null?"":model.DriveLicenseNO),
                   
                    //new SqlParameter("@InputBy", model.InputBy)
                                        };
            int re = 0;
            DbHelperSQL.RunProcedure("Proc_AddEmployee", parameters, out re);
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
        public bool Update(Employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Employee set ");
            strSql.Append("Name=@Name,");
            strSql.Append("LeaveDate=@LeaveDate,");
            strSql.Append("IsPrivate=@IsPrivate,");
            strSql.Append("OrganID=@OrganID,");
            strSql.Append("JoinDate=@JoinDate");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@LeaveDate", model.LeaveDate),
					new SqlParameter("@JoinDate", model.JoinDate),
                    new SqlParameter("@OrganID", model.OrganID),
                    new SqlParameter("@IsPrivate", model.IsPrivate),
					new SqlParameter("@EmployeeID", model.EmployeeID)
                                        };


            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update Employee set ");
            //strSql.Append("Name=@Name,");
            //strSql.Append("Sex=@Sex,");
            //strSql.Append("Nation=@Nation,");
            //strSql.Append("Native=@Native,");
            //strSql.Append("Education=@Education,");
            //strSql.Append("PersonID=@PersonID,");
            //strSql.Append("BirthDate=@BirthDate,");
            //strSql.Append("Address=@Address,");
            //strSql.Append("Telephone=@Telephone,");
            //strSql.Append("Mobile=@Mobile,");
            //strSql.Append("position=@position,");
            //strSql.Append("JoinDate=@JoinDate,");
            //strSql.Append("Photo=@Photo,");
            //strSql.Append("DriveLicenseNO=@DriveLicenseNO,");
            //strSql.Append("IsDriver=@IsDriver");
            //strSql.Append(" where EmployeeID=@EmployeeID ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@Name", model.Name),
            //        new SqlParameter("@Sex", model.Sex),
            //        new SqlParameter("@Nation", model.Nation),
            //        new SqlParameter("@Native", model.Native==null?"":model.Native),
            //        new SqlParameter("@Education", model.Education),
            //        new SqlParameter("@PersonID", model.PersonID),
            //        new SqlParameter("@BirthDate", model.LeaveDate),
            //        new SqlParameter("@Address", model.Address),
            //        new SqlParameter("@Telephone", model.Telephone==null?"":model.Telephone),
            //        new SqlParameter("@Mobile", model.Mobile==null?"":model.Mobile),
            //        new SqlParameter("@position", model.position==null?"":model.position),
            //        new SqlParameter("@JoinDate", model.JoinDate),
            //        new SqlParameter("@Photo", model.Photo==null?"":model.Photo),
            //        new SqlParameter("@DriveLicenseNO", model.DriveLicenseNO==null?"":model.DriveLicenseNO),
            //        new SqlParameter("@IsDriver", model.IsDriver),
            //        new SqlParameter("@EmployeeID", model.EmployeeID)
            //                            };


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
        public bool Delete(string EmployeeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Employee ");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.VarChar,50)			};
            parameters[0].Value = EmployeeID;

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
        public bool DeleteList(string EmployeeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Employee ");
            strSql.Append(" where EmployeeID in (" + EmployeeIDlist + ")  ");
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
        public Employee GetModel(string EmployeeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Employee ");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.VarChar,50)			};
            parameters[0].Value = EmployeeID;

            Employee model = new Employee();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EmployeeID"] != null && ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrganID"] != null && ds.Tables[0].Rows[0]["OrganID"].ToString() != "")
                {
                    model.OrganID = int.Parse(ds.Tables[0].Rows[0]["OrganID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsPrivate"] != null && ds.Tables[0].Rows[0]["IsPrivate"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsPrivate"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsPrivate"].ToString().ToLower() == "true"))
                    {
                        model.IsPrivate = true;
                    }
                    else
                    {
                        model.IsPrivate = false;
                    }
                }
                //if (ds.Tables[0].Rows[0]["Native"] != null && ds.Tables[0].Rows[0]["Native"].ToString() != "")
                //{
                //    model.Native = ds.Tables[0].Rows[0]["Native"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["Nation"] != null && ds.Tables[0].Rows[0]["Nation"].ToString() != "")
                //{
                //    model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["Education"] != null && ds.Tables[0].Rows[0]["Education"].ToString() != "")
                //{
                //    model.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["PersonID"] != null && ds.Tables[0].Rows[0]["PersonID"].ToString() != "")
                //{
                //    model.PersonID = ds.Tables[0].Rows[0]["PersonID"].ToString();
                //}
                if (ds.Tables[0].Rows[0]["LeaveDate"] != null && ds.Tables[0].Rows[0]["LeaveDate"].ToString() != "")
                {
                    model.LeaveDate = DateTime.Parse(ds.Tables[0].Rows[0]["LeaveDate"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                //{
                //    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["Telephone"] != null && ds.Tables[0].Rows[0]["Telephone"].ToString() != "")
                //{
                //    model.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["Mobile"] != null && ds.Tables[0].Rows[0]["Mobile"].ToString() != "")
                //{
                //    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["position"] != null && ds.Tables[0].Rows[0]["position"].ToString() != "")
                //{
                //    model.position = ds.Tables[0].Rows[0]["position"].ToString();
                //}
                if (ds.Tables[0].Rows[0]["JoinDate"] != null && ds.Tables[0].Rows[0]["JoinDate"].ToString() != "")
                {
                    model.JoinDate = DateTime.Parse(ds.Tables[0].Rows[0]["JoinDate"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["Photo"] != null && ds.Tables[0].Rows[0]["Photo"].ToString() != "")
                //{
                //    model.Photo = (string)ds.Tables[0].Rows[0]["Photo"];
                //}
                //if (ds.Tables[0].Rows[0]["StartJobDate"] != null && ds.Tables[0].Rows[0]["StartJobDate"].ToString() != "")
                //{
                //    model.StartJobDate = DateTime.Parse(ds.Tables[0].Rows[0]["StartJobDate"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["DriveLicenseNO"] != null && ds.Tables[0].Rows[0]["DriveLicenseNO"].ToString() != "")
                //{
                //    model.DriveLicenseNO = ds.Tables[0].Rows[0]["DriveLicenseNO"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["IssueDepartment"] != null && ds.Tables[0].Rows[0]["IssueDepartment"].ToString() != "")
                //{
                //    model.IssueDepartment = ds.Tables[0].Rows[0]["IssueDepartment"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["DL_StartDate"] != null && ds.Tables[0].Rows[0]["DL_StartDate"].ToString() != "")
                //{
                //    model.DL_StartDate = DateTime.Parse(ds.Tables[0].Rows[0]["DL_StartDate"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["DL_EndDate"] != null && ds.Tables[0].Rows[0]["DL_EndDate"].ToString() != "")
                //{
                //    model.DL_EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["DL_EndDate"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["IsDriver"] != null && ds.Tables[0].Rows[0]["IsDriver"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["IsDriver"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsDriver"].ToString().ToLower() == "true"))
                //    {
                //        model.IsDriver = true;
                //    }
                //    else
                //    {
                //        model.IsDriver = false;
                //    }
                //}
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
            strSql.Append(" FROM Employee ");
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
            strSql.Append(" FROM Employee ");
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
            strSql.Append("select count(1) FROM Employee ");
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
                strSql.Append("order by T.EmployeeID desc");
            }
            strSql.Append(")AS Row, T.*  from Employee T ");
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
            parameters[0].Value = "Employee";
            parameters[1].Value = "EmployeeID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
