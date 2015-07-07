Imports System.Data.SqlClient

Public Class Clientes
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
    Protected WithEvents rfvNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents tblClientes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lnkDadosGerais As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCodCli As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCnpjCpf As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRg As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents drpVendedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents drpCatCliente As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmailGeral As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataCriacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpUsuCriacao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBairro As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lnkContatos As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCodCont As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEMail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtApelido As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeCont As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpTipoCont As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtAniversario As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkProdCli As System.Web.UI.WebControls.LinkButton
    Protected WithEvents drpCatProd As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPrecoSugerido As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidCatProd As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnLimparCont As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluiCont As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvarCont As System.Web.UI.WebControls.Button
    Protected WithEvents btnFindCatProd As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimparCatProd As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluiCatProd As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvarCatProd As System.Web.UI.WebControls.Button
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Datagrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtNumero As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCep As System.Web.UI.WebControls.TextBox
    Protected WithEvents Hidden1 As System.Web.UI.HtmlControls.HtmlInputHidden
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Function expandirRecolher(ByVal expandir As Integer) As Boolean
        Dim i As Integer
        If Me.tblClientes.Rows(expandir).Visible = True Then
            Me.tblClientes.Rows(expandir).Visible = False
            Return True
        Else
            For i = 0 To Me.tblClientes.Rows.Count - 1 Step 1
                If i Mod 2 <> 0 Then
                    If expandir <> i Then
                        Me.tblClientes.Rows(i).Visible = False
                    End If
                End If
            Next
            Me.tblClientes.Rows(expandir).Visible = True
            Return False
        End If
    End Function

    Private Sub limparCamposContato()
        'Contatos
        Me.txtCodCont.Text = ""
        Me.txtNomeCont.Text = ""
        Me.txtApelido.Text = ""
        Me.drpTipoCont.SelectedIndex = -1
        Me.txtTelefone.Text = ""
        Me.txtEMail.Text = ""
        Me.txtAniversario.Text = ""
        Me.DataGrid2.DataBind()
        Me.DataGrid1.SelectedIndex = -1
    End Sub

    Private Sub carregaDadosContato()
        CarregaDataGrid("Exec PrcContato " & Me.txtCodCli.Text, Me.Datagrid2)
        Session("objContatos") = Nothing
        Session("objContatos") = objDataSet
    End Sub

    Private Sub limparCampos()
        'Dados Gerais
        Me.Hidden1.Value = ""
        Me.txtCodCli.Text = ""
        Me.txtRazaoSocial.Text = ""
        Me.txtNomeFantasia.Text = ""
        Me.txtCnpjCpf.Text = ""
        Me.txtRg.Text = ""
        Me.drpVendedor.SelectedIndex = -1
        Me.drpCatCliente.SelectedIndex = -1
        Me.txtSite.Text = ""
        Me.txtEmailGeral.Text = ""
        'Endereco
        Me.txtEndereco.Text = ""
        Me.txtNumero.Text = ""
        Me.txtComplemento.Text = ""
        Me.txtBairro.Text = ""
        Me.txtCidade.Text = ""
        Me.drpEstado.SelectedIndex = -1
        Me.txtCep.Text = ""
        Me.limparCamposContato()
        Me.limparCamposCatProd()
        Me.Datagrid2.DataBind()
        Me.Datagrid3.DataBind()
        'Fechando todas as linhas
        'For i = 0 To Me.tblClientes.Rows.Count - 1
        '    If i Mod 2 <> 0 Then
        '        Me.tblClientes.Rows(i).Visible = False
        '    End If
        'Next
    End Sub

    Private Sub limparCamposCatProd()
        Me.drpCatProd.SelectedIndex = -1
        Me.txtPrecoSugerido.Text = ""
    End Sub

    Private Sub exibeMensagem(ByVal sMsg As String)
        Dim barraInicio As String = "</"
        Dim scr As String = "script"
        Dim barraFim As String = ">"
        Dim sScriptCode As String = "<script>alert('" & sMsg & "');" & barraInicio & scr & barraFim
        Try
            MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub carregaDados()
        CarregaDataGrid("Exec PrcClientes", Me.DataGrid1)
        Session("objClientes") = Nothing
        Session("objClientes") = objDataSet
    End Sub

    Private Sub carregaDadosCatProd()
        CarregaDataGrid("Exec PrcProdClientes " & Me.txtCodCli.Text, Me.Datagrid3)
        Session("objCatProd") = Nothing
        Session("objCatProd") = objDataSet
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnExcluir.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        Me.btnExcluiCont.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        Me.btnExcluiCatProd.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        Me.txtAniversario.Attributes.Add("onkeypress", "putdata(this, this.value)")

        If Not IsPostBack Then
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
            End If

            If Request("item") <> "" Then
                Me.wucLateral1.selecionarItemLateral = Request("item")
            End If

            Dim i As Integer = 0
            For i = 3 To Me.tblClientes.Rows.Count - 1
                If i Mod 2 <> 0 Then
                    Me.tblClientes.Rows(i).Visible = False
                End If
            Next

            Me.lnkDadosGerais.Text = "(-) Dados Gerais"
            Me.txtDataCriacao.Text = Now()
            CarregaCombo(Me.drpVendedor, "Select codVend, nomeVend from Vendedores", "codVend", "nomeVend", True)
            CarregaCombo(Me.drpCatCliente, "Select codCatCli,nomeCatCli from CatCliente", "codCatCli", "nomeCatCli", True)
            CarregaCombo(Me.drpUsuCriacao, "Select idUsuario, sNomeDeUsuario from Usuario", "idUsuario", "sNomedeUsuario", True)
            CarregaCombo(Me.drpTipoCont, "Select codTipoContato, tipo from TipoContato", "codTipoContato", "tipo", True)
            CarregaCombo(Me.drpCatProd, "Select codCatProd, nomeCatProd From CategoriaProduto", "codCatProd", "nomeCatProd", True)
            Me.drpUsuCriacao.SelectedValue = Session("codUsu")
        End If
        Me.lblPagina.Text = "Cadastro de Clientes"
    End Sub

    Private Sub lnkDadosGerais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkDadosGerais.Click
        Dim a As Boolean = Me.expandirRecolher(1)
        If a Then
            Me.lnkDadosGerais.Text = "(+) Dados Gerais"
        Else
            Me.lnkDadosGerais.Text = "(-) Dados Gerais"
            Me.lnkContatos.Text = "(+) Contatos"
            Me.lnkProdCli.Text = "(+) Produtos do Cliente"
        End If
    End Sub

    Private Sub lnkContatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkContatos.Click
        Dim a As Boolean = Me.expandirRecolher(3)
        If a Then
            Me.lnkContatos.Text = "(+) Endereço"
        Else
            Me.lnkDadosGerais.Text = "(+) Dados Gerais"
            Me.lnkContatos.Text = "(-) Contatos"
            Me.lnkProdCli.Text = "(+) Produtos do Cliente"
        End If
    End Sub

    Private Sub lnkProdCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkProdCli.Click
        Dim a As Boolean = Me.expandirRecolher(5)
        If a Then
            Me.lnkProdCli.Text = "(+) Produtos do Cliente"
        Else
            Me.lnkDadosGerais.Text = "(+) Dados Gerais"
            Me.lnkContatos.Text = "(+) Contatos"
            Me.lnkProdCli.Text = "(-) Produtos do Cliente"
        End If
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click

        If Me.VerificaLogin1.TemPermissao("C") Then
            Dim strSql As String = "Exec PrcClientesClausula ' "
            If Me.txtRazaoSocial.Text <> "" Then
                strSql = strSql & " and razaoSocial like ''%" & Me.txtRazaoSocial.Text & "%''"
            End If

            If Me.txtNomeFantasia.Text <> "" Then
                strSql = strSql & " and nomeFantasia like ''%" & Me.txtNomeFantasia.Text & "%''"
            End If

            If Me.txtCnpjCpf.Text <> "" Then
                strSql = strSql & " and cnpjCpf like ''%" & Me.txtCnpjCpf.Text & "%''"
            End If

            If Me.drpVendedor.SelectedIndex <> 0 Then
                strSql = strSql & " and codVend = ''" & Me.drpVendedor.SelectedValue & "''"
            End If

            If Me.drpCatCliente.SelectedIndex <> 0 Then
                strSql = strSql & " and codCatCli = ''" & Me.drpCatCliente.SelectedValue & "''"
            End If

            strSql = strSql & "'"
            Me.DataGrid1.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.DataGrid1)
            Session("objClientes") = Nothing
            Session("objClientes") = objDataSet
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub


    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = convData(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String
        Dim dataCriacao As Date
        dataCriacao = Me.txtDataCriacao.Text

        'Montando a string do sql
        If Me.VerificaLogin1.TemPermissao("I") Then
            If Me.txtCodCli.Text = "" Then
                strSQL = "Exec PriClientes " & Me.drpVendedor.SelectedValue & ", " & Me.drpCatCliente.SelectedValue & ", '" & _
                Me.txtRazaoSocial.Text & "', '" & Me.txtNomeFantasia.Text & "', '" & Me.txtCnpjCpf.Text & "', '" & _
                Me.txtRg.Text & "', '" & Me.txtEndereco.Text & "', '" & Me.txtNumero.Text & "', '" & Me.txtComplemento.Text & "', '" & _
                Me.txtBairro.Text & "', '" & Me.txtCidade.Text & "', '" & UCase(Me.drpEstado.SelectedValue) & "', '" & Me.txtCep.Text & "', '" & _
                convDataHora(dataCriacao) & "', '" & Me.txtSite.Text & "', '" & _
                Me.txtEmailGeral.Text & "', " & Me.drpUsuCriacao.SelectedValue
                Dim dtCliente As DataTable = executaQuery(strSQL)
                Me.Hidden1.Value = dtCliente.Rows(0).Item(0)
                Me.txtCodCli.Text = Me.Hidden1.Value
            Else
                strSQL = "Exec PraClientes " & Me.drpVendedor.SelectedValue & ", " & Me.drpCatCliente.SelectedValue & ", '" & _
                Me.txtRazaoSocial.Text & "', '" & Me.txtNomeFantasia.Text & "', '" & Me.txtCnpjCpf.Text & "', '" & _
                Me.txtRg.Text & "', '" & Me.txtEndereco.Text & "', '" & Me.txtNumero.Text & "', '" & Me.txtComplemento.Text & "', '" & _
                Me.txtBairro.Text & "', '" & Me.txtCidade.Text & "', '" & UCase(Me.drpEstado.SelectedValue) & "', '" & Me.txtCep.Text & "', '" & _
                convDataHora(dataCriacao) & "', '" & Me.txtSite.Text & "', '" & _
                Me.txtEmailGeral.Text & "', " & Me.drpUsuCriacao.SelectedValue & ", " & Me.txtCodCli.Text
                Dim dtCliente As DataTable = executaQuery(strSQL)
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

            Catch ex As Exception
                StrMsg = ex.Message
                exibeMensagem(StrMsg)
            End Try
            exibeMensagem("Registro salvo com sucesso")
            'Me.limparCampos()
            Me.carregaDados()
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCampos()
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        CarregaDataGrid("Exec PrcContato " & Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text, Me.Datagrid2)
        Session("objDataSet2") = Nothing
        Session("objDataSet2") = objDataSet

        Dim codigo As Integer = IIf(Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text)
        Dim dtusu As System.Data.DataTable = executaQuery("Select * from Clientes where codCli = " & codigo)

        'Dados Gerais
        Me.txtCodCli.Text = codigo
        Me.Hidden1.Value = codigo
        Me.txtRazaoSocial.Text = dtusu.Rows(0).Item(3)
        Me.txtNomeFantasia.Text = dtusu.Rows(0).Item(4)
        Me.txtCnpjCpf.Text = dtusu.Rows(0).Item(5)
        Me.txtRg.Text = dtusu.Rows(0).Item(6)
        Me.drpVendedor.SelectedValue = dtusu.Rows(0).Item(1)
        Me.drpCatCliente.SelectedValue = dtusu.Rows(0).Item(2)
        Me.txtSite.Text = dtusu.Rows(0).Item(15)
        Me.txtEmailGeral.Text = dtusu.Rows(0).Item(16)

        'Endereço
        Me.txtEndereco.Text = dtusu.Rows(0).Item(7)
        Me.txtNumero.Text = dtusu.Rows(0).Item(8)
        Me.txtComplemento.Text = dtusu.Rows(0).Item(9)
        Me.txtBairro.Text = dtusu.Rows(0).Item(10)
        Me.txtCidade.Text = dtusu.Rows(0).Item(11)
        Me.drpEstado.SelectedValue = LCase(dtusu.Rows(0).Item(12))
        Me.txtCep.Text = dtusu.Rows(0).Item(13)
        Me.carregaDadosCatProd()
        Me.tblClientes.Rows(1).Visible = True
    End Sub

    Private Sub DataGrid2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datagrid2.SelectedIndexChanged
        Dim codigo As Integer = IIf(Me.Datagrid2.Items(Me.Datagrid2.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.Datagrid2.Items(Me.Datagrid2.SelectedIndex).Cells(0).Text)
        Dim dtusu As System.Data.DataTable = executaQuery("Select * from Contato where codCont = " & codigo)
        Me.txtCodCont.Text = codigo
        Me.txtNomeCont.Text = dtusu.Rows(0).Item(3)
        Me.drpTipoCont.SelectedValue = dtusu.Rows(0).Item(2)
        Me.txtTelefone.Text = dtusu.Rows(0).Item(4)
        Me.txtApelido.Text = dtusu.Rows(0).Item(5)
        Me.txtEMail.Text = dtusu.Rows(0).Item(6)
        If IsDBNull(dtusu.Rows(0).Item(7)) = False Then
            Me.txtAniversario.Text = dtusu.Rows(0).Item(7)
        Else
            Me.txtAniversario.Text = ""
        End If
    End Sub

    Private Sub btnSalvarCatProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvarCatProd.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = convData(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String
        If Me.VerificaLogin1.TemPermissao("I") Then
            If Me.txtCodCli.Text = "" Then
                exibeMensagem("Favor salvar o registro antes de incluir")
                Exit Sub
            End If

            'Montando a string do sql
            If Me.hidCatProd.Value = "" Then
                strSQL = "Exec PriProdClientes " & Me.txtCodCli.Text & ", " & _
                Me.drpCatProd.SelectedValue & ", " & Replace(Me.txtPrecoSugerido.Text, ",", ".")
                Dim dtCatProd As DataTable = executaQuery(strSQL)
            Else

                strSQL = "Exec PraProdClientes " & Me.txtCodCli.Text & ", " & _
                Me.drpCatProd.SelectedValue & ", " & Replace(Me.txtPrecoSugerido.Text, ",", ".")
                Dim dtCatProd As DataTable = executaQuery(strSQL)
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

            Catch ex As Exception
                StrMsg = ex.Message
                exibeMensagem(StrMsg)
            End Try
            Me.carregaDadosCatProd()
            Me.limparCamposCatProd()
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub btnSalvarCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvarCont.Click
        If Me.VerificaLogin1.TemPermissao("I") Then
            Dim niver As String = ""
            If Me.txtAniversario.Text <> "" Then niver = "'" & convData(Me.txtAniversario.Text) & "'" Else niver = "NULL"

            If Me.txtNomeCont.Text <> "" And Me.drpTipoCont.SelectedIndex <> -1 Then
                If Me.txtCodCont.Text = "" Then
                    strSQL = "Exec PriContato " & Me.Hidden1.Value & ", " & Me.drpTipoCont.SelectedValue & ", '" & Me.txtNomeCont.Text & "', '" & _
                    Me.txtTelefone.Text & "', '" & Me.txtApelido.Text & "', '" & Me.txtEMail.Text & "', " & _
                     niver & ",''"
                Else
                    strSQL = "Exec PraContato " & Me.Hidden1.Value & ", " & Me.drpTipoCont.SelectedValue & ", '" & Me.txtNomeCont.Text & "', '" & _
                    Me.txtTelefone.Text & "', '" & Me.txtApelido.Text & "', '" & Me.txtEMail.Text & "', " & _
                    niver & ",'', " & Me.txtCodCont.Text
                End If
                Dim dtContato As DataTable = executaQuery(strSQL)
                Me.carregaDadosContato()
                Me.limparCamposContato()
            End If
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub Datagrid3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datagrid3.SelectedIndexChanged
        Dim strSql As String = "Select * from ProdClientes where codCli = " & _
        Me.Datagrid3.Items(Me.Datagrid3.SelectedIndex).Cells(3).Text & " and codCatProd = " & Me.Datagrid3.Items(Me.Datagrid3.SelectedIndex).Cells(2).Text

        Dim dtCatProd As System.Data.DataTable = executaQuery(strSql)
        Me.drpCatProd.SelectedValue = dtCatProd.Rows(0).Item(1)
        Me.hidCatProd.Value = dtCatProd.Rows(0).Item(1)
        Me.txtPrecoSugerido.Text = dtCatProd.Rows(0).Item(2)
    End Sub

    Private Sub btnExcluiCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluiCont.Click

    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        Me.DataGrid1.CurrentPageIndex = e.NewPageIndex
        Me.DataGrid1.DataSource = Session("objClientes")
        Me.DataGrid1.DataBind()
        Me.DataGrid1.SelectedIndex = -1
    End Sub

    Private Sub Datagrid2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid2.PageIndexChanged
        Me.Datagrid2.CurrentPageIndex = e.NewPageIndex
        Me.Datagrid2.DataSource = Session("objContatos")
        Me.Datagrid2.DataBind()
        Me.Datagrid2.SelectedIndex = -1
    End Sub

    Private Sub Datagrid3_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid3.PageIndexChanged
        Me.Datagrid3.CurrentPageIndex = e.NewPageIndex
        Me.Datagrid3.DataSource = Session("objCatProd")
        Me.Datagrid3.DataBind()
        Me.Datagrid3.SelectedIndex = -1
    End Sub
End Class
