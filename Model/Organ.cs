using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// Organ:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    //[Serializable]
    public class Organ
    {
        private int _organid;
        private string _organname;
        private string _remark;
        private int _superior;
        private int _level;
        private string _inputBy;

        private string _superiorName;
        private string _levelName;

        public string LevelName
        {
            get {
                if (_level == 1)
                    return "二级";
                else  
                    return "三级";
            }
            set { _levelName = value; }
        }

        public string SuperiorName
        {
            get { return _superiorName; }
            set { _superiorName = value; }
        }

        public string InputBy
        {
            get { return _inputBy; }
            set { _inputBy = value; }
        }
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
        public string OrganName
        {
            set { _organname = value; }
            get { return _organname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Superior
        {
            set { _superior = value; }
            get { return _superior; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Level
        {
            set { _level = value; }
            get { return _level; }
        }

    }
}
