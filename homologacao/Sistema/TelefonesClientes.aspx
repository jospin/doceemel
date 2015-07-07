<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TelefonesClientes.aspx.vb" Inherits="Celso1.TelefonesClientes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TelefonesClientes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table14" style="FONT-SIZE: x-small; Z-INDEX: 100; LEFT: 32px; WIDTH: 152px; COLOR: #996600; FONT-FAMILY: 'Trebuchet MS'; POSITION: absolute; TOP: 80px; HEIGHT: 40px"
				borderColor="whitesmoke" cellSpacing="1" cellPadding="1" width="152" border="1" runat="server">
				<TR>
					<TD style="WIDTH: 63px">Tipo</TD>
					<TD style="WIDTH: 63px">Número</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 63px">
						<asp:DropDownList id="drpTipoTel" runat="server" Width="128px" ForeColor="#996600" Font-Size="X-Small"
							Font-Names="Trebuchet MS"></asp:DropDownList></TD>
					<TD style="WIDTH: 63px">
						<asp:textbox id="txtNumero" tabIndex="1" runat="server" Width="144px" Font-Size="X-Small" Font-Names="Trebuchet MS"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 63px" colSpan="2">
						<asp:DataGrid id="DataGrid2" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
							Width="272px" ForeColor="Black" Font-Size="X-Small" Font-Names="Trebuchet MS">
							<FooterStyle Font-Size="X-Small" Font-Names="Trebuchet MS" BackColor="#996600"></FooterStyle>
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS" Font-Bold="True"></SelectedItemStyle>
							<EditItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS"></EditItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS" BackColor="#FFE0C0"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Trebuchet MS"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Trebuchet MS" ForeColor="White" BackColor="#996600"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="codTipoTel" HeaderText="C&#243;dTipoTel"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="codcli" HeaderText="CodCli"></asp:BoundColumn>
								<asp:BoundColumn DataField="tipoTel" HeaderText="Tipo">
									<HeaderStyle Width="1cm"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Button" DataTextField="numTel" SortExpression="Select" HeaderText="N&#250;mero"
									CommandName="select">
									<HeaderStyle Width="5cm"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="numtel" HeaderText="Numero"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Trebuchet MS" ForeColor="White" BackColor="#996600"
								Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
					<TD style="WIDTH: 63px" colSpan="2"></TD>
				</TR>
			</TABLE>
			<asp:button id="btnLimpar" style="Z-INDEX: 106; LEFT: 200px; POSITION: absolute; TOP: 48px"
				tabIndex="5" runat="server" Width="72px" Text="Limpar" CausesValidation="False"></asp:button>
			<INPUT id="hidCodCli" style="Z-INDEX: 105; LEFT: 56px; WIDTH: 48px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="2" name="Hidden1" runat="server">
			<asp:button id="btnSalvar" tabIndex="4" runat="server" Width="72px" Text="Salvar" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 48px"></asp:button>
			<asp:button id="btnExcluir" tabIndex="5" runat="server" Width="72px" Text="Excluir" CausesValidation="False"
				style="Z-INDEX: 103; LEFT: 120px; POSITION: absolute; TOP: 48px"></asp:button><INPUT id="hidCodTipoTel" style="Z-INDEX: 104; LEFT: 8px; WIDTH: 48px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="2" name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
