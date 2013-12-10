<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserMgr.aspx.cs" Inherits="SystemUI_UserUI_UserMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="../../JavaScript/vmsJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div id="SubMain">
      <div id="S_Title">用户管理</div>
              <div id="Banner">
                <div id="Banner_Search">
                
                    所属机构：<asp:DropDownList ID="ddl_Organ" runat="server" Height="17px" 
                        Width="126px" onselectedindexchanged="ddl_Organ_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                
                </div>
                <div id="Banner_Edit">
                <asp:ImageButton ID="btn_Add" runat="server" Text="" 
                        PostBackUrl="~/SystemUI/UserUI/UserAMV.aspx" onclick="btn_Add_Click" 
                        SkinID="ibtnAdd" />
                    &nbsp;&nbsp;
                <asp:ImageButton ID="btn_Delete" runat="server" Text="" 
                    onclick="btn_Delete_Click" SkinID="ibtnSub" />
                </div>
             </div>
             <div id="Contant">
      <asp:GridView ID="GridView1" runat="server"  Width="713px" 
                    AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                     
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_All" runat="server"  Text="全选" onclick="javascript:SelectAllCheckboxes(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="60px" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="UserID" HeaderText="UM编号" >
                        <ItemStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UserName" HeaderText="用户名" />
                    <asp:TemplateField HeaderText="状态" Visible="False">
                      
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Status").ToString()=="1"?"已启用":"已禁用" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户类型">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserType") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserType").ToString()=="0"?"普通用户":"系统管理员" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OpenDate" HeaderText="开通时间" />
                    <asp:BoundField DataField="OrganID" HeaderText="所属机构" />
                        <asp:TemplateField>
                        <ItemTemplate>
                        <a href='UserAMV.aspx?UID=<%#Eval("UserID")%>&Type=Edit'>修改</a>
                        </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <a href='UserAMV.aspx?UID=<%#Eval("UserID")%>&Type=View'>详细</a>
                        </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                        <ItemTemplate>
                        <a href='User2Position.aspx?code=<%#Eval("UserID")%>&Type=View&name=<%#Eval("UserName")%>'>分配组织</a>
                        </ItemTemplate>
                                                    <ItemStyle Width="70px" />
                        </asp:TemplateField>
                                                <asp:TemplateField>
                        <ItemTemplate>
                        <a href='Role2User.aspx?code=<%#Eval("UserID")%>&Type=View&name=<%#Eval("UserName")%>'>分配人员类别</a>
                        </ItemTemplate>
                            <ItemStyle Width="110px" />
                        </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Literal ID="Literal1" runat="server" Text="暂无数据！"></asp:Literal>
                </EmptyDataTemplate>
        </asp:GridView>
                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                     SelectMethod="GetOrganList" TypeName="BLL.UserBLL">
                     <SelectParameters>
                         <asp:SessionParameter Name="organID" SessionField="SelOrganID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
                  </div>
        </div>
    </form>
</body>
</html>
