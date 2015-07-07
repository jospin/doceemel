Imports System.Data.SqlClient

Public Class Pedidos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents wucSuperior1 As wucSuperior
    Protected WithEvents lblPagina As System.Web.UI.WebControls.Label
    Protected WithEvents wucLateral1 As wucLateral
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents VerificaLogin1 As verificaLogin
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tblPedidos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtCodPedPesq As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataEmissao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodPed As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvDataEmissao As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents drpStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTotalPed As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataLiquidacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvCliente As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents drpCliente As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtObsPed As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkTotalizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkFaturar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkLiquidar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkItens As System.Web.UI.WebControls.LinkButton
    Protected WithEvents drpProduto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPrecoTotal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrecoUnit As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQtd As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkTotItens As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnLimparItens As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluirItem As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvarItem As System.Web.UI.WebControls.Button
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lnkProdClientes As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tblProdClientes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Datagrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidPed As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProd As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lnkCabecalho As System.Web.UI.WebControls.LinkButton
    Protected WithEvents hidTotalPed As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lnkPrint As System.Web.UI.WebControls.LinkButton
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

        Private Function internetIntranet() As String
            'verificando se a URL digitada é da internet ou intranet
            Dim a As String = LCase(Request.Url.Host)
            'If a = "artfixserver" Or a = "localhost" Or a = "celso" Then
            If a = "artfixserver" Or a = "celso" Or a = "localhost" Then
                Return ConfigurationSettings.AppSettings("reportRootURL")
            Else
                Return ConfigurationSettings.AppSettings("reportRootInternet")
            End If
        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Me.btnExcluir.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
            Me.lnkFaturar.Attributes.Add("onclick", "return confirm('Deseja faturar este pedido?');")
            Me.lnkLiquidar.Attributes.Add("onclick", "return confirm('Deseja liquidar este pedido?');")
            Me.btnExcluirItem.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")

        If Not IsPostBack Then

            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
            End If

            If Request("item") <> "" Then
                Me.wucLateral1.selecionarItemLateral = Request("item")
            End If

            CarregaCombo(Me.drpCliente, "Select codCli, razaoSocial From Clientes", "codCli", "razaoSocial", True)
            CarregaCombo(Me.drpProduto, "Select codProd, nomeProd From Produtos", "codProd", "nomeProd", True)
            Me.tblPedidos.Rows(3).Visible = False
            Me.tblProdClientes.Rows(1).Visible = False
        End If
        Me.txtDataEmissao.Attributes.Add("onkeypress", "putdata(this, this.value)")
        Me.txtDataLiquidacao.Attributes.Add("onkeypress", "putdata(this, this.value)")
        End Sub

    Private Sub filtrar()
        strSQL = ""
        If Me.VerificaLogin1.TemPermissao("C") Then
            If Me.txtCodPedPesq.Text <> "" Then
                strSQL = strSQL & " and codPed = " & Me.txtCodPedPesq.Text
            End If

            If Me.drpStatus.SelectedIndex > 0 Then
                strSQL = strSQL & " and status = " & Me.drpStatus.SelectedValue
            End If

            If Me.drpCliente.SelectedIndex > 0 Then
                strSQL = strSQL & " and P.codCli = " & Me.drpCliente.SelectedValue
            End If

            'If Me.drpStatus.SelectedIndex > 0 Then
            '    strSQL = strSQL & " AND CLIENTES.NOME LIKE ''%" & Me.txtNome.Text & "%''"
            'End If

            'If Me.txtcodCliBusca.Text <> "" Then
            '    strSQL = strSQL & " AND CODCLI = " & Me.txtcodCliBusca.Text
            'End If

            'If Me.drpVendedor.SelectedValue <> "" Then
            '    strSQL = strSQL & " AND CLIENTES.CODVEN = " & Me.drpVendedor.SelectedValue
            'End If

            strSQL = strSQL & "'"

            CarregaDataGrid("Exec PrcPedidosClausula '" & strSQL, Me.DataGrid1)
            Me.DataGrid1.CurrentPageIndex = 0
            Session("objPedidos") = Nothing
            Session("objPedidos") = objDataSet
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub carregaDados()
        CarregaDataGrid("Exec PrcPedidos", Me.DataGrid1)
        Session("objPedidos") = Nothing
        Session("objPedidos") = objDataSet
    End Sub

    Private Sub lnkCabecalho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCabecalho.Click
        If Me.tblPedidos.Rows(1).Visible = False Then
            Me.tblPedidos.Rows(1).Visible = True
            Me.lnkCabecalho.Text = "(-) Cabeçalho"
            Me.lnkItens.Text = "(+) Itens"
        Else
            Me.tblPedidos.Rows(1).Visible = False
            Me.lnkCabecalho.Text = "(+) Cabeçalho"
        End If
        Me.tblPedidos.Rows(3).Visible = False
    End Sub

    Private Sub lnkItens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkItens.Click
        If Me.tblPedidos.Rows(3).Visible = False Then
            Me.tblPedidos.Rows(3).Visible = True
            Me.lnkItens.Text = "(-) Itens"
            Me.lnkCabecalho.Text = "(+) Cabeçalho"
        Else
            Me.tblPedidos.Rows(3).Visible = False
            Me.lnkItens.Text = "(+) Itens"
        End If
        Me.tblPedidos.Rows(1).Visible = False
    End Sub

    Private Sub lnkProdClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkProdClientes.Click
        If Me.tblProdClientes.Rows(1).Visible = False Then
            Me.tblProdClientes.Rows(1).Visible = True
            Me.lnkProdClientes.Text = "(-) Produtos do Cliente"
        Else
            Me.tblProdClientes.Rows(1).Visible = False
            Me.lnkProdClientes.Text = "(+) Produtos do Cliente"
        End If
    End Sub

    Private Sub drpProduto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProduto.SelectedIndexChanged
        If Me.VerificaLogin1.TemPermissao("C") Then
            Dim dtProd As DataTable = executaQuery("Select codCatProd From Produtos Where codProd = " & Me.drpProduto.SelectedValue)
            Dim dtCatProd As DataTable = executaQuery("Select preco From CategoriaProduto Where codCatProd = " & dtProd.Rows(0).Item(0))
            Me.txtPrecoUnit.Text = FormatNumber(dtCatProd.Rows(0).Item(0), 2, TriState.True)
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub drpCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCliente.SelectedIndexChanged
        If Me.VerificaLogin1.TemPermissao("C") Then
            If Me.drpCliente.SelectedIndex > 0 Then
                CarregaDataGrid("Exec PrcProdClientes " & Me.drpCliente.SelectedValue, Me.Datagrid3)
                Me.Datagrid3.CurrentPageIndex = 0
                Session("objProdClientes") = Nothing
                Session("objProdClientes") = objDataSet
            End If
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = convData(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String
        Dim valorTotal As String = "0"

        If Me.VerificaLogin1.TemPermissao("I") Then

            If Me.txtTotalPed.Text <> "" Then
                valorTotal = Replace(Me.hidTotalPed.Value, ",", ".")
            End If

            'If Me.drpStatus.SelectedValue = 3 And Me.txtDataLiquidacao.Text = "" Then
            '    exibeMensagem("Para liquidar um pedido, informe a data de liquidação")
            '    Exit Sub
            'End If

            If Me.txtTotalPed.Text = "" And Me.txtCodPed.Text <> "" Then
                exibeMensagem("Favor totalizar o pedido antes de salvar!")
                Exit Sub
            End If

            'Montando a string do sql
            If Me.txtCodPed.Text = "" Then
                strSQL = "Exec PriPedidos " & Me.drpCliente.SelectedValue & ", '" & convData(Me.txtDataEmissao.Text) & "', '" & _
                valorTotal & "', 1, " & " '" & Me.txtObsPed.Text & "'"
                Dim dtPed As DataTable = executaQuery(strSQL)
                Me.txtCodPed.Text = dtPed.Rows(0).Item(0)
            Else
                strSQL = "Exec PraPedidos " & Me.drpCliente.SelectedValue & ", '" & convData(Me.txtDataEmissao.Text) & "', '" & _
                valorTotal & "', " & Me.drpStatus.SelectedValue & ", '" & Me.txtObsPed.Text & "', " & _
                Me.txtCodPed.Text
                Dim dtPed As DataTable = executaQuery(strSQL)
            End If
            Try
                ''Guardando o log
                'strSQL = "Exec Pri_LogAcesso " & Session("codUsu") & ", '" & _
                '            dtLog & "', '" & tmLog & "', 'CADASTROU O VENDEDOR " & Me.txtnomeVend.Text & " NA WEB'"
                'cnPrivateConnection = createConnection()
                ''abrindo a conexão com o banco de dados
                'cnPrivateConnection.Open()
                'ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                'ObjCommand.ExecuteReader()
                'cnPrivateConnection.Close()
                exibeMensagem("Registro salvo com sucesso")
            Catch ex As Exception
                StrMsg = ex.Message
                exibeMensagem(StrMsg)
            End Try
            'Me.limparCamposCabecalho()
            Me.carregaDados()

            'Me.tblPedidos.Rows(1).Visible = False
        'Me.tblPedidos.Rows(3).Visible = True
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub exibeMensagem(ByVal sMsg As String)
        Dim sScriptCode As String = "<script>alert('" & sMsg & "');</script>"
        Try
            MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub limparCamposCabecalho()
        Me.txtCodPed.Text = ""
        Me.txtDataEmissao.Text = ""
        Me.txtDataLiquidacao.Text = ""
        Me.drpStatus.SelectedIndex = -1
        Me.drpCliente.SelectedIndex = -1
        Me.txtTotalPed.Text = ""
        Me.txtObsPed.Text = ""
        Me.habilitarCampos()
        Me.Datagrid2.SelectedIndex = -1
    End Sub

    Private Sub btnSalvarItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvarItem.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = convData(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String
        Dim valorTotal As Single = 0

        If Me.VerificaLogin1.TemPermissao("I") Then
            If Me.txtCodPed.Text = "" Then
                exibeMensagem("Favor salvar o pedido antes de incluir itens!")
                Exit Sub
            End If

            valorTotal = Me.txtQtd.Text * Me.txtPrecoUnit.Text

            'Montando a string do sql
            If Me.hidPed.Value = "" And Me.hidProd.Value = "" Then
                strSQL = "Exec priPedidosProdutos " & Me.txtCodPed.Text & ", " & Me.drpProduto.SelectedValue & ", " & _
                Me.txtQtd.Text & ", " & Replace(Me.txtPrecoUnit.Text, ",", ".") & ", " & Replace(valorTotal, ",", ".")
            Else
                strSQL = "Exec praPedidosProdutos " & Me.txtQtd.Text & ", " & Replace(Me.txtPrecoUnit.Text, ",", ".") & ", " & _
                Replace(valorTotal, ",", ".") & ", " & Me.txtCodPed.Text & ", " & Me.drpProduto.SelectedValue
            End If
            Try
                'criando a conexão com o banco de dados
                Dim cnPrivateConnection As SqlConnection = createConnection()
                'abrindo a conexão com o banco de dados
                cnPrivateConnection.Open()
                ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                ObjCommand.ExecuteReader()
                cnPrivateConnection.Close()
                ''Guardando o log
                'strSQL = "Exec Pri_LogAcesso " & Session("codUsu") &    ", '" & _
                '            dtLog & "', '" & tmLog & "', 'CADASTROU O VENDEDOR " & Me.txtnomeVend.Text & " NA WEB'"
                'cnPrivateConnection = createConnection()
                ''abrindo a conexão com o banco de dados
                'cnPrivateConnection.Open()
                'ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                'ObjCommand.ExecuteReader()
                'cnPrivateConnection.Close()
                exibeMensagem("Registro salvo com sucesso")
                Me.limparCamposItem()
                Me.carregaDadosItens()
                Me.txtTotalPed.Text = ""
            Catch ex As Exception
                If Int(CType(ex, System.Data.SqlClient.SqlException).Number) = 2627 Then
                    exibeMensagem("Não é possível incluir dois itens iguais no pedido!")
                Else
                    StrMsg = ex.Message
                    StrMsg = Replace(StrMsg, "'", "")
                    exibeMensagem(StrMsg)
                End If
            End Try
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub limparCamposItem()
        Me.drpProduto.SelectedIndex = -1
        Me.txtQtd.Text = ""
        Me.txtPrecoUnit.Text = ""
        Me.txtPrecoTotal.Text = ""
        Me.Datagrid3.SelectedIndex = -1
        Me.Datagrid3.DataBind()
    End Sub

    Private Sub carregaDadosItens()
        CarregaDataGrid("Exec PrcPedidosProdutos " & Me.txtCodPed.Text, Me.Datagrid2)
        Session("objPedidosProdutos") = Nothing
        Session("objPedidosProdutos") = objDataSet
    End Sub

    Private Sub DataGrid2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datagrid2.SelectedIndexChanged
        Dim codProd As Integer = IIf(Me.Datagrid3.Items(Me.Datagrid2.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.Datagrid2.Items(Me.Datagrid2.SelectedIndex).Cells(0).Text)
        Dim codPed As Integer = IIf(Me.Datagrid2.Items(Me.Datagrid2.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.Datagrid2.Items(Me.Datagrid2.SelectedIndex).Cells(1).Text)
        Dim dtProdPed As System.Data.DataTable = executaQuery("PrcPedidosProdutos1 " & codPed & ", " & codProd)
        Me.drpProduto.SelectedValue = dtProdPed.Rows(0).Item(4)
        Me.txtQtd.Text = dtProdPed.Rows(0).Item(1)
        Me.txtPrecoUnit.Text = dtProdPed.Rows(0).Item(2)
        Me.txtPrecoTotal.Text = dtProdPed.Rows(0).Item(3)
        Me.hidPed.Value = codPed
        Me.hidProd.Value = codProd
    End Sub

    Private Sub desabilitarCampos()
        Me.txtCodPed.Enabled = False
        Me.txtDataEmissao.Enabled = False
        Me.txtDataLiquidacao.Enabled = False
        'Me.drpStatus.Enabled = False
        Me.drpCliente.Enabled = False
        Me.txtTotalPed.Enabled = False
        Me.txtObsPed.Enabled = False
        Me.btnExcluir.Enabled = False
        Me.btnSalvar.Enabled = False
        Me.drpProduto.Enabled = False
        Me.txtQtd.Enabled = False
        Me.txtPrecoUnit.Enabled = False
        Me.txtPrecoTotal.Enabled = False
        Me.btnSalvarItem.Enabled = False
        Me.btnExcluirItem.Enabled = False
        Me.btnLimparItens.Enabled = False
    End Sub

    Private Sub habilitarCampos()
        'Me.txtCodPed.Enabled = True
        Me.txtDataEmissao.Enabled = True
        Me.txtDataLiquidacao.Enabled = True
        'Me.drpStatus.Enabled = True
        Me.drpCliente.Enabled = True
        Me.txtObsPed.Enabled = True
        Me.btnExcluir.Enabled = True
        Me.btnSalvar.Enabled = True
        Me.drpProduto.Enabled = True
        Me.txtQtd.Enabled = True
        Me.txtPrecoUnit.Enabled = True
        Me.btnSalvarItem.Enabled = True
        Me.btnExcluirItem.Enabled = True
        Me.btnLimparItens.Enabled = True
        Me.txtPrecoTotal.Enabled = True
    End Sub

    Private Sub txtPrecoUnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecoUnit.TextChanged
        If Me.txtPrecoUnit.Text <> "" And Me.txtQtd.Text <> "" Then
            Me.txtPrecoTotal.Text = FormatNumber(Me.txtQtd.Text * Me.txtPrecoUnit.Text, 2, TriState.True)
        End If
    End Sub

    Private Sub txtQtd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtd.TextChanged
        If Me.txtPrecoUnit.Text <> "" And Me.txtQtd.Text <> "" Then
            Me.txtPrecoTotal.Text = FormatNumber(Me.txtQtd.Text * Me.txtPrecoUnit.Text, 2, TriState.True)
        End If
    End Sub

    Private Sub DataGrid3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datagrid3.SelectedIndexChanged
        Dim codProd As Integer = IIf(Me.Datagrid3.Items(Me.Datagrid3.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.Datagrid3.Items(Me.Datagrid3.SelectedIndex).Cells(0).Text)
        Dim codPed As Integer = IIf(Me.Datagrid3.Items(Me.Datagrid3.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.Datagrid3.Items(Me.Datagrid3.SelectedIndex).Cells(1).Text)
        Dim dtProdPed As System.Data.DataTable = executaQuery("PrcPedidosProdutos1 " & codPed & ", " & codProd)
        Me.drpProduto.SelectedValue = dtProdPed.Rows(0).Item(1)
        Me.txtQtd.Text = dtProdPed.Rows(0).Item(2)
        Me.txtPrecoUnit.Text = dtProdPed.Rows(0).Item(3)
        Me.txtPrecoTotal.Text = dtProdPed.Rows(0).Item(4)
        Me.hidPed.Value = codPed
        Me.hidProd.Value = codProd
    End Sub

    Private Sub lnkTotalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkTotalizar.Click
        Dim dtItens As DataTable = executaQuery("Select totalItem from PedidosProdutos Where codPed = " & Me.txtCodPed.Text)
        Dim total As Single = 0
        Dim i As Integer
        If dtItens.Rows.Count <= 0 Then
            exibeMensagem("Não é possível totalizar o pedido sem itens!")
            Exit Sub
        Else
            For i = 0 To dtItens.Rows.Count - 1
                total = total + dtItens.Rows(i).Item(0)
            Next
            Me.txtTotalPed.Text = FormatNumber(total, 2, TriState.True)
            Me.hidTotalPed.Value = total
        End If
        Me.lnkFaturar.Enabled = True
        'Me.tblPedidos.Rows(3).Visible = False
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCamposCabecalho()
        Me.limparCamposItem()
    End Sub

    Private Sub btnLimparItens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimparItens.Click
        Me.limparCamposItem()
    End Sub

    Private Sub DataGrid4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGrid2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid2.PageIndexChanged
        Me.Datagrid2.CurrentPageIndex = e.NewPageIndex
        Me.Datagrid2.DataSource = Session("objPedidosProdutos")
        Me.Datagrid2.DataBind()
        Me.Datagrid2.SelectedIndex = -1
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Me.filtrar()
    End Sub

    Private Sub lnkPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.txtCodPed.Text = "" Then
            exibeMensagem("Selecione um pedido!")
            Exit Sub
        Else
            Response.Write("<script languague=javascript>window.open('" & Me.internetIntranet & "Pedidos&rs:Command=Render&codPed=" & Me.txtCodPed.Text & "','retorno','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,fullscreen=no,resizable=yes,menubar=yes,width=900,height=500');</script>")
        End If
    End Sub

    Private Sub lnkTotItens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkTotItens.Click
        Me.lnkTotalizar_Click(sender, e)
    End Sub

    Private Sub lnkFaturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkFaturar.Click
        Dim strSql As String
        If Me.VerificaLogin1.TemPermissao("F") Then
            strSql = "Update Pedidos Set status = 2 Where codPed = " & Me.txtCodPed.Text
            Dim dtFaturar As DataTable = executaQuery(strSql)
            Me.lnkLiquidar.Visible = True
            Me.desabilitarCampos()
            Me.carregaDados()
            Dim dtFaturado As DataTable = executaQuery("Select status From Pedidos Where codPed = " & Me.txtCodPed.Text)
            Me.drpStatus.SelectedValue = dtFaturado.Rows(0).Item(0)
        Else
            RemeterUsuario("Faturar")
        End If
    End Sub

    Private Sub btnExcluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluirItem.Click
        If Me.hidPed.Value = "" And Me.hidProd.Value = "" Then
            exibeMensagem("Selecione um item para exclusão")
            Exit Sub
        End If

        If Me.VerificaLogin1.TemPermissao("E") Then
            Try
                'criando a conexão com o banco de dados
                Dim cnPrivateConnection As SqlConnection = createConnection()
                strSQL = "Exec PrePedidosProdutos " & Me.hidPed.Value & ", " & Me.hidProd.Value
                cnPrivateConnection = createConnection()
                'abrindo a conexão com o banco de dados
                cnPrivateConnection.Open()
                ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                ObjCommand.ExecuteReader()
                cnPrivateConnection.Close()
            Catch ex As Exception
                Dim StrMsg As String = ex.Message
                exibeMensagem(StrMsg)
            End Try
            exibeMensagem("Exclusão efetuada com sucesso")
            Me.carregaDadosItens()
            Me.limparCamposItem()
        Else
            RemeterUsuario("Excluir")
        End If
    End Sub

    Private Sub lnkLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkLiquidar.Click
        Dim strSql As String
        strSql = "Update Pedidos Set status = 3, dataLiquidacao = '" & convData(DateAndTime.Now) & "' Where codPed = " & Me.txtCodPed.Text
        Dim dtLiquidar As DataTable = executaQuery(strSql)
        Me.lnkLiquidar.Visible = True
        Me.desabilitarCampos()
        Me.carregaDados()
        Dim dtLiquidado As DataTable = executaQuery("Select status, dataLiquidacao From Pedidos Where codPed = " & Me.txtCodPed.Text)
        Me.txtDataLiquidacao.Text = dtLiquidado.Rows(0).Item(1)
        Me.drpStatus.SelectedValue = dtLiquidado.Rows(0).Item(0)
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim codigo As Integer = IIf(Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text)
        Dim dtPed As System.Data.DataTable = executaQuery("PrcPedidosGrid " & codigo)
        Me.limparCamposCabecalho()
        Me.txtCodPed.Text = codigo
        Me.drpCliente.SelectedValue = dtPed.Rows(0).Item(1)
        Me.txtDataEmissao.Text = dtPed.Rows(0).Item(2)
        'Me.txtTotalPed.Text = dtPed.Rows(0).Item(3)
        Me.drpStatus.SelectedValue = dtPed.Rows(0).Item(4)
        Me.txtObsPed.Text = dtPed.Rows(0).Item(5)
        If dtPed.Rows(0).Item(4) = 3 And IsDBNull(dtPed.Rows(0).Item(6)) = False Then
            Me.txtDataLiquidacao.Text = dtPed.Rows(0).Item(6)
        End If

        carregaDadosItens()
        CarregaDataGrid("Exec PrcProdClientes " & Me.drpCliente.SelectedValue, Me.Datagrid3)
        If Me.drpStatus.SelectedValue = 3 Or Me.drpStatus.SelectedValue = 2 Then
            Me.desabilitarCampos()
        Else
            Me.habilitarCampos()
        End If
        Me.hidTotalPed.Value = dtPed.Rows(0).Item(3)
        If dtPed.Rows(0).Item(4) = 2 Then
            Me.lnkLiquidar.Visible = True
        Else
            Me.lnkLiquidar.Visible = False
        End If
        Me.lnkFaturar.Enabled = False

    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If Me.VerificaLogin1.TemPermissao("E") Then
            If Me.txtCodPed.Text = "" Then
                exibeMensagem("Favor selecionar um pedido!")
            Else
                If Me.drpStatus.SelectedValue = 2 Or Me.drpStatus.SelectedValue = 3 Then
                    exibeMensagem("Erro ao excluir pedido!! Somente pedidos pendentes podem ser excluídos!")
                Else
                    Try
                        Dim dtExcluirItens As DataTable = executaScalar("PreProdutosPedidos " & Me.txtCodPed.Text)
                        Dim dtExcluir As DataTable = executaScalar("PrePedidos " & Me.txtCodPed.Text)
                        exibeMensagem("Registro excluído com sucesso!")
                        Me.carregaDados()
                        Me.limparCamposCabecalho()
                        Me.limparCamposItem()
                    Catch ex As Exception
                        exibeMensagem(Replace(ex.Message, "'", ""))
                    End Try
                End If
            End If
        Else
            RemeterUsuario("Excluir")
        End If
    End Sub

    Private Sub txtDataEmissao_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataEmissao.TextChanged
        Me.txtDataEmissao.Text = Me.txtDataEmissao.Text + "2007"
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        Me.DataGrid1.CurrentPageIndex = e.NewPageIndex
        Me.DataGrid1.DataSource = Session("objPedidos")
        Me.DataGrid1.DataBind()
        Me.DataGrid1.SelectedIndex = -1
    End Sub

    Private Sub Datagrid3_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid3.PageIndexChanged
        Me.Datagrid3.CurrentPageIndex = e.NewPageIndex
        Me.Datagrid3.DataSource = Session("objProdClientes")
        Me.Datagrid3.DataBind()
        Me.Datagrid3.SelectedIndex = -1
    End Sub
End Class
