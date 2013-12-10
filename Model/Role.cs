using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Role
    {
        private int _id;
        private string _rolecode;
        private string _rolename;
        private int? _status;
        private bool _isadmin;
        private int? _organid;
        private string _subsystemcode;
        private DateTime _inputTime;
        private string _inputBy;

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
        public string RoleCode
        {
            set { _rolecode = value; }
            get { return _rolecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAdmin
        {
            set { _isadmin = value; }
            get { return _isadmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrganID
        {
            set { _organid = value; }
            get { return _organid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubSystemCode
        {
            set { _subsystemcode = value; }
            get { return _subsystemcode; }
        }
    }
}
