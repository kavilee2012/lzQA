using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SubSystem
    {
        private int _id;
        private string _systemcode;
        private string _systemname;
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
        public string SystemCode
        {
            set { _systemcode = value; }
            get { return _systemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SystemName
        {
            set { _systemname = value; }
            get { return _systemname; }
        }
    }
}
