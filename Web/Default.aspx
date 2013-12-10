<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" Theme="Red" %>

<%@ Register src="MyControl/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车辆管理系统</title>
    <link href="CSS/Menu.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/jquery-1.3.2.js" type="text/javascript"></script>
    </head>
<body>
    <form id="form1" runat="server">
        <div id="Main">
        <div id="head" style=" background-image:url(Image/index/t2.jpg); background-repeat:repeat-x; width:100%; height:61px; "> 
        <div id="h_left" style=" background-image:url(Image/index/t1.jpg); width:280px; height:61px; float:left;">
        </div>
        
         <div id="h_right" style=" background-image:url(Image/index/t3.jpg); width:49px; height:61px; float:right; ">
        </div>
        </div>
        <div id="M_Banner">
            <div style=" width:400px; height:100%; float:left; margin-left:10px;" >
                <a href="Home.aspx" target="fm" style=" color:Blue;">首页</a>
                &nbsp; &nbsp;
                <span style=" font-weight:bold;"><asp:Literal ID="lab_OrganID" runat="server">admin</asp:Literal></span>&nbsp; 欢迎您,<span style=" font-weight:bold;"><asp:Literal ID="lab_UserName" runat="server">admin</asp:Literal>&nbsp; </span>!&nbsp; 今天是<asp:Literal ID="lab_Time" runat="server"></asp:Literal></div>
            <div style=" width:200px; height:100%; float:right; text-align:right; font-weight:bold;">
                <asp:LinkButton ID="btn_Exit" runat="server" onclick="btn_Exit_Click">安全退出</asp:LinkButton>
            </div>
            </div>
            
        <div id="B_Content" style="	">
            <div id="B_Left">
                 <uc1:Menu ID="Menu1" runat="server" />
                </div>
            <div id="B_Right">
                <%--<div style="margin-left:188px; background-color:Green; z-index:2; width:100%; height:100%;">--%>
                <iframe name="fm" id="fm" style="width:100%; height:100%"  
                    src="Home.aspx"frameborder="0"></iframe>
                <%--</div>--%>
            </div>
       </div>
    
   <div id="Footer">版权所有</div>
</div>
   
    </form>
</body>
</html>
