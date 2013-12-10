<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganAMV.aspx.cs" Inherits="SystemUI_OrganUI_OrganAMV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="SubMain">
    
        <asp:DetailsView ID="dv_Organ" runat="server" Height="50px" Width="229px" 
            AutoGenerateRows="False" DataSourceID="sourceDV" 
            oniteminserting="dv_Organ_ItemInserting">
            <Fields>
                <asp:TemplateField HeaderText="机构编号" SortExpression="OrganID" 
                    InsertVisible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_OrganID" ReadOnly="true" runat="server" Text='<%# Bind("OrganID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="txt_OrganID" runat="server" Text='<%# Bind("OrganID") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txt_OrganID" ErrorMessage="格式不正确" 
                            ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OrganID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="机构名称" SortExpression="OrganName">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_OrganName" runat="server" Text='<%# Bind("OrganName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="不能为空" ControlToValidate="txt_OrganName"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="txt_OrganName" runat="server" Text='<%# Bind("OrganName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="不能为空" ControlToValidate="txt_OrganName"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("OrganName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="等级" SortExpression="Level">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("Level") %>'>
                            <asp:ListItem Value="0">国</asp:ListItem>
                            <asp:ListItem Value="1">省</asp:ListItem>
                            <asp:ListItem Value="2">市</asp:ListItem>
                            <asp:ListItem Value="3">县</asp:ListItem>
                            <asp:ListItem Value="4">乡镇</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="0">国</asp:ListItem>
                            <asp:ListItem Value="1">省</asp:ListItem>
                            <asp:ListItem Value="2">市</asp:ListItem>
                            <asp:ListItem Value="3">县</asp:ListItem>
                            <asp:ListItem Value="4">乡镇</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Level") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="上级机构" SortExpression="Superior">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_Superior" runat="server" DataSourceID="ddl_Source" 
                            DataTextField="OrganName" DataValueField="OrganID"  AppendDataBoundItems="True" 
                            SelectedValue='<%# Bind("Superior")%>'>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ddl_Source" runat="server" SelectMethod="GetAllList" 
                            TypeName="BLL.OrganBLL"></asp:ObjectDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="ddl_Superior" runat="server" DataSourceID="ddl_Source" 
                            DataTextField="OrganName" DataValueField="OrganID"  AppendDataBoundItems="True" 
                            SelectedValue='<%# Bind("Superior")%>'>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ddl_Source" runat="server" SelectMethod="GetAllList" 
                            TypeName="BLL.OrganBLL"></asp:ObjectDataSource>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Superior") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Remark" HeaderText="备注" 
                    SortExpression="Remark" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Button ID="LinkButton1" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="更新"></asp:Button>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:Button ID="LinkButton1" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="插入"></asp:Button>
                    </InsertItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
    
        <asp:ObjectDataSource ID="sourceDV" runat="server" 
            DataObjectTypeName="Model.Organ" InsertMethod="Add" SelectMethod="GetModel" 
            TypeName="BLL.OrganBLL" UpdateMethod="Update" 
            oninserting="sourceDV_Inserting">
            <SelectParameters>
                <asp:QueryStringParameter Name="OrganID" QueryStringField="OrganID" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
