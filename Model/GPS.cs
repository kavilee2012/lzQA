using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GPS
    {
        private int _id;
        private string frameNO;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private decimal? _distance;
        private int? _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private string _vehicleID;
        private string _photo;

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
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
        public DateTime? StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Distance
        {
            set { _distance = value; }
            get { return _distance; }
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
