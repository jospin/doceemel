Imports System.Data.SqlClient
Public Class MatComodato
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblSuperior As System.Web.UI.WebControls.Label
    Protected WithEvents txtnomeMatCom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodMatCom As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDataIni As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQtd As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDataFim As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator

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
        'Put user code to initialize the page here
        btnExcluir.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        If Session("logado") = False Then
            Response.Redirect("inicial.aspx?")
        End If

        If Not IsPostBack Then
            Me.carregaDadosGrid()
        End If
    End Sub

    Private Sub limparCampos()
        Me.txtCodMatCom.Text = ""
        Me.txtnomeMatCom.Text = ""
        Me.txtDataIni.Text = ""
        Me.txtDataFim.Text = ""
        Me.txtQtd.Text = ""
        Me.DataGrid1.SelectedIndex = -1
    End Sub

    Private Sub carregaDadosGrid()
        Carrega_Grid("Exec PrcMatComodato", Me.DataGrid1)
        Session("objDataSet1") = Nothing
        Session("objDataSet1") = objDataSet
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = Module1.conv_data(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String

        'Montando a string do sql
        If Me.txtCodMatCom.Text = "" Then
            strSQL = "Exec priMatComodato '" & Me.txtnomeMatCom.Text & "', " & Me.txtQtd.Text & ", '" & _
            Module1.conv_data(Me.txtDataIni.Text) & "', '" & Module1.conv_data(Me.txtDataFim.Text) & "'"
        Else
            strSQL = "Exec praMatComodato '" & Me.txtnomeMatCom.Text & "', " & Me.txtQtd.Text & ", '" & _
            Module1.conv_data(Me.txtDataIni.Text) & "', '" & Module1.conv_data(Me.txtDataFim.Text) & "', " & _
            Me.txtCodMatCom.Text
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
        Me.carregaDadosGrid()
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

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim codigo As Integer = IIf(Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text)
        Dim dtusu As System.Data.DataTable = Module1.executaQuery("Select codMatCom, nomeMatCom, qtd, convert(varchar,dataIni,103) as dataIni, convert(varchar,dataFim,103) as dataFim from MatComodato where codMatCom = " & codigo)
        Me.txtCodMatCom.Text = Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(0).Text
        Me.txtnomeMatCom.Text = dtusu.Rows(0).Item("nomeMatCom")
        Me.txtQtd.Text = Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(2).Text
        Me.txtDataIni.Text = dtusu.Rows(0).Item("dataIni")
        Me.txtDataFim.Text = dtusu.Rows(0).Item("dataFim")
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCampos()
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If Me.txtCodMatCom.Text = "" Then
            exibeMensagem("Selecione um periodo para exclusão")
            Exit Sub
        End If

        Try
            'criando a conexão com o banco de dados
            Dim cnPrivateConnection As SqlConnection = createConnection()
            strSQL = "Exec PreMatComodato " & Me.txtCodMatCom.Text
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
        Me.carregaDadosGrid()
        Me.limparCampos()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Dim strSql As String = "Exec prcMatComodatoClausula ' "
        If Me.txtnomeMatCom.Text <> "" Then
            strSql = strSql & " and nomeMatCom like  ''%" & Me.txtnomeMatCom.Text & "%''"
        End If

        strSql = strSql & "'"
        Me.DataGrid1.CurrentPageIndex = 0
        Module1.Carrega_Grid(strSql, Me.DataGrid1)
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        Me.DataGrid1.CurrentPageIndex = e.NewPageIndex
        Me.DataGrid1.DataSource = objDataSet
        Me.DataGrid1.DataBind()
        Me.carregaDadosGrid()
    End Sub
End Class
