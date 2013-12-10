using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Alert
    {
        private int _alertid;
        private string _alertname;
        private string _alertRule;
        //private string _minvalue;
        //private string _maxvalue;
        private int _organid = 0;
        private string _description;
        /// <summary>
        /// 
        /// </summary>
        public int AlertID
        {
            set { _alertid = value; }
            get { return _alertid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AlertName
        {
            set { _alertname = value; }
            get { return _alertname; }
        }


        public string AlertRule
        {
            get { return _alertRule; }
            set { _alertRule = value; }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string MinValue
        //{
        //    set { _minvalue = value; }
        //    get { return _minvalue; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string MaxValue
        //{
        //    set { _maxvalue = value; }
        //    get { return _maxvalue; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public int OrganID
        {
            set { _organid = value; }
            get { return _organid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
    }
}
