Imports System.Data.SqlClient

Public Class CatProduto
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
    Protected WithEvents txtCodCatProd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeCatProd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPreco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObsCatProd As System.Web.UI.WebControls.TextBox
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
        End If
        Me.lblPagina.Text = "Cadastro de Categoria de Produtos"
    End Sub

    Private Sub carregaDados()
        CarregaDataGrid("Exec prcCategoriaProduto", Me.DataGrid1)
        Session("objCatProduto") = Nothing
        Session("objCatProduto") = objDataSet
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
            If Me.txtCodCatProd.Text = "" Then
                exibeMensagem("Selecione uma categoria para exclusão")
                Exit Sub
            End If

            Try
                'criando a conexão com o banco de dados
                Dim cnPrivateConnection As SqlConnection = createConnection()
                strSQL = "Exec PreCategoriaProduto " & Me.txtCodCatProd.Text
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
        Me.txtCodCatProd.Text = ""
        Me.txtNomeCatProd.Text = ""
        Me.txtPreco.Text = ""
        Me.txtObsCatProd.Text = ""
        Me.DataGrid1.SelectedIndex = -1
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim codigo As Integer = IIf(Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text)
        Dim dtusu As System.Data.DataTable = executaQuery("Select * from CategoriaProduto where codCatProd = " & codigo)
        Me.txtCodCatProd.Text = Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text
        Me.txtNomeCatProd.Text = dtusu.Rows(0).Item("nomeCatProd")
        Me.txtPreco.Text = dtusu.Rows(0).Item("preco")
        Me.txtObsCatProd.Text = dtusu.Rows(0).Item("obsCatProd")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = convData(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String

        'Montando a string do sql
        If Me.txtCodCatProd.Text = "" Then
            strSQL = "Exec PriCategoriaProduto '" & Me.txtNomeCatProd.Text & "', " & Replace(Me.txtPreco.Text, ",", ".") & _
            ", '" & Me.txtObsCatProd.Text & "'"
        Else
            strSQL = "Exec PraCategoriaProduto '" & Me.txtNomeCatProd.Text & "', " & Replace(Me.txtPreco.Text, ",", ".") & _
            ", '" & Me.txtObsCatProd.Text & "', " & Me.txtCodCatProd.Text
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
            Dim strSql As String = "Exec prcCatProdutoClausula ' "
            If Me.txtNomeCatProd.Text <> "" Then
                strSql = strSql & " and nomeCatProd like ''%" & Me.txtNomeCatProd.Text & "%''"
            End If

            strSql = strSql & "'"
            Me.DataGrid1.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.DataGrid1)
            Session("objCatProduto") = Nothing
            Session("objCatProduto") = objDataSet
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCampos()
    End Sub


    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        Me.DataGrid1.CurrentPageIndex = e.NewPageIndex
        Me.DataGrid1.DataSource = Session("objCatProduto")
        Me.DataGrid1.DataBind()
        Me.DataGrid1.SelectedIndex = -1
    End Sub
End Class
