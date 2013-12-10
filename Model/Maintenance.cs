using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Maintenance
    {
        private int _id;
        private string frameNO;
        private DateTime? _maintenancedate;
        private string _address;
        private string _factory;
        private string _project;
        private int? _organid;
        private DateTime _inputTime;
        private string _inputBy;
        private string _relator;
        private decimal _amount;
        private int _kilometre;
        private string _vehicleID;

        public string VehicleID
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
        }
        public int Kilometre
        {
            get { return _kilometre; }
            set { _kilometre = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Relator
        {
            get { return _relator; }
            set { _relator = value; }
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
        public DateTime? MaintenanceDate
        {
            set { _maintenancedate = value; }
            get { return _maintenancedate; }
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
        public string Factory
        {
            set { _factory = value; }
            get { return _factory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Project
        {
            set { _project = value; }
            get { return _project; }
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
