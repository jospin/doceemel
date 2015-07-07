Imports System.Data.SqlClient

Public Class userInfo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hSessao As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hCommand As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lbUsuario As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents hNavegarPara As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
        If hCommand.Value = "getUser" Then
            lerInformacaoUsuario()
            seguirCaminhoInicial()
        Else
            hSessao.Value = obtemNumeroDeSessao(sender, e)
            Me.Page_Load(sender, e)
        End If
    End Sub

    Private Function seguirCaminhoInicial()
        Dim sUrl As String = Session("CaminhoInicial")
        Session("CaminhoInicial") = ""
        hNavegarPara.Value = sUrl
        Response.Redirect(sUrl)
    End Function

    Private Function obtemNumeroDeSessao(ByVal sender As System.Object, ByVal e As System.EventArgs) As String
        Dim sSession As String = Session.SessionID()
        Dim dtNow As DateTime = Now
        Dim sessao As String
        Dim usuario As String

        sessao = sSession.GetHashCode() & dtNow.GetHashCode()
        Dim dtLogin As DataTable = executaQuery("Insert testeLogin Values ('" & sessao & "', '" & Session("loginUsu") & "')")
        Me.hCommand.Value = "getUser"
        Return sessao
    End Function

    Private Sub lerInformacaoUsuario()
        Dim sWhereClause As String = " where sessao = '" & hSessao.Value & "'"
        Dim sSQL As String = "select usuario from testeLogin " + sWhereClause
        Dim DT As DataTable = FuncoesGenericas.executaQuery(sSQL)

        If DT.Rows.Count > 0 Then
            Session("usuario") = "" & DT.Rows(0)("usuario")
            lbUsuario.Text = Session("usuario")
        End If

        Dim sSqlUsuario As String = "select sLoginUsuario, sNomeDeUsuario from usuario where sLoginUsuario='" & DT.Rows(0)("usuario") & "'"
        ' Dim sSqlUsuario As String = "select login, nomeUsu from Usuarios where login='" & DT.Rows(0)("usuario") & "'"
        Dim dtUser As DataTable = FuncoesGenericas.executaQuery(sSqlUsuario)
        If dtUser.Rows.Count > 0 Then
            Session("nome_usuario") = dtUser.Rows(0)("sLoginUsuario")
        End If
        sSQL = "delete testeLogin " + sWhereClause
        FuncoesGenericas.executaNonQuery(sSQL)
    End Sub
End Class
