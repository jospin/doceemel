<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wucLateral.ascx.vb" Inherits="Estoque.wucLateral" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="Styles.css" type="text/css" rel="stylesheet">
<TABLE id="Table1" style="WIDTH: 142px; HEIGHT: 486px" cellSpacing="1" cellPadding="1"
	width="142">
	<TR>
		<TD style="VERTICAL-ALIGN: super; WIDTH: 34px; HEIGHT: 14px" vAlign="top" bgColor="ghostwhite"><asp:datagrid id="DataGrid1" runat="server" Width="136px" AutoGenerateColumns="False" BorderColor="Transparent"
				PageSize="12" ShowHeader="False" BackColor="GhostWhite" Height="119px" CellPadding="4">
				<FooterStyle CssClass="dgFooter"></FooterStyle>
				<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
				<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
				<ItemStyle Font-Size="10pt" ForeColor="#996600" CssClass="dgItem" BackColor="GhostWhite"></ItemStyle>
				<HeaderStyle CssClass="dgHeader"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="codSubMenu" HeaderText="codigo">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:ButtonColumn Text="Select" DataTextField="nomeSubMenu" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn Visible="False" DataField="pagina" HeaderText="pagina"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="codMenuSup" HeaderText="codMenuSup"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
</TABLE>
<asp:textbox id="txtContextoDeSeguranca" runat="server" Width="16px" Visible="False"></asp:textbox>
