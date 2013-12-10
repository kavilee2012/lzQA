using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Violation
    {
        private int _id;
        private string frameNO;
        private string _driver;
        private DateTime? _violationtime;
        private string _violationaddress;
        private decimal? _finemoney;
        private DateTime? _noticetime;
        private string _dealstatus;
        private DateTime? _dealtime;
        private string _remark;
        private int? _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private decimal _lateFee;
        private string _violationAct;
        private string _vehicleID;
        private string _violationActName;

        public string ViolationActName
        {
            get { return _violationActName; }
            set { _violationActName = value; }
        }

        public string VehicleID
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
        }
        public string ViolationAct
        {
            get { return _violationAct; }
            set { _violationAct = value; }
        }

        public decimal LateFee
        {
            get { return _lateFee; }
            set { _lateFee = value; }
        }

        public string InputBy
        {
            get { return _inputBy; }
            set { _inputBy = value; }
        }

        public DateTime InputTime
        {
            get { return _inputTime; }
            set { _inputTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FrameNO
        {
            set { frameNO = value; }
            get { return frameNO; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Driver
        {
            set { _driver = value; }
            get { return _driver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ViolationTime
        {
            set { _violationtime = value; }

            get
            {
                if (_violationtime != null)
                    return _violationtime;
                else
                    return DateTime.Parse("1900-1-1");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ViolationAddress
        {
            set { _violationaddress = value; }
            get { return _violationaddress; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FineMoney
        {
            set { _finemoney = value; }
            get { return _finemoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? NoticeTime
        {
            set { _noticetime = value; }
            get { return _noticetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DealStatus
        {
            set { _dealstatus = value; }
            get { return _dealstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DealTime
        {
            set { _dealtime = value; }
            get
            {
                if (_dealtime != null)
                    return _dealtime;
                else
                    return DateTime.Parse("1900-1-1");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrganID
        {
            set { _organid = value; }
            get { return _organid; }
        }
    }
}
