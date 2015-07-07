<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Pedidos.aspx.vb" Inherits="Estoque.Pedidos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Pedidos</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="Funcoes.js"></script>
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
			<INPUT id="hidPed" style="Z-INDEX: 107; LEFT: 160px; WIDTH: 24px; POSITION: absolute; TOP: 736px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="hidProd" style="Z-INDEX: 105; LEFT: 104px; WIDTH: 24px; POSITION: absolute; TOP: 752px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server">
			<asp:label id="lblPagina" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server" CssClass="Label"></asp:label><asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 216px"
				runat="server" ShowSummary="False" ShowMessageBox="True" HeaderText="Preenchimento Obrigatório"></asp:validationsummary>
			<TABLE id="tblPedidos" style="Z-INDEX: 104; LEFT: 264px; WIDTH: 96px; POSITION: absolute; TOP: 152px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="300" border="0" runat="server">
				<TR>
					<TD><asp:linkbutton id="lnkCabecalho" runat="server" CausesValidation="False" BackColor="#FFE0C0" Width="568px">(-) Cabeçalho</asp:linkbutton></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 218px">
						<TABLE class="texto" id="Table3" style="WIDTH: 496px; HEIGHT: 57px" borderColor="#f5f5f5"
							cellSpacing="1" cellPadding="1" width="496" border="0">
							<TR>
								<TD style="WIDTH: 91px">Código Pedido</TD>
								<TD style="WIDTH: 109px">Data De Emissão
									<asp:requiredfieldvalidator id="rfvDataEmissao" runat="server" ControlToValidate="txtDataEmissao" ErrorMessage="Data de Emissão">*</asp:requiredfieldvalidator></TD>
								<TD><STRONG>Status</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><STRONG>Código para Pesq.</STRONG></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 91px"><asp:textbox id="txtCodPed" runat="server" CssClass="texto" Width="88px" Enabled="False" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD style="WIDTH: 109px"><asp:textbox id="txtDataEmissao" runat="server" CssClass="texto" Width="107px" Font-Size="X-Small"
										Font-Names="Trebuchet MS" AutoPostBack="True"></asp:textbox></TD>
								<TD><asp:dropdownlist id="drpStatus" runat="server" CssClass="texto" Width="183px" Enabled="False">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="1">Pendente</asp:ListItem>
										<asp:ListItem Value="2">Faturado</asp:ListItem>
										<asp:ListItem Value="3">Liquidado</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD><asp:textbox id="txtCodPedPesq" runat="server" CssClass="texto" Width="107px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="texto" id="Table2" style="WIDTH: 496px; HEIGHT: 48px" borderColor="#f5f5f5"
							cellSpacing="1" cellPadding="1" width="496" border="0">
							<TR>
								<TD style="WIDTH: 264px"><STRONG>Cliente</STRONG>
									<asp:requiredfieldvalidator id="rfvCliente" runat="server" ControlToValidate="drpCliente" ErrorMessage="Cliente">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 131px">Data de Liquidação</TD>
								<TD style="WIDTH: 131px">Total</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 264px"><asp:dropdownlist id="drpCliente" runat="server" CssClass="texto" Width="256px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 131px"><asp:textbox id="txtDataLiquidacao" runat="server" CssClass="texto" Width="107px" Enabled="False"
										Font-Size="X-Small" Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD style="WIDTH: 131px"><asp:textbox id="txtTotalPed" runat="server" CssClass="texto" Width="107px" Enabled="False" Font-Size="X-Small"
										Font-Names="Trebuchet MS" Height="24px"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="texto" id="Table5" borderColor="#f5f5f5" cellSpacing="1" cellPadding="1"
							width="496">
							<TR>
								<TD style="WIDTH: 131px">Observação</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 131px"><asp:textbox id="txtObsPed" runat="server" CssClass="texto" Width="480px" Font-Size="X-Small"
										Font-Names="Trebuchet MS" Height="59px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
						&nbsp;
						<asp:linkbutton id="lnkTotalizar" runat="server" CssClass="label">Totalizar</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lnkPrint" runat="server" CssClass="label">Imprimir Pedido</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lnkFaturar" runat="server" CssClass="label">Faturar</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lnkLiquidar" runat="server" CssClass="label">Liquidar</asp:linkbutton><BR>
						<BR>
						<TABLE id="Table4" style="WIDTH: 317px; HEIGHT: 8px" cellSpacing="1" cellPadding="1" width="317"
							border="0">
							<TR>
								<TD><asp:button id="btnSalvar" tabIndex="4" runat="server" CssClass="botao" Width="72px" Text="Salvar"></asp:button></TD>
								<TD><asp:button id="btnExcluir" tabIndex="5" runat="server" CssClass="botao" CausesValidation="False"
										Width="72px" Text="Excluir"></asp:button></TD>
								<TD><asp:button id="btnLimpar" tabIndex="6" runat="server" CssClass="botao" CausesValidation="False"
										Width="72px" Text="Limpar"></asp:button></TD>
								<TD><asp:button id="btnPesquisar" tabIndex="7" runat="server" CssClass="botao" CausesValidation="False"
										Width="80px" Text="Pesquisar"></asp:button></TD>
							</TR>
						</TABLE>
						<BR>
						<asp:datagrid id="DataGrid1" runat="server" Width="568px" BorderColor="Silver" AutoGenerateColumns="False"
							ShowFooter="True" PageSize="12" AllowPaging="True">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="codPed" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="dataEmissao" HeaderText="Data de Emiss&#227;o"></asp:BoundColumn>
								<asp:ButtonColumn DataTextField="razaoSocial" HeaderText="Cliente" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="status" HeaderText="Status do Pedido"></asp:BoundColumn>
								<asp:BoundColumn DataField="total" HeaderText="Total" DataFormatString="{0:C}"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
					<TD style="HEIGHT: 218px"></TD>
				</TR>
				<TR>
					<TD><asp:linkbutton id="lnkItens" runat="server" CausesValidation="False" BackColor="#FFE0C0" Width="568px">(+) Itens</asp:linkbutton></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="texto" id="Table6" cellSpacing="1" cellPadding="1" width="376" border="0">
							<TR>
								<TD style="WIDTH: 91px">Produto</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 91px"><asp:dropdownlist id="drpProduto" runat="server" CssClass="texto" Width="536px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<TABLE class="texto" id="Table7" cellSpacing="1" cellPadding="1" width="280" border="0">
							<TR>
								<TD style="WIDTH: 76px; HEIGHT: 17px">Qtd.</TD>
								<TD style="WIDTH: 127px; HEIGHT: 17px">Preço Unitário</TD>
								<TD style="WIDTH: 91px; HEIGHT: 17px">Preço Total</TD>
								<TD style="WIDTH: 91px; HEIGHT: 17px" colSpan="2"><asp:linkbutton id="lnkTotItens" runat="server" CssClass="label" Width="144px">Totalizar Pedido</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 76px" vAlign="top"><asp:textbox id="txtQtd" runat="server" CssClass="texto" Width="64px" Font-Size="X-Small" Font-Names="Trebuchet MS"
										AutoPostBack="True"></asp:textbox></TD>
								<TD style="WIDTH: 127px" vAlign="top"><asp:textbox id="txtPrecoUnit" runat="server" CssClass="texto" Width="107px" Font-Size="X-Small"
										Font-Names="Trebuchet MS" AutoPostBack="True"></asp:textbox></TD>
								<TD style="WIDTH: 91px" vAlign="top"><asp:textbox id="txtPrecoTotal" runat="server" CssClass="texto" Width="107px" Enabled="False"
										Font-Size="X-Small" Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD style="WIDTH: 91px" vAlign="top" colSpan="2"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table8" style="WIDTH: 224px; HEIGHT: 32px" borderColor="whitesmoke" cellSpacing="1"
							cellPadding="1" width="224" border="1">
							<TR>
								<TD style="WIDTH: 76px"><asp:button id="btnSalvarItem" tabIndex="4" runat="server" CssClass="botao" Width="72px" Text="Salvar"></asp:button></TD>
								<TD style="WIDTH: 75px"><asp:button id="btnExcluirItem" tabIndex="5" runat="server" CssClass="botao" CausesValidation="False"
										Width="72px" Text="Excluir"></asp:button></TD>
								<TD style="WIDTH: 74px"><asp:button id="btnLimparItens" tabIndex="6" runat="server" CssClass="botao" CausesValidation="False"
										Width="72px" Text="Limpar"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:datagrid id="Datagrid2" runat="server" Width="368px" BorderColor="Silver" AutoGenerateColumns="False"
							ShowFooter="True" PageSize="12" AllowPaging="True">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="codProd" HeaderText="C&#243;digo do Produto"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="codPed" HeaderText="C&#243;digo do Pedido"></asp:BoundColumn>
								<asp:ButtonColumn DataTextField="nomeProd" HeaderText="Produto" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="qtdProd" HeaderText="Qtd"></asp:BoundColumn>
								<asp:BoundColumn DataField="valorUnit" HeaderText="Valor Unit." DataFormatString="{0:C}"></asp:BoundColumn>
								<asp:BoundColumn DataField="totalItem" HeaderText="Total Item" DataFormatString="{0:C}"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
					<TD vAlign="top" align="center">
						<TABLE id="tblProdClientes" cellSpacing="1" cellPadding="1" width="146" border="0" runat="server">
							<TR>
								<TD bgColor="#ffe0c0"><asp:linkbutton id="lnkProdClientes" runat="server" CausesValidation="False" BackColor="#FFE0C0"
										Width="200px">(+) Produtos do Cliente</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD><asp:datagrid id="Datagrid3" runat="server" Width="236px" BorderColor="Silver" AutoGenerateColumns="False"
										ShowFooter="True" PageSize="4" AllowPaging="True" DESIGNTIMEDRAGDROP="159">
										<FooterStyle CssClass="dgFooter"></FooterStyle>
										<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
										<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
										<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
										<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn DataTextField="nomeCatProd" HeaderText="Categoria" CommandName="Select"></asp:ButtonColumn>
											<asp:BoundColumn DataField="precoSugerido" HeaderText="Pre&#231;o Sugerido" DataFormatString="{0:C}"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="codCatProd" HeaderText="codCatProd"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="codCli" HeaderText="codCli"></asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<INPUT id="hidTotalPed" style="Z-INDEX: 108; LEFT: 216px; WIDTH: 24px; POSITION: absolute; TOP: 280px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
