using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Kilometre
    {
        private int _id;
        private string _frameno;
        private DateTime? _km_time;
        private decimal? _km_count;
        private string _km_image;
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
            set { _frameno = value; }
            get { return _frameno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KM_Time
        {
            set { _km_time = value; }
            get { return _km_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? KM_Count
        {
            set { _km_count = value; }
            get { return _km_count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KM_Image
        {
            set { _km_image = value; }
            get { return _km_image; }
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
