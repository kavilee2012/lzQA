<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script src="JavaScript/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="JavaScript/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="CSS/jquery-ui.css" />

    

</head>

<script type="text/javascript" language="javascript">



<<<<<<< .mine
    
        //        alert("test start");
        //        var url = "autocomplete.ashx";
        //        $("#t1").autocomplete(
        //              {
        //                  source: url,
        //                  minLength: 1,
        //                  select: function(e, ui) {
        //                      //alert(ui.item.value);
        //                      $("#t2").val(ui.item.value);
        //                  }
        //              });
=======
    $(document).ready(function() {
        alert("test start");
        var url = "ashx/autocomplete.ashx";
        $("#t1").autocomplete(
              {
                  source: url,
                  minLength: 1,
                  select: function(e, ui) {
                      //alert(ui.item.value);
                      $("#t2").val(ui.item.value);
                  }
              });
>>>>>>> .r197



<<<<<<< .mine
$(document).ready(function(){
  $("#b1").click(function(){
  $('#result').load('http://www.baiduc.com');
  })
})
=======
//              $("#b1").click( function(){
//                  alert("test start");
//                  $.ajax({
//                      type: "POST",
//                      url: "ashx/Validate.ashx",
//                      dataType: "html",
//                      
//                      beforeSend: function(XMLHttpRequest) {
//                      $("#result").html("正在查询");
//                          //Pause(this,100000);
//                      },
//                      success: function(msg) {
//                      $("#result").html(msg);
//                      $("#result").css("color", "red");
//                      },
//                      complete: function(XMLHttpRequest, textStatus) {
//                          //隐藏正在查询图片
//                      },
//                      error: function() {
//                      //错误处理
//                      alert("失败");
//                      }
//                  });
//              });
//              
//              
              
              
    });
>>>>>>> .r197




</script>
<body>
 <form runat="server">
<div  >
<div id="d1"></div>

  <label for="tags">Tags: </label>
  <input id="tags" value="F001" />
  <input id="b2" type="button" />
    
    <asp:TextBox ID="t1" runat="server"></asp:TextBox>
    <asp:TextBox ID="t2" runat="server"></asp:TextBox>
    <asp:Button ID="b1" runat="server" Text="Button"  />
    <div id = "result" style="width:200px; height:200px; background-color:Gray;"></div>
</div>
</form>
</body>
</html>
