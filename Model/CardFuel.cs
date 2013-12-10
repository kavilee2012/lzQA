using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CardFuel
    {
        private int _id;
        private string frameNO;
        private DateTime? _chargetime;
        private decimal? _chargeamount;
        private decimal? _balance;
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
            set { frameNO = value; }
            get { return frameNO; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ChargeTime
        {
            set { _chargetime = value; }
            get { return _chargetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ChargeAmount
        {
            set { _chargeamount = value; }
            get { return _chargeamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Balance
        {
            set { _balance = value; }
            get { return _balance; }
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
