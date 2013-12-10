using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using SqlServerDAL;

namespace BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL dal=new EmployeeDAL();

		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EmployeeID)
		{
			return dal.Exists(EmployeeID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName, int OrganID)
        {
            return dal.Exists(UserName, OrganID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Employee model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Employee model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string EmployeeID)
		{
			
			return dal.Delete(EmployeeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string EmployeeIDlist )
		{
			return dal.DeleteList(EmployeeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Employee GetModel(string EmployeeID)
		{
			return dal.GetModel(EmployeeID);
		}

        /// <summary>
        /// 获取所有司机信息
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public IList<Employee> GetAllEmployee(int organID)
        {
            string where = " OrganID = " + organID;
            return GetModelList(where);
        }


		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Employee GetModelByCache(string EmployeeID)
        //{
			
        //    string CacheKey = "EmployeeModel-" + EmployeeID;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(EmployeeID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Employee)objModel;
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
		public List<Employee> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Employee> DataTableToList(DataTable dt)
		{
			List<Employee> modelList = new List<Employee>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Employee model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Employee();
					if(dt.Rows[n]["EmployeeID"]!=null && dt.Rows[n]["EmployeeID"].ToString()!="")
					{
					model.EmployeeID=dt.Rows[n]["EmployeeID"].ToString();
					}
					if(dt.Rows[n]["OrganID"]!=null && dt.Rows[n]["OrganID"].ToString()!="")
					{
						model.OrganID=int.Parse(dt.Rows[n]["OrganID"].ToString());
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
                    //if(dt.Rows[n]["Sex"]!=null && dt.Rows[n]["Sex"].ToString()!="")
                    //{
                    //    if((dt.Rows[n]["Sex"].ToString()=="1")||(dt.Rows[n]["Sex"].ToString().ToLower()=="true"))
                    //    {
                    //    model.Sex=true;
                    //    }
                    //    else
                    //    {
                    //        model.Sex=false;
                    //    }
                    //}
                    //if(dt.Rows[n]["Native"]!=null && dt.Rows[n]["Native"].ToString()!="")
                    //{
                    //model.Native=dt.Rows[n]["Native"].ToString();
                    //}
                    //if(dt.Rows[n]["Nation"]!=null && dt.Rows[n]["Nation"].ToString()!="")
                    //{
                    //model.Nation=dt.Rows[n]["Nation"].ToString();
                    //}
                    //if(dt.Rows[n]["Education"]!=null && dt.Rows[n]["Education"].ToString()!="")
                    //{
                    //model.Education=dt.Rows[n]["Education"].ToString();
                    //}
                    //if(dt.Rows[n]["PersonID"]!=null && dt.Rows[n]["PersonID"].ToString()!="")
                    //{
                    //model.PersonID=dt.Rows[n]["PersonID"].ToString();
                    //}
                    if (dt.Rows[n]["LeaveDate"] != null && dt.Rows[n]["LeaveDate"].ToString() != "")
					{
                        model.LeaveDate = DateTime.Parse(dt.Rows[n]["LeaveDate"].ToString());
					}
                    //if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
                    //{
                    //model.Address=dt.Rows[n]["Address"].ToString();
                    //}
                    //if(dt.Rows[n]["Telephone"]!=null && dt.Rows[n]["Telephone"].ToString()!="")
                    //{
                    //model.Telephone=dt.Rows[n]["Telephone"].ToString();
                    //}
                    //if(dt.Rows[n]["Mobile"]!=null && dt.Rows[n]["Mobile"].ToString()!="")
                    //{
                    //model.Mobile=dt.Rows[n]["Mobile"].ToString();
                    //}
                    //if(dt.Rows[n]["position"]!=null && dt.Rows[n]["position"].ToString()!="")
                    //{
                    //model.position=dt.Rows[n]["position"].ToString();
                    //}
					if(dt.Rows[n]["JoinDate"]!=null && dt.Rows[n]["JoinDate"].ToString()!="")
					{
						model.JoinDate=DateTime.Parse(dt.Rows[n]["JoinDate"].ToString());
					}
                    //if(dt.Rows[n]["Photo"]!=null && dt.Rows[n]["Photo"].ToString()!="")
                    //{
                    //    model.Photo=(string)dt.Rows[n]["Photo"];
                    //}
                    //if(dt.Rows[n]["StartJobDate"]!=null && dt.Rows[n]["StartJobDate"].ToString()!="")
                    //{
                    //    model.StartJobDate=DateTime.Parse(dt.Rows[n]["StartJobDate"].ToString());
                    //}
                    //if(dt.Rows[n]["DriveLicenseNO"]!=null && dt.Rows[n]["DriveLicenseNO"].ToString()!="")
                    //{
                    //model.DriveLicenseNO=dt.Rows[n]["DriveLicenseNO"].ToString();
                    //}
                    //if(dt.Rows[n]["IssueDepartment"]!=null && dt.Rows[n]["IssueDepartment"].ToString()!="")
                    //{
                    //model.IssueDepartment=dt.Rows[n]["IssueDepartment"].ToString();
                    //}
                    //if(dt.Rows[n]["DL_StartDate"]!=null && dt.Rows[n]["DL_StartDate"].ToString()!="")
                    //{
                    //    model.DL_StartDate=DateTime.Parse(dt.Rows[n]["DL_StartDate"].ToString());
                    //}
                    //if(dt.Rows[n]["DL_EndDate"]!=null && dt.Rows[n]["DL_EndDate"].ToString()!="")
                    //{
                    //    model.DL_EndDate=DateTime.Parse(dt.Rows[n]["DL_EndDate"].ToString());
                    //}
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
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
    }
}
