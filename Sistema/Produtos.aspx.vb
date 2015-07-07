Imports System.Data.SqlClient

Public Class Produtos
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
    Protected WithEvents txtCodProd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeProd As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpCodCatProd As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtQtdEstoque As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObs As System.Web.UI.WebControls.TextBox
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnExcluir.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        If Not IsPostBack Then
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
            End If

            If Request("item") <> "" Then
                Me.wucLateral1.selecionarItemLateral = Request("item")
            End If
                CarregaCombo(Me.drpCodCatProd, "Select codCatProd, nomeCatProd From CategoriaProduto", "codCatProd", "nomeCatProd", True)
        End If
        Me.lblPagina.Text = "Cadastro de Produtos"
    End Sub

    Private Sub carregaDados()
        CarregaDataGrid("Exec PrcProdutos", Me.DataGrid1)
        Session("objProdutos") = Nothing
        Session("objProdutos") = objDataSet
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

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If Me.VerificaLogin1.TemPermissao("E") Then
            If Me.txtCodProd.Text = "" Then
                exibeMensagem("Selecione uma categoria para exclusão")
                Exit Sub
            End If

            Try
                'criando a conexão com o banco de dados
                Dim cnPrivateConnection As SqlConnection = createConnection()
                strSQL = "Exec PreProdutos " & Me.txtCodProd.Text
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
            Me.carregaDados()
            Me.limparCampos()
        Else
            RemeterUsuario("Excluir")
        End If
    End Sub

    Private Sub limparCampos()
        Me.txtCodProd.Text = ""
        Me.txtNomeProd.Text = ""
        Me.txtQtdEstoque.Text = ""
        Me.txtObs.Text = ""
        Me.drpCodCatProd.SelectedIndex = -1
        Me.DataGrid1.SelectedIndex = -1
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim codigo As Integer = IIf(Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text)
        Dim dtusu As System.Data.DataTable = executaQuery("Select * from Produtos where codProd = " & codigo)
        Me.txtCodProd.Text = Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text
        Me.txtNomeProd.Text = dtusu.Rows(0).Item("nomeProd")
        Me.txtQtdEstoque.Text = dtusu.Rows(0).Item("qtdEstoque")
        Me.txtObs.Text = dtusu.Rows(0).Item("obs")
        Me.drpCodCatProd.SelectedValue = dtusu.Rows(0).Item("codCatProd")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = convData(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String

        'Montando a string do sql
        If Me.txtCodProd.Text = "" Then
            strSQL = "Exec PriProdutos " & Me.drpCodCatProd.SelectedValue & ", '" & Me.txtNomeProd.Text & "', '" & _
            Me.txtQtdEstoque.Text & "', '" & Me.txtObs.Text & "'"
        Else
            strSQL = "Exec PraProdutos " & Me.drpCodCatProd.SelectedValue & ", '" & Me.txtNomeProd.Text & "', '" & _
            Me.txtQtdEstoque.Text & "', '" & Me.txtObs.Text & "', " & Me.txtCodProd.Text
        End If
        If Me.VerificaLogin1.TemPermissao("I") Then
            Try
                'criando a conexão com o banco de dados
                Dim cnPrivateConnection As SqlConnection = createConnection()
                'abrindo a conexão com o banco de dados
                cnPrivateConnection.Open()
                ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                ObjCommand.ExecuteReader()
                cnPrivateConnection.Close()
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
            Me.limparCampos()
            Me.carregaDados()
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        If Me.VerificaLogin1.TemPermissao("C") Then
            Dim strSql As String = "Exec PrcProdutosClausula ' "
            If Me.txtNomeProd.Text <> "" Then
                strSql = strSql & " and nomeProd like ''%" & Me.txtNomeProd.Text & "%''"
            End If

            If Me.drpCodCatProd.SelectedIndex > 0 Then
                strSql = strSql & " and codCatProd = ''" & Me.drpCodCatProd.SelectedValue & "''"
            End If

            strSql = strSql & "'"
            Me.DataGrid1.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.DataGrid1)
            Session("objProdutos") = Nothing
            Session("objProdutos") = objDataSet
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCampos()
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        Me.DataGrid1.CurrentPageIndex = e.NewPageIndex
        Me.DataGrid1.DataSource = Session("objProdutos")
        Me.DataGrid1.DataBind()
        Me.carregaDados()
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub
End Class
