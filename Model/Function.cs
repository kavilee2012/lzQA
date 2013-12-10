using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Function
    {
        private int _id;
        private string _code;
        private string _name;
        private int? _grade;
        private int? _status = 1;
        private int _viewOrder;
        private string _fatherCode;
        private string _url;
        private int _type;

        public int F_Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string FatherCode
        {
            get { return _fatherCode; }
            set { _fatherCode = value; }
        }

        public int ViewOrder
        {
            get { return _viewOrder; }
            set { _viewOrder = value; }
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
        public string F_Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Grade
        {
            set { _grade = value; }
            get { return _grade; }
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
