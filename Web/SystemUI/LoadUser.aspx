<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadUser.aspx.cs" Inherits="SystemUI_LoadUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 315px;
        }
        .style2
        {
            height: 315px;
            width: 146px;
        }
        .style3
        {
            width: 146px;
        }
        .style4
        {
            height: 28px;
        }
        .style5
        {
            height: 28px;
            text-align: right;
            width: 185px;
        }
        .style6
        {
            width: 185px;
            text-align: right;
            height: 44px;
        }
        .style7
        {
            height: 28px;
            width: 345px;
            text-align: left;
        }
        .style8
        {
            width: 345px;
            height: 44px;
            text-align: left;
        }
        .style9
        {
            width: 185px;
            height: 17px;
            text-align: right;
        }
        .style10
        {
            width: 345px;
            height: 17px;
            text-align: left;
        }
        .style11
        {
            height: 17px;
        }
        .style12
        {
            height: 44px;
        }
        .style13
        {
            height: 63px;
        }
        .style14
        {
            height: 315px;
            width: 753px;
        }
        .style15
        {
            width: 753px;
        }
        .style16
        {
            height: 70px;
            text-align: left;
        }
        .style17
        {
            width: 70px;
            text-align: right;
            height: 44px;
            font-weight: bold;
        }
        .style18
        {
            width: 70px;
            height: 17px;
            text-align: right;
            font-weight: bold;
        }
        .style19
        {
            height: 28px;
            text-align: right;
            font-weight: bold;
            width: 70px;
        }
        .style20
        {
            height: 70px;
            text-align: right;
            font-weight: bold;
            width: 70px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="SubMain">
    
        <table style="width:100%;">
            <tr>
                <td colspan="3" style="text-align: center" class="style13">
                    导入用户列表</td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style14" style=" vertical-align:top;">
                    <table style="width: 722px; height: 80px;">
                        <tr>
                            <td class="style20">
                                &nbsp;</td>
                            <td class="style16" colspan="3">
                                注意：导入文件格式必须严格按照规定模板格式，<a href="../File/梯队化导入模板.xls">点击下载模板</a></td>
                        </tr>
                        <tr>
                            <td class="style19">
                                第一步：</td>
                            <td class="style5">
                                选择导入机构：</td>
                            <td class="style7">
                                <asp:DropDownList ID="ddl_Organ" runat="server" 
                                    onselectedindexchanged="ddl_Organ_SelectedIndexChanged" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style19">
                                第二步：</td>
                            <td class="style5">
                                选择路径：</td>
                            <td class="style7">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_Sure" runat="server" onclick="btn_Sure_Click" Text="确定" />
                            </td>
                            <td class="style4">
                            </td>
                        </tr>
                        <tr>
                            <td class="style18">
                                第三步：</td>
                            <td class="style9">
                                选择EXCEL工作表名：</td>
                            <td class="style10">
                                <asp:DropDownList ID="ddl_Name" runat="server">
                                </asp:DropDownList>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </td>
                            <td class="style11">
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                &nbsp;</td>
                            <td class="style6">
                            </td>
                            <td class="style8">
                                <asp:Button ID="btn_Load" runat="server" Text="开始导入" onclick="btn_Load_Click" />
                            </td>
                            <td class="style12">
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style1">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
