<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Produtos.aspx.vb" Inherits="Estoque.Produtos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Produtos</title>
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
			<TABLE id="Table3" style="Z-INDEX: 104; LEFT: 336px; WIDTH: 96px; POSITION: absolute; TOP: 144px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="300" border="0">
				<TR>
					<TD>
						<TABLE class="label" id="Table5" style="WIDTH: 368px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="368" border="0">
							<TR>
								<TD style="WIDTH: 46px">Código</TD>
								<TD><STRONG>Nome do Produto</STRONG>&nbsp;
									<asp:RequiredFieldValidator id="rfvNome" runat="server" ControlToValidate="txtNomeProd" ErrorMessage="Nome do Produto">*</asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 46px">
									<asp:textbox id="txtCodProd" runat="server" CssClass="texto" Width="40px" Enabled="False" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD>
									<asp:textbox id="txtNomeProd" runat="server" CssClass="texto" Width="316px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="label" id="Table2" style="WIDTH: 304px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="304" border="0">
							<TR>
								<TD style="WIDTH: 124px"><STRONG>Categoria
										<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Categoria" ControlToValidate="drpCodCatProd">*</asp:RequiredFieldValidator></STRONG></TD>
								<TD>Qtd. no Estoque&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px">
									<asp:DropDownList id="drpCodCatProd" runat="server" CssClass="texto" Width="256px"></asp:DropDownList></TD>
								<TD>
									<asp:textbox id="txtQtdEstoque" runat="server" CssClass="texto" Font-Names="Trebuchet MS" Font-Size="X-Small"
										Width="96px"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="label" id="Table6" style="WIDTH: 304px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="304" border="0">
							<TR>
								<TD>Observações</TD>
							</TR>
							<TR>
								<TD>
									<asp:textbox id="txtObs" runat="server" CssClass="texto" Font-Names="Trebuchet MS" Font-Size="X-Small"
										Width="360px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
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
								<asp:BoundColumn DataField="codProd" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:ButtonColumn DataTextField="nomeProd" HeaderText="Nome do Produto" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="qtdEstoque" HeaderText="Estoque"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="nomeProd" HeaderText="Nome do Produto"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
