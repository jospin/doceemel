<%@ Control Language="vb" AutoEventWireup="false" Codebehind="MenuPadrao.ascx.vb" Inherits="Celso1.MenuPadrao" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<meta name="vs_showGrid" content="False">
<DIV style="WIDTH: 960px; POSITION: relative; HEIGHT: 576px" ms_positioning="GridLayout">
	<asp:Image id="Image1" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server"
		Height="72px" Width="192px" ImageUrl="images/Doce&amp;melMenor.jpg"></asp:Image>
	<asp:RadioButtonList id="rdoSuperior" style="Z-INDEX: 102; LEFT: 280px; POSITION: absolute; TOP: 72px"
		runat="server" Font-Names="Trebuchet MS" Font-Size="X-Small" ForeColor="#996600" RepeatDirection="Horizontal"
		AutoPostBack="True"></asp:RadioButtonList>
	<asp:Label id="lblSuperior" style="Z-INDEX: 103; LEFT: 360px; POSITION: absolute; TOP: 24px"
		runat="server" Font-Names="Trebuchet MS" Font-Size="X-Small" ForeColor="#996600">Sistema Doce & Mel</asp:Label>
	<asp:RadioButtonList id="rdoLateral" style="Z-INDEX: 104; LEFT: 0px; POSITION: absolute; TOP: 216px"
		runat="server" Font-Names="Trebuchet MS" Font-Size="X-Small" ForeColor="#996600" AutoPostBack="True"></asp:RadioButtonList>
	<asp:Image id="Image2" style="Z-INDEX: 105; LEFT: 264px; POSITION: absolute; TOP: 208px" runat="server"
		Height="120px" Width="312px" ImageUrl="images/Doce&amp;melAgua.jpg"></asp:Image></DIV>
