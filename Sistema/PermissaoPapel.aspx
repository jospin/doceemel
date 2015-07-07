<%@ Register TagPrefix="uc1" TagName="wucLateral" Src="wucLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucSuperior" Src="wucSuperior.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PermissaoPapel.aspx.vb" Inherits="Estoque.PermissaoPapel" %>
<%@ Register TagPrefix="uc1" TagName="verificaLogin" Src="verificaLogin.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Permissão por Grupo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="clientEventHandlersJS">
		<!--
		function Envia_onclick()
		{ janela=window.open('ConsultaUsuario.aspx','retorno','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,fullscreen=no,resizable=no,menubar=no,width=500,height=500');   
		}//-->
		</script>
	</HEAD>
	<body onload="Confirmar()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblPagina" style="Z-INDEX: 103; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server" CssClass="Label"></asp:label>
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 8px; WIDTH: 256px; POSITION: absolute; TOP: 8px; HEIGHT: 81px"
				cellSpacing="1" cellPadding="1" width="256">
				<TR>
					<TD style="WIDTH: 164px"><uc1:wucsuperior id="WucSuperior1" runat="server"></uc1:wucsuperior></TD>
					<TD style="WIDTH: 158px"><uc1:verificalogin id="VerificaLogin1" runat="server"></uc1:verificalogin></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 164px"><uc1:wuclateral id="WucLateral1" runat="server"></uc1:wuclateral></TD>
					<TD style="WIDTH: 158px"></TD>
				</TR>
			</TABLE>
			</TD>
			<script language="vbscript" src="script\PcpArtfix.vbs"></script>
			<asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 102; LEFT: 32px; POSITION: absolute; TOP: 168px"
				runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary>
			<P>
				<TABLE id="tblCabecalhoContribuinte" style="Z-INDEX: 105; LEFT: 192px; WIDTH: 584px; POSITION: absolute; TOP: 168px; HEIGHT: 340px"
					borderColor="#ffffff" cellSpacing="1" cellPadding="1" width="584" bgColor="#ffffff"
					border="0">
					<TR>
						<TD style="HEIGHT: 43px" vAlign="middle" align="left">
							<TABLE id="tblDadosContribuinte" style="BORDER-RIGHT: #cccccc thin solid; BORDER-TOP: #cccccc thin solid; BORDER-LEFT: #cccccc thin solid; WIDTH: 624px; BORDER-BOTTOM: #cccccc thin solid; HEIGHT: 36px"
								borderColor="#cccccc" cellSpacing="1" cellPadding="1" width="624" border="0">
								<TR>
									<TD class="LabelPesquisa" style="WIDTH: 59px; HEIGHT: 17px" align="right" width="59">Página 
										de Acesso</TD>
									<TD style="WIDTH: 254px; HEIGHT: 17px" vAlign="middle" width="254"><asp:dropdownlist id="drpContexto" runat="server" CssClass="radio" AutoPostBack="True" Width="232px"></asp:dropdownlist><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Selecione o Contexto de Segurança"
											ControlToValidate="drpContexto">*</asp:requiredfieldvalidator></TD>
									<TD style="WIDTH: 41px; HEIGHT: 17px" vAlign="middle" width="41"><asp:label id="Label1" runat="server" CssClass="LabelPesquisa">Papel:</asp:label></TD>
									<TD style="WIDTH: 232px; HEIGHT: 17px" vAlign="middle" width="232"><asp:dropdownlist id="drpPapel" runat="server" CssClass="radio" AutoPostBack="True" Width="244px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 26px" vAlign="middle" align="center">
							<P align="left"><asp:button id="btnGravar" runat="server" CssClass="botao" Width="80px" BorderStyle="Outset"
									Text="Gravar"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:button id="btnLimpar" runat="server" CssClass="botao" Width="80px" BorderStyle="Outset"
									Text="Limpar" CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<INPUT id="txtMensagem" style="WIDTH: 48px; HEIGHT: 22px" type="hidden" size="2" name="txtMensagem"
									runat="server"><INPUT id="txtresposta" style="WIDTH: 48px; HEIGHT: 22px" type="hidden" size="2" name="txtresposta"
									runat="server"><INPUT id="txtcontrole" style="WIDTH: 48px; HEIGHT: 22px" type="hidden" size="2" name="txtcontrole"
									runat="server"></P>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">&nbsp;
							<TABLE id="tblDetalheNF" borderColor="#ffffff" cellSpacing="1" cellPadding="1" width="99%"
								border="0">
								<TR>
									<TD style="HEIGHT: 8px"><STRONG><asp:label id="Label2" runat="server" CssClass="LabelPesquisa" Visible="False">Papéis Atribuidos:</asp:label></STRONG></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="left"><asp:datagrid id="dtgPermissoesContexto" runat="server" Width="595px" PageSize="12" ShowFooter="True"
											AutoGenerateColumns="False" BorderColor="Silver">
											<FooterStyle CssClass="dgFooter"></FooterStyle>
											<SelectedItemStyle CssClass="dgSelectedItem"></SelectedItemStyle>
											<EditItemStyle CssClass="dgEditItem"></EditItemStyle>
											<AlternatingItemStyle CssClass="dgAlternatingItem"></AlternatingItemStyle>
											<ItemStyle ForeColor="DimGray" CssClass="dgItem"></ItemStyle>
											<HeaderStyle CssClass="dgHeader"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="cdContexto" HeaderText="cdContexto"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="cdPermissao" HeaderText="cdPermissao"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="idPapel" HeaderText="idPapel"></asp:BoundColumn>
												<asp:BoundColumn DataField="sNomePermissao" HeaderText="Permiss&#227;o"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="Valor" HeaderText="Valor"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="ValorOrig" HeaderText="Valor Original"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="Operacao" HeaderText="Opera&#231;&#227;o"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Acesso">
													<ItemTemplate>
														<asp:RadioButtonList id=RbPermissao runat="server" CssClass="radio" Width="199px" SelectedIndex='<%# DataBinder.Eval(Container, "DataItem.Valor") %>' RepeatDirection="Horizontal" DataValueField='<%# DataBinder.Eval(Container, "DataItem.Valor") %>'>
															<asp:ListItem Value="0">Permitido</asp:ListItem>
															<asp:ListItem Value="1">N&#227;o Permitido</asp:ListItem>
														</asp:RadioButtonList>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD vAlign="top"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>
