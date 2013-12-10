using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class YearCheck
    {
        private int _id;
        private string frameNO;
        private DateTime? _yc_date;
        private DateTime? _validdate;
        private int? _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private string _vehicleID;

        public string VehicleID
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
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
        public DateTime? YC_Date
        {
            set { _yc_date = value; }
            get { return _yc_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ValidDate
        {
            set { _validdate = value; }
            get { return _validdate; }
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
