<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Office.aspx.vb" Inherits="Estoque.Office" smartNavigation="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Office</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 264px; POSITION: absolute; TOP: 8px; HEIGHT: 32px"
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
			<INPUT id="hidCodForn" style="Z-INDEX: 106; LEFT: 32px; WIDTH: 8px; POSITION: absolute; TOP: 576px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 216px"
				runat="server" ShowSummary="False" ShowMessageBox="True" HeaderText="Preenchimento Obrigatório"></asp:validationsummary><asp:label id="lblPagina" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server" CssClass="Label"></asp:label>
			<TABLE class="Label" id="tblFornecedores" style="Z-INDEX: 101; LEFT: 320px; WIDTH: 344px; POSITION: absolute; TOP: 176px; HEIGHT: 384px"
				cellSpacing="1" cellPadding="1" width="344" border="0">
				<TR>
					<TD style="HEIGHT: 26px" vAlign="top" align="left">
						<P>
							<TABLE class="Label" id="Table3" style="WIDTH: 256px; HEIGHT: 43px" cellSpacing="1" cellPadding="1"
								width="256">
								<TR>
									<TD style="WIDTH: 3px">Código</TD>
									<TD><STRONG>Modelo&nbsp; </STRONG>
										<asp:requiredfieldvalidator id="rfvModelo" runat="server" ControlToValidate="txtModeOffice" ErrorMessage="Modelo do Office">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 3px"><asp:textbox id="txtCodOffice" runat="server" CssClass="texto" Width="40px" Enabled="False"></asp:textbox></TD>
									<TD><asp:textbox id="txtModeOffice" runat="server" CssClass="texto" Width="200px" MaxLength="50"></asp:textbox></TD>
								</TR>
							</TABLE>
						</P>
						<TABLE class="Label" id="Table4" cellSpacing="1" cellPadding="1" width="300">
							<TR>
								<TD style="WIDTH: 66px"><asp:button id="btnSalvar" runat="server" CssClass="botao" Width="72px" Text="Salvar"></asp:button></TD>
								<TD><asp:button id="btnExcluir" runat="server" CssClass="botao" Width="72px" Text="Excluir" CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnLimpar" runat="server" CssClass="botao" Width="72px" Text="Limpar" CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnPesquisar" runat="server" CssClass="botao" Width="72px" Text="Pesquisar"
										CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top"><asp:datagrid id="dtgOffice" runat="server" Width="400px" AllowPaging="True" PageSize="12" ShowFooter="True"
							AutoGenerateColumns="False" BorderColor="Silver">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn DataTextField="modeloOffice" HeaderText="Modelo" CommandName="Select">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="codOffice" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="modeloOffice" HeaderText="Modelo"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<INPUT id="hidCodEnd" style="Z-INDEX: 105; LEFT: 16px; WIDTH: 8px; POSITION: absolute; TOP: 576px; HEIGHT: 22px"
				type="hidden" size="1" runat="server">
		</form>
	</body>
</HTML>
