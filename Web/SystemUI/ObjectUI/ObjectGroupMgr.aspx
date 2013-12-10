<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectGroupMgr.aspx.cs" Inherits="SystemUI_ObjectUI_ObjectGroupMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="../../JavaScript/vmsJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
 <div id="SubMain">
 <div id="S_Title">数据组管理</div>
              <div id="Banner">
                <div id="Banner_Search">
                
                </div>
                <div id="Banner_Edit">
                <asp:ImageButton ID="btn_Add" runat="server" Text="" 
                        PostBackUrl="~/SystemUI/ObjectUI/ObjectGroupAMV.aspx" 
                        onclick="btn_Add_Click" SkinID="ibtnAdd" />&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btn_Delete" runat="server" Text="" 
                    onclick="btn_Delete_Click" SkinID="ibtnSub" />
                </div>
             </div>
             <div id="Contant">
      <asp:GridView ID="GridView1" runat="server"  Width="662px" 
                    AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                     
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_All" runat="server"  Text="全选" onclick="javascript:SelectAllCheckboxes(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_XX" runat="server" oncheckedchanged="chk_CheckedChanged" />
                        </ItemTemplate>
                        <HeaderStyle Width="60px" />
                    </asp:TemplateField>
                     
                    <asp:BoundField DataField="Code" HeaderText="编号" >
                        <ItemStyle Width="60px" />
                    </asp:BoundField>
<asp:BoundField DataField="Name" HeaderText="名称"></asp:BoundField>
                    <asp:BoundField DataField="TypeCode" HeaderText="数据类型" Visible="False" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OrganID" HeaderText="机构编号" Visible="False" />
                        <asp:BoundField DataField="InputTime" HeaderText="录入时间">
                            <ItemStyle Width="120px" />
                    </asp:BoundField>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <a href='ObjectGroupAMV.aspx?Code=<%#Eval("Code")%>&Type=Edit'>修改</a>
                        </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                         <asp:TemplateField>
                        <ItemTemplate>
                        <a href='ObjectGroupAMV.aspx?Code=<%#Eval("Code")%>&Type=View'>详细</a>
                        </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Literal ID="Literal1" runat="server" Text="暂无数据！"></asp:Literal>
                </EmptyDataTemplate>
        </asp:GridView>
                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                     SelectMethod="GetOrganList" TypeName="BLL.ObjectGroupBLL">
                     <SelectParameters>
                         <asp:SessionParameter Name="organID" SessionField="OrganID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
                  </div>
        </div>
    
    </form>
</body>
</html>
