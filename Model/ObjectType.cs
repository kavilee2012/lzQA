using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ObjectType
    {
        private int _id;
        private string _typecode;
        private string _typename;
        private string _subsystemname;
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
        public string TypeCode
        {
            set { _typecode = value; }
            get { return _typecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubSystemName
        {
            set { _subsystemname = value; }
            get { return _subsystemname; }
        }
    }
}
