<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Vendedores.aspx.vb" Inherits="Estoque.Vendedores" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Vendedores</title>
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
			<asp:label id="lblPagina" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server" CssClass="Label"></asp:label>
			<asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 216px"
				runat="server" HeaderText="Preenchimento Obrigatório" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary>
			<TABLE id="Table3" style="Z-INDEX: 108; LEFT: 336px; WIDTH: 96px; POSITION: absolute; TOP: 144px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="300" border="0">
				<TR>
					<TD>
						<TABLE class="label" id="Table5" style="WIDTH: 328px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="328" border="0">
							<TR>
								<TD style="WIDTH: 46px">Código</TD>
								<TD><STRONG>Nome</STRONG>
									<asp:RequiredFieldValidator id="rfvNome" runat="server" ControlToValidate="txtnomeVend" ErrorMessage="Nome">*</asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 46px">
									<asp:textbox id="txtCodVend" runat="server" CssClass="texto" Width="40px" Enabled="False" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD>
									<asp:textbox id="txtnomeVend" runat="server" CssClass="texto" Width="272px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="label" id="Table2" style="WIDTH: 328px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="328" border="0">
							<TR>
								<TD style="WIDTH: 73px; HEIGHT: 1px">Comissão 1&nbsp;
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtComissao1" ErrorMessage="Comissão1">*</asp:RequiredFieldValidator></TD>
								<TD style="HEIGHT: 1px">Comissão 2</TD>
								<TD style="HEIGHT: 1px">Comissão 3&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 73px">
									<asp:textbox id="txtComissao1" tabIndex="1" runat="server" CssClass="texto" Width="104px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD>
									<asp:textbox id="txtComissao2" tabIndex="2" runat="server" CssClass="texto" Width="104px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD>
									<asp:textbox id="txtComissao3" tabIndex="3" runat="server" CssClass="texto" Width="96px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table4" style="WIDTH: 317px; HEIGHT: 8px" cellSpacing="1" cellPadding="1" width="317"
							border="0">
							<TR>
								<TD>
									<asp:button id="btnSalvar" tabIndex="4" runat="server" CssClass="botao" Width="72px" Text="Salvar"></asp:button></TD>
								<TD>
									<asp:button id="btnExcluir" tabIndex="5" runat="server" CssClass="botao" Width="72px" Text="Excluir"
										CausesValidation="False"></asp:button></TD>
								<TD>
									<asp:button id="btnLimpar" tabIndex="6" runat="server" CssClass="botao" Width="72px" Text="Limpar"
										CausesValidation="False"></asp:button></TD>
								<TD>
									<asp:button id="btnPesquisar" tabIndex="7" runat="server" CssClass="botao" Width="80px" Text="Pesquisar"
										CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="DataGrid1" runat="server" Width="368px" AllowPaging="True" PageSize="12" ShowFooter="True"
							AutoGenerateColumns="False" BorderColor="Silver">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="codVend" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:ButtonColumn DataTextField="nomeVend" HeaderText="Nome do Vendedor" CommandName="Select">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="comissao1" HeaderText="Comiss&#227;o 1"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
