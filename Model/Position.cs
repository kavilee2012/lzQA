using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Position
    {
        private int? _id;
        private string _posicode;
        private string _posiname;
        private string _fathercode;
        private int? _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private string _fatherCodeName;

        public string FatherCodeName
        {
            get { return _fatherCodeName; }
            set { _fatherCodeName = value; }
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
        public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PosiCode
        {
            set { _posicode = value; }
            get { return _posicode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PosiName
        {
            set { _posiname = value; }
            get { return _posiname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FatherCode
        {
            set { _fathercode = value; }
            get { return _fathercode; }
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
