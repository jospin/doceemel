<%@ Register TagPrefix="uc1" TagName="MenuPadrao" Src="MenuPadrao.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TelClientes.aspx.vb" Inherits="Celso1.TelClientes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TelClientes</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 96px; POSITION: absolute; TOP: 8px; HEIGHT: 28px"
				borderColor="whitesmoke" cellSpacing="1" cellPadding="1" width="96" border="0">
				<TR>
					<TD>
						<uc1:MenuPadrao id="MenuPadrao1" runat="server"></uc1:MenuPadrao></TD>
				</TR>
			</TABLE>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 106; LEFT: 256px; POSITION: absolute; TOP: 240px"
				runat="server" ForeColor="Black" Font-Size="X-Small" Font-Names="Trebuchet MS" Width="360px"
				AllowPaging="True" PageSize="15" AutoGenerateColumns="False">
				<FooterStyle Font-Size="X-Small" Font-Names="Trebuchet MS" BackColor="#996600"></FooterStyle>
				<SelectedItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS" Font-Bold="True"></SelectedItemStyle>
				<EditItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS"></EditItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS" BackColor="#FFE0C0"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Trebuchet MS" ForeColor="White" BackColor="#996600"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="codTipoTel" HeaderText="C&#243;digo">
						<HeaderStyle Width="1cm"></HeaderStyle>
					</asp:BoundColumn>
					<asp:ButtonColumn Text="Button" DataTextField="tipoTel" SortExpression="Select" HeaderText="Nome"
						CommandName="select">
						<HeaderStyle Width="5cm"></HeaderStyle>
					</asp:ButtonColumn>
				</Columns>
				<PagerStyle Font-Size="X-Small" Font-Names="Trebuchet MS" ForeColor="White" BackColor="#996600"
					Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<TABLE id="Table5" style="Z-INDEX: 107; LEFT: 256px; WIDTH: 320px; POSITION: absolute; TOP: 200px; HEIGHT: 32px"
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
			<TABLE id="Table2" style="FONT-SIZE: x-small; Z-INDEX: 108; LEFT: 264px; COLOR: #996600; FONT-FAMILY: 'Trebuchet MS'; POSITION: absolute; TOP: 128px"
				borderColor="whitesmoke" cellSpacing="1" cellPadding="1" width="300" border="1">
				<TR>
					<TD style="WIDTH: 31px">Código</TD>
					<TD><STRONG>Nome do Tipo&nbsp;
							<asp:RequiredFieldValidator id="rfvNome" runat="server" ErrorMessage="Nome" ControlToValidate="txtTipo">*</asp:RequiredFieldValidator></STRONG></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 31px">
						<asp:textbox id="txtCodTipoTel" runat="server" Font-Size="X-Small" Font-Names="Trebuchet MS"
							Width="40px" Enabled="False"></asp:textbox></TD>
					<TD>
						<asp:textbox id="txtTipo" runat="server" Font-Size="X-Small" Font-Names="Trebuchet MS" Width="272px"></asp:textbox></TD>
				</TR>
			</TABLE>
			<asp:label id="lblSuperior" style="Z-INDEX: 109; LEFT: 352px; POSITION: absolute; TOP: 56px"
				runat="server" ForeColor="#996600" Font-Size="X-Small" Font-Names="Trebuchet MS">Cadastro de Tipo de Telefones</asp:label>
		</form>
	</body>
</HTML>
