using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Employee
    {
        private string _employeeid;
        private int? _organid;
        private string _name;
        private bool _sex;
        private string _native;
        private string _nation;
        private string _education;
        private string _personid;
        private DateTime? _birthdate;
        private string _address;
        private string _telephone;
        private string _mobile;
        private string _position;
        private DateTime? _joindate;
        private string _photo;
        private DateTime? _startjobdate;
        private string _drivelicenseno;
        private string _issuedepartment;
        private DateTime? _dl_startdate;
        private DateTime? _dl_enddate;
        private bool _isDriver;
        private DateTime _inputTime;
        private string _inputBy;
        private bool _isPrivate;

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

        public bool IsDriver
        {
            get { return _isDriver; }
            set { _isDriver = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeID
        {
            set { _employeeid = value; }
            get { return _employeeid; }
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Native
        {
            set { _native = value; }
            get { return _native; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonID
        {
            set { _personid = value; }
            get { return _personid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LeaveDate
        {
            set { _birthdate = value; }
            get { return _birthdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? JoinDate
        {
            set { _joindate = value; }
            get { return _joindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartJobDate
        {
            set { _startjobdate = value; }
            get { return _startjobdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DriveLicenseNO
        {
            set { _drivelicenseno = value; }
            get { return _drivelicenseno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IssueDepartment
        {
            set { _issuedepartment = value; }
            get { return _issuedepartment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DL_StartDate
        {
            set { _dl_startdate = value; }
            get { return _dl_startdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DL_EndDate
        {
            set { _dl_enddate = value; }
            get { return _dl_enddate; }
        }
    }
}
