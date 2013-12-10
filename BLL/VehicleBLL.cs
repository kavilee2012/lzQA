using System;
using System.Data;
using System.Collections.Generic;
using SqlServerDAL;
using System.Text;
using Model;
namespace BLL
{
	/// <summary>
	/// 业务逻辑类Vehicle 的摘要说明。
	/// </summary>
	public class VehicleBLL
	{
        public VehicleBLL()
        { 
        
        }
        private readonly VehicleDAL dal = new VehicleDAL();

		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FrameNO)
		{
			return dal.Exists(FrameNO);
		}


        /// <summary>
        /// 根据车牌号返回车架号
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        public string GetFrameNO(string vehicleID)
        {
            return dal.GetFrameNO(vehicleID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Vehicle model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.Vehicle model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string FrameNO)
		{
			
			dal.Delete(FrameNO);
		}

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Vehicle ");
            strSql.Append(" where FrameNO in (" + idlist + ")  ");
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
		public Model.Vehicle GetModel(string FrameNO)
		{
			
			return dal.GetModel(FrameNO);
		}

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="VehicleID"></param>
        /// <param name="type">0：车牌号 1：车架号</param>
        /// <returns></returns>
        public Vehicle GetModel_Type(string VehicleID, int type, string gpList, string organList)
        {
            return dal.GetModel_Type(VehicleID, type, gpList, organList);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中。
        ///// </summary>
        //public Model.Vehicle GetModelByCache(int ID,string FrameNO)
        //{
			
        //    string CacheKey = "VehicleModel-" + ID+FrameNO;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID,FrameNO);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.Vehicle)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetOrganList(int organID)
        {
            string strWhere = "OrganID = " + organID;
            return dal.GetList(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Vehicle> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Vehicle> DataTableToList(DataTable dt)
		{
			List<Model.Vehicle> modelList = new List<Model.Vehicle>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Vehicle model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Model.Vehicle();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.VehicleID=dt.Rows[n]["VehicleID"].ToString();
					model.FrameNO=dt.Rows[n]["FrameNO"].ToString();
					if(dt.Rows[n]["VehicleType"].ToString()!="")
					{
						model.VehicleType=int.Parse(dt.Rows[n]["VehicleType"].ToString());
					}
					if(dt.Rows[n]["VehiclePrice"].ToString()!="")
					{
						model.VehiclePrice=decimal.Parse(dt.Rows[n]["VehiclePrice"].ToString());
					}
					if(dt.Rows[n]["StartUseDate"].ToString()!="")
					{
						model.StartUseDate=DateTime.Parse(dt.Rows[n]["StartUseDate"].ToString());
					}
					model.KeepPerson=dt.Rows[n]["KeepPerson"].ToString();
					model.BackupKeyPerson=dt.Rows[n]["BackupKeyPerson"].ToString();
					if(dt.Rows[n]["PlanScrapDate"].ToString()!="")
					{
						model.PlanScrapDate=DateTime.Parse(dt.Rows[n]["PlanScrapDate"].ToString());
					}
					if(dt.Rows[n]["OrganID"].ToString()!="")
					{
						model.OrganID=int.Parse(dt.Rows[n]["OrganID"].ToString());
					}
                    if (dt.Rows[n]["IsPrivate"].ToString() != "")
                    {
                        model.IsPrivate = bool.Parse(dt.Rows[n]["IsPrivate"].ToString());
                    }
					model.ChargePerson=dt.Rows[n]["ChargePerson"].ToString();
					model.SuperChargePerson=dt.Rows[n]["SuperChargePerson"].ToString();
                    model.Photo = dt.Rows[n]["Photo"].ToString();
                    model.ObjectGroup = dt.Rows[n]["ObjectGroup"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        public DataTable GetVehicleType()
        {
            return dal.GetVehicleType();
        }

        public string GetTypeName(int id)
        {
            return dal.GetTypeName(id);
        }
		#endregion  成员方法
	}
}

