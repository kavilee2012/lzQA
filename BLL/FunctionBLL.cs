using System;
using System.Collections.Generic;
using System.Text;
using Model;
using SqlServerDAL;

namespace BLL
{
    public class FunctionBLL
    {
        FunctionDAL dal = new FunctionDAL();

        public IList<Function> GetAllFunctionList()
        {
            return dal.GetAllFunctionList();
        }

        public IList<Function> GetChildFunctionList(string fatherCode,bool isSuper)
        {
            return dal.GetChildFunctionList(fatherCode,isSuper);
        }

        public Function GetFunctionByCode(string code)
        {
            return dal.GetFunctionByCode(code);
        }

        public int SetRole2Function(string roleCode, List<string> funcList)
        {
            return dal.SetRole2Function(roleCode, funcList);
        }

        public List<string> GetRole2Function(string roleCode)
        {
            return dal.GetRole2Function(roleCode);

        }

        public List<string> GetUserFunctionList(string userID)
        {
            return dal.GetUserFunctionList(userID);
        }
    }
}
