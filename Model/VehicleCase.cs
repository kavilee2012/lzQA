using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class VehicleCase
    {
        private int _id;
        private string frameNO;
        private string _employee;
        private int? _casecount;
        private string _remark;
        private int _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private DateTime _caseDate;
        private string _vehicleID;

        public string VehicleID
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
        }

        public DateTime CaseDate
        {
            get { return _caseDate; }
            set { _caseDate = value; }
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
        public string Employee
        {
            set { _employee = value; }
            get { return _employee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CaseCount
        {
            set { _casecount = value; }
            get { return _casecount; }
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
        public int OrganID
        {
            set { _organid = value; }
            get { return _organid; }
        }
    }
}
