<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganMgr.aspx.cs" Inherits="SystemUI_OrganUI_OrganMgr" Theme="Red" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>


<script src="../../JavaScript/vmsJS.js" type="text/javascript"></script>
<body>
    <form id="form1" runat="server">
            <div id="SubMain">
            <div id="S_Title">机构管理</div>
              <div id="Banner">
                <div id="Banner_Search">
                
                </div>
                <div id="Banner_Edit">
                 <asp:ImageButton ID="btn_Delete0" runat="server" Text="" 
                    onclick="btn_Delete0_Click" SkinID="ibtnImport" 
                         PostBackUrl="~/SystemUI/LoadUser.aspx" />
                &nbsp;&nbsp;
                <asp:ImageButton ID="btn_Add" runat="server" Text="" 
                        PostBackUrl="~/SystemUI/OrganUI/OrganAdd.aspx" onclick="btn_Add_Click" 
                        SkinID="ibtnAdd"  />
                    &nbsp;&nbsp;
                <asp:ImageButton ID="btn_Delete" runat="server" Text="" 
                    onclick="btn_Delete_Click" SkinID="ibtnSub"/>&nbsp;&nbsp;

                    </div>
             </div>
             <div id="Contant">
          <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" Width="570px">
                <RowStyle HorizontalAlign="Center" />
                <Columns>
                     
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_All" runat="server" 
                                oncheckedchanged="chk_All_CheckedChanged1" Text="全选" onclick="javascript:SelectAllCheckboxes(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="60px" />
                    </asp:TemplateField>
                     
                    <asp:BoundField DataField="OrganID" HeaderText="编号" />
                    <asp:BoundField DataField="OrganName" HeaderText="机构名称" />
                    <asp:BoundField DataField="SuperiorName" HeaderText="上级机构" />
                    <asp:BoundField DataField="LevelName" HeaderText="级别" />
                        <asp:TemplateField>
                        <ItemTemplate>
                        <a href='OrganModity.aspx?OrganID=<%#Eval("OrganID")%>'>修改</a>
                        </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <a href='OrganView.aspx?OrganID=<%#Eval("OrganID")%>'>详细</a>
                        </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" />
        </asp:GridView></div>
        </div>
    </form>
</body>
</html>
