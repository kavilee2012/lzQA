
<!DOCTYPE HTML>
<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>DEMO</title>
</head>
<style>

html,body
{width:100%;height:100%;margin:0;position:relative;overflow:hidden;}

p{margin:2em;}

#header,
#container,
#footer{
	
}

#header
{
	top:0;left:0;
	position:absolute;
	width:100%;
	height:150px;
	background:#eaeaea;
	z-index:2;
}

#container
{
	left:0;
	top:150px;
	position:absolute;
	width:100%;
	background:#888;
	bottom:120px;
}

#sidebar
{
    left:0;
	top:0;
	position:absolute;
	height:100%;
	overflow:auto;
	background:#999;
	width:300px;
	z-index:2;
}

#content
{
	position:absolute;
	height:100%;
	overflow:auto;
	width:100%;
	background:#a0a0a0;
}

#main-content{
	margin-left:300px;
}

#footer	
{
	bottom:0;
	left:0;
	position:absolute;
	width:100%;
	height:120px;
	background:#ddd;
	z-index:2;
}
</style>
<body>
<div id="header">
	<p>������ͷ�����̶��߶�</p>
</div>

<div id="container">
	<div id="sidebar">
		��������������������������������������������������������<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>sidebar<br>
	</div>
	
	<!--ʹ��������������ȷ����main-content�ĸ߶�-->
	<div id="content">
		<div id="main-content">ʹ��������������ȷ����main-content�ĸ߶�ʹ��������������ȷ����main-content�ĸ߶�ʹ��������������ȷ����main-content�ĸ߶�main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>main-content<br>
		</div>
	</div>
	
</div>

<div id="footer">
	<p>������ʾ��Ȩ��Ϣ���̶��߶�</p>
</div>
<script src="http://a.tbcdn.cn/s/kissy/1.1.5/packages/kissy-min.js"></script>
<script>
KISSY.ready(function(S){
	if(KISSY.UA.ie === 6){
		var D=S.DOM,E=S.Event;
		//�˷���������ݴ����������ı�߶�ֵ��
		function changeContainerHeight(){
			var viewportHeight=D.docHeight(),
				headerH=D.get('#header').offsetHeight,
				footerH=D.get('#footer').offsetHeight,
				vH=parseInt(viewportHeight-(headerH+footerH),10),
				contentObj=D.get('#content'),
				sidebarObj=D.get('#sidebar');
			//��ȡʣ��ĸ߶�ֵ
			D.css([contentObj,sidebarObj],'height',vH+'px');	
		}
		E.on(window,'resize',function(){
			changeContainerHeight();
		});
		//ҳ�����ʱִ��һ��
		changeContainerHeight();
	}
});
</script>
</body>
</html>

