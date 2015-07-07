<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Maquinas.aspx.vb" Inherits="Estoque.Maquinas" smartNavigation="True" culture="pt-BR"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<meta name="vs_snapToGrid" content="True">
		<title>Máquinas</title>
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
				runat="server" HeaderText="Preenchimento Obrigatório" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary><asp:label id="lblPagina" style="Z-INDEX: 103; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server" CssClass="Label"></asp:label>
			<TABLE class="Label" id="tblFornecedores" style="Z-INDEX: 102; LEFT: 256px; POSITION: absolute; TOP: 176px"
				borderColor="gainsboro" cellSpacing="1" cellPadding="1" width="520" border="1" runat="server">
				<TR>
					<TD style="HEIGHT: 17px" vAlign="top" bgColor="gainsboro"><P><STRONG>Identificação</STRONG></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" vAlign="top" align="left">
						<P>
							<TABLE class="Label" id="Table3" style="WIDTH: 232px; HEIGHT: 43px" cellSpacing="1" cellPadding="1"
								width="232">
								<TR>
									<TD style="WIDTH: 92px"><STRONG>Identificador
											<asp:requiredfieldvalidator id="rfvIdentificador" runat="server" ErrorMessage="Identificador" ControlToValidate="txtIdentificador">*</asp:requiredfieldvalidator></STRONG></TD>
									<TD style="WIDTH: 168px">
										<P><STRONG>Nome da Máquina </STRONG><STRONG>&nbsp; </STRONG>
											<asp:requiredfieldvalidator id="rfvNomeMaq" runat="server" ErrorMessage="Nome da Máquina" ControlToValidate="txtNomeMaq">*</asp:requiredfieldvalidator></P>
									</TD>
									<TD style="WIDTH: 168px">Nota Fiscal</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 92px"><asp:textbox id="txtIdentificador" runat="server" CssClass="texto" Width="104px"></asp:textbox></TD>
									<TD style="WIDTH: 168px"><asp:textbox id="txtNomeMaq" runat="server" CssClass="texto" Width="208px" MaxLength="20"></asp:textbox></TD>
									<TD style="WIDTH: 168px"><asp:textbox id="txtNotaFiscal" runat="server" CssClass="texto" Width="104px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<TABLE class="Label" id="Table5" style="WIDTH: 256px; HEIGHT: 43px" cellSpacing="1" cellPadding="1"
								width="256">
								<TR>
									<TD style="WIDTH: 179px">Senha BIOS<STRONG>&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:linkbutton id="lnkDesSenBios" runat="server" CausesValidation="False">Desvendar Senha</asp:linkbutton></STRONG></TD>
									<TD style="WIDTH: 168px">
										<P>Senha de Tela<STRONG>&nbsp;
												<asp:linkbutton id="lnkDesSenTela" runat="server" CausesValidation="False">Desvendar Senha</asp:linkbutton></STRONG></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 179px"><asp:textbox id="txtSenhaBios" runat="server" CssClass="texto" Width="168px" TextMode="Password"></asp:textbox></TD>
									<TD style="WIDTH: 168px"><asp:textbox id="txtSenhaTela" runat="server" CssClass="texto" Width="168px" TextMode="Password"></asp:textbox></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" vAlign="top" bgColor="#d3d3d3"><STRONG>Rede</STRONG></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" vAlign="middle" align="left">
						<TABLE class="Label" id="Table2" style="WIDTH: 360px; HEIGHT: 41px" cellSpacing="1" cellPadding="1"
							width="360">
							<TR>
								<TD style="WIDTH: 124px"><STRONG>&nbsp;IP</STRONG>&nbsp;
									<asp:requiredfieldvalidator id="rfvIp" runat="server" ErrorMessage="IP" ControlToValidate="drpIp">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 124px"><STRONG>Usuário</STRONG>&nbsp;&nbsp;</TD>
								<TD style="WIDTH: 124px">Hub/Switch</TD>
								<TD style="WIDTH: 124px">Porta</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px"><asp:dropdownlist id="drpIp" runat="server" CssClass="texto" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 124px"><asp:dropdownlist id="drpUsuario" runat="server" CssClass="texto" Width="201px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 124px">
									<asp:dropdownlist id="drpHubSw" runat="server" CssClass="texto" Width="136px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 124px">
									<asp:dropdownlist id="drpPorta" runat="server" CssClass="texto" Width="104px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" bgColor="#e0e0e0"><STRONG>Hardware</STRONG></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE class="Label" id="Table6" style="WIDTH: 360px; HEIGHT: 41px" cellSpacing="1" cellPadding="1"
							width="360">
							<TR>
								<TD style="WIDTH: 196px; HEIGHT: 17px">Placa Mãe&nbsp;
									<asp:requiredfieldvalidator id="rfvPlacaMae" runat="server" ErrorMessage="Placa Mãe" ControlToValidate="drpPlacaMae">*</asp:requiredfieldvalidator>&nbsp;
									<asp:linkbutton id="lnkVisualizarImagem" runat="server" Width="96px">Visualizar Imagem</asp:linkbutton></TD>
								<TD style="WIDTH: 124px; HEIGHT: 17px">Processador&nbsp;&nbsp;
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Processador" ControlToValidate="drpProcessador">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 124px; HEIGHT: 17px">Memória&nbsp;
									<asp:requiredfieldvalidator id="rfvMemoria" runat="server" ErrorMessage="Memória" ControlToValidate="drpMemoria">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 124px; HEIGHT: 17px">HD&nbsp;
									<asp:requiredfieldvalidator id="rfvHd" runat="server" ErrorMessage="HD" ControlToValidate="txtHd">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 196px"><asp:dropdownlist id="drpPlacaMae" runat="server" CssClass="texto" Width="184px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 124px"><asp:dropdownlist id="drpProcessador" runat="server" CssClass="texto" Width="201px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 124px"><asp:dropdownlist id="drpMemoria" runat="server" CssClass="texto" Width="112px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 124px"><asp:textbox id="txtHd" runat="server" CssClass="texto" Width="72px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" bgColor="#e0e0e0"><STRONG>Windows e Office</STRONG></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE class="Label" id="Table7" style="WIDTH: 440px; HEIGHT: 43px" cellSpacing="1" cellPadding="1"
							width="440">
							<TR>
								<TD style="WIDTH: 125px"><STRONG>Windows</STRONG>&nbsp;
									<asp:requiredfieldvalidator id="rfvWindows" runat="server" ErrorMessage="Windows" ControlToValidate="drpWindows">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 124px">Serial&nbsp;&nbsp;
									<asp:requiredfieldvalidator id="rfvSerialWin" runat="server" ErrorMessage="Serial Windows" ControlToValidate="txtSerialWin">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 125px"><asp:dropdownlist id="drpWindows" runat="server" CssClass="texto" Width="184px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 124px"><asp:textbox id="txtSerialWin" runat="server" CssClass="texto" Width="247px" MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE class="Label" id="Table8" style="WIDTH: 440px; HEIGHT: 43px" cellSpacing="1" cellPadding="1"
							width="440">
							<TR>
								<TD style="WIDTH: 125px; HEIGHT: 17px"><STRONG>Office</STRONG>&nbsp;
									<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ErrorMessage="Office" ControlToValidate="drpWindows">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 124px; HEIGHT: 17px">Serial&nbsp;&nbsp;
									<asp:requiredfieldvalidator id="rfvSerialOffice" runat="server" ErrorMessage="Serial Office" ControlToValidate="txtSerialOffice">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 125px"><asp:dropdownlist id="drpOffice" runat="server" CssClass="texto" Width="184px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 124px"><asp:textbox id="txtSerialOffice" runat="server" CssClass="texto" Width="247px" MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
						<BR>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" bgColor="#e0e0e0"><STRONG>Softwares</STRONG></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE class="Label" id="Table9" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; WIDTH: 360px; HEIGHT: 16px; BORDER-RIGHT-WIDTH: 1px"
							cellSpacing="1" cellPadding="1" width="360">
							<TR>
								<TD style="HEIGHT: 17px">Anti-Vírus&nbsp;
									<asp:requiredfieldvalidator id="rfvAntiVirus" runat="server" ErrorMessage="Anti-Vírus" ControlToValidate="drpAntiVirus">*</asp:requiredfieldvalidator></TD>
								<TD style="HEIGHT: 17px">Anti-Spyware&nbsp;
									<asp:requiredfieldvalidator id="rfvAntiSpyware" runat="server" ErrorMessage="Anti-Spyware" ControlToValidate="drpAntiSpyware">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD><asp:dropdownlist id="drpAntiVirus" runat="server" CssClass="texto" Width="184px"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD vAlign="top"><asp:dropdownlist id="drpAntiSpyware" runat="server" CssClass="texto" Width="168px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<BR>
						<TABLE class="Label" id="Table11" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; WIDTH: 456px; HEIGHT: 63px; BORDER-RIGHT-WIDTH: 1px"
							cellSpacing="1" cellPadding="1" width="456">
							<TR>
								<TD style="HEIGHT: 16px">Software</TD>
							</TR>
							<TR>
								<TD><asp:dropdownlist id="drpSoftware" runat="server" CssClass="texto" Width="288px"></asp:dropdownlist>&nbsp;
									<asp:button id="btnAddSoft" runat="server" CssClass="botao" Width="40px" Text="Add" CausesValidation="False"></asp:button>&nbsp;
									<asp:button id="btnRemoveSoft" runat="server" CssClass="botao" Width="48px" Text="Remove" CausesValidation="False"></asp:button>&nbsp;
									<asp:button id="btnLimparSoft" runat="server" CssClass="botao" Width="48px" Text="Limpar" CausesValidation="False"></asp:button>&nbsp;
								</TD>
							</TR>
						</TABLE>
						<BR>
						<asp:datagrid id="dtgSoftware" runat="server" Width="400px" BorderColor="Silver" AutoGenerateColumns="False"
							ShowFooter="True" PageSize="3" AllowPaging="True">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn DataTextField="endereco" HeaderText="E-Mail" CommandName="Select">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="endereco" HeaderText="endereco"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="codEMail" HeaderText="codEMail">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD vAlign="top" bgColor="#e0e0e0"><STRONG>Histórico de Usuários</STRONG></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px" vAlign="top"><asp:datagrid id="dtgHistUsuario" runat="server" Width="480px" BorderColor="Silver" AutoGenerateColumns="False"
							ShowFooter="True" PageSize="3" AllowPaging="True">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="sNomeDeUsuario" HeaderText="Usu&#225;rio"></asp:BoundColumn>
								<asp:BoundColumn DataField="inicio" HeaderText="Data In&#237;cio">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="final" HeaderText="Data Final"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid><BR>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" vAlign="top">
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
					<TD vAlign="top"><asp:datagrid id="dtgMaquinas" runat="server" Width="592px" BorderColor="Silver" AutoGenerateColumns="False"
							ShowFooter="True" PageSize="12" AllowPaging="True">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn DataTextField="identificador" HeaderText="Identificador" CommandName="Select">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="codMaq" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="nomeMaq" HeaderText="Nome da Maquina"></asp:BoundColumn>
								<asp:BoundColumn DataField="sNomeDeUsuario" HeaderText="Usu&#225;rio"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="identificador" HeaderText="Identificador"></asp:BoundColumn>
								<asp:BoundColumn DataField="numIp" HeaderText="IP"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<INPUT id="hidCodEnd" type="hidden" size="1" runat="server"> <INPUT id="hidCodMaq" style="Z-INDEX: 105; LEFT: 32px; WIDTH: 16px; POSITION: absolute; TOP: 344px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden2" runat="server">
		</form>
	</body>
</HTML>
