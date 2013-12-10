using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using SqlServerDAL;

namespace BLL
{
    public class OrganBLL
    {
        private readonly OrganDAL dal = new OrganDAL();

        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OrganID)
        {
            return dal.Exists(OrganID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Organ model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Organ model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int OrganID)
        {

            return dal.Delete(OrganID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string OrganIDlist)
        {
            return dal.DeleteList(OrganIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Organ GetModel(int OrganID)
        {

            return dal.GetModel(OrganID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Organ GetModelByCache(int OrganID)
        //{

        //    string CacheKey = "OrganModel-" + OrganID;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(OrganID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (Organ)objModel;
        //}

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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Organ> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Organ> DataTableToList(DataTable dt)
        {
            List<Organ> modelList = new List<Organ>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Organ model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Organ();
                    if (dt.Rows[n]["OrganID"] != null && dt.Rows[n]["OrganID"].ToString() != "")
                    {
                        model.OrganID = int.Parse(dt.Rows[n]["OrganID"].ToString());
                    }
                    if (dt.Rows[n]["OrganName"] != null && dt.Rows[n]["OrganName"].ToString() != "")
                    {
                        model.OrganName = dt.Rows[n]["OrganName"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["Superior"] != null && dt.Rows[n]["Superior"].ToString() != "")
                    {
                        model.Superior = int.Parse(dt.Rows[n]["Superior"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
