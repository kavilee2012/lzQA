using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using System.Data;
using System.IO;
using BLL;
using Model;

public partial class SystemUI_LoadUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindOrgan();
        }
    }

    protected void ddl_Organ_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void BindOrgan()
    {
       DataSet ds = new OrganBLL().GetAllList();
       ddl_Organ.DataSource = ds.Tables[0];
       ddl_Organ.DataTextField = "OrganName";
       ddl_Organ.DataValueField = "OrganID";
       ddl_Organ.DataBind();
    }

    protected void btn_Sure_Click(object sender, EventArgs e)
    {


        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentLength < 10485760)
            {
                try
                {
                    string name = this.FileUpload1.FileName;
                    //获取上传文件 
                    string type = name.Substring(name.LastIndexOf(".") + 1);
                    //获取上传文件的后缀 

                    string newName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + type;
                    //更改上传文件名 
                    string path1 = Server.MapPath("~/File/") + newName;
                    FileUpload1.SaveAs(path1);

                    HiddenField1.Value = path1;

                    Dictionary<string, int> source = ExcelService.GetAllSheets(path1);
                    if (source != null)
                    {
                        foreach (KeyValuePair<string, int> item in source)
                        {
                            ListItem li = new ListItem();
                            li.Text = item.Key;
                            li.Value = item.Value.ToString();

                            ddl_Name.Items.Add(li);
                        }
                    }

                }
                catch (Exception ex)
                {
                    UtilityService.Alert(this.Page, "导入失败!,详细:" + ex.Message);
                }
            }
            else
            {
                UtilityService.Alert(this.Page, "文件过大,请分批导入!");
            }
        }
    }

    protected void btn_Load_Click(object sender, EventArgs e)
    {
        //if (FileUpload1.HasFile)
        //{
        //    if (FileUpload1.PostedFile.ContentLength < 10485760)
        //    {
        try
        {
            //string name = this.FileUpload1.FileName;
            ////获取上传文件 
            //string type = name.Substring(name.LastIndexOf(".") + 1);
            ////获取上传文件的后缀 

            //string newName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + type;
            ////更改上传文件名 
            //string path1 = Server.MapPath("~/File/") + newName;
            //FileUpload1.SaveAs(path1);

            //UtilityService.Alert(this.Page,"key:" + ddl_Name.SelectedItem.Text + "  value:" + ddl_Name.SelectedItem.Value.ToString());

            LoadExcel(HiddenField1.Value);

        }
        catch (Exception ex)
        {
            UtilityService.Alert(this.Page, "导入失败!,详细:" + ex.Message);
        }
        finally
        {
            if (File.Exists(HiddenField1.Value))
            {
                File.Delete(HiddenField1.Value);
            }
            ddl_Name.DataSource = null;
            ddl_Name.DataBind();

            HiddenField1.Value = null;
        }
        //    }
        //    else
        //    {
        //        UtilityService.Alert(this.Page, "文件过大,请分批导入!");
        //    }
        //}
    }

    private void LoadExcel(string path)
    {
        try
        {
            DataTable dt = null;
            try
            {
                dt = ExcelService.ImportDataTableFromExcel(path, int.Parse(ddl_Name.SelectedItem.Value), 0);

            }
            catch
            { }
            if (dt != null)
            {
                EmployeeBLL iBLL = new EmployeeBLL();
                IList<Employee> iList = new List<Employee>();
                IList<int> iListErrorRowNumber = new List<int>();
                IList<int> iListFailRowNumber = new List<int>();
                int _OrganID = Convert.ToInt32(ddl_Organ.SelectedValue);
                string _InputBy = Session["UserID"].ToString();

                int count = 0;
                int row = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    //excel内容
                    string _UserName = dr["姓名"].ToString();
                    string _PQ = dr["片区"].ToString();
                    string _DZ = dr["大组"].ToString();
                    string _XZ = dr["小组"].ToString();
                    string _RoleName = dr["梯队任职"].ToString();
                    string _IsPrivateStr = dr["是否公估"].ToString();


                    if (string.IsNullOrEmpty(_UserName) || string.IsNullOrEmpty(_PQ) || !ValidateService.IsNumber(_DZ) || string.IsNullOrEmpty(_XZ) || string.IsNullOrEmpty(_RoleName) || string.IsNullOrEmpty(_IsPrivateStr))
                    {
                        row++;
                        iListErrorRowNumber.Add(row);
                        continue;
                    }

                    bool _isPrivate = _IsPrivateStr == "否" ? false : true;

                    //添加用户
                    string _userID = AddUser(_UserName, _OrganID);


                    //添加组织
                    string _PQname = "",_DZname="",_XZname="";
                    string _PQcode = "",_DZcode="",_XZcode="";
                    if (_PQ != "0")
                    {
                        _PQname = _PQ + "片区";
                        _PQcode = AddPosition(_PQname, _OrganID, "市级管理层");
                    }
                    else
                    {
                        _PQcode = AddPosition("市级管理层", _OrganID, "市级管理层");
                    }


                    if (_DZ != "0")
                    {
                        _DZname =_PQname + _DZ + "大组";
                    }
                    _DZcode = AddPosition(_DZname, _OrganID, _PQname);


                    if (_XZ != "0")
                    {
                        if (_DZname != string.Empty)
                        {
                            _XZname = _DZname + _XZ + "小组";
                        }
                        else
                        {
                            _XZname = _PQname + _XZ + "小组";
                        }
                    }
                    _XZcode = AddPosition(_XZname, _OrganID, _DZname);
                    
                   

                    string _posiCode = "";
                    if (!string.IsNullOrEmpty(_PQcode))
                    {
                        _posiCode = _PQcode;
                    }
                    if (!string.IsNullOrEmpty(_DZcode))
                    {
                        _posiCode = _DZcode;
                    }
                    if (!string.IsNullOrEmpty(_XZcode))
                    {
                        _posiCode = _XZcode;
                    }

                    //添加组织关联
                    if (!string.IsNullOrEmpty(_posiCode))
                    {
                        List<string> posiList = new List<string>();
                        posiList.Add(_posiCode);
                        int rePU = new PositionBLL().AddPosi2User(_userID, posiList);
                    }

                    //添加角色
                    string _roleCode = AddRole(_RoleName, _OrganID);

                    //添加角色关联
                    if (!string.IsNullOrEmpty(_roleCode))
                    {
                        List<string> roleList = new List<string>();
                        roleList.Add(_roleCode);
                        int reRU = new UserBLL().AddRole2User(_userID, roleList);
                    }

                    //添加员工
                    AddEmployee(_UserName,_OrganID,_isPrivate);
                    count++;
                }

                string msg = "";
                if (count > 0)
                {
                    msg = msg + "成功上传数据" + count + "条!";
                    msg = msg + "\\n";
                }

                if (iListErrorRowNumber.Count > 0)
                {

                    msg = msg + "数据不全或有误共" + iListErrorRowNumber.Count + "条,请核对以下行号的数据是否有误,并进行修改!";
                    msg = msg + "\\n 有误行号:";
                    foreach (int i in iListErrorRowNumber)
                    {
                        msg += i + ",";
                    }
                    msg = msg + "\\n";
                }

                if (iListFailRowNumber.Count > 0)
                {
                    msg = msg + "车架号已存在共" + iListFailRowNumber.Count + "条!";
                    msg = msg + "\\n 已存在行号:";
                    foreach (int i in iListFailRowNumber)
                    {
                        msg += i + ",";
                    }
                    msg = msg + "\\n";
                }

                UtilityService.Alert(this.Page, msg);


            }
        }
        catch (Exception ex)
        {
            UtilityService.Alert(this.Page, "导入失败!,详细:" + ex.Message);
        }
    }


    private string AddPosition(string name,int organID,string fatherName)
    {
        if (name == "0" || name == string.Empty)
        {
            return "";
        }
        PositionBLL pBLL = new PositionBLL();
        bool _re = pBLL.Exists(name, organID);
        if (!_re)
        {
            string _fatherCode = pBLL.GetPosiCode(fatherName, organID);
            if (string.IsNullOrEmpty(_fatherCode))
            {
                _fatherCode = "0";
            }
            Position p = new Position();
            p.PosiName = name;
            p.FatherCode = _fatherCode;
            p.OrganID = organID;
            p.InputBy = Session["UserID"].ToString();

            bool re = pBLL.Add(p);

            if (re)
            { 
                //添加数据组
                string _groupName = name + "数据组";
                try
                {
                    ObjectGroup r = new ObjectGroup();
                    r.Name = _groupName;
                    r.TypeCode = "T0001";
                    r.OrganID = organID;
                    r.InputBy = Session["UserID"].ToString();
                    int reOG = new ObjectGroupBLL().Add(r);
                    if (reOG > 0)
                    {
                        string _groupCode = new ObjectGroupBLL().GetObjectGroupCode(_groupName, organID);
                        string _pCode = pBLL.GetPosiCode(name, organID);

                        List<string> ogList = new List<string>();
                        ogList.Add(_groupCode);

                        int reP2O = new PositionBLL().AddPosi2ObjectGroup(_pCode, ogList);

                    }
                }
                catch
                { 
                    
                }
            }
        }
        string _Code = pBLL.GetPosiCode(name, organID);
        return _Code;
    }

    private string AddRole(string name, int organID)
    {
        if (name == string.Empty || name == "无")
        {
            return "";
        }
        RoleBLL pBLL = new RoleBLL();
        bool _re = pBLL.Exists(name, organID);
        if (!_re)
        {
            Role p = new Role();
            p.RoleName = name;

            p.OrganID = organID;
            p.InputBy = Session["UserID"].ToString();

            int re = pBLL.Add(p);
        }

        string _Code = pBLL.GetRoleCode(name, organID);
        return _Code;
    }

    private string AddUser(string name, int organID)
    {
        UserBLL pBLL = new UserBLL();

        int i = 0;
        string newName = name;  
        while (true)
        {
            bool _re = pBLL.Exists(newName, organID);
            if (_re)
            {
                i++;
                newName = name + i.ToString();
            }
            else
            {
                User p = new User();
                p.UserName = newName;

                p.OrganID = organID;
                p.InputBy = Session["UserID"].ToString();

                int reAdd = pBLL.Add(p);
                break;
            }
        }


        string _Code = pBLL.GetUserID(newName, organID);
        return _Code;
    }

    private void AddEmployee(string name, int organID, bool isPrivate)
    {
        EmployeeBLL pBLL = new EmployeeBLL();

        int i = 0;
        string newName = name;
        while (true)
        {
            bool _re = pBLL.Exists(newName, organID);
            if (_re)
            {
                i++;
                newName = name + i.ToString();
            }
            else
            {
                Employee e = new Employee();
                e.Name = name;
                e.IsPrivate = isPrivate;
                e.JoinDate = null;
                e.LeaveDate = null;

                e.OrganID = organID;
                e.InputBy = Session["UserID"].ToString();

                bool re = new EmployeeBLL().Add(e);
                break;
            }
        }
    }

}
