<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Clientes.aspx.vb" Inherits="Estoque.Clientes" smartNavigation="True" culture="pt-BR"%>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Clientes</title>
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
				runat="server" CssClass="Label"></asp:label><asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 216px"
				runat="server" HeaderText="Preenchimento Obrigatório" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary>
			<TABLE id="tblClientes" style="Z-INDEX: 104; LEFT: 320px; WIDTH: 464px; POSITION: absolute; TOP: 176px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="464" border="0" runat="server">
				<TR>
					<TD bgColor="#ffe0c0"><asp:linkbutton id="lnkDadosGerais" runat="server" BackColor="#FFE0C0" Width="480px" CausesValidation="False">(+) Dados Gerais</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="label" id="Table5" style="WIDTH: 456px; HEIGHT: 16px" cellSpacing="1" cellPadding="1"
							width="456" border="0">
							<TR>
								<TD style="WIDTH: 46px">Código</TD>
								<TD style="WIDTH: 258px"><STRONG>Razão Social</STRONG>&nbsp;
									<asp:requiredfieldvalidator id="rfvNome" runat="server" ControlToValidate="txtRazaoSocial" ErrorMessage="Razão Social">*</asp:requiredfieldvalidator></TD>
								<TD>Nome Fantasia</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 46px"><asp:textbox id="txtCodCli" runat="server" CssClass="texto" Width="40px" Enabled="False" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD style="WIDTH: 258px"><asp:textbox id="txtRazaoSocial" runat="server" CssClass="texto" Width="208px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD><asp:textbox id="txtNomeFantasia" runat="server" CssClass="texto" Width="216px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="label" id="Table2" style="WIDTH: 456px; HEIGHT: 16px" cellSpacing="1" cellPadding="1"
							width="456" border="0">
							<TR>
								<TD style="WIDTH: 207px"><STRONG>CNPJ / CPF
										<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtCnpjCpf" ErrorMessage="CNPJ / CPF">*</asp:requiredfieldvalidator></STRONG></TD>
								<TD style="WIDTH: 126px"><STRONG>RG</STRONG>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtRazaoSocial" ErrorMessage="Razão Social">*</asp:requiredfieldvalidator></TD>
								<TD><STRONG>Categoria do&nbsp;Cliente&nbsp;
										<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="drpCatCliente" ErrorMessage="Categoria do Cliente">*</asp:requiredfieldvalidator></STRONG></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 207px"><asp:textbox id="txtCnpjCpf" runat="server" CssClass="texto" Width="152px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD style="WIDTH: 126px"><asp:textbox id="txtRg" runat="server" CssClass="texto" Width="136px" Font-Size="X-Small" Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD><asp:dropdownlist id="drpCatCliente" runat="server" CssClass="texto" Width="176px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<TABLE class="label" id="Table3" style="WIDTH: 456px; HEIGHT: 16px" cellSpacing="1" cellPadding="1"
							width="456" border="0">
							<TR>
								<TD style="WIDTH: 153px"><STRONG>Vendedor&nbsp;
										<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="drpVendedor" ErrorMessage="Vendedor">*</asp:requiredfieldvalidator></STRONG></TD>
								<TD style="WIDTH: 126px">Site&nbsp;</TD>
								<TD>E-mail Geral<STRONG>&nbsp;</STRONG></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 153px"><asp:dropdownlist id="drpVendedor" runat="server" CssClass="texto" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 126px"><asp:textbox id="txtSite" runat="server" CssClass="texto" Width="136px" Font-Size="X-Small" Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD><asp:textbox id="txtEmailGeral" runat="server" CssClass="texto" Width="152px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="label" id="Table6" style="WIDTH: 256px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="256" border="0">
							<TR>
								<TD style="WIDTH: 130px">Usuário Criação<STRONG>&nbsp;</STRONG></TD>
								<TD style="WIDTH: 126px">Data Criação</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 130px"><asp:dropdownlist id="drpUsuCriacao" runat="server" CssClass="texto" Width="168px" Enabled="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 126px"><asp:textbox id="txtDataCriacao" runat="server" CssClass="texto" Width="136px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<BR>
						<TABLE class="label" id="Table7" style="WIDTH: 496px; HEIGHT: 136px" cellSpacing="1" cellPadding="1"
							width="496" border="0">
							<TR>
								<TD style="FONT-SIZE: xx-small; WIDTH: 126px; HEIGHT: 1px" bgColor="#ffe0c0">Endereço</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 126px">
									<TABLE class="label" id="Table8" style="WIDTH: 456px; HEIGHT: 16px" cellSpacing="1" cellPadding="1"
										width="456" border="0">
										<TR>
											<TD style="WIDTH: 53px">Endereço</TD>
											<TD style="WIDTH: 258px">Número&nbsp;</TD>
											<TD>Complemento</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 53px"><asp:textbox id="txtEndereco" runat="server" CssClass="texto" Width="274px" Font-Size="X-Small"
													Font-Names="Trebuchet MS"></asp:textbox></TD>
											<TD style="WIDTH: 258px"><asp:textbox id="txtNumero" runat="server" CssClass="texto" Width="67px" Font-Size="X-Small"
													Font-Names="Trebuchet MS"></asp:textbox></TD>
											<TD><asp:textbox id="txtComplemento" runat="server" CssClass="texto" Width="115px" Font-Size="X-Small"
													Font-Names="Trebuchet MS"></asp:textbox></TD>
										</TR>
									</TABLE>
									<TABLE class="label" id="Table9" style="WIDTH: 456px; HEIGHT: 16px" cellSpacing="1" cellPadding="1"
										width="456" border="0">
										<TR>
											<TD style="WIDTH: 53px">Bairro</TD>
											<TD style="WIDTH: 167px">Cidade</TD>
											<TD>Estado</TD>
											<TD>CEP</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 53px"><asp:textbox id="txtBairro" runat="server" CssClass="texto" Width="132px" Font-Size="X-Small"
													Font-Names="Trebuchet MS"></asp:textbox></TD>
											<TD style="WIDTH: 167px"><asp:textbox id="txtCidade" runat="server" CssClass="texto" Width="168px" Font-Size="X-Small"
													Font-Names="Trebuchet MS"></asp:textbox></TD>
											<TD><asp:dropdownlist id="drpEstado" runat="server" CssClass="texto" Width="60px">
													<asp:ListItem></asp:ListItem>
													<asp:ListItem Value="sp">SP</asp:ListItem>
													<asp:ListItem Value="rj">RJ</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtCep" runat="server" CssClass="texto" Width="95px" Font-Size="X-Small" Font-Names="Trebuchet MS"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<TABLE id="Table4" style="WIDTH: 317px; HEIGHT: 8px" cellSpacing="1" cellPadding="1" width="317"
							border="0">
							<TR>
								<TD><asp:button id="btnSalvar" tabIndex="4" runat="server" CssClass="botao" Width="72px" Text="Salvar"></asp:button></TD>
								<TD><asp:button id="btnExcluir" tabIndex="5" runat="server" CssClass="botao" Width="72px" Text="Excluir"
										CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnLimpar" tabIndex="6" runat="server" CssClass="botao" Width="72px" Text="Limpar"
										CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnPesquisar" tabIndex="7" runat="server" CssClass="botao" Width="80px" Text="Pesquisar"
										CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:linkbutton id="lnkContatos" runat="server" BackColor="#FFE0C0" Width="496px" CausesValidation="False">(+) Contatos</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="label" id="Table11" style="WIDTH: 488px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="488" border="0">
							<TR>
								<TD style="WIDTH: 46px">Código</TD>
								<TD style="WIDTH: 258px">Nome&nbsp;
								</TD>
								<TD>Tipo</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 46px"><asp:textbox id="txtCodCont" runat="server" CssClass="texto" Width="40px" Enabled="False" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD style="WIDTH: 258px"><asp:textbox id="txtNomeCont" runat="server" CssClass="texto" Width="232px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD><asp:dropdownlist id="drpTipoCont" runat="server" CssClass="texto" Width="200px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<TABLE class="label" id="Table10" style="WIDTH: 456px; HEIGHT: 16px" cellSpacing="1" cellPadding="1"
							width="456" border="0">
							<TR>
								<TD style="WIDTH: 53px">Apelido</TD>
								<TD style="WIDTH: 258px">Telefone</TD>
								<TD>E-mail</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 53px"><asp:textbox id="txtApelido" runat="server" CssClass="texto" Width="112px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD style="WIDTH: 258px"><asp:textbox id="txtTelefone" runat="server" CssClass="texto" Width="128px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
								<TD><asp:textbox id="txtEMail" runat="server" CssClass="texto" Width="232px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="label" id="Table12" style="WIDTH: 144px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="144" border="0">
							<TR>
								<TD style="WIDTH: 53px">Aniversário</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 53px"><asp:textbox id="txtAniversario" runat="server" CssClass="texto" Width="152px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table14" style="WIDTH: 136px; HEIGHT: 28px" cellSpacing="1" cellPadding="1"
							width="136" border="0">
							<TR>
								<TD><asp:button id="btnSalvarCont" tabIndex="4" runat="server" CssClass="botao" Width="72px" Text="Salvar"
										CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnExcluiCont" tabIndex="5" runat="server" CssClass="botao" Width="72px" Text="Excluir"
										CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnLimparCont" tabIndex="6" runat="server" CssClass="botao" Width="72px" Text="Limpar"
										CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:datagrid id="Datagrid2" runat="server" Width="496px" AllowPaging="True" PageSize="3" ShowFooter="True"
							AutoGenerateColumns="False" BorderColor="Silver">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="codCont" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:ButtonColumn DataTextField="nomeCont" HeaderText="Nome" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="eMail" HeaderText="E-Mail"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="nomeCont" HeaderText="Nome"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<TD><asp:linkbutton id="lnkProdCli" runat="server" BackColor="#FFE0C0" Width="496px" CausesValidation="False">(+) Produtos do Cliente</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="label" id="Table13" style="WIDTH: 488px; HEIGHT: 49px" cellSpacing="1" cellPadding="1"
							width="488" border="0">
							<TR>
								<TD style="WIDTH: 258px">Categoria do Produto</TD>
								<TD>Preço Sugerido</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 258px"><asp:dropdownlist id="drpCatProd" runat="server" CssClass="texto" Width="304px"></asp:dropdownlist></TD>
								<TD><asp:textbox id="txtPrecoSugerido" runat="server" CssClass="texto" Width="144px" Font-Size="X-Small"
										Font-Names="Trebuchet MS"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table15" style="WIDTH: 317px; HEIGHT: 8px" cellSpacing="1" cellPadding="1" width="317"
							border="0">
							<TR>
								<TD><asp:button id="btnSalvarCatProd" tabIndex="4" runat="server" CssClass="botao" Width="72px"
										Text="Salvar" CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnExcluiCatProd" tabIndex="5" runat="server" CssClass="botao" Width="72px"
										Text="Excluir" CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnLimparCatProd" tabIndex="6" runat="server" CssClass="botao" Width="72px"
										Text="Limpar" CausesValidation="False"></asp:button></TD>
								<TD><asp:button id="btnFindCatProd" tabIndex="7" runat="server" CssClass="botao" Width="80px" Text="Pesquisar"
										CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:datagrid id="Datagrid3" runat="server" Width="496px" AllowPaging="True" PageSize="3" ShowFooter="True"
							AutoGenerateColumns="False" BorderColor="Silver">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn DataTextField="nomeCatProd" HeaderText="Categoria" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="precoSugerido" HeaderText="Pre&#231;o Sugerido"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="codCatProd" HeaderText="codCatProd"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="codCli" HeaderText="CodCli"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="DataGrid1" runat="server" Width="496px" BorderColor="Silver" AutoGenerateColumns="False"
							ShowFooter="True" PageSize="12" AllowPaging="True">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="codCli" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:ButtonColumn DataTextField="razaoSocial" HeaderText="Raz&#227;o Social" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="nomeFantasia" HeaderText="Nome Fantasia"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnpjCpf" HeaderText="CNPJ/CPF"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="razaoSocial" HeaderText="RazaoSocial"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<INPUT id="hidCatProd" style="Z-INDEX: 105; LEFT: 272px; WIDTH: 32px; POSITION: absolute; TOP: 816px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="Hidden1" style="Z-INDEX: 106; LEFT: 240px; WIDTH: 32px; POSITION: absolute; TOP: 216px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"></form>
	</body>
</HTML>
