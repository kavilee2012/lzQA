using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using SqlServerDAL;

namespace BLL
{
    public class CommonBLL
    {
        public DataTable GetSubSystem()
        {
            return new CommonDAL().GetSubSystem();
        }

        public void BindDDL_SubSystem(DropDownList ddl)
        {
            DataTable dt = new CommonDAL().GetSubSystem();
            ddl.DataSource = dt;
            ddl.DataValueField = "SystemCode";
            ddl.DataTextField = "SystemName";
        }

        public DataTable GetObjectType()
        {
            return new CommonDAL().GetObjectType();
        }

        public static void BindDDL_ObjectType(DropDownList ddl)
        {
            DataTable dt = new CommonDAL().GetObjectType();
            ddl.DataSource = dt;
            ddl.DataValueField = "TypeCode";
            ddl.DataTextField = "TypeName";
        }

        public void BindBLL_Organ(DropDownList ddl)
        {
            DataTable dt = new OrganBLL().GetAllList().Tables[0];
            ddl.DataSource = dt;
            ddl.DataValueField = "OrganID";
            ddl.DataTextField = "OrganName";
        }
    }
}
