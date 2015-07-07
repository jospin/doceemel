<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Papeis.aspx.vb" Inherits="Estoque.CondicaoPagamento" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Grupos</title>
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
			<INPUT id="IdPapel" style="Z-INDEX: 109; LEFT: 560px; WIDTH: 50px; POSITION: absolute; TOP: 216px; HEIGHT: 16px"
				type="hidden" size="3" name="IdUsuario" runat="server">
			<TABLE id="tblDetalheNF" style="Z-INDEX: 104; LEFT: 248px; POSITION: absolute; TOP: 256px"
				borderColor="#ffffff" cellSpacing="1" cellPadding="1" width="696" border="0">
				<TR>
					<TD style="HEIGHT: 8px"><STRONG>
							<asp:label id="Label1" runat="server" CssClass="LabelPesquisa" Visible="False">Papéis Cadastrados</asp:label></STRONG></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left">
						<asp:datagrid id="dtgPapeis" runat="server" Width="727px" AllowPaging="True" PageSize="12" ShowFooter="True"
							AutoGenerateColumns="False" BorderColor="Silver">
							<FooterStyle CssClass="dgFooter"></FooterStyle>
							<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
							<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
							<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
							<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn DataTextField="sNomePapel" HeaderText="Nome do Papel" CommandName="Select">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="idPapel" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="sNomePapel" HeaderText="Nome do Papel"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Excluir">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:ImageButton id="imgExcluir" runat="server" CausesValidation="False" ImageUrl="images\btn_ExcluirVermelho.gif"
											CommandName="Delete"></asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
			<asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 216px"
				runat="server" HeaderText="Preenchimento Obrigatório" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary>
			<asp:label id="lblPagina" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server" CssClass="Label"></asp:label>
			<TABLE id="tblDadosContribuinte" style="BORDER-RIGHT: #cccccc thin solid; BORDER-TOP: #cccccc thin solid; Z-INDEX: 105; LEFT: 248px; BORDER-LEFT: #cccccc thin solid; WIDTH: 732px; BORDER-BOTTOM: #cccccc thin solid; POSITION: absolute; TOP: 160px; HEIGHT: 4px"
				borderColor="#cccccc" cellSpacing="1" cellPadding="1" width="732" border="0">
				<TR>
					<TD style="WIDTH: 139px; HEIGHT: 32px" align="left" width="139">
						<asp:label id="Label2" runat="server" CssClass="LabelPesquisa">Nome do Papel</asp:label></TD>
					<TD style="WIDTH: 706px; HEIGHT: 32px" width="706">
						<asp:textbox id="txtNomePapel" runat="server" Width="531px" CssClass="Texto" MaxLength="50"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o nome do papel"
							ControlToValidate="txtNomePapel" Font-Size="12pt" Display="Dynamic">*</asp:requiredfieldvalidator></TD>
				</TR>
			</TABLE>
			<asp:button id="btnGravar" style="Z-INDEX: 106; LEFT: 256px; POSITION: absolute; TOP: 216px"
				runat="server" Width="80px" CssClass="botao" Text="Gravar" BorderStyle="Outset"></asp:button>
			<asp:button id="btnLimpar" style="Z-INDEX: 107; LEFT: 360px; POSITION: absolute; TOP: 216px"
				runat="server" Width="80px" CssClass="botao" Text="Limpar" CausesValidation="False" BorderStyle="Outset"></asp:button>
			<asp:button id="bntPesquisa" style="Z-INDEX: 108; LEFT: 464px; POSITION: absolute; TOP: 216px"
				runat="server" Width="80px" CssClass="botao" Text="Pesquisar" CausesValidation="False" BorderStyle="Outset"></asp:button>
			<asp:textbox id="txtNumPapel" runat="server" Width="89px" CssClass="Texto" MaxLength="100" style="Z-INDEX: 110; LEFT: 288px; POSITION: absolute; TOP: 16px"
				Visible="False"></asp:textbox>
		</form>
	</body>
</HTML>
