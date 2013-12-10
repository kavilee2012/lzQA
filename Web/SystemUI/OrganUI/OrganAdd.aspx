<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganAdd.aspx.cs" Inherits="SystemUI_OrganUI_OrganAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style type="text/css">
    ul li
    {
    	margin-top:10px;
    }
    </style>
    <script src="../../JavaScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
            <div id="PageBody"  style="float:left;">
            <ul style=" font-size:12px; font-weight:bold; ">
            <li>编&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;号： <asp:TextBox ID="txt_ID" 
                    runat="server" ReadOnly="True">自动生成</asp:TextBox></li>
            <li>名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 称： <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_Name" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </li>
            <li>级&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;别： 
            <asp:DropDownList ID="ddl_Level" runat="server">
                      <asp:ListItem Value="1">二级</asp:ListItem>
                      <asp:ListItem Selected="True" Value="2">三级</asp:ListItem>
                      <asp:ListItem Value="3">三级以下</asp:ListItem>
                    </asp:DropDownList>
            </li>
            <li>上级机构： <asp:DropDownList ID="ddl_Superior" runat="server">
                    </asp:DropDownList></li>
            <li>描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 述： 
                <asp:TextBox ID="txt_Remark" 
                    runat="server" Width="211px" onClick="calendar()" Height="34px" 
                    TextMode="MultiLine"></asp:TextBox></li>
                    <li></li>
                    <li></li>
                    <li></li>
            <li><asp:Button ID="btn_Add" runat="server"  Text="添加" onclick="Button1_Click" /></li>
            </ul>
        </div>
    
    </form>
</body>
</html>
