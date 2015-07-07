<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PaginasDeAcesso.aspx.vb" Inherits="Estoque.PaginasDeAcesso" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Páginas de Acesso</title>
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
					<TD style="WIDTH: 158px"><uc1:verificalogin id="VerificaLogin1" runat="server"></uc1:verificalogin></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 164px"><uc1:wuclateral id="WucLateral1" runat="server"></uc1:wuclateral></TD>
					<TD style="WIDTH: 158px"></TD>
				</TR>
			</TABLE>
			<asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 104; LEFT: 24px; POSITION: absolute; TOP: 216px"
				runat="server" HeaderText="Preenchimento Obrigatório" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary>
			<asp:label id="lblPagina" style="Z-INDEX: 103; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server" CssClass="Label"></asp:label>
			<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 320px; WIDTH: 392px; POSITION: absolute; TOP: 176px; HEIGHT: 380px"
				cellSpacing="1" cellPadding="1" width="392">
				<TR>
					<TD style="HEIGHT: 26px" vAlign="top">
						<P>
							<TABLE class="Label" id="Table3" cellSpacing="1" cellPadding="1" width="300">
								<TR>
									<TD style="WIDTH: 130px">Código
										<asp:requiredfieldvalidator id="rfvCodigo" runat="server" ControlToValidate="txtCdContexto" ErrorMessage="Nome da Página">*</asp:requiredfieldvalidator></TD>
									<TD><STRONG class="LabelPesquisa"> Nome&nbsp;da Página&nbsp;
											<asp:requiredfieldvalidator id="rfvNome" runat="server" ErrorMessage="Descrição da Página" ControlToValidate="txtSNomeContexto">*</asp:requiredfieldvalidator></STRONG></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 130px"><asp:textbox id="txtCdContexto" runat="server" Width="192px" CssClass="texto" MaxLength="30"></asp:textbox></TD>
									<TD><asp:textbox id="txtSNomeContexto" runat="server" Width="200px" CssClass="texto" MaxLength="50"></asp:textbox></TD>
								</TR>
							</TABLE>
						</P>
						<TABLE class="Label" id="Table4" cellSpacing="1" cellPadding="1" width="300">
							<TR>
								<TD style="WIDTH: 66px"><asp:button id="btnSalvar" runat="server" Width="72px" Text="Salvar" CssClass="botao"></asp:button></TD>
								<TD><asp:button id="btnExcluir" runat="server" Width="72px" Text="Excluir" CssClass="botao" CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnLimpar" runat="server" Width="72px" Text="Limpar" CssClass="botao" CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnPesquisar" runat="server" Width="72px" Text="Pesquisar" CssClass="botao"
										CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top"><asp:datagrid id="dtgPaginasDeAcesso" runat="server" Width="400px" AllowPaging="True" PageSize="12"
							ShowFooter="True" AutoGenerateColumns="False" BorderColor="Silver">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn DataTextField="cdContexto" HeaderText="P&#225;gina" CommandName="Select">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="sNomeContexto" HeaderText="Descri&#231;&#227;o da P&#225;gina"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="cdContexto" HeaderText="pagina"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
