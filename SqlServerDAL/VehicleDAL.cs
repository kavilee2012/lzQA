using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
namespace SqlServerDAL
{
	/// <summary>
	/// 数据访问类Vehicle。
	/// </summary>
	public class VehicleDAL
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FrameNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Vehicle");
			strSql.Append(" where FrameNO=@FrameNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@FrameNO", FrameNO)};
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 根据车牌号返回车架号
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        public string GetFrameNO(string vehicleID)
        {
            string sql = "SELECT FrameNO FROM Vehicle WHERE VehicleID = '" + vehicleID + "'";
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


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Vehicle model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("if not exists(select * from Vehicle where frameNO = @FrameNO) insert into Vehicle(");
            strSql.Append("VehicleID,FrameNO,VehicleType,VehiclePrice,StartUseDate,KeepPerson,BackupKeyPerson,PlanScrapDate,OrganID,ChargePerson,SuperChargePerson,Photo,ObjectGroup,InputBy,IsPrivate)");
			strSql.Append(" values (");
            strSql.Append("@VehicleID,@FrameNO,@VehicleType,@VehiclePrice,@StartUseDate,@KeepPerson,@BackupKeyPerson,@PlanScrapDate,@OrganID,@ChargePerson,@SuperChargePerson,@Photo,@ObjectGroup,@InputBy,@IsPrivate)");
			SqlParameter[] parameters = {
					new SqlParameter("@VehicleID", model.VehicleID==null?"":model.VehicleID),
					new SqlParameter("@FrameNO", model.FrameNO),
					new SqlParameter("@VehicleType", model.VehicleType==null?0:model.VehicleType),
					new SqlParameter("@VehiclePrice", model.VehiclePrice==null?0:model.VehiclePrice),
					new SqlParameter("@StartUseDate", model.StartUseDate==null?DateTime.Parse("1900-1-1"):model.StartUseDate),
					new SqlParameter("@KeepPerson", model.KeepPerson==null?"":model.KeepPerson),
					new SqlParameter("@BackupKeyPerson", model.BackupKeyPerson==null?"":model.BackupKeyPerson),
					new SqlParameter("@PlanScrapDate", model.PlanScrapDate==null?DateTime.Parse("1900-1-1"):model.PlanScrapDate),
					new SqlParameter("@OrganID", model.OrganID),
					new SqlParameter("@ChargePerson", model.ChargePerson==null?"":model.ChargePerson),
					new SqlParameter("@SuperChargePerson", model.SuperChargePerson==null?"":model.SuperChargePerson),
                    new SqlParameter("@Photo", model.Photo==null?"":model.Photo),
                    new SqlParameter("@InputBy", model.InputBy),
                    new SqlParameter("@ObjectGroup", model.ObjectGroup==null?"":model.ObjectGroup),
                    new SqlParameter("@IsPrivate", model.IsPrivate==null?false:model.IsPrivate)
                                        };

			int obj = DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return obj;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Vehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Vehicle set ");
			strSql.Append("VehicleID=@VehicleID,");
			strSql.Append("VehicleType=@VehicleType,");
			strSql.Append("VehiclePrice=@VehiclePrice,");
			strSql.Append("StartUseDate=@StartUseDate,");
			strSql.Append("KeepPerson=@KeepPerson,");
			strSql.Append("BackupKeyPerson=@BackupKeyPerson,");
			strSql.Append("PlanScrapDate=@PlanScrapDate,");
			strSql.Append("ChargePerson=@ChargePerson,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("ObjectGroup=@ObjectGroup,");
            strSql.Append("IsPrivate=@IsPrivate,");
            strSql.Append("OrganID=@OrganID,");
			strSql.Append("SuperChargePerson=@SuperChargePerson");
            strSql.Append(" where FrameNO=@FrameNO");
			SqlParameter[] parameters = {
					new SqlParameter("@VehicleID", model.VehicleID==null?"":model.VehicleID),
					new SqlParameter("@FrameNO", model.FrameNO),
					new SqlParameter("@VehicleType", model.VehicleType==null?0:model.VehicleType),
					new SqlParameter("@VehiclePrice", model.VehiclePrice==null?0:model.VehiclePrice),
					new SqlParameter("@StartUseDate", model.StartUseDate==null?DateTime.Parse("1900-1-1"):model.StartUseDate),
					new SqlParameter("@KeepPerson", model.KeepPerson==null?"":model.KeepPerson),
					new SqlParameter("@BackupKeyPerson", model.BackupKeyPerson==null?"":model.BackupKeyPerson),
					new SqlParameter("@PlanScrapDate", model.PlanScrapDate==null?DateTime.Parse("1900-1-1"):model.PlanScrapDate),
					new SqlParameter("@ChargePerson", model.ChargePerson==null?"":model.ChargePerson),
					new SqlParameter("@SuperChargePerson", model.SuperChargePerson==null?"":model.SuperChargePerson),
                    new SqlParameter("@Photo", model.Photo==null?"":model.Photo),
                    new SqlParameter("@OrganID", model.OrganID),
                    new SqlParameter("@IsPrivate", model.IsPrivate==null?false:model.IsPrivate),
                    new SqlParameter("@ObjectGroup", model.ObjectGroup==null?"":model.ObjectGroup)
                                        };

			int re = DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return re;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string FrameNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Vehicle ");
			strSql.Append(" where FrameNO=@FrameNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@FrameNO", FrameNO)};

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Vehicle GetModel(string FrameNO)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,VehicleID,FrameNO,VehicleType,VehiclePrice,StartUseDate,KeepPerson,BackupKeyPerson,PlanScrapDate,OrganID,ChargePerson,SuperChargePerson,Photo,ObjectGroup,IsPrivate from Vehicle ");
			strSql.Append(" where FrameNO=@FrameNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@FrameNO", SqlDbType.VarChar,50)};
			parameters[0].Value = FrameNO;

			Vehicle model=new Vehicle();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.VehicleID=ds.Tables[0].Rows[0]["VehicleID"].ToString();
				model.FrameNO=ds.Tables[0].Rows[0]["FrameNO"].ToString();
				if(ds.Tables[0].Rows[0]["VehicleType"].ToString()!="")
				{
					model.VehicleType=int.Parse(ds.Tables[0].Rows[0]["VehicleType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VehiclePrice"].ToString()!="")
				{
					model.VehiclePrice=decimal.Parse(ds.Tables[0].Rows[0]["VehiclePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StartUseDate"].ToString()!="")
				{
					model.StartUseDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartUseDate"].ToString());
				}
				model.KeepPerson=ds.Tables[0].Rows[0]["KeepPerson"].ToString();
				model.BackupKeyPerson=ds.Tables[0].Rows[0]["BackupKeyPerson"].ToString();
				if(ds.Tables[0].Rows[0]["PlanScrapDate"].ToString()!="")
				{
					model.PlanScrapDate=DateTime.Parse(ds.Tables[0].Rows[0]["PlanScrapDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrganID"].ToString()!="")
				{
					model.OrganID=int.Parse(ds.Tables[0].Rows[0]["OrganID"].ToString());
				}
                if (ds.Tables[0].Rows[0]["IsPrivate"].ToString() != "")
                {
                    model.IsPrivate = bool.Parse(ds.Tables[0].Rows[0]["IsPrivate"].ToString());
                }
				model.ChargePerson=ds.Tables[0].Rows[0]["ChargePerson"].ToString();
				model.SuperChargePerson=ds.Tables[0].Rows[0]["SuperChargePerson"].ToString();
                model.Photo = ds.Tables[0].Rows[0]["Photo"].ToString();
                model.ObjectGroup = ds.Tables[0].Rows[0]["ObjectGroup"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Vehicle GetModel_Type(string VehicleID,int type,string gpList,string organList)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,VehicleID,FrameNO,VehicleType,VehiclePrice,StartUseDate,KeepPerson,BackupKeyPerson,PlanScrapDate,OrganID,ChargePerson,SuperChargePerson,Photo,ObjectGroup,IsPrivate from Vehicle ");
            if (type == 0)
            {
                strSql.Append(" where VehicleID=@VehicleID ");
            }
            else
            {
                strSql.Append(" where FrameNO=@VehicleID ");
            }

            string strWhere = "";
            if (gpList != string.Empty)
            {
                strWhere += " AND  ObjectGroup IN(" + gpList + ")";
            }
            if (organList != string.Empty)
            {
                strWhere += " AND  OrganID IN(" + organList + ")";
            }
            if (strWhere.Length > 0)
            {
                //strWhere = strWhere.Substring(5);
                strSql.Append(strWhere);
            }

            SqlParameter[] parameters = {
					new SqlParameter("@VehicleID", VehicleID)};

            Vehicle model = new Vehicle();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.VehicleID = ds.Tables[0].Rows[0]["VehicleID"].ToString();
                model.FrameNO = ds.Tables[0].Rows[0]["FrameNO"].ToString();
                if (ds.Tables[0].Rows[0]["VehicleType"].ToString() != "")
                {
                    model.VehicleType = int.Parse(ds.Tables[0].Rows[0]["VehicleType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VehiclePrice"].ToString() != "")
                {
                    model.VehiclePrice = decimal.Parse(ds.Tables[0].Rows[0]["VehiclePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartUseDate"].ToString() != "")
                {
                    model.StartUseDate = DateTime.Parse(ds.Tables[0].Rows[0]["StartUseDate"].ToString());
                }
                model.KeepPerson = ds.Tables[0].Rows[0]["KeepPerson"].ToString();
                model.BackupKeyPerson = ds.Tables[0].Rows[0]["BackupKeyPerson"].ToString();
                if (ds.Tables[0].Rows[0]["PlanScrapDate"].ToString() != "")
                {
                    model.PlanScrapDate = DateTime.Parse(ds.Tables[0].Rows[0]["PlanScrapDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrganID"].ToString() != "")
                {
                    model.OrganID = int.Parse(ds.Tables[0].Rows[0]["OrganID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsPrivate"].ToString() != "")
                {
                    model.IsPrivate = bool.Parse(ds.Tables[0].Rows[0]["IsPrivate"].ToString());
                }
                model.ChargePerson = ds.Tables[0].Rows[0]["ChargePerson"].ToString();
                model.SuperChargePerson = ds.Tables[0].Rows[0]["SuperChargePerson"].ToString();
                model.Photo = ds.Tables[0].Rows[0]["Photo"].ToString();
                model.ObjectGroup = ds.Tables[0].Rows[0]["ObjectGroup"].ToString();
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select * FROM Vehicle ");
			strSql.Append(" ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" * ");
			strSql.Append(" FROM Vehicle ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}


        public DataTable GetVehicleType()
        {
            string sql = "SELECT * FROM VehicleType";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }

        public string GetTypeName(int id)
        {
            string sql = "SELECT TypeName FROM VehicleType where TypeID = " + id;
            object dt = DbHelperSQL.GetSingle(sql);
            if (dt == null || dt == DBNull.Value)
                return "";
            else
                return dt.ToString();
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
			parameters[0].Value = "Vehicle";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

