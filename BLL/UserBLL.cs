using System;
using System.Collections.Generic;
using System.Text;
using Model;
using SqlServerDAL;
using System.Data;

namespace BLL
{
    public class UserBLL
    {
        	private readonly UserDAL dal = new UserDAL();

		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID)
		{
			return dal.Exists(UserID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName,int OrganID)
        {
            return dal.Exists(UserName,OrganID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(User model)
		{
			return dal.Update(model);
		}

        public bool UpdatePwd(string userID, string pwd)
        {
            return dal.UpdatePwd(userID, pwd);
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
		public bool Delete(string UserID)
		{
			
			return dal.Delete(UserID);
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
		public User GetModel(string uID)
		{
			
			return dal.GetModel(uID);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetOrganList(int organID)
        {
            string strWhere = "";
            if (organID != 0)
            {
                strWhere = "OrganID = " + organID;
            }
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
		public List<User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<User> DataTableToList(DataTable dt)
		{
			List<User> modelList = new List<User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new User();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
					model.UserID=dt.Rows[n]["UserID"].ToString();
					}
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
					if(dt.Rows[n]["Password"]!=null && dt.Rows[n]["Password"].ToString()!="")
					{
					model.Password=dt.Rows[n]["Password"].ToString();
					}
					if(dt.Rows[n]["OrganID"]!=null && dt.Rows[n]["OrganID"].ToString()!="")
					{
						model.OrganID=int.Parse(dt.Rows[n]["OrganID"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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
        public DataSet GetRole2User(string userID)
        {
            return dal.GetRole2User(userID);
        }


        /// <summary>
        /// 分配数据组
        /// </summary>
        /// <param name="posiCode"></param>
        /// <param name="groupCodeArr"></param>
        /// <returns></returns>
        public int AddRole2User(string userID, List<string> roleCodeArr)
        {
            return dal.AddRole2User(userID, roleCodeArr);
        }


        public string GetUserID(string userName, int organID)
        {
            return dal.GetUserID(userName, organID);
        }


		#endregion  Method
    }
}
