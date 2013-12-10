using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace SqlServerDAL
{
    public class ReportDAL
    {

        /// <summary>
        /// 获取报表分类
        /// </summary>
        /// <param name="fatherID"></param>
        /// <returns></returns>
        public DataTable GetReportSort(string fatherID)
        {
            string sql = "SELECT * FROM ReportSort WHERE FatherID = '" + fatherID + "'";
            return DbHelperSQL.Query(sql).Tables[0];
        }


        #region 人车比

        //
        //--某一机构，在一时间段内车辆数与工作专员数之比趋势图表
        public DataTable GetPersonVehicleForOneOrgan(Hashtable args)
        {
            int organID = Convert.ToInt32(args["OrganID"]);
            string starttime = Convert.ToString(args["StartTime"]);
            string EndTime = Convert.ToString(args["EndTime"]);

            // string sql = "SELECT Int_Month as 月份,(SELECT COUNT(EmployeeID)FROM Employee WHERE OrganID = " + organID + ") AS 员工数, (SELECT COUNT(ID) FROM Vehicle WHERE OrganID = " + organID + ") AS 车辆数 FROM V_YearMonth WHERE Int_Year = 2011";

            string sql = "begin "
+ " set nocount on "
+ "  declare @dtBegin datetime "
+ "  declare @dtEnd datetime "
+ "  declare @organid int "
+ "  declare @t table(dt datetime) "

+ " select @dtBegin='" + starttime + "' "
+ "  select @dtEnd='" + EndTime + "' "
+ "  select @organid='" + organID + "' "

+ " while @dtBegin<=@dtEnd "
+ "  begin "
+ "  insert @t select @dtBegin "
+ "  set @dtBegin=@dtBegin+1 "
+ "  end "

+ " select convert(char(7),t.dt,23) as '月份',count(distinct employeeid) as '查勘员人数',count(distinct vehicleid) as '查勘车辆数', Convert(decimal(18,2),1.0*count(distinct employeeid)/count(distinct vehicleid)) AS '人车比'  from employee e ,@t t ,vehicle v  "
+ " where convert(char(7),e.joindate,23)<=convert(char(7),t.dt,23) and  "
+ " (convert(char(7),e.leavedate,23)>=convert(char(7),t.dt,23) or e.leavedate is null)  "

+ " and  "
+ " convert(char(7),v.startusedate,23)<=convert(char(7),t.dt,23) and  "
+ " (convert(char(7),v.PlanScrapDate,23)>=convert(char(7),t.dt,23) or v.PlanScrapDate is null)   "
+ " and v.organid=@organid and e.organid=@organid  "


+ " group by convert(char(7),t.dt,23) order by convert(char(7),t.dt,23) "

+ " end ";

            return GetPersonVehilceTable(sql);
        }


        //--某一时间段内，各机构的车辆数与工作专员数之比的比较图表
        public DataTable GetPersonVehicleForAllOrgan(Hashtable args)
        {
            string starttime = Convert.ToString(args["StartTime"]);
            string EndTime = Convert.ToString(args["EndTime"]);

            string sql = "begin "
+ " set nocount on "
 + " declare @dtBegin datetime "
+ "  declare @dtEnd datetime "

+ " select @dtBegin='" + starttime + "' "
+ "  select @dtEnd='" + EndTime + "' "

+ " select o.organname as '机构名',count(distinct employeeid) as '查勘员人数',count(distinct vehicleid) as '查勘车辆数', Convert(decimal(18,2),1.0*count(distinct employeeid)/count(distinct vehicleid)) AS '人车比'  from employee e ,Organ o ,vehicle v  "
+ " where  "
+ " (e.leavedate is null and e.joindate<=@dtend)  "
+ " or  "
+ " ( "
+ " (e.joindate>=@dtBegin and e.joindate<=@dtEnd  ) "
+ " or  "
+ " (e.leavedate>=@dtBegin and e.leavedate<=@dtEnd  ) "
+ " or  "
+ " (e.leavedate>=@dtEnd and e.leavedate<=@dtBegin  ) "
+ " ) "

+ " and  "
+ " (v.planscrapdate is null and v.startusedate<=@dtend)  "
+ " or  "
+ " ( "
+ " (v.startusedate>=@dtBegin and v.startusedate<=@dtEnd) "
+ " or  "
+ " (v.planscrapdate>=@dtBegin and v.planscrapdate<=@dtEnd  ) "
+ " or  "
+ " (v.planscrapdate>=@dtEnd and v.planscrapdate<=@dtBegin  ) "
+ " ) "
+ " and e.organid=v.organid  "
+ " and e.organid=o.organid  "

+ " group by O.organname order by o.organname "

+ " end ";

            return GetPersonVehilceTable(sql);
        }


        /// <summary>
        /// 人车比
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetPersonVehilceTable(string sql)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Date");
            //dt.Columns.Add("PersonCount");
            //dt.Columns.Add("VehicleCount");
            //dt.Columns.Add("Rate");

            //DataRow dr = dt.NewRow();
            //dr["Date"] = "5";
            //dr["PersonCount"] = "12";
            //dr["VehicleCount"] = "24";
            //dr["Rate"] = "1/2";
            
            //dt.Rows.Add(dr);
            //return dt;

            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }





        #endregion


        #region 用油量

        //---3.3.2用油量
        //--某一机构，某一时间段内的各车辆的每百公里用油量比较图表
        public DataTable GetUseFuelForOneOrgan(Hashtable args)
        {
            string sql = "SELECT NULL";
            return GetFuelTable(sql);
        }
        //--某台车，在一时间段内的各个月的每百公里用油量趋势图表
        public DataTable GetUseFuelForOneVehicle(Hashtable args)
        {
            string sql = "SELECT NULL";
            return GetFuelTable(sql);
        }

        //--某一时间段内，各机构的平均每百公里用油量比较图表
        public DataTable GetUseFuelForAllOrgan(Hashtable args)
        {
            string sql = "SELECT NULL";
            return GetFuelTable(sql);
        }

        /// <summary>
        /// 用油量
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetFuelTable(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }

        #endregion




        #region 违章数

        //--3.3.3违章数

        //--某一机构，某一时间段内的各车辆的违章数比较图表
        public DataTable GetVioCountForOneOrganVehicle(Hashtable args)
        {
            int organID = Convert.ToInt32(args["OrganID"]);
            string sql = "SELECT A.FrameNO as 车架号,count(B.ID) as 违章数  FROM Vehicle A LEFT JOIN Violation B ON A.FrameNO = B.FrameNO WHERE A.OrganID = " + organID + " Group BY A.FrameNO";
            return GetViolationTable(sql);
        }

        //--某一机构，某一时间段内的各驾驶员的违章数比较图表
        //
        public DataTable GetVioCountForOneOrganDriver(Hashtable args)
        {
            int organID = Convert.ToInt32(args["OrganID"]);
            string sql = "SELECT A.EmployeeID as 驾驶员,count(B.ID) as 违章数  FROM Employee A LEFT JOIN Violation B ON A.EmployeeID = B.Driver WHERE A.OrganID = " + organID + " Group BY A.EmployeeID";
            return GetViolationTable(sql);
        }


        //--某台车，在一时间段内的各个月的违章数趋势图表
        public DataTable GetVioCountForOneVehicle(Hashtable args)
        {
            string sql = "SELECT NULL";
            return GetViolationTable(sql);
        }

        //--某一时间段内，各机构的平均每车违章数比较图表
        //
        public DataTable GetVioCountForAllOrganAvg(Hashtable args)
        {
            string sql = "SELECT OrganName as 机构,(SELECT COUNT(ID) FROM Vehicle WHERE OrganID = A.OrganID) AS 车辆数,(SELECT COUNT(ID) FROM Violation WHERE OrganID=A.OrganID) as 违章数 FROM Organ A ";
            return GetViolationTable(sql);
        }

        //--某一机构，某一时间段内的各车辆的违章处理时效比较图表
        //SELECT A.FrameNO,count(B.ID) FROM Vehicle A LEFT JOIN Violation B ON A.FrameNO = B.FrameNO GROUP BY A.FrameNO
        public DataTable GetVioDealForOneOrgan(Hashtable args)
        {
            string sql = "";
            return GetViolationTable(sql);
        }

        //--某台车，在一时间段内的各个月的违章处理时效趋势图表
        public DataTable GetVioDealForOneVehicle(Hashtable args)
        {
            string sql = "SELECT NULL";
            return GetViolationTable(sql);
        }

        //--某一时间段内，各机构的平均每车违章处理时效比较图表
        public DataTable GetVioDealForAllOrgan(Hashtable args)
        {
            string sql = "SELECT NULL";
            return GetViolationTable(sql);
        }

        //--某一时间段内，各机构的严重违章比较图表
        //SELECT * FROM Organ A LEFT JOIN Violation B ON A.OrganID = B.OrganID WHERE DealStatus = 1
        public DataTable GetVioLevelForAllOrgan(Hashtable args)
        {
            string sql = "SELECT NULL";
            return GetViolationTable(sql);
        }


        /// <summary>
        /// 违章数
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetViolationTable(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }

        #endregion



        #region 抽查评分

        //---3.3.4抽查评分

        //--某一机构，某一时间段内的各车辆的抽查评分比较图表
        public DataTable GetScoreForOneOrgan(Hashtable args)
        {
            string _startTime = args["StartTime"].ToString() + " 00:00:00";
            string _endTime = args["EndTime"].ToString() + " 23:59:59";

            StringBuilder sql = new StringBuilder();//"SELECT OrganName 机构名称,(select AVG(Score) FROM CheckScore WHERE OrganID = A.OrganID) 平均分 FROM Organ A ";
            sql.Append("declare @startTime datetime,@endTime datetime,@OrganID int; ");
            sql.Append("set @startTime='" + _startTime + "';set @endTime ='" + _endTime + "';set @OrganID = " + args["OrganID"] + ";");
            sql.Append("if object_id('tempdb..#temp') is not null drop table #temp;");
            sql.Append("CREATE TABLE #temp(FrameNO varchar(50),SumScore float,SumCount float);");
            sql.Append("INSERT INTO #temp SELECT FrameNO,SUM(Score),Count(FrameNO) FROM  CheckScore WHERE OrganID = @OrganID AND CheckDate BETWEEN @startTime AND @endTime GROUP BY FrameNO; ");
            sql.Append("INSERT INTO #temp SELECT FrameNO,0,0 FROM Vehicle A WHERE A.OrganID = @OrganID;");
            sql.Append("SELECT MAX(Y.VehicleID) as 车牌号,SUM(SumScore) as 总得分,Sum(SumCount) as 抽查次数,cast(round((case SUM(SumCount) when 0 then 0 else (SUM(SumScore)/Sum(SumCount)) end ),2) as decimal(10,2)) as 平均得分  FROM #temp X JOIN Vehicle Y ON X.FrameNO = Y.FrameNO GROUP BY X.FrameNO;");
            sql.Append("DROP TABLE #temp;");

            return GetCheckScoreTable(sql.ToString());
        }

        //--某一时间段内，各机构的平均抽查评分比较图表
        public DataTable GetScoreForAllOrgan(Hashtable args)
        {
            string _startTime = args["StartTime"].ToString() + " 00:00:00";
            string _endTime = args["EndTime"].ToString() + " 23:59:59";

            StringBuilder sql = new StringBuilder();//"SELECT OrganName 机构名称,(select AVG(Score) FROM CheckScore WHERE OrganID = A.OrganID) 平均分 FROM Organ A ";
            sql.Append("declare @startTime datetime,@endTime datetime; ");
            sql.Append("set @startTime='" + _startTime + "';set @endTime ='" + _endTime + "';");
            sql.Append("if object_id('tempdb..#temp') is not null drop table #temp;");
            sql.Append(" CREATE TABLE #temp(OrganID int,SumScore float,SumCount float);");
            sql.Append("INSERT INTO #temp SELECT OrganID,SUM(Score)SumScore,Count(id)as SumCount FROM CheckScore WHERE CheckDate BETWEEN @startTime AND @endTime GROUP BY OrganID; ");
            sql.Append("INSERT INTO #temp SELECT OrganID,0 SumScore,0 SumCount FROM Organ;");
            sql.Append("SELECT Max(OrganName) 机构名称,SUM(SumScore) as 总得分,Sum(SumCount) as 抽查次数, cast(round((case SUM(SumCount) when 0 then 0 else (SUM(SumScore)/Sum(SumCount)) end ),2) as decimal(10,2)) as 平均得分  FROM #temp A LEFT JOIN Organ B ON A.OrganID = B.OrganID GROUP BY A.OrganID;");
            sql.Append("DROP TABLE #temp;");


            return GetCheckScoreTable(sql.ToString());
        }


        /// <summary>
        /// 抽查评分
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetCheckScoreTable(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }

        #endregion

        #region 案件数

        /// <summary>
        /// 某一机构，某一时间段内的各车辆的行驶公里数比较图表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable GetVehicleCaseOneOrgan(Hashtable args)
        {
            string _startTime = args["StartTime"].ToString() + " 00:00:00";
            string _endTime = args["EndTime"].ToString() + " 23:59:59";

            StringBuilder sql = new StringBuilder();
            sql.Append("declare @startTime datetime,@endTime datetime,@OrganID int; ");
            sql.Append("set @startTime='" + _startTime + "';set @endTime ='" + _endTime + "';set @OrganID = " + args["OrganID"] + ";");
            sql.Append("if object_id('tempdb..#temp') is not null drop table #temp;");
            sql.Append(" CREATE TABLE #temp(FrameNO varchar(50),SumKilo float,SumCount float);");
            sql.Append("INSERT INTO #temp SELECT FrameNO,SUM(KM_Count),Count(FrameNO) FROM  Kilometre WHERE OrganID = @OrganID AND KM_Time BETWEEN @startTime AND @endTime GROUP BY FrameNO; ");
            sql.Append("INSERT INTO #temp SELECT FrameNO,0,0 FROM Vehicle A WHERE A.OrganID = @OrganID;");
            sql.Append("SELECT MAX(Y.VehicleID) as 车牌号,SUM(SumKilo) as 总行驶公里数 FROM #temp X JOIN Vehicle Y on X.FrameNO = Y.FrameNO GROUP BY X.FrameNO;");
            sql.Append("DROP TABLE #temp;");

            return GetVehicleCaseTable(sql.ToString());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable GetVehicleCaseAllOrgan(Hashtable args)
        {
            StringBuilder sql = new StringBuilder();
            //sql.Append("declare @startTime datetime,@endTime datetime,@OrganID int; ");
            //sql.Append("set @startTime='" + args["StartTime"] + "';set @endTime ='" + args["EndTime"] + "';set @OrganID = " + args["OrganID"] + ";");
            //sql.Append("if object_id('tempdb..#temp') is not null drop table #temp;");
            //sql.Append(" CREATE TABLE #temp(OrganID int,SumScore float,SumCount float);");
            //sql.Append("INSERT INTO #temp SELECT OrganID,SUM(Score)SumScore,Count(id)as SumCount FROM CheckScore WHERE CheckDate BETWEEN @startTime AND @endTime GROUP BY OrganID; ");
            //sql.Append("INSERT INTO #temp SELECT OrganID,0 SumScore,0 SumCount FROM Organ;");
            //sql.Append("SELECT Max(OrganName) 机构名称,SUM(SumScore) as 总得分,Sum(SumCount) as 抽查次数, cast(round((case SUM(SumCount) when 0 then 0 else (SUM(SumScore)/Sum(SumCount)) end ),2) as decimal(10,2)) as 平均得分  FROM #temp A LEFT JOIN Organ B ON A.OrganID = B.OrganID GROUP BY A.OrganID;");
            //sql.Append("DROP TABLE #temp;");

            return GetVehicleCaseTable(sql.ToString());
        }

        /// <summary>
        /// 案件数
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetVehicleCaseTable(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }

        #endregion


        #region 总费用

        //---某一机构，某一时间段内的各车辆的总费用比较图表
        public DataTable GetCostForOneOrgan(Hashtable args)
        {
            string _startTime = args["StartTime"].ToString() + " 00:00:00";
            string _endTime = args["EndTime"].ToString() + " 23:59:59";

            StringBuilder sql = new StringBuilder();
            sql.Append("declare @startTime datetime,@endTime datetime,@OrganID int; ");
            sql.Append("set @startTime='" + _startTime + "';set @endTime ='" + _endTime + "';set @OrganID = " + args["OrganID"] + ";");
            sql.Append("if object_id('tempdb..#temp') is not null drop table #temp;");
            sql.Append("CREATE TABLE #temp(VehicleID varchar(50),FrameNO varchar(50),保养费用 decimal,维修费用 decimal,现金油费 decimal,刷卡油费 decimal,保险费用 decimal);");
            sql.Append("INSERT INTO #temp ");
            sql.Append("SELECT A.VehicleID,A.FrameNO, ");
            sql.Append("(SELECT SUM(Amount)  FROM Maintenance where FrameNO = a.FrameNO AND MaintenanceDate BETWEEN @startTime AND @endTime)保养费用,");
            sql.Append("(SELECT SUM(RepairFee)  FROM Repair where FrameNO = a.FrameNO AND RepairDate BETWEEN @startTime AND @endTime)维修费用,");
            sql.Append("(SELECT SUM(FuelMoney)  FROM CashFuel where FrameNO = a.FrameNO AND FuelTime BETWEEN @startTime AND @endTime)现金油费,");
            sql.Append("(SELECT SUM(ChargeAmount)  FROM CardFuel where FrameNO = a.FrameNO AND ChargeTime BETWEEN @startTime AND @endTime)刷卡油费,");
            sql.Append("(SELECT SUM(BuyFeeSum)  FROM Insurance where FrameNO = a.FrameNO AND BuyDate BETWEEN @startTime AND @endTime)保险费用");                     
            sql.Append(" FROM Vehicle A  WHERE OrganID = @OrganID;");
            sql.Append(" SELECT MAX(VehicleID) AS 车牌号,SUM(ISNULL(保养费用,0)+ISNULL(维修费用,0)+ISNULL(现金油费,0)+ISNULL(刷卡油费,0)+ISNULL(保险费用,0)) as 总费用 from #temp GROUP BY FrameNO;");
            sql.Append("DROP TABLE #temp;");

            return GetCostTable(sql.ToString());
        }

      // 某一时间段内，各机构的平均每车总费用比较图表
        public DataTable GetCostForAllOrgan(Hashtable args)
        {
            string _startTime = args["StartTime"].ToString() + " 00:00:00";
            string _endTime = args["EndTime"].ToString() + " 23:59:59";

            StringBuilder sql = new StringBuilder();
            sql.Append("declare @startTime datetime,@endTime datetime,@OrganID int; ");
            sql.Append("set @startTime='" + _startTime + "';set @endTime ='" + _endTime + "';set @OrganID = " + args["OrganID"] + ";");
            sql.Append("if object_id('tempdb..#temp') is not null drop table #temp;");
            sql.Append("CREATE TABLE #temp(FrameNO varchar(50),OrganID int,保养费用 decimal,维修费用 decimal,现金油费 decimal,刷卡油费 decimal,保险费用 decimal);");
            sql.Append("if object_id('tempdb..#temp2') is not null drop table #temp2;");
            sql.Append("CREATE TABLE #temp2(FrameNO varchar(50),OrganID int,SumFee decimal);");
            sql.Append("INSERT INTO #temp ");
            sql.Append("SELECT A.FrameNO,A.OrganID,");
            sql.Append("(SELECT SUM(Amount)  FROM Maintenance where FrameNO = a.FrameNO AND MaintenanceDate BETWEEN @startTime AND @endTime)保养费用,");
            sql.Append("(SELECT SUM(RepairFee)  FROM Repair where FrameNO = a.FrameNO AND RepairDate BETWEEN @startTime AND @endTime)维修费用,");
            sql.Append("(SELECT SUM(FuelMoney)  FROM CashFuel where FrameNO = a.FrameNO AND FuelTime BETWEEN @startTime AND @endTime)现金油费,");
            sql.Append("(SELECT SUM(ChargeAmount)  FROM CardFuel where FrameNO = a.FrameNO AND ChargeTime BETWEEN @startTime AND @endTime)刷卡油费,");
            sql.Append("(SELECT SUM(BuyFeeSum)  FROM Insurance where FrameNO = a.FrameNO AND BuyDate BETWEEN @startTime AND @endTime)保险费用 ");
            sql.Append(" FROM Vehicle A ");
            sql.Append("INSERT INTO #temp2 SELECT FrameNO,Max(OrganID),SUM(ISNULL(保养费用,0)+ISNULL(维修费用,0)+ISNULL(现金油费,0)+ISNULL(刷卡油费,0)+ISNULL(保险费用,0)) from #temp GROUP BY FrameNO;");
            sql.Append("SELECT Max(OrganName) 机构名称, SUM(SumFee)总费用,Count(FrameNO) 车辆数,cast(round((case Count(FrameNO) when 0 then 0 else (SUM(SumFee)/Count(FrameNO)) end ),2) as decimal(10,2)) as 平均费用 FROM #temp2 A JOIN Organ B ON A.OrganID = B.OrganID Group BY A.OrganID;");

            sql.Append("DROP TABLE #temp;DROP TABLE #temp2;");
            return GetCostTable(sql.ToString());
        }

        //某台车，在某几年内的每年的总费用趋势图表
        public DataTable GetCostForOneVehicle(Hashtable args)
        {
            int _startTime = (DateTime.Parse(args["StartTime"].ToString())).Year;
            int _endTime = (DateTime.Parse(args["EndTime"].ToString())).Year;

            StringBuilder sql = new StringBuilder();
            sql.Append("declare @startTime int,@endTime int,@vehicleID varchar(50), @cnt int;");
            sql.Append("set @startTime=" + _startTime + ";set @endTime =" + _endTime + ";set @vehicleID = '" + args["Car"] + "';set @cnt=@startTime;");
            sql.Append("if object_id('tempdb..#temp') is not null drop table #temp;");
            sql.Append("CREATE TABLE #temp(T_Year varchar(20),FrameNO varchar(50),保养费用 decimal,维修费用 decimal,现金油费 decimal,刷卡油费 decimal,保险费用 decimal);");
            sql.Append("while @cnt <= @endTime begin ");
            sql.Append("INSERT INTO #temp ");
            sql.Append("SELECT @cnt,A.FrameNO,");
            sql.Append("(SELECT SUM(Amount)  FROM Maintenance where FrameNO = a.FrameNO AND YEAR(MaintenanceDate) = @cnt)保养费用,");
            sql.Append("(SELECT SUM(RepairFee)  FROM Repair where FrameNO = a.FrameNO AND YEAR(RepairDate) = @cnt)维修费用,");
            sql.Append("(SELECT SUM(FuelMoney)  FROM CashFuel where FrameNO = a.FrameNO AND YEAR(FuelTime) = @cnt)现金油费,");
            sql.Append("(SELECT SUM(ChargeAmount)  FROM CardFuel where FrameNO = a.FrameNO AND YEAR(ChargeTime) = @cnt)刷卡油费,");
            sql.Append("(SELECT SUM(BuyFeeSum)  FROM Insurance where FrameNO = a.FrameNO AND YEAR(BuyDate) = @cnt)保险费用");
            sql.Append(" FROM Vehicle A  WHERE VehicleID = @vehicleID;");
            sql.Append(" set @cnt = @cnt + 1; end;");
            sql.Append("SELECT (CAST(T_Year AS VARCHAR(50))+'年') 年份,(ISNULL(保养费用,0)+ISNULL(维修费用,0)+ISNULL(现金油费,0)+ISNULL(刷卡油费,0)+ISNULL(保险费用,0)) as 总费用 from #temp; ");
            sql.Append("DROP TABLE #temp;");
            return GetCostTable(sql.ToString());
        }

        /// <summary>
        /// 总费用
        /// </summary>
        /// <param name="organID"></param>
        /// <returns></returns>
        public DataTable GetCostTable(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }
        #endregion
    }
}
