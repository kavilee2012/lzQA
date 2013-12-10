using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CheckScore
    {
        private int _id;
        private string frameNO;
        private DateTime? _checkdate;
        private int? _score;
        private string _checkimage;
        //private string _gps;
        private int? _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private string _vehicleID;
        private string _detail;

        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

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
        public DateTime? CheckDate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CheckImage
        {
            set { _checkimage = value; }
            get { return _checkimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        //public string GPS
        //{
        //    set { _gps = value; }
        //    get { return _gps; }
        //}
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
