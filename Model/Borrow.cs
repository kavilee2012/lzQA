using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Borrow
    {
        #region Model
        private int _id;
        private string _frameno;
        private string _brrowperson;
        private DateTime? _brrowtime;
        private string _remark;
        private int? _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private string _vehicleID;
        private DateTime _backTime;

        public DateTime BackTime
        {
            get { return _backTime; }
            set { _backTime = value; }
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
            set { _frameno = value; }
            get { return _frameno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BorrowPerson
        {
            set { _brrowperson = value; }
            get { return _brrowperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BorrowTime
        {
            set { _brrowtime = value; }
            get { return _brrowtime; }
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
        #endregion Model
    }
}
