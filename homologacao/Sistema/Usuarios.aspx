<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Usuarios.aspx.vb" Inherits="Estoque.Usuarios"%>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Usuários</title>
		<meta name="vs_snapToGrid" content="True">
		<meta name="vs_showGrid" content="True">
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
			<TABLE id="tblUsuarios" style="Z-INDEX: 102; LEFT: 320px; WIDTH: 392px; POSITION: absolute; TOP: 176px; HEIGHT: 380px"
				cellSpacing="1" cellPadding="1" width="392" runat="server">
				<TR>
					<TD style="HEIGHT: 26px" vAlign="top">
						<P>
							<TABLE class="Label" id="Table3" cellSpacing="1" cellPadding="1" width="300">
								<TR>
									<TD style="WIDTH: 3px">Código</TD>
									<TD><STRONG class="LabelPesquisa">Nome&nbsp;
											<asp:requiredfieldvalidator id="rfvNome" runat="server" ControlToValidate="txtSNomeUsuario" ErrorMessage="Nome do Centro de Custo">*</asp:requiredfieldvalidator></STRONG></TD>
									<TD><STRONG class="labelpesquisa">Login&nbsp;
											<asp:requiredfieldvalidator id="rfvLogin" runat="server" ControlToValidate="txtSLoginUsuario" ErrorMessage="Nome do Centro de Custo">*</asp:requiredfieldvalidator></STRONG></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 3px"><asp:textbox id="txtIdUsuario" runat="server" CssClass="texto" Width="40px" Enabled="False"></asp:textbox></TD>
									<TD><asp:textbox id="txtSNomeUsuario" runat="server" CssClass="texto" Width="200px" MaxLength="100"></asp:textbox></TD>
									<TD><asp:textbox id="txtSLoginUsuario" runat="server" CssClass="texto" Width="136px" MaxLength="50"></asp:textbox></TD>
								</TR>
							</TABLE>
							<TABLE class="Label" id="Table2" cellSpacing="1" cellPadding="1" width="392" style="WIDTH: 392px; HEIGHT: 57px">
								<TR>
									<TD style="WIDTH: 141px">Senha<STRONG>&nbsp; </STRONG>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="txtSenha" ErrorMessage="Nome do Centro de Custo">*</asp:requiredfieldvalidator>&nbsp;
										<asp:linkbutton id="lnkDesSenha" runat="server" CausesValidation="False">Desvendar Senha</asp:linkbutton></TD>
									<TD>Confirmar Senha<STRONG>&nbsp; </STRONG>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtConfSenha" ErrorMessage="Nome do Centro de Custo">*</asp:requiredfieldvalidator></TD>
									<TD>Unidade Organizacional</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px"><asp:textbox id="txtSenha" runat="server" CssClass="texto" Width="120px" MaxLength="100" TextMode="Password"></asp:textbox></TD>
									<TD><asp:textbox id="txtConfSenha" runat="server" CssClass="texto" Width="120px" MaxLength="50" TextMode="Password"></asp:textbox></TD>
									<TD><asp:textbox id="txtOu" runat="server" CssClass="texto" Width="120px" MaxLength="50"></asp:textbox></TD>
								</TR>
							</TABLE>
							<TABLE class="Label" id="Table6" style="WIDTH: 88px; HEIGHT: 61px" cellSpacing="1" cellPadding="1"
								width="88">
								<TR>
									<TD>Status</TD>
								</TR>
								<TR>
									<TD>
										<asp:radiobuttonlist id="rdoStatus" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="A">Ativo</asp:ListItem>
											<asp:ListItem Value="I">Inativo</asp:ListItem>
										</asp:radiobuttonlist></TD>
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
					<TD vAlign="top"><asp:datagrid id="dtgUsuarios" runat="server" Width="400px" AllowPaging="True" PageSize="12" ShowFooter="True"
							AutoGenerateColumns="False" BorderColor="Silver">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn DataTextField="sNomedeUsuario" HeaderText="Nome" CommandName="Select">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="idUsuario" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="sLoginUsuario" HeaderText="Login">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="sNomedeUsuario" HeaderText="Nome"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
