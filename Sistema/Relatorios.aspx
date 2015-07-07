<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Relatorios.aspx.vb" Inherits="Estoque.Relatorios" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Relatórios</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 264px; POSITION: absolute; TOP: 8px; HEIGHT: 32px"
				cellSpacing="1" cellPadding="1" width="264">
				<TR>
					<TD style="WIDTH: 164px"><uc1:wucsuperior id="WucSuperior1" runat="server"></uc1:wucsuperior></TD>
					<TD style="WIDTH: 158px">
						<uc1:verificalogin id="VerificaLogin1" runat="server"></uc1:verificalogin></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 164px">
						<uc1:wuclateral id="WucLateral1" runat="server"></uc1:wuclateral></TD>
					<TD style="WIDTH: 158px"></TD>
				</TR>
			</TABLE>
			<TABLE class="Label" id="Table4" style="Z-INDEX: 105; LEFT: 368px; WIDTH: 416px; POSITION: absolute; TOP: 160px; HEIGHT: 16px"
				cellSpacing="1" cellPadding="1" width="416">
				<TR>
					<TD style="WIDTH: 180px">
						<asp:LinkButton id="lnkUsuEmail" runat="server">Relatório de Usuários com E-Mail</asp:LinkButton></TD>
					<TD style="WIDTH: 214px">
						<asp:LinkButton id="lnkRelMaquinasIP" runat="server">Relatório de Máquinas, IP e Usuários</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 180px">
						<asp:LinkButton id="lnkMaquinas" runat="server">Relatório de Máquinas Detalhado</asp:LinkButton></TD>
					<TD style="WIDTH: 214px">
						<asp:LinkButton id="lnkHubSw" runat="server">Relatório de HUb's e Switches</asp:LinkButton></TD>
				</TR>
			</TABLE>
			<asp:label id="lblPagina" style="Z-INDEX: 103; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server" CssClass="Label"></asp:label>
			<asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 104; LEFT: 24px; POSITION: absolute; TOP: 216px"
				runat="server" HeaderText="Preenchimento Obrigatório" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></form>
	</body>
</HTML>
