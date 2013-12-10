using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SqlServerDAL
{
    public class CommonDAL
    {
        /// <summary>
        /// 获取数据类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetObjectType()
        {
            string sql = "SELECT * FROM ObjectType";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }


        /// <summary>
        /// 获取子系统
        /// </summary>
        /// <returns></returns>
        public DataTable GetSubSystem()
        {
            string sql = "SELECT * FROM SubSystem";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
    }
}
