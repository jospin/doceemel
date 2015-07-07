Imports System.Security.Principal
Imports System.data.SqlClient

Public Class wAuth
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hSession As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hResult As System.Web.UI.HtmlControls.HtmlInputHidden

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
        If User.Identity.IsAuthenticated Then
            Dim sUname As String = "rene"       'User.Identity.Name 'aqui se passa o login do usuário
            Dim sSessionID As String = hSession.Value
            If sSessionID <> "" Then
                Try
                    AbrirDB()
                Catch ex As Exception
                    exibeMensagem("Base de dados não pode ser aberta : " & ex.ToString)
                End Try
                Dim sSQL As String = "insert testeLogin( sessao, usuario) values ( '" & sSessionID & "', '" & sUname & "') "
                Dim cmd As SqlCommand = Cnn.CreateCommand
                cmd.CommandText = sSQL
                cmd.ExecuteNonQuery()
                FecharBD()
                hResult.Value = "OK"
            End If
        Else
            hResult.Value = "notAuthenticated"
            Exit Sub
        End If

    End Sub

    Private Sub btTeste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub exibeMensagem(ByVal sMsg As String)
        Dim sScriptCode As String = "<script>alert('" & sMsg & "');</script>"
        MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)
    End Sub

End Class
