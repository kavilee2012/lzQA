using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Model;
using BLL;
using System.Collections.Generic;
using Utility;

public partial class SystemUI_RoleUI_Role2Function : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string _name = Request.QueryString["name"].ToString();
            string _code = Request.QueryString["Code"].ToString();
            //if (_name == "系统管理员" || _name == "超级管理员" || _code.Substring(2, 4) == "0000")
            //{
            //    btn_Sure.Enabled = false;
            //    //UtilityService.AlertAndRedirect(this.Page, "不能修改系统管理员信息！", "RoleMgr.aspx");
            //}
            lab_Name.Text = _name;
            BindTreeView();
            LoadRoleFunction();
        }
    }

    protected void BindTreeView()
    {

        FunctionBLL bll = new FunctionBLL();
        IList<Function> list = bll.GetChildFunctionList("0",false);
        foreach (Function model in list)
        {
            string name = model.F_Name;
            string code = model.F_Code.ToString();
            TreeNode td = new TreeNode(name, code);

            td.SelectAction = TreeNodeSelectAction.None;
            td.Expanded = false;

            BindChildTree(td);
            tvModel.Nodes.Add(td);
        }
    }

    protected void BindChildTree(TreeNode node)
    {
        string nodeid = node.Value;

        FunctionBLL bll = new FunctionBLL();
        IList<Function> list = bll.GetChildFunctionList(nodeid,false);
        if (list != null)
        {
            foreach (Function model in list)
            {
                string name = model.F_Name;
                string code = model.F_Code.ToString();
                TreeNode td = new TreeNode(name, code);
                td.SelectAction = TreeNodeSelectAction.None;
                td.Expanded = false;

                BindChildTree(td);
                node.ChildNodes.Add(td);

            }
        }

    }


    public List<string> GetAllSelectedTreeNodes()//显示选中的树节点编号
    {
        List<string> selList = new List<string>();
        foreach (TreeNode node in this.tvModel.Nodes)
        {
            if (node.Checked)
            {
                selList.Add(node.Value.ToString());
            }
            GetCheckedNodes(node,selList);
        }
        return selList;
    }

    private void GetCheckedNodes(TreeNode parentNode, List<string> selList)
    {
        foreach (TreeNode node in parentNode.ChildNodes)
        {

            if (node.Checked == true)
            {
                selList.Add(node.Value.ToString());
            }
            if (node.ChildNodes.Count > 0)
            {
                GetCheckedNodes(node,selList);
            }
        }
    }


    protected void LoadRoleFunction()
    { 
        FunctionBLL bll = new FunctionBLL();
        List<string> list = bll.GetRole2Function(Request.QueryString["Code"].ToString());
        foreach (TreeNode node in this.tvModel.Nodes)
        {
            SetCheckedNodes(node,list);
        }
    }


    private void SetCheckedNodes(TreeNode parentNode,List<string> list)
    {

        foreach (TreeNode node in parentNode.ChildNodes)
        {
            if (list.Contains(node.Value.ToString()))
            {
                node.Checked = true;
                if (!parentNode.Checked)
                {
                    parentNode.Checked = true;
                }
            }
            else
            {
                node.Checked = false;
            }

            if (node.ChildNodes.Count > 0)
            {
                SetCheckedNodes(node,list);
            }

        }

    }


    protected void btn_Sure_Click(object sender, EventArgs e)
    {
        List<string> funcList = GetAllSelectedTreeNodes();
        string roleCode = Request.QueryString["Code"].ToString();

        int re = new FunctionBLL().SetRole2Function(roleCode, funcList);
        if (re > 0)
        {
            UtilityService.Alert(this.Page,"设置完成!");
            LoadRoleFunction();
        }
        else
        {
            UtilityService.Alert(this.Page, "设置失败!");
        }
    }
}
