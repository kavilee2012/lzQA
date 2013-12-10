<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PositionMgr.aspx.cs" Inherits="SystemUI_UserUI_PositionMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="../../JavaScript/vmsJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
 <div id="SubMain">
     <div id="S_Title">组织管理</div>
              <div id="Banner">
                <div id="Banner_Search">

                
                </div>
                <div id="Banner_Edit">
                <asp:ImageButton ID="btn_Add" runat="server" Text="" 
                        PostBackUrl="~/SystemUI/UserUI/PositionAMV.aspx" onclick="btn_Add_Click" 
                        SkinID="ibtnAdd" />&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btn_Delete" runat="server" Text="" 
                    onclick="btn_Delete_Click"  SkinID="ibtnSub" />&nbsp;</div>
             </div>
             <div id="Contant">
      <asp:GridView ID="GridView1" runat="server"  Width="703px" 
                    AutoGenerateColumns="False">
                <Columns>
                     
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_All" runat="server"  Text="全选" onclick="javascript:SelectAllCheckboxes(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" oncheckedchanged="chk_CheckedChanged" />
                        </ItemTemplate>
                        <HeaderStyle Width="60px" />
                    </asp:TemplateField>
                     
                    <asp:BoundField DataField="PosiCode" HeaderText="编号" Visible="False" >
                        <ItemStyle Width="60px" />
                    </asp:BoundField>
<asp:BoundField DataField="PosiName" HeaderText="名称"></asp:BoundField>
                    <asp:BoundField DataField="FatherCodeName" HeaderText="上级组织" />
                    <asp:BoundField DataField="InputTime" HeaderText="录入时间" >
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <a href='PositionAMV.aspx?Code=<%#Eval("PosiCode")%>&Type=Edit'>修改</a>
                        
                        </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <a href='PositionAMV.aspx?Code=<%#Eval("PosiCode")%>&Type=View'>详细</a>
                        </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <a href='Position2ObjectGroup.aspx?code=<%#Eval("PosiCode")%>&Type=View&name=<%#Eval("PosiName")%>'>分配数据组</a>
                        </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Literal ID="Literal1" runat="server" Text="暂无数据！"></asp:Literal>
                </EmptyDataTemplate>
        </asp:GridView>
                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                     SelectMethod="GetOrganList" TypeName="BLL.PositionBLL">
                     <SelectParameters>
                         <asp:SessionParameter Name="organID" SessionField="OrganID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
                  </div>
        </div>
    </form>
</body>
</html>
