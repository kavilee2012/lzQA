<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectTypeAMV.aspx.cs" Inherits="SystemUI_ObjectUI_ObjectTypeAMV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="SubMain">
    
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            DataSourceID="ObjectDataSource1" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="TypeCode" HeaderText="TypeCode" 
                    SortExpression="TypeCode" />
                <asp:BoundField DataField="OrganID" HeaderText="OrganID" 
                    SortExpression="OrganID" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="Model.ObjectGroup" SelectMethod="GetModel" 
            TypeName="BLL.ObjectGroupBLL" UpdateMethod="Update">
            <SelectParameters>
                <asp:QueryStringParameter Name="code" QueryStringField="Code" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
