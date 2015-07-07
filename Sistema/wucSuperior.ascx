<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wucSuperior.ascx.vb" Inherits="Estoque.wucSuperior" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="Styles.css" type="text/css" rel="stylesheet">
<TABLE id="Table1" style="WIDTH: 872px; HEIGHT: 96px" cellSpacing="1" cellPadding="1" width="872">
	<TR>
		<TD style="VERTICAL-ALIGN: super; WIDTH: 125px; HEIGHT: 35px" vAlign="top">
			<asp:Image id="Image1" runat="server" ImageUrl="images\Doce&amp;mel.jpg" Width="160px" Height="72px"></asp:Image></TD>
		<TD style="WIDTH: 34px; HEIGHT: 35px" vAlign="middle" colSpan="3">
			<TABLE class="MenuPrincipal" id="Table2" style="WIDTH: 664px; HEIGHT: 54px" borderColor="#ffffff"
				cellSpacing="2" borderColorDark="#ffffff" cellPadding="2" width="664" borderColorLight="#ffffff"
				border="20">
				<TR>
					<TD style="WIDTH: 209px" vAlign="middle" bgColor="#f5f5f5"><IMG class="Bolinha" alt="" src="images/blackball.gif" align="middle" border="0">&nbsp;
						<asp:LinkButton id="lnkSistema" runat="server" CommandArgument="1" Font-Size="X-Small" CssClass="LinkMenuPrin"
							Width="40px" CausesValidation="False">Sistema</asp:LinkButton></TD>
					<TD style="WIDTH: 217px" bgColor="whitesmoke"><IMG class="Bolinha" alt="" src="images/blackball.gif" border="0">&nbsp;
						<asp:LinkButton id="lnkCadastros1" runat="server" CausesValidation="False" Width="40px" CssClass="LinkMenuPrin"
							Font-Size="X-Small" CommandArgument="2">Cadastros</asp:LinkButton></TD>
					<TD bgColor="#f5f5f5"><IMG class="Bolinha" alt="" src="images/blackball.gif" border="0">&nbsp;
						<asp:LinkButton id="lnkRelatorios" runat="server" CommandArgument="4" Font-Size="X-Small" CssClass="LinkMenuPrin"
							Width="40px" CausesValidation="False">Relatórios</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 209px" bgColor="#f5f5f5"><IMG class="Bolinha" alt="" src="images/blackball.gif" border="0">&nbsp;
						<asp:LinkButton id="lnkMovimentos" runat="server" CommandArgument="3" Font-Size="X-Small" CssClass="LinkMenuPrin"
							Width="40px" CausesValidation="False">Movimentos</asp:LinkButton></TD>
					<TD style="WIDTH: 217px" bgColor="#f5f5f5"><IMG class="Bolinha" alt="" src="images/blackball.gif" border="0">
						<asp:LinkButton id="lnkSeguranca" runat="server" CommandArgument="3" Font-Size="X-Small" CssClass="LinkMenuPrin"
							Width="40px" CausesValidation="False">Segurança</asp:LinkButton></TD>
					<TD bgColor="#f5f5f5"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD style="VERTICAL-ALIGN: super; WIDTH: 125px; HEIGHT: 12px" vAlign="top"></TD>
		<TD style="WIDTH: 331px; HEIGHT: 12px" vAlign="middle" align="center"></TD>
		<TD style="HEIGHT: 12px" vAlign="middle" align="right" colSpan="2">
			<asp:Label id="Label1" runat="server" CssClass="Label"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="VERTICAL-ALIGN: super; WIDTH: 486px; HEIGHT: 8px" vAlign="top" bgColor="#996600"
			colSpan="4"></TD>
	</TR>
</TABLE>
