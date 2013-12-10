<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Theme="Red" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
               body {padding: 0; margin: 0;}  

        body,html{height: 100%;}  
        
        .Line
        {
        width:300px; height:30px;margin-left:50px; margin-top:5px; 	font-size:12px; line-height:30px; vertical-align:middle;
        }
        
 

    .outer 
    {  

     height: 100%;  

     overflow: hidden;  

     position: relative;  

     width: 100%;  

     display:table;  

   }  


   .middle {  

     position: absolute;  

     top: 20%;  

     left: 0;  

     vertical-align:middle;  

     display:table-cell;  

     width:100%;  
}  

 

.content{ 
    top:50%;
    left:50%;
  text-align:left;  
  width:500px;
  height:400px; 
  margin:100px auto; 
  
} 
<%--background-color:#C4E5EA; --%>
.top
{
	width:400px; height:70px; margin-left:50px; position:absolute; color:#156588;  font-size:30px; font-weight:bold; text-align:center; vertical-align:middle; 
 margin-top:20px; 
}

    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div class="content">
        <div class ="top" style=" line-height:70px;">欢迎使用品质审计系统</div>
        
        <div id="right" style="width:400px; height:300px; margin-left:50px; border-color:#C4E5EA; border-style:solid; border-width:1px; margin-top:90px;z-index:0;  position:absolute;">
        <div id="line1" class="Line"  style="margin-top:100px; "></div>
        <div class="Line" >登&nbsp; 录 名：<asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txt_Name" ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
        <div class="Line">
        密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 码：<asp:TextBox ID="txt_Pwd" runat="server" TextMode="Password"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Name" ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
        <div class="Line" style=" visibility:hidden;" >
        验&nbsp; 证 码：<asp:TextBox ID="txt_Code" runat="server" Width="55px"></asp:TextBox>
                <asp:Label ID="lab_Code" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="9pt" onclick="LinkButton1_Click" CausesValidation="False">换一个</asp:LinkButton>
        </div>
        <div class="Line"  style=" margin-top:20px; text-align:center; background-color:White;">
        <asp:ImageButton ID="btn_Login" runat="server" Text="登 录" onclick="btn_Login_Click" 
                Height="32px" Width="83px" ImageUrl="~/Image/Login/button.jpg" />
        </div>
        </div>
        <div id="red" style=" width:404px; height:71px; background-image:url(image/login/red.jpg);  margin-left:28px; margin-top:100px; z-index:2; position:absolute;">
            </div>
        </div>
        
    </form>
</body>
</html>
