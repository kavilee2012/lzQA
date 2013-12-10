<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAMV.aspx.cs" Inherits="SystemUI_UserUI_UserAMV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="../../JavaScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style>
            .style1
        {
            text-align: right;
            font-weight: bold;
            width: 123px;
        }
        .style2
        {
            width: 215px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="SubMain" style="float:left;">
        <table style="width:500px; height: 141px; float:left">
        <tr>
            <td class="style1">
                UM账号：</td>
            <td class="style2">
                <asp:TextBox ID="txt_UM" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txt_Name" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                用户名：</td>
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
                机构：</td>
            <td class="style2" >
                <asp:Panel ID="Panel1" runat="server">
                    <asp:DropDownList ID="ddl_Organ" runat="server" Height="17px" Width="126px">
                    </asp:DropDownList>
                </asp:Panel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;color:black;mso-ansi-language:EN-US;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">用户开通时间: </span></td>
            <td class="style2" >
                <asp:TextBox ID="txt_OpenDate" runat="server" onClick="WdatePicker()"></asp:TextBox>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2" >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2" >
                <asp:Button ID="btn_Add" runat="server" onclick="btn_Add_Click" Text="添加" />
                <asp:Button ID="btn_Modity" runat="server" onclick="btn_Modity_Click" 
                    Text="修改" />
                <asp:Button ID="btn_ResetPwd" runat="server" Text="初始化密码" 
                    onclick="btn_ResetPwd_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
