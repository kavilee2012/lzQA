using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Insurance
    {
        private int _id;
        private string frameNO;
        private int _insID;
        private string _buyChannel;
        private DateTime? _buydate;
        private DateTime? _outdate;
        private decimal? _buyfee;
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
        public int InsID
        {
            set { _insID = value; }
            get { return _insID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuyChannel
        {
            set { _buyChannel = value; }
            get { return _buyChannel; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? BuyDate
        {
            set { _buydate = value; }
            get { return _buydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OutDate
        {
            set { _outdate = value; }
            get { return _outdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BuyFeeSum
        {
            set { _buyfee = value; }
            get { return _buyfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrganID
        {
            set { _organid = value; }
            get { return _organid; }
        }

        private IList<InsuranceDetail> _insDetail;

        public IList<InsuranceDetail> InsDetail
        {
            get { return _insDetail; }
            set { _insDetail = value; }
        }
    }

    public class InsuranceDetail
    {
        private int _insID;
        
        private string _insType;
        private decimal _insFee;
        private decimal _insQuota;
        private int _organID;
        private decimal _insOneQuota;

        public decimal InsOneQuota
        {
            get { return _insOneQuota; }
            set { _insOneQuota = value; }
        }

        public int OrganID
        {
            get { return _organID; }
            set { _organID = value; }
        }

        public decimal InsQuota
        {
            get { return _insQuota; }
            set { _insQuota = value; }
        }

        public decimal InsFee
        {
            get { return _insFee; }
            set { _insFee = value; }
        }

        public string InsType
        {
            get { return _insType; }
            set { _insType = value; }
        }

        public int InsID
        {
            get { return _insID; }
            set { _insID = value; }
        }
    }
}
