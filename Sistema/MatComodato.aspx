<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MatComodato.aspx.vb" Inherits="Celso1.MatComodato"%>
<%@ Register TagPrefix="uc1" TagName="MenuPadrao" Src="MenuPadrao.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MatComodato</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 96px; POSITION: absolute; TOP: 8px; HEIGHT: 28px"
				cellSpacing="1" cellPadding="1" width="96" border="0">
				<TR>
					<TD>
						<uc1:MenuPadrao id="MenuPadrao1" runat="server"></uc1:MenuPadrao></TD>
				</TR>
			</TABLE>
			<TABLE id="Table5" style="Z-INDEX: 106; LEFT: 288px; WIDTH: 320px; POSITION: absolute; TOP: 248px; HEIGHT: 32px"
				borderColor="whitesmoke" cellSpacing="1" cellPadding="1" width="320" border="1">
				<TR>
					<TD style="WIDTH: 76px">
						<asp:button id="btnSalvar" tabIndex="4" runat="server" Width="72px" Text="Salvar"></asp:button></TD>
					<TD style="WIDTH: 75px">
						<asp:button id="btnExcluir" tabIndex="5" runat="server" Width="72px" Text="Excluir" CausesValidation="False"></asp:button></TD>
					<TD style="WIDTH: 74px">
						<asp:button id="btnLimpar" tabIndex="6" runat="server" Width="72px" Text="Limpar" CausesValidation="False"></asp:button></TD>
					<TD>
						<asp:button id="btnPesquisar" tabIndex="7" runat="server" Width="80px" Text="Pesquisar" CausesValidation="False"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 105; LEFT: 224px; POSITION: absolute; TOP: 288px"
				runat="server" ForeColor="Black" Font-Size="X-Small" Font-Names="Trebuchet MS" Width="536px"
				AllowPaging="True" PageSize="5" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS" Font-Bold="True"></SelectedItemStyle>
				<EditItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS"></EditItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS" BackColor="#FFE0C0"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Trebuchet MS" ForeColor="White" BackColor="#996600"></HeaderStyle>
				<FooterStyle Font-Size="X-Small" Font-Names="Trebuchet MS" BackColor="#996600"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="codmatCom" HeaderText="C&#243;digo">
						<HeaderStyle Width="1cm"></HeaderStyle>
					</asp:BoundColumn>
					<asp:ButtonColumn Text="Button" DataTextField="nomeMatCom" SortExpression="Select" HeaderText="Nome"
						CommandName="select">
						<HeaderStyle Width="5cm"></HeaderStyle>
					</asp:ButtonColumn>
					<asp:BoundColumn DataField="qtd" HeaderText="Qtd">
						<HeaderStyle Width="2cm"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="dataIni" HeaderText="Data Inicial"></asp:BoundColumn>
					<asp:BoundColumn DataField="dataFim" HeaderText="Data Final"></asp:BoundColumn>
				</Columns>
				<PagerStyle Font-Size="X-Small" Font-Names="Trebuchet MS" ForeColor="White" BackColor="#996600"
					Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<TABLE id="Table3" style="FONT-SIZE: x-small; Z-INDEX: 104; LEFT: 296px; WIDTH: 328px; COLOR: #996600; FONT-FAMILY: 'Trebuchet MS'; POSITION: absolute; TOP: 176px; HEIGHT: 57px"
				borderColor="whitesmoke" cellSpacing="1" cellPadding="1" width="328" border="1">
				<TR>
					<TD style="WIDTH: 31px">Qtd&nbsp;
						<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtQtd" ErrorMessage="Quantidade">*</asp:RequiredFieldValidator></TD>
					<TD>Data Inicial&nbsp;<STRONG> </STRONG>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Data Inicial" ControlToValidate="txtDataIni">*</asp:RequiredFieldValidator></TD>
					<TD>Data Final
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Data Final" ControlToValidate="txtDataIni">*</asp:RequiredFieldValidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 31px">
						<asp:textbox id="txtQtd" runat="server" Font-Size="X-Small" Font-Names="Trebuchet MS" Width="64px"></asp:textbox></TD>
					<TD width="1">
						<asp:textbox id="txtDataIni" runat="server" Font-Size="X-Small" Font-Names="Trebuchet MS" Width="112px"></asp:textbox></TD>
					<TD>
						<asp:textbox id="txtDataFim" runat="server" Font-Size="X-Small" Font-Names="Trebuchet MS" Width="128px"></asp:textbox></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="FONT-SIZE: x-small; Z-INDEX: 103; LEFT: 296px; COLOR: #996600; FONT-FAMILY: 'Trebuchet MS'; POSITION: absolute; TOP: 120px"
				borderColor="whitesmoke" cellSpacing="1" cellPadding="1" width="300" border="1">
				<TR>
					<TD style="WIDTH: 31px">Código</TD>
					<TD><STRONG>Nome
							<asp:RequiredFieldValidator id="rfvNome" runat="server" ErrorMessage="Nome" ControlToValidate="txtnomeMatCom">*</asp:RequiredFieldValidator></STRONG></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 31px">
						<asp:textbox id="txtCodMatCom" runat="server" Font-Size="X-Small" Font-Names="Trebuchet MS" Width="40px"
							Enabled="False"></asp:textbox></TD>
					<TD>
						<asp:textbox id="txtnomeMatCom" runat="server" Font-Size="X-Small" Font-Names="Trebuchet MS"
							Width="272px"></asp:textbox></TD>
				</TR>
			</TABLE>
			<asp:label id="lblSuperior" style="Z-INDEX: 102; LEFT: 352px; POSITION: absolute; TOP: 56px"
				runat="server" ForeColor="#996600" Font-Size="X-Small" Font-Names="Trebuchet MS">Cadastro de Materiais em Comodato</asp:label>
			<asp:ValidationSummary id="ValidationSummary1" style="Z-INDEX: 107; LEFT: 728px; POSITION: absolute; TOP: 48px"
				runat="server" HeaderText="Preenchimento Obrigatório" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></form>
	</body>
</HTML>
