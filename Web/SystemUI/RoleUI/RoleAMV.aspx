<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleAMV.aspx.cs" Inherits="SystemUI_RoleUI_RoleAMV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style4
        {
            width: 136px;
            text-align: right;
            height: 39px;
        }
        .style5
        {
            width: 136px;
            text-align: right;
            height: 31px;
            font-weight: bold;
        }
        .style6
        {
            height: 31px;
        }
        .style9
        {
            width: 136px;
            text-align: right;
            height: 3px;
            font-weight: bold;
        }
        .style10
        {
            height: 3px;
        }
        .style12
        {
            height: 39px;
        }
        .style13
        {
            width: 136px;
            text-align: right;
            height: 27px;
            font-weight: bold;
        }
        .style14
        {
            height: 27px;
        }
        .style15
        {
            height: 39px;
            text-align: left;
        }
        .style16
        {
            height: 3px;
            text-align: left;
        }
        .style17
        {
            height: 27px;
            text-align: left;
        }
        .style18
        {
            height: 31px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="SubMain" style="float:left;">
        <table style="width:400px; height: 200px;">
        <tr>
            <td class="style5">
                类别编号：</td>
            <td class="style18">
                <asp:Label ID="lab_Code" runat="server" Text="自动编号"></asp:Label>
            </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style13">
                类别名称：</td>
            <td class="style17">
                <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_Name" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="style14">
                </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style16">
                <asp:HiddenField ID="hind_OrganID" runat="server" />
            </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style4">
                </td>
            <td class="style15">
                <asp:Button ID="btn_Add" runat="server" onclick="btn_Add_Click" Text="添加" />
                <asp:Button ID="btn_Modity" runat="server" onclick="btn_Modity_Click" 
                    Text="修改" style="height: 26px" />
            </td>
            <td class="style12">
                </td>
        </tr>
    </table>
    </div>

    </form>
</body>
</html>
