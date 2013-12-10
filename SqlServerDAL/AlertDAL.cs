using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDAL
{
    public class AlertDAL
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("AlertID", "Alert");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AlertID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Alert");
            strSql.Append(" where AlertID=@AlertID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AlertID", SqlDbType.Int,4)			};
            parameters[0].Value = AlertID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Alert model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Alert(");
            strSql.Append("AlertID,AlertName,AlertRule,OrganID,Description)");
            strSql.Append(" values (");
            strSql.Append("@AlertID,@AlertName,@AlertRule,@OrganID,@Description)");
            SqlParameter[] parameters = {
					new SqlParameter("@AlertID", SqlDbType.Int,4),
					new SqlParameter("@AlertName", SqlDbType.VarChar,30),
					new SqlParameter("@AlertRule", SqlDbType.VarChar,500),
					new SqlParameter("@OrganID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,500)};
            parameters[0].Value = model.AlertID;
            parameters[1].Value = model.AlertName;
            parameters[2].Value = model.AlertRule;
            parameters[3].Value = model.OrganID;
            parameters[4].Value = model.Description;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Alert model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Alert set ");
            strSql.Append("AlertName=@AlertName,");
            strSql.Append("AlertRule=@AlertRule,");
            strSql.Append("OrganID=@OrganID,");
            strSql.Append("Description=@Description");
            strSql.Append(" where AlertID=@AlertID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AlertName", SqlDbType.VarChar,30),
					new SqlParameter("@AlertRule", SqlDbType.VarChar,500),
					new SqlParameter("@OrganID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,500),
					new SqlParameter("@AlertID", SqlDbType.Int,4)};
            parameters[0].Value = model.AlertName;
            parameters[1].Value = model.AlertRule;
            parameters[2].Value = model.OrganID;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.AlertID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AlertID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Alert ");
            strSql.Append(" where AlertID=@AlertID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AlertID", SqlDbType.Int,4)			};
            parameters[0].Value = AlertID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AlertIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Alert ");
            strSql.Append(" where AlertID in (" + AlertIDlist + ")  ");
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
        public Alert GetModel(int AlertID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AlertID,AlertName,AlertRule,OrganID,Description from Alert ");
            strSql.Append(" where AlertID=@AlertID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AlertID", SqlDbType.Int,4)			};
            parameters[0].Value = AlertID;

            Alert model = new Alert();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AlertID"] != null && ds.Tables[0].Rows[0]["AlertID"].ToString() != "")
                {
                    model.AlertID = int.Parse(ds.Tables[0].Rows[0]["AlertID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AlertName"] != null && ds.Tables[0].Rows[0]["AlertName"].ToString() != "")
                {
                    model.AlertName = ds.Tables[0].Rows[0]["AlertName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AlertRule"] != null && ds.Tables[0].Rows[0]["AlertRule"].ToString() != "")
                {
                    model.AlertRule = ds.Tables[0].Rows[0]["AlertRule"].ToString();
                }
                //if (ds.Tables[0].Rows[0]["MinValue"] != null && ds.Tables[0].Rows[0]["MinValue"].ToString() != "")
                //{
                //    model.MinValue = ds.Tables[0].Rows[0]["MinValue"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["MaxValue"] != null && ds.Tables[0].Rows[0]["MaxValue"].ToString() != "")
                //{
                //    model.MaxValue = ds.Tables[0].Rows[0]["MaxValue"].ToString();
                //}
                if (ds.Tables[0].Rows[0]["OrganID"] != null && ds.Tables[0].Rows[0]["OrganID"].ToString() != "")
                {
                    model.OrganID = int.Parse(ds.Tables[0].Rows[0]["OrganID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AlertID,AlertName,AlertRule,OrganID,Description ");
            strSql.Append(" FROM Alert ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AlertID,AlertName,AlertRule,OrganID,Description ");
            strSql.Append(" FROM Alert ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Alert ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.AlertID desc");
            }
            strSql.Append(")AS Row, T.*  from Alert T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "Alert";
            parameters[1].Value = "AlertID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/



        /// <summary>
        /// 车辆年检到期前一个月，发出预警
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertYearCheck(int organID)
        {
            // AND DIFF(Getdate(),StartUseDate)< 0
            //string sql = "if object_id('tempdb..#tempVehicle') is not null drop table #tempVehicle"
            //    + " SELECT *,(datename(YYYY,GETDATE())+'-'+datename(MM,StartUseDate)+'-'+datename(DD,StartUseDate)) AS YCTime INTO #tempVehicle FROM Vehicle A WHERE OrganID = @OrganID AND StartUseDate IS NOT NULL"
            //    + " SELECT COUNT(ID) FROM #tempVehicle WHERE DATEDIFF(dd,GETDATE(),YCTime) < 30 AND FrameNO NOT IN(SELECT FrameNO FROM YearCheck WHERE OrganID = @OrganID AND DATENAME(YYYY,YC_Date)=datename(YYYY,GETDATE()))"
            //    + " drop table #tempVehicle";

            string sql = "SELECT count(id) FROM Vehicle WHERE FrameNO in(Select FrameNO from YearCheck where OrganID = @OrganID GROUP BY FrameNO having datediff(DD,getdate(),Max(ValidDate)) < 31)";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            object re = DbHelperSQL.GetSingle(sql, parameters);
            return Convert.ToInt32(re);
        }


        public DataSet GetAlertYearCheck(int organID)
        {
            //string sql = "if object_id('tempdb..#tempVehicle') is not null drop table #tempVehicle"
            //    + " SELECT *,(datename(YYYY,GETDATE())+'-'+datename(MM,StartUseDate)+'-'+datename(DD,StartUseDate)) AS YCTime INTO #tempVehicle FROM Vehicle A WHERE OrganID = @OrganID AND StartUseDate IS NOT NULL"
            //    + " SELECT * FROM #tempVehicle WHERE DATEDIFF(dd,GETDATE(),YCTime) <= 31 AND FrameNO NOT IN(SELECT FrameNO FROM YearCheck WHERE OrganID = @OrganID AND DATENAME(YYYY,YC_Date)=datename(YYYY,GETDATE()))"
            //    + " drop table #tempVehicle";
            string sql = "SELECT * FROM Vehicle WHERE FrameNO in(Select FrameNO from YearCheck where OrganID = @OrganID GROUP BY FrameNO having datediff(DD,getdate(),Max(ValidDate)) < 31)";

            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataSet re = DbHelperSQL.Query(sql, parameters);
            return re;
        }


        /// <summary>
        /// 每月导入一次违章记录 当责任人处理完违章后，更新违章的处理状态（未处理-->已处理） 要求通知后5天发现还没有处理的，第一次预警,  10天后如果还没处理,再次预警
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertViolation(int organID)
        {
            string sql = "SELECT COUNT(*) FROM Violation WHERE OrganID = @OrganID AND DealStatus = '未处理' AND DATEDIFF(DD,NoticeTime,getdate())>5";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            object re = DbHelperSQL.GetSingle(sql, parameters);
            return Convert.ToInt32(re);
        }


        public DataSet GetAlertViolation(int organID)
        {
            string sql = "SELECT * FROM Violation WHERE OrganID = @OrganID AND DealStatus = '未处理' AND DATEDIFF(DD,NoticeTime,getdate())>5";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataSet re = DbHelperSQL.Query(sql, parameters);
            return re;
        }




        /// <summary>
        /// 根据车辆的预设定的报废日期，提前一个月预警  次年报废的车辆，在头年的10月份开始预警。例如，13年无论哪个月份报废的车辆，12年10月份至13年1月份出现预警，其余月份无需预警。
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertScrap(int organID)
        {
            string sql = "SELECT Count(id) FROM Vehicle WHERE OrganID = @OrganID AND DATEDIFF(MM,GETDATE(),(datename(yyyy,PlanScrapDate)+'-1-1')) BETWEEN 1 AND 3";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            object re = DbHelperSQL.GetSingle(sql,parameters);
            return Convert.ToInt32(re);
        }


        public DataSet GetAlertScrap(int organID)
        {
            string sql = "SELECT * FROM Vehicle WHERE OrganID = @OrganID AND DATEDIFF(MM,GETDATE(),(datename(yyyy,PlanScrapDate)+'-1-1')) BETWEEN 1 AND 3";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataSet re = DbHelperSQL.Query(sql,parameters);
            return re;
        }


        /// <summary>
        /// 每次保养后再多7000公里,或5个月后
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertMaintenance(int organID)
        {
            List<string> list = new List<string>();

            string sql1 = "select FrameNO,max(Kilometre) as Count,min(MaintenanceDate) as MT from Maintenance where organID = @OrganID group by FrameNO";
            string sql2 = "select FrameNO,max(KM_Count) as Count from Kilometre where organID = @OrganID group by FrameNO";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataTable re1 = DbHelperSQL.Query(sql1, parameters).Tables[0];
            DataTable re2 = DbHelperSQL.Query(sql2, parameters).Tables[0];

            DataColumn[] keys = new DataColumn[1];
            keys[0] = re2.Columns["FrameNO"];
            re2.PrimaryKey = keys;

            if (re1 != null || re1.Rows.Count > 0)
            {
                foreach (DataRow dr in re1.Rows)
                {
                    DataRow r = re2.Rows.Find(dr["FrameNO"].ToString());
                    if (r != null)
                    {
                        int x = int.Parse(r["Count"].ToString()) - int.Parse(dr["Count"].ToString());
                        if (x >= 7000)
                        {
                            list.Add(dr["FrameNO"].ToString());
                        }
                    }

                    DateTime mt = DateTime.Parse(dr["MT"].ToString());
                    if (mt.AddMonths(5) < DateTime.Now && !list.Contains(dr["FrameNO"].ToString()))
                    {
                        list.Add(dr["FrameNO"].ToString());
                    }
                }
            }
            return list.Count;
        }


        public DataSet GetAlertMaintenance(int organID)
        {
            List<string> list = new List<string>();

            string sql1 = "select FrameNO,max(Kilometre) as Count,min(MaintenanceDate) as MT  from Maintenance where organID = @OrganID group by FrameNO";
            string sql2 = "select FrameNO,max(KM_Count) as Count from Kilometre where organID = @OrganID group by FrameNO";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataTable re1 = DbHelperSQL.Query(sql1, parameters).Tables[0];
            DataTable re2 = DbHelperSQL.Query(sql2, parameters).Tables[0];

            DataColumn[] keys = new DataColumn[1];
            keys[0] = re2.Columns["FrameNO"];
            re2.PrimaryKey = keys;

            if (re1 != null || re1.Rows.Count > 0)
            {
                foreach (DataRow dr in re1.Rows)
                {
                    DataRow r = re2.Rows.Find(dr["FrameNO"].ToString());
                    if (r != null)
                    {
                        int x = int.Parse(r["Count"].ToString()) - int.Parse(dr["Count"].ToString());
                        if (x >= 7000)
                        {
                            list.Add(dr["FrameNO"].ToString());
                        }
                    }

                    DateTime mt = DateTime.Parse(dr["MT"].ToString());
                    if (mt.AddMonths(5) < DateTime.Now && !list.Contains(dr["FrameNO"].ToString()))
                    {
                        list.Add(dr["FrameNO"].ToString());
                    }
                }
            }
            if (list.Count > 0)
            {
                string fs = "";
                foreach (string s in list)
                {
                    fs += "'" + s + "',";
                }
                fs = fs.TrimEnd(',');
                string where = " FrameNO in (" + fs + ")";

                return new VehicleDAL().GetList(where);

            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 后台自动将高于平均值的1.2倍的车辆显示,
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertKilometre(int organID)
        {
            List<string> list = new List<string>();

            string sql1 = "select FrameNO,max(KM_Count) as newKM from Kilometre A where organID = @OrganID and id = (select max(id) from Kilometre where FrameNO = A.FrameNO) group by FrameNO";
            string sql2 = "select FrameNO,max(KM_Count) as oldKM,count(id) as Cnt from Kilometre A where organID = @OrganID and id < (select max(id) from Kilometre where FrameNO = A.FrameNO) group by FrameNO";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataTable re1 = DbHelperSQL.Query(sql1, parameters).Tables[0];
            DataTable re2 = DbHelperSQL.Query(sql2, parameters).Tables[0];
            DataColumn[] keys = new DataColumn[1];
            keys[0] = re2.Columns["FrameNO"];
            re2.PrimaryKey = keys;

            if (re1 != null || re1.Rows.Count>0)
            {
                foreach (DataRow dr in re1.Rows)
                {
                    DataRow r = re2.Rows.Find(dr["FrameNO"].ToString());
                    if (r != null)
                    {
                        float oldKM = float.Parse(r["oldKM"].ToString());
                        float cnt = float.Parse(r["Cnt"].ToString());

                        float newKM = float.Parse(dr["newKM"].ToString());

                        float avgKM = oldKM / cnt;
                        float thisKM = newKM - oldKM;

                        float x = thisKM/avgKM;
                        if (x >= 1.2)
                        {
                            list.Add(dr["FrameNO"].ToString());
                        }
                    }
                }
            }
            return list.Count;
        }


        public DataSet GetAlertKilometre(int organID)
        {
            List<string> list = new List<string>();

            string sql1 = "select FrameNO,max(KM_Count) as newKM from Kilometre A where organID = @OrganID and id = (select max(id) from Kilometre where FrameNO = A.FrameNO) group by FrameNO";
            string sql2 = "select FrameNO,max(KM_Count) as oldKM,count(id) as Cnt from Kilometre A where organID = @OrganID and id < (select max(id) from Kilometre where FrameNO = A.FrameNO) group by FrameNO";
            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataTable re1 = DbHelperSQL.Query(sql1, parameters).Tables[0];
            DataTable re2 = DbHelperSQL.Query(sql2, parameters).Tables[0];
            DataColumn[] keys = new DataColumn[1];
            keys[0] = re2.Columns["FrameNO"];
            re2.PrimaryKey = keys;


            if (re1 != null || re1.Rows.Count > 0)
            {
                foreach (DataRow dr in re1.Rows)
                {
                    DataRow r = re2.Rows.Find(dr["FrameNO"].ToString());
                    if (r != null)
                    {
                        float oldKM = float.Parse(r["oldKM"].ToString());
                        float cnt = float.Parse(r["Cnt"].ToString());

                        float newKM = float.Parse(dr["newKM"].ToString());

                        float avgKM = oldKM / cnt;
                        float thisKM = newKM - oldKM;

                        float x = thisKM / avgKM;
                        if (x >= 1.2)
                        {
                            list.Add(dr["FrameNO"].ToString());
                        }
                    }
                }
            }

            if (list.Count > 0)
            {
                string fs = "";
                foreach (string s in list)
                {
                    fs += "'" + s + "',";
                }
                fs = fs.TrimEnd(',');
                string where = " FrameNO in (" + fs + ")";

                return new VehicleDAL().GetList(where);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 后台自动将高于平均值的1.2倍的车辆显示,
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public int AlertFuel(int organID)
        {

            List<string> list = new List<string>();
            IList<AlertFuel> afList = new List<AlertFuel>();

            string sql1 = "select FrameNO,avg(ChargeAmount) as avgAmount from CardFuel A where organID = @OrganID and id = (select max(id) from CardFuel where FrameNO = A.FrameNO) group by FrameNO";
            string sql2 = "select FrameNO,avg(ChargeAmount) as avgAmount from CardFuel A where organID = @OrganID and id < (select max(id) from CardFuel where FrameNO = A.FrameNO) group by FrameNO";

            string sql3 = "select FrameNO,avg(FuelMoney) as avgAmount from CashFuel A where organID = @OrganID and id = (select max(id) from CashFuel where FrameNO = A.FrameNO) group by FrameNO";
            string sql4 = "select FrameNO,avg(FuelMoney) as avgAmount from CashFuel A where organID = @OrganID and id < (select max(id) from CashFuel where FrameNO = A.FrameNO) group by FrameNO";


            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataTable reCard1 = DbHelperSQL.Query(sql1, parameters).Tables[0];
            DataTable reCard2 = DbHelperSQL.Query(sql2, parameters).Tables[0];
            DataColumn[] keys1 = new DataColumn[1];
            keys1[0] = reCard2.Columns["FrameNO"];
            reCard2.PrimaryKey = keys1;

            DataTable reCash1 = DbHelperSQL.Query(sql3, parameters).Tables[0];
            DataTable reCash2 = DbHelperSQL.Query(sql4, parameters).Tables[0];
            DataColumn[] keys2 = new DataColumn[1];
            keys2[0] = reCash2.Columns["FrameNO"];
            reCash2.PrimaryKey = keys2;


            

            if (reCard1 != null || reCard1.Rows.Count > 0)
            {
                foreach (DataRow dr in reCard1.Rows)
                {
                    DataRow r = reCard2.Rows.Find(dr["FrameNO"].ToString());
                    if (r != null)
                    {
                        float avgCard = 0, newCard = 0;

                        avgCard = float.Parse(r["avgAmount"].ToString());
                        newCard = float.Parse(dr["avgAmount"].ToString());

                        AlertFuel af = new AlertFuel();
                        af.FrameNO = dr["FrameNO"].ToString();
                        af.avgCard = avgCard;
                        af.newCard = newCard;

                        afList.Add(af);
                    }
                }
            }

            if (reCash1 != null || reCash1.Rows.Count > 0)
            {
                foreach (DataRow dr in reCash1.Rows)
                {
                    DataRow r = reCash2.Rows.Find(dr["FrameNO"].ToString());
                    if (r != null)
                    {
                        float avgCash = 0, newCash = 0;

                        avgCash = float.Parse(r["avgAmount"].ToString());
                        newCash = float.Parse(dr["avgAmount"].ToString());
                        string _frameNO = dr["FrameNO"].ToString();
                        bool _find = false;
                        foreach (AlertFuel a in afList)
                        {
                            if (a.FrameNO == _frameNO)
                            {
                                _find = true;
                                a.avgCash = avgCash;
                                a.newCash = newCash;
                            }
                        }
                        if (!_find)
                        {
                            AlertFuel af = new AlertFuel();
                            af.FrameNO = _frameNO;
                            af.avgCash = avgCash;
                            af.newCash = newCash;
                            afList.Add(af);
                        }
                    }
                }
            }

            foreach (AlertFuel a in afList)
            {
                a.newCash = a.newCash == null ? 0 : a.newCash;
                a.avgCash = a.avgCash == null ? 0 : a.avgCash;
                a.newCard = a.newCard == null ? 0 : a.newCard;
                a.avgCard = a.avgCard == null ? 0 : a.avgCard;

                float x = (a.newCard + a.newCash) / (a.avgCard + a.avgCash);
                if (x >= 1.2)
                {
                    list.Add(a.FrameNO);
                }
            }
            return list.Count;
        }


        public DataSet GetAlertFuel(int organID)
        {
            List<string> list = new List<string>();
            IList<AlertFuel> afList = new List<AlertFuel>();

            string sql1 = "select FrameNO,avg(ChargeAmount) as avgAmount from CardFuel A where organID = @OrganID and id = (select max(id) from CardFuel where FrameNO = A.FrameNO) group by FrameNO";
            string sql2 = "select FrameNO,avg(ChargeAmount) as avgAmount from CardFuel A where organID = @OrganID and id < (select max(id) from CardFuel where FrameNO = A.FrameNO) group by FrameNO";

            string sql3 = "select FrameNO,avg(FuelMoney) as avgAmount from CashFuel A where organID = @OrganID and id = (select max(id) from CashFuel where FrameNO = A.FrameNO) group by FrameNO";
            string sql4 = "select FrameNO,avg(FuelMoney) as avgAmount from CashFuel A where organID = @OrganID and id < (select max(id) from CashFuel where FrameNO = A.FrameNO) group by FrameNO";


            SqlParameter[] parameters = {
                    new SqlParameter("@OrganID",organID)
                    };

            DataTable reCard1 = DbHelperSQL.Query(sql1, parameters).Tables[0];
            DataTable reCard2 = DbHelperSQL.Query(sql2, parameters).Tables[0];
            DataColumn[] keys1 = new DataColumn[1];
            keys1[0] = reCard2.Columns["FrameNO"];
            reCard2.PrimaryKey = keys1;

            DataTable reCash1 = DbHelperSQL.Query(sql3, parameters).Tables[0];
            DataTable reCash2 = DbHelperSQL.Query(sql4, parameters).Tables[0];
            DataColumn[] keys2 = new DataColumn[1];
            keys2[0] = reCash2.Columns["FrameNO"];
            reCash2.PrimaryKey = keys2;




            if (reCard1 != null || reCard1.Rows.Count > 0)
            {
                foreach (DataRow dr in reCard1.Rows)
                {
                    DataRow r = reCard2.Rows.Find(dr["FrameNO"].ToString());
                    if (r != null)
                    {
                        float avgCard = 0, newCard = 0;

                        avgCard = float.Parse(r["avgAmount"].ToString());
                        newCard = float.Parse(dr["avgAmount"].ToString());

                        AlertFuel af = new AlertFuel();
                        af.FrameNO = dr["FrameNO"].ToString();
                        af.avgCard = avgCard;
                        af.newCard = newCard;

                        afList.Add(af);
                    }
                }
            }

            if (reCash1 != null || reCash1.Rows.Count > 0)
            {
                foreach (DataRow dr in reCash1.Rows)
                {
                    DataRow r = reCash2.Rows.Find(dr["FrameNO"].ToString());
                    if (r != null)
                    {
                        float avgCash = 0, newCash = 0;

                        avgCash = float.Parse(r["avgAmount"].ToString());
                        newCash = float.Parse(dr["avgAmount"].ToString());
                        string _frameNO = dr["FrameNO"].ToString();
                        bool _find = false;
                        foreach (AlertFuel a in afList)
                        {
                            if (a.FrameNO == _frameNO)
                            {
                                _find = true;
                                a.avgCash = avgCash;
                                a.newCash = newCash;
                            }
                        }
                        if (!_find)
                        {
                            AlertFuel af = new AlertFuel();
                            af.FrameNO = _frameNO;
                            af.avgCash = avgCash;
                            af.newCash = newCash;
                            afList.Add(af);
                        }
                    }
                }
            }

            foreach (AlertFuel a in afList)
            {
                a.newCash = a.newCash == null ? 0 : a.newCash;
                a.avgCash = a.avgCash == null ? 0 : a.avgCash;
                a.newCard = a.newCard == null ? 0 : a.newCard;
                a.avgCard = a.avgCard == null ? 0 : a.avgCard;

                float x = (a.newCard + a.newCash) / (a.avgCard + a.avgCash);
                if (x >= 1.2)
                {
                    list.Add(a.FrameNO);
                }
            }

            if (list.Count > 0)
            {
                string fs = "";
                foreach (string s in list)
                {
                    fs += "'" + s + "',";
                }
                fs = fs.TrimEnd(',');
                string where = " FrameNO in (" + fs + ")";

                return new VehicleDAL().GetList(where);
            }
            else
            {
                return null;
            }
        }
    }
}
