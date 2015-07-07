Imports System.Data.SqlClient

Public Class TipoTelefone
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
    Protected WithEvents txtCodTipoTel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTipoTel As System.Web.UI.WebControls.TextBox
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
        Me.lblPagina.Text = "Cadastro de Tipo de Telefone"
    End Sub

    Private Sub carregaDados()
        CarregaDataGrid("Exec PrcTipoTelefone", Me.DataGrid1)
        Session("objTipoTelefone") = Nothing
        Session("objTipoTelefone") = objDataSet
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = convData(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String

        'Montando a string do sql
        If Me.txtCodTipoTel.Text = "" Then
            strSQL = "Exec PriTipoTelefone '" & Me.txtTipoTel.Text & "'"
        Else
            strSQL = "Exec PraTipoTelefone '" & Me.txtTipoTel.Text & "', " & Me.txtCodTipoTel.Text
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

    Private Sub limparCampos()
        Me.txtCodTipoTel.Text = ""
        Me.txtTipoTel.Text = ""
        Me.DataGrid1.SelectedIndex = -1
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
            If Me.txtCodTipoTel.Text = "" Then
                exibeMensagem("Selecione um tipo de contato para exclusão")
                Exit Sub
            End If

            Try
                'criando a conexão com o banco de dados
                Dim cnPrivateConnection As SqlConnection = createConnection()
                strSQL = "Exec PreTipoTelefone " & Me.txtCodTipoTel.Text
                cnPrivateConnection = createConnection()
                'abrindo a conexão com o banco de dados
                cnPrivateConnection.Open()
                ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                ObjCommand.ExecuteReader()
                cnPrivateConnection.Close()
                exibeMensagem("Exclusão efetuada com sucesso")
            Catch ex As Exception
                Dim StrMsg As String = Replace(ex.Message, "'", "")
                Dim numberError As String = CType(ex, System.Data.SqlClient.SqlException).Number
                If numberError = 547 Then
                    exibeMensagem("Existem clientes cadastrados com este tipo! Exclusão não permitida")
                Else
                    exibeMensagem(StrMsg)
                End If
            End Try
            Me.carregaDados()
            Me.limparCampos()
        Else
            RemeterUsuario("Excluir")
        End If
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        If Me.VerificaLogin1.TemPermissao("C") Then
            Dim strSql As String = "Exec prcTipoTelefoneClausula ' "
            If Me.txtTipoTel.Text <> "" Then
                strSql = strSql & " and nomeTipo like ''%" & Me.txtTipoTel.Text & "%''"
            End If
            strSql = strSql & "'"
            Me.DataGrid1.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.DataGrid1)
            Session("objTipoTelefone") = Nothing
            Session("objTipoTelefone") = objDataSet
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim codigo As Integer = IIf(Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text)
        Dim dtusu As System.Data.DataTable = executaQuery("Select * from TipoTelefone where codTipoTel = " & codigo)
        Me.txtCodTipoTel.Text = Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text
        Me.txtTipoTel.Text = dtusu.Rows(0).Item(1)
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCampos()
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        Me.DataGrid1.CurrentPageIndex = e.NewPageIndex
        Me.DataGrid1.DataSource = Session("objTipoTelefone")
        Me.DataGrid1.DataBind()
        Me.DataGrid1.SelectedIndex = -1
    End Sub
End Class
