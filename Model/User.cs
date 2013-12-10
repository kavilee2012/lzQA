using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class User
    {
        private int _id;
        private string _userid;
        private string _password;
        private int? _organid;
        private int? _status = 1;
        private string _userName;
        private DateTime _inputTime;
        private string _inputBy;
        private bool _isPrivate;
        private DateTime _openDate;

        public DateTime OpenDate
        {
            get { return _openDate; }
            set { _openDate = value; }
        }

        public bool IsPrivate
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
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

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
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
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
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
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
    }
}
