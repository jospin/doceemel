<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Principal.aspx.vb" Inherits="Estoque.Principal"%>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sistema Doce E Mel Versão 1.0</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 200px; POSITION: absolute; TOP: 8px; HEIGHT: 71px"
				cellSpacing="1" cellPadding="1" width="200">
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 12px">
						<uc1:wucSuperior id="WucSuperior1" runat="server"></uc1:wucSuperior></TD>
					<TD style="WIDTH: 158px; HEIGHT: 12px">
						<uc1:verificaLogin id="VerificaLogin1" runat="server"></uc1:verificaLogin></TD>
					<TD style="HEIGHT: 12px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 1px">
						<uc1:wucLateral id="WucLateral1" runat="server"></uc1:wucLateral></TD>
					<TD style="WIDTH: 158px; HEIGHT: 1px"></TD>
					<TD style="HEIGHT: 1px"></TD>
				</TR>
			</TABLE>
			<asp:Image id="Image1" style="Z-INDEX: 102; LEFT: 328px; POSITION: absolute; TOP: 176px" runat="server"
				ImageUrl="images\Doce&amp;melAgua.jpg" Width="320px" Height="120px"></asp:Image>
		</form>
	</body>
</HTML>
