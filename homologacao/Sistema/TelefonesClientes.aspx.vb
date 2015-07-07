Imports System.Data.SqlClient

Public Class TelefonesClientes
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Table14 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents drpTipoTel As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents txtNumero As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidCodTipoTel As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodCli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button

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
        If Not IsPostBack Then
            Module1.CarregaComboSort(Me.drpTipoTel, "Select * From TipoTelefone", "codTipoTel", "tipoTel", True, True)
            Me.carregaDados()
        End If
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'variáveis que pegam a data e a hora em que o usuário inclui o vendedor
        Dim dtLog As String = Module1.conv_data(DateAndTime.Now)
        Dim tmLog As String = DateAndTime.TimeString
        'variável que armazena a string do sql
        Dim StrMsg As String

        'Montando a string do sql
        If Me.hidCodTipoTel.Value = "" And Me.hidCodCli.Value = "" Then
            strSQL = "Exec PriTelefonesClientes " & Me.drpTipoTel.SelectedValue & ", " & Session("codCliTel") & ", '" & Me.txtNumero.Text & "'"
        Else
            strSQL = "Exec PraTelefonesClientes " & Me.drpTipoTel.SelectedValue & ", " & Session("codCliTel") & _
            ", '" & Me.txtNumero.Text & "', " & Me.hidCodTipoTel.Value & ", " & Me.hidCodCli.Value
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
            StrMsg = Replace(ex.Message, "'", "")
            exibeMensagem(StrMsg)
        End Try
        Me.limparCampos()
        Me.carregaDados()
    End Sub

    Private Sub carregaDados()
        Carrega_Grid("Exec PrcTelefonesClientes " & Session("codCliTel"), Me.DataGrid2)
        Session("objDataSet1") = Nothing
        Session("objDataSet1") = objDataSet
    End Sub

    Private Sub limparCampos()
        Me.hidCodTipoTel.Value = ""
        Me.hidCodCli.Value = ""
        Me.drpTipoTel.SelectedIndex = -1
        Me.txtNumero.Text = ""
        Me.DataGrid2.SelectedIndex = -1
    End Sub

    Private Sub exibeMensagem(ByVal sMsg As String)
        Dim sScriptCode As String = "<script>alert('" & sMsg & "');</script>"
        Try
            MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGrid2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid2.SelectedIndexChanged
        Dim codigo As Integer = IIf(Me.DataGrid2.Items(Me.DataGrid2.SelectedIndex).Cells(0).Text = "&nbsp;", "", Me.DataGrid2.Items(Me.DataGrid2.SelectedIndex).Cells(0).Text)
        Me.hidCodTipoTel.Value = Me.DataGrid2.Items(Me.DataGrid2.SelectedIndex).Cells(0).Text
        Me.hidCodCli.Value = Me.DataGrid2.Items(Me.DataGrid2.SelectedIndex).Cells(1).Text
        Me.drpTipoTel.SelectedValue = Me.DataGrid2.Items(Me.DataGrid2.SelectedIndex).Cells(0).Text
        Me.txtNumero.Text = Me.DataGrid2.Items(Me.DataGrid2.SelectedIndex).Cells(4).Text
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If Me.hidCodTipoTel.Value = "" And Me.hidCodCli.Value <> "" Then
            exibeMensagem("Selecione um telefone para exclusão")
            Exit Sub
        End If

        Try
            'criando a conexão com o banco de dados
            Dim cnPrivateConnection As SqlConnection = createConnection()
            strSQL = "Exec PreTelefonesClientes " & Me.hidCodTipoTel.Value & ", " & Me.hidCodCli.Value
            cnPrivateConnection = createConnection()
            'abrindo a conexão com o banco de dados
            cnPrivateConnection.Open()
            ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
            ObjCommand.ExecuteReader()
            cnPrivateConnection.Close()
            exibeMensagem("Exclusão efetuada com sucesso")
        Catch ex As Exception
            Dim StrMsg As String = Replace(ex.Message, "'", "")
            exibeMensagem(StrMsg)
        End Try
        Me.carregaDados()
        Me.limparCampos()
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCampos()
    End Sub
End Class
