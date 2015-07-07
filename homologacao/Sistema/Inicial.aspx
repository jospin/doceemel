<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Inicial.aspx.vb" Inherits="Estoque.Inicial" culture="pt-BR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sistema Doce & Mel Versão 1.0 - Login</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Image id="Image1" style="Z-INDEX: 101; LEFT: 360px; POSITION: absolute; TOP: 152px" runat="server"
				ImageUrl="images\Doce&amp;melMenor.jpg" Width="192px" Height="72px"></asp:Image>
			<TABLE id="Table1" style="FONT-SIZE: x-small; Z-INDEX: 102; LEFT: 384px; WIDTH: 128px; COLOR: #996600; FONT-FAMILY: 'Trebuchet MS'; POSITION: absolute; TOP: 240px; HEIGHT: 134px"
				borderColor="whitesmoke" cellSpacing="1" cellPadding="1" width="128" border="1" align="center">
				<TR>
					<TD align="center">Usuário</TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="txtUsuario" runat="server" Font-Names="Trebuchet MS" Font-Size="X-Small" CssClass="texto"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="center">Senha</TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="txtSenha" runat="server" Font-Names="Trebuchet MS" Font-Size="X-Small" TextMode="Password"
							CssClass="texto"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="btnLogar" runat="server" Width="136px" Font-Names="Trebuchet MS" ForeColor="#996600"
							Font-Size="X-Small" Text="Logar" CssClass="botao"></asp:Button></TD>
				</TR>
			</TABLE>
			<INPUT id="hidTentativas" style="Z-INDEX: 103; LEFT: 224px; WIDTH: 32px; POSITION: absolute; TOP: 208px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
