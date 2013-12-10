<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PositionAMV.aspx.cs" Inherits="SystemUI_UserUI_PositionAMV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="SubMain" style=" float:left; ">
        <table style="width:500px; font-size:12px; font-weight:bold;">
        <tr>
            <td class="style1">
                组织编号：</td>
            <td class="style2">
                <asp:TextBox ID="lab_Code" runat="server" Text="自动生成" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                组织名称：</td>
            <td class="style2">
                <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_Name" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                上级组织：</td>
            <td class="style2">
                <asp:DropDownList ID="ddl_Father" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btn_Add" runat="server" onclick="btn_Add_Click" Text="添加" />
                <asp:Button ID="btn_Modity" runat="server" onclick="btn_Modity_Click" 
                    Text="修改" />
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
