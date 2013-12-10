using System;
using System.Collections.Generic;
using System.Text;
using SqlServerDAL;
using System.Data;
using Model;

namespace BLL
{
    public class AlertBLL
    {
        private readonly AlertDAL dal=new AlertDAL();

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
        public bool Exists(int AlertID)
        {
            return dal.Exists(AlertID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Alert model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Alert model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AlertID)
        {

            return dal.Delete(AlertID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string AlertIDlist)
        {
            return dal.DeleteList(AlertIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Alert GetModel(int AlertID)
        {

            return dal.GetModel(AlertID);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public Alert GetModelByCache(int AlertID)
        //{

        //    string CacheKey = "AlertModel-" + AlertID;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(AlertID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (Alert)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Alert> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Alert> DataTableToList(DataTable dt)
        {
            List<Alert> modelList = new List<Alert>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Alert model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Alert();
                    if (dt.Rows[n]["AlertID"] != null && dt.Rows[n]["AlertID"].ToString() != "")
                    {
                        model.AlertID = int.Parse(dt.Rows[n]["AlertID"].ToString());
                    }
                    if (dt.Rows[n]["AlertName"] != null && dt.Rows[n]["AlertName"].ToString() != "")
                    {
                        model.AlertName = dt.Rows[n]["AlertName"].ToString();
                    }
                    if (dt.Rows[n]["AlertRule"] != null && dt.Rows[n]["AlertRule"].ToString() != "")
                    {
                        model.AlertRule = dt.Rows[n]["AlertRule"].ToString();
                    }
                    //if (dt.Rows[n]["MinValue"] != null && dt.Rows[n]["MinValue"].ToString() != "")
                    //{
                    //    model.MinValue = dt.Rows[n]["MinValue"].ToString();
                    //}
                    //if (dt.Rows[n]["MaxValue"] != null && dt.Rows[n]["MaxValue"].ToString() != "")
                    //{
                    //    model.MaxValue = dt.Rows[n]["MaxValue"].ToString();
                    //}
                    if (dt.Rows[n]["OrganID"] != null && dt.Rows[n]["OrganID"].ToString() != "")
                    {
                        model.OrganID = int.Parse(dt.Rows[n]["OrganID"].ToString());
                    }
                    if (dt.Rows[n]["Description"] != null && dt.Rows[n]["Description"].ToString() != "")
                    {
                        model.Description = dt.Rows[n]["Description"].ToString();
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




        public int AlertYearCheck(int organID)
        {
            return dal.AlertYearCheck(organID);
        }


        public DataSet GetAlertYearCheck(int organID)
        {
            return dal.GetAlertYearCheck(organID);
        }


        public int AlertViolation(int organID)
        {
            return dal.AlertViolation(organID);
        }


        public DataSet GetAlertViolation(int organID)
        {
            return dal.GetAlertViolation(organID);
        }


        public int AlertScrap(int organID)
        {
            return dal.AlertScrap(organID);
        }


        public DataSet GetAlertScrap(int organID)
        {
            return dal.GetAlertScrap(organID);
        }




        /// <summary>
        /// 每次保养后再多7000公里,或5个月后
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertMaintenance(int organID)
        {
            return dal.AlertMaintenance(organID);
        }


        public DataSet GetAlertMaintenance(int organID)
        {
            return dal.GetAlertMaintenance(organID);
        }


        /// <summary>
        /// 后台自动将高于平均值的1.2倍的车辆显示,
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertKilometre(int organID)
        {
            return dal.AlertKilometre(organID);
        }


        public DataSet GetAlertKilometre(int organID)
        {
            return dal.GetAlertKilometre(organID);
        }


        /// <summary>
        /// 后台自动将高于平均值的1.2倍的车辆显示,
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertFuel(int organID)
        {
            return dal.AlertFuel(organID);
        }


        public DataSet GetAlertFuel(int organID)
        {
            return dal.GetAlertFuel(organID);
        }
    }
}
