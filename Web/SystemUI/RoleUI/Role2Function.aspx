<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Role2Function.aspx.cs" Inherits="SystemUI_RoleUI_Role2Function" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="SubMain">
    <div style="width:100%; float:left; text-align:left;">
        &nbsp;当前人员类别：<asp:Label ID="lab_Name" runat="server" Text=" "></asp:Label>
&nbsp;&nbsp;
    <asp:Button ID="btn_Sure" runat="server" Text="修改权限" onclick="btn_Sure_Click" />
    </div>
    <div style="width:100%; float:left; ">    
    <asp:TreeView ID="tvModel" runat="server" onclick="postBackByObject(event)" ShowCheckBoxes="All" Height="241px" Width="168px">
        
    </asp:TreeView> 
    </div>    
    </div>

   
    </form>
</body>


<script type="text/javascript">

    function postBackByObject(e) {  //兼容FireFox的写法，FireFox没有window.event.srcElement;


        var o = e.target || window.event.srcElement;
  
        if (o == null) {
            return;
        }
        if (o.tagName == "INPUT" && o.type == "checkbox") //点击treeview的checkbox是触发
        {
            var d = o.id; //获得当前checkbox的id;
            var e = d.replace("CheckBox", "Nodes"); //通过查看脚本信息,获得包含所有子节点div的id
            var div = window.document.getElementById(e); //获得div对象
            if (div != null)  //如果不为空则表示,存在自节点
            {
                var check = div.getElementsByTagName("INPUT"); //获得div中所有的已input开始的标记
                for (i = 0; i < check.length; i++) {
                    if (check[i].type == "checkbox") //如果是checkbox
                    {
                        check[i].checked = o.checked; //字节点的状态和父节点的状态相同,即达到全选
                    }

                }
                PostParentNode(o);
            }
            else  //点子节点的时候,使父节点的状态改变,即不为全选
            {


                PostParentNode(o);


            }

        }

    }

    function PostParentNode(o) {
        var divid = o.parentElement.parentElement.parentElement.parentElement.parentElement; //子节点所在的div

        var id = divid.id.replace("Nodes", "CheckBox"); //获得根节点的id
        var vCheckBox = window.document.getElementById(id); //父CheckBox,新增递归调用 add bywfz

        var checkbox = divid.getElementsByTagName("INPUT"); //获取所有子节点数
        var s = 0;
        for (i = 0; i < checkbox.length; i++) {
            if (checkbox[i].checked)  //判断有多少子节点被选中
            {
                s++;
            }
        }

        if (s > 0)  //如果全部选中 或者 选择的是另外一个根节点的子节点 ，
        {                               //    则开始的根节点的状态仍然为选中状态
            window.document.getElementById(id).checked = true;
            if (vCheckBox.tagName == "INPUT" && vCheckBox.type == "checkbox") {
                PostParentNode(vCheckBox); //递归调用
            }
        }
        else {                               //否则为没选中状态
            window.document.getElementById(id).checked = false;
            if (vCheckBox.tagName == "INPUT" && vCheckBox.type == "checkbox") {
                PostParentNode(vCheckBox); //递归调用
            }
        }

    }

</script>


</html>
