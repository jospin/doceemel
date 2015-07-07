<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Faturamento.aspx.vb" Inherits="Celso1.Faturamento" culture="pt-BR" %>
<%@ Register TagPrefix="uc1" TagName="MenuSuperior" Src="MenuSuperior.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Faturamento</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="FONT-SIZE: x-small; Z-INDEX: 101; LEFT: 8px; WIDTH: 136px; FONT-FAMILY: Arial; POSITION: absolute; TOP: 8px; HEIGHT: 41px"
				cellSpacing="1" cellPadding="1" width="136" border="0">
				<TR>
					<TD><uc1:menusuperior id="MenuSuperior1" runat="server"></uc1:menusuperior></TD>
				</TR>
			</TABLE>
			<TABLE id="tbFaturamento" style="Z-INDEX: 110; LEFT: 160px; POSITION: absolute; TOP: 312px"
				cellSpacing="1" cellPadding="1" width="300" border="0" runat="server">
				<TR>
					<TD bgColor="#f5f5f5"><asp:linkbutton id="lnkFaturamento" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="688px"
							ForeColor="#404040" Font-Bold="True" CausesValidation="False">(+) Faturamento</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="DataGrid1" tabIndex="4" runat="server" Width="688px" AllowPaging="True" PageSize="15"
							ShowFooter="True" ForeColor="#404040" AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" BackColor="#FFFFC0"></SelectedItemStyle>
							<EditItemStyle ForeColor="Black"></EditItemStyle>
							<AlternatingItemStyle Font-Names="Arial" BackColor="White"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Left" ForeColor="Black"
								VerticalAlign="Middle" BackColor="#E0E0E0"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" ForeColor="White" BackColor="DarkCyan"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="DarkCyan"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="codCfo" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="dataemissao" HeaderText="Emiss&#227;o"></asp:BoundColumn>
								<asp:BoundColumn DataField="nome" HeaderText="Cliente"></asp:BoundColumn>
								<asp:BoundColumn DataField="valorliquido" HeaderText="Valor" DataFormatString="{0:C}">
									<HeaderStyle Width="3cm"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="numeromov" HeaderText="Nota Fiscal"></asp:BoundColumn>
								<asp:BoundColumn DataField="codVen2" HeaderText="CodVen2"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="XX-Small" Font-Names="Arial" PageButtonCount="20" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD bgColor="#f5f5f5"><asp:linkbutton id="lnkFatConjunto" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="688px"
							ForeColor="#404040" Font-Bold="True" CausesValidation="False">(+) Faturamento em Conjunto</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="Datagrid2" tabIndex="4" runat="server" Width="688px" AllowPaging="True" PageSize="15"
							ShowFooter="True" ForeColor="#404040" AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" BackColor="#FFFFC0"></SelectedItemStyle>
							<EditItemStyle ForeColor="Black"></EditItemStyle>
							<AlternatingItemStyle Font-Names="Arial" BackColor="White"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Left" ForeColor="Black"
								VerticalAlign="Middle" BackColor="#E0E0E0"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" ForeColor="White" BackColor="DarkCyan"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="DarkCyan"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="codCfo" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="dataemissao" HeaderText="Emiss&#227;o"></asp:BoundColumn>
								<asp:BoundColumn DataField="nome" HeaderText="Cliente"></asp:BoundColumn>
								<asp:BoundColumn DataField="valorliquido" HeaderText="Valor" DataFormatString="{0:C}">
									<HeaderStyle Width="3cm"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="numeromov" HeaderText="Nota Fiscal"></asp:BoundColumn>
								<asp:BoundColumn DataField="codVen2" HeaderText="CodVen2"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="XX-Small" Font-Names="Arial" PageButtonCount="20" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<asp:label id="lblPeriodo" style="Z-INDEX: 108; LEFT: 312px; POSITION: absolute; TOP: 152px"
				runat="server" Font-Names="Arial" Font-Size="X-Small">Período</asp:label><asp:dropdownlist id="drpPeriodo" style="Z-INDEX: 106; LEFT: 312px; POSITION: absolute; TOP: 168px"
				runat="server" Width="272px"></asp:dropdownlist><asp:label id="lblSubMenu" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 47px"
				runat="server" Font-Names="Arial">Faturamento</asp:label><asp:dropdownlist id="drpVendedor" style="Z-INDEX: 103; LEFT: 312px; POSITION: absolute; TOP: 120px"
				runat="server" Width="272px"></asp:dropdownlist><asp:button id="btnFiltrar" style="Z-INDEX: 104; LEFT: 592px; POSITION: absolute; TOP: 136px"
				tabIndex="3" runat="server" Width="80px" Text="Filtrar" Height="40px"></asp:button><asp:label id="lblVendedor" style="Z-INDEX: 107; LEFT: 312px; POSITION: absolute; TOP: 104px"
				runat="server" Font-Names="Arial" Font-Size="X-Small">Vendedor</asp:label>
			<TABLE id="Table2" style="FONT-SIZE: x-small; Z-INDEX: 109; LEFT: 244px; WIDTH: 440px; FONT-FAMILY: Arial; POSITION: absolute; TOP: 200px; HEIGHT: 103px"
				borderColor="gainsboro" cellSpacing="1" cellPadding="1" width="440" border="1">
				<TR>
					<TD style="WIDTH: 108px">Total Faturado</TD>
					<TD>Meta</TD>
					<TD>Percentual da Meta</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 108px; HEIGHT: 13px"><asp:label id="Label1" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="163px"></asp:label></TD>
					<TD style="HEIGHT: 13px"><asp:label id="lblMeta" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="134px"></asp:label></TD>
					<TD style="HEIGHT: 13px"><asp:label id="lblPercMeta" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="133px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 108px">Comissão</TD>
					<TD>Percentual Comissão</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 108px"><asp:label id="lblComissao" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="156px"></asp:label></TD>
					<TD><asp:label id="lblPercentual" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="133px"></asp:label></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
