using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using SqlServerDAL;

namespace BLL
{
    public class RoleBLL
    {
        private readonly RoleDAL dal = new RoleDAL();
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string RoleCode)
		{
			return dal.Exists(RoleCode);
		}

        

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name, int organID)
        {
            return dal.Exists(name, organID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Role model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Role model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string RoleCode)
		{
			
			return dal.Delete(RoleCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Role GetModel(string code)
		{
			
			return dal.GetModel(code);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetOrganList(int organID)
        {
            string strWhere = "OrganID IN(0," + organID + ")";
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
		public List<Role> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Role> DataTableToList(DataTable dt)
		{
			List<Role> modelList = new List<Role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Role model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Role();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["RoleCode"]!=null && dt.Rows[n]["RoleCode"].ToString()!="")
					{
					model.RoleCode=dt.Rows[n]["RoleCode"].ToString();
					}
					if(dt.Rows[n]["RoleName"]!=null && dt.Rows[n]["RoleName"].ToString()!="")
					{
					model.RoleName=dt.Rows[n]["RoleName"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["IsAdmin"]!=null && dt.Rows[n]["IsAdmin"].ToString()!="")
					{
						if((dt.Rows[n]["IsAdmin"].ToString()=="1")||(dt.Rows[n]["IsAdmin"].ToString().ToLower()=="true"))
						{
						model.IsAdmin=true;
						}
						else
						{
							model.IsAdmin=false;
						}
					}
					if(dt.Rows[n]["OrganID"]!=null && dt.Rows[n]["OrganID"].ToString()!="")
					{
						model.OrganID=int.Parse(dt.Rows[n]["OrganID"].ToString());
					}
					if(dt.Rows[n]["SubSystemCode"]!=null && dt.Rows[n]["SubSystemCode"].ToString()!="")
					{
					model.SubSystemCode=dt.Rows[n]["SubSystemCode"].ToString();
					}
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

                /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="posiName"></param>
        /// <param name="organID"></param>
        /// <returns></returns>
        public string GetRoleCode(string name, int organID)
        {
            return dal.GetRoleCode(name, organID);
        }
        

		#endregion  Method
    }
}
