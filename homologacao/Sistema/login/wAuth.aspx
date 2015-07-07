<%@ Page Language="vb" AutoEventWireup="false" Codebehind="wAuth.aspx.vb" Inherits="login.wAuth"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<script>
	function testeRecebe() {
		if (Form1.hSession.value != "" ) {
			winOpener = window.parent.frames(0);
			winOpener.testeCallBack(Form1.hResult.value);
		} else  {
			var p1 = window.location.search;
			if ( p1 == "" ) {
				return;
			}
			p1 = p1.substr(3);
			Form1.hSession.value = p1;
			Form1.submit();
		}
	}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body onload="testeRecebe()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hSession" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" type="hidden"
				name="hSession" runat="server">&nbsp; <INPUT id="hResult" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 40px" type="hidden"
				name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
