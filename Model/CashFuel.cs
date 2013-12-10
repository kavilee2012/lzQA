using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CashFuel
    {
        private int _id;
        private string _frameNO;
        private DateTime? _fueltime;
        private string _address;
        private decimal? _fuelmoney;
        private string _operator;
        private string _reason;
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
            set { _frameNO = value; }
            get { return _frameNO; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FuelTime
        {
            set { _fueltime = value; }
            get { return _fueltime; }
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
        public decimal? FuelMoney
        {
            set { _fuelmoney = value; }
            get { return _fuelmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reason
        {
            set { _reason = value; }
            get { return _reason; }
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
