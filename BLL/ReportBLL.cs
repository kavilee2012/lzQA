using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SqlServerDAL;
using System.Collections;

namespace BLL
{
    public class ReportBLL
    {
        ReportDAL dal = new ReportDAL();


         /// <summary>
        /// 获取报表分类
        /// </summary>
        /// <param name="fatherID"></param>
        /// <returns></returns>
        public DataTable GetReportSort(string fatherID)
        {
            return dal.GetReportSort(fatherID);
        }


        /// <summary>
        /// 人车比
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetPersonVehilceRate(string sortID, Hashtable args)
        {
            if (sortID == "RS001")
            {
                return dal.GetPersonVehicleForOneOrgan(args);
            }
            else if (sortID == "RS002")
            {
                return dal.GetPersonVehicleForAllOrgan(args);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 用油量
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetFuelRate(string sortID, Hashtable args)
        {
            if (sortID == "RS006")
            {
                return dal.GetVioCountForOneOrganVehicle(args);
            }
            else if (sortID == "RS007")
            {
                return dal.GetVioCountForOneOrganDriver(args);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 违章数
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetViolationReport(string sortID, Hashtable args)
        {
            if (sortID == "RS006")
            {
                return dal.GetVioCountForOneOrganVehicle(args);
            }
            else if (sortID == "RS007")
            {
                return dal.GetVioCountForOneOrganDriver(args);
            }
            else if (sortID == "RS008")
            {
                return dal.GetVioCountForOneVehicle(args);
            }
            else if (sortID == "RS009")
            {
                return dal.GetVioCountForAllOrganAvg(args);
            }
            else if (sortID == "RS010")
            {
                return dal.GetVioDealForOneOrgan(args);
            }
            else if (sortID == "RS011")
            {
                return dal.GetVioDealForOneVehicle(args);
            }
            else if (sortID == "RS012")
            {
                return dal.GetVioDealForAllOrgan(args);
            }
            else if (sortID == "RS013")
            {
                return dal.GetVioLevelForAllOrgan(args);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 抽查评分
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetCheckScoreRate(string sortID, Hashtable args)
        {
            if (sortID == "RS014")
            {
                return dal.GetScoreForOneOrgan(args);
            }
            else if (sortID == "RS015")
            {
                return dal.GetScoreForAllOrgan(args);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 案件数
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetVehicleCaseRate(string sortID, Hashtable args)
        {
            if (sortID == "RS016")
            {
                return dal.GetVehicleCaseOneOrgan(args);
            }
            else if (sortID == "RS017")
            {
                return dal.GetVehicleCaseAllOrgan(args);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 总费用
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetCostRate(string sortID, Hashtable args)
        {
            if (sortID == "RS018")
            {
                return dal.GetCostForOneOrgan(args);
            }
            else if (sortID == "RS019")
            {
                return dal.GetCostForOneVehicle(args);
            }
            else if (sortID == "RS020")
            {
                return dal.GetCostForAllOrgan(args);
            }
            else
            {
                return null;
            }
        }
    }
}
