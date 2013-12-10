using System;
namespace Model
{
	/// <summary>
	/// 实体类Vehicle 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Vehicle
	{
		public Vehicle()
		{}
		#region Model
		private int _id;
		private string vehicleID;
		private string _frameno;
		private int? _vehicletype;
		private decimal? _vehicleprice;
		private DateTime? _startusedate;
		private string _keepperson;
		private string _backupkeyperson;
		private DateTime? _planscrapdate;
		private int? _organid;
		private string _chargeperson;
		private string _superchargeperson;
        private string _photo;
        private string _objectGroup;
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

        public string ObjectGroup
        {
            get { return _objectGroup; }
            set { _objectGroup = value; }
        }

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VehicleID
		{
			set{ vehicleID=value;}
			get{return vehicleID;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FrameNO
		{
			set{ _frameno=value;}
			get{return _frameno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VehicleType
		{
			set{ _vehicletype=value;}
			get{return _vehicletype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? VehiclePrice
		{
			set{ _vehicleprice=value;}
			get{return _vehicleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartUseDate
		{
			set{ _startusedate=value;}
			get{return _startusedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeepPerson
		{
			set{ _keepperson=value;}
			get{return _keepperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BackupKeyPerson
		{
			set{ _backupkeyperson=value;}
			get{return _backupkeyperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PlanScrapDate
		{
			set{ _planscrapdate=value;}
			get{return _planscrapdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrganID
		{
			set{ _organid=value;}
			get{return _organid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChargePerson
		{
			set{ _chargeperson=value;}
			get{return _chargeperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SuperChargePerson
		{
			set{ _superchargeperson=value;}
			get{return _superchargeperson;}
		}
		#endregion Model

	}
}

