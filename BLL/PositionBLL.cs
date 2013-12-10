using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using SqlServerDAL;

namespace BLL
{
    public class PositionBLL
    {
        private readonly PositionDAL dal = new PositionDAL();

		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PosiCode)
		{
			return dal.Exists(PosiCode);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name,int organID)
        {
            return dal.Exists(name,organID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Position model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Position model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PosiCode)
		{
			
			return dal.Delete(PosiCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PosiCodelist )
		{
			return dal.DeleteList(PosiCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Position GetModel(string PosiCode)
		{
			
			return dal.GetModel(PosiCode);
		}

                /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="posiName"></param>
        /// <param name="organID"></param>
        /// <returns></returns>
        public string GetPosiCode(string posiName, int organID)
        {
            return dal.GetPosiCode(posiName, organID);
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
		public List<Position> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Position> DataTableToList(DataTable dt)
		{
			List<Position> modelList = new List<Position>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Position model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Position();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["PosiCode"]!=null && dt.Rows[n]["PosiCode"].ToString()!="")
					{
					model.PosiCode=dt.Rows[n]["PosiCode"].ToString();
					}
					if(dt.Rows[n]["PosiName"]!=null && dt.Rows[n]["PosiName"].ToString()!="")
					{
					model.PosiName=dt.Rows[n]["PosiName"].ToString();
					}
					if(dt.Rows[n]["FatherCode"]!=null && dt.Rows[n]["FatherCode"].ToString()!="")
					{
					model.FatherCode=dt.Rows[n]["FatherCode"].ToString();
					}
					if(dt.Rows[n]["OrganID"]!=null && dt.Rows[n]["OrganID"].ToString()!="")
					{
						model.OrganID=int.Parse(dt.Rows[n]["OrganID"].ToString());
					}
                    if (dt.Rows[n]["InputTime"] != null && dt.Rows[n]["InputTime"].ToString() != "")
                    {
                        model.InputTime = DateTime.Parse(dt.Rows[n]["InputTime"].ToString());
                    }
                    if (dt.Rows[n]["InputBy"] != null && dt.Rows[n]["InputBy"].ToString() != "")
                    {
                        model.InputBy = dt.Rows[n]["InputBy"].ToString();
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
        /// 攻取某职位授权的数据对象
        /// </summary>
        /// <param name="posiCode"></param>
        /// <returns></returns>
        public DataSet GetPositionObjectGroup(string posiCode)
        {
            return dal.GetPositionObjectGroup(posiCode);
        }

                /// <summary>
        /// 分配数据组
        /// </summary>
        /// <param name="posiCode"></param>
        /// <param name="groupCodeArr"></param>
        /// <returns></returns>
        public int AddPosi2ObjectGroup(string posiCode, List<string> groupCodeArr)
        { 
        return dal.AddPosi2ObjectGroup(posiCode,groupCodeArr);
        }


        /// <summary>
        /// 攻取某职位授权的数据对象
        /// </summary>
        /// <param name="posiCode"></param>
        /// <returns></returns>
        public DataSet GetPosition2Role(string posiCode)
        {
            return dal.GetPosition2Role(posiCode);
        }

        /// <summary>
        /// 分配数据组
        /// </summary>
        /// <param name="posiCode"></param>
        /// <param name="groupCodeArr"></param>
        /// <returns></returns>
        public int AddPosi2Role(string posiCode, List<string> roleCodeArr)
        {
            return dal.AddPosi2Role(posiCode, roleCodeArr);
        }

        /// <summary>
        /// 攻取某职位授权的数据对象
        /// </summary>
        /// <param name="posiCode"></param>
        /// <returns></returns>
        public DataSet GetPosi2User(string userID)
        {
            return dal.GetPosi2User(userID);
        }

        /// <summary>
        /// 分配数据组
        /// </summary>
        /// <param name="posiCode"></param>
        /// <param name="groupCodeArr"></param>
        /// <returns></returns>
        public int AddPosi2User(string userID, List<string> posiCodeArr)
        {
            return dal.AddPosi2User(userID, posiCodeArr);
        }

		#endregion  Method
    }
}
