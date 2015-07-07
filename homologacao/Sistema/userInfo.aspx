<%@ Page Language="vb" AutoEventWireup="false" Codebehind="userInfo.aspx.vb" Inherits="Estoque.userInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<script language="JavaScript">
			/*function teste(){
				if ( Form1.hNavegarPara.value == "" ) {
					if ( parent.frames(1).location.href == "about:blank") {
						parent.frames(1).location.href = "login/wAuth.aspx?x=" + Form1.hSessao.value ;		
					}
				} else {	
					var sUrl = Form1.hNavegarPara.value;
					top.location.href = sUrl;
				}
			}
			
			function testeCallBack( msg ) {
				if ( msg == "OK" ) {
					var p = window.parent;
					var c = window.parent.frames.length;
					Form1.hCommand.value = "getUser";
					Form1.submit();
				}
			}*/
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script language="javascript" src="Funcoes.js"></script>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body onload="teste()" MS_POSITIONING="GridLayout">
		<table width="100%" height="100%" align="center">
			<tr>
				<td Class="Label" valign="middle" width="100%" height="100%" align="center">
					Verificando dados do usuário
				</td>
			</tr>
		</table>
		<form id="Form1" method="post" runat="server">
			<INPUT id="hCommand" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 128px" type="hidden"
				name="hCommand" runat="server"><INPUT id="hNavegarPara" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 152px"
				type="hidden" name="hCommand" runat="server"><INPUT id="hSessao" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 104px" type="hidden"
				runat="server">
			<asp:label id="lbUsuario" style="Z-INDEX: 103; LEFT: 40px; POSITION: absolute; TOP: 72px" runat="server"
				Width="264px" Height="24px" Visible="False">Label</asp:label><asp:label id="Label2" style="Z-INDEX: 104; LEFT: 40px; POSITION: absolute; TOP: 48px" runat="server"
				Width="88px" Font-Bold="True" Visible="False">Usuário</asp:label>
		</form>
	</body>
</HTML>
