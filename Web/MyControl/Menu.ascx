<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="MyControl_Menu" %>
<%--        <script src="../JavaScript/jquery-1.3.2.js" type="text/javascript"></script>
        <link href="../CSS/Menu.css" rel="stylesheet" type="text/css" />--%>
    
    
        <asp:Repeater ID="Repeater1" runat="server" onitemdatabound="Repeater1_ItemDataBound">
        <ItemTemplate>
        <div class="m_title">
         <div style="width:100%; height:5px; float:left;background-image: url(image/menu/menu_topline.gif); background-repeat:repeat-y;"></div>
        <div style="width:100%; height:30px; float:left;background-image: url(image/menu/menu_bg1.gif); background-repeat:repeat-y; border-bottom:solid 1px red;">
        <a href="javascript:void(0)">
        <%# DataBinder.Eval(Container.DataItem, "F_Name")%>
        </a>
        </div>
       
        </div>
        <asp:Repeater ID="Repeater2" runat="server">
        <HeaderTemplate> 
        <div class="m_content">
        <ul class="MM">
        </HeaderTemplate>
        <ItemTemplate><%--//<%# DataBinder.Eval(Container.DataItem, "F_code")%>--%>
        <li><a href="<%# DataBinder.Eval(Container.DataItem, "Url")%>" target="fm"><%# DataBinder.Eval(Container.DataItem, "F_Name")%></a></li>
        </ItemTemplate> 
        <FooterTemplate>
        </ul>
        </div>
        </FooterTemplate>
        </asp:Repeater>
        </ItemTemplate>
        </asp:Repeater>
            <script language="javascript" type="text/javascript">
                $(document).ready(function() {
                    //将二级菜单设置为不可见 
                    //$(".FAQlist").css("display", "none");
                    //单击一级菜单触发的事件
                    $(".m_title").click(function() {
                        $(".m_content").slideUp(500); //css("display", "none"); //将二级菜单全部设置为不可见
                        $(this).next(".m_content").slideToggle(500); //.toggle(1000); //css("display", "block"); //当前一级菜单的二级菜单设置为可见
                    })

                }) 
    </script>