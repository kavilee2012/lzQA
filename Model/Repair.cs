using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Repair
    {
        private int _id;
        private string _frameno;
        private DateTime? _repairdate;
        private string _repairperson;
        private decimal? _repairfee;
        private bool _isinsurance;
        private int? _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private string _repairDetail;
        private string _vehicleID;
        private string _reportImg;

        public string ReportImg
        {
            get { return _reportImg; }
            set { _reportImg = value; }
        }

        public string VehicleID
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
        }
        public string RepairDetail
        {
            get { return _repairDetail; }
            set { _repairDetail = value; }
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
            set { _frameno = value; }
            get { return _frameno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RepairDate
        {
            set { _repairdate = value; }
            get { return _repairdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RepairPerson
        {
            set { _repairperson = value; }
            get { return _repairperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RepairFee
        {
            set { _repairfee = value; }
            get { return _repairfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsInsurance
        {
            set { _isinsurance = value; }
            get { return _isinsurance; }
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
