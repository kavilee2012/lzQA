using System;
using System.Collections.Generic;
using System.Text;
using SqlServerDAL;
using System.Data;

namespace BLL
{
    public class LoginBLL
    {
        LoginDAL dal = new LoginDAL();
        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetLoginUserInfo(string userID, string pwd)
        {
            return dal.GetLoginUserInfo(userID, pwd);
        }

        /// <summary>
        /// 获取登录功能权限
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetLoginUserFcList(string userID)
        {
            return dal.GetLoginUserFcList(userID);
        }

        /// <summary>
        /// 获取登录数据权限
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public IList<string> GetLoginUserObjectGroup(string userID)
        {

            return dal.GetLoginUserObjectGroup(userID);
        }

        /// <summary>
        /// 获取登录数据权限
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetLoginUserSubOrgan(int organID)
        {

            return dal.GetLoginUserSubOrgan(organID);
        }

             /// <summary>
        /// 获取超级管理员功能权限
        /// </summary>
        /// <param name="organID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetSuperUserFcList()
        {
            return dal.GetSuperUserFcList();
        }
    }
}
