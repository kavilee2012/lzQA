using System;
using System.Collections.Generic;
using System.Text;
using SqlServerDAL;
using System.Data;
using Model;

namespace BLL
{
    public class ObjectGroupBLL
    {
        private readonly ObjectGroupDAL dal = new ObjectGroupDAL();

		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Code)
		{
			return dal.Exists(Code);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ObjectGroup model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ObjectGroup model)
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
		public bool Delete(string Code)
		{
			
			return dal.Delete(Code);
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
		public ObjectGroup GetModel(string code)
		{
			
			return dal.GetModel(code);
		}

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
		public List<ObjectGroup> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ObjectGroup> DataTableToList(DataTable dt)
		{
			List<ObjectGroup> modelList = new List<ObjectGroup>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ObjectGroup model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ObjectGroup();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["Code"]!=null && dt.Rows[n]["Code"].ToString()!="")
					{
					model.Code=dt.Rows[n]["Code"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["TypeCode"]!=null && dt.Rows[n]["TypeCode"].ToString()!="")
					{
					model.TypeCode=dt.Rows[n]["TypeCode"].ToString();
					}
					if(dt.Rows[n]["OrganID"]!=null && dt.Rows[n]["OrganID"].ToString()!="")
					{
						model.OrganID=int.Parse(dt.Rows[n]["OrganID"].ToString());
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

        public string GetObjectGroupCode(string name, int organID)
        {
            return dal.GetObjectGroupCode(name, organID);
        }

		#endregion  Method
    }
}
