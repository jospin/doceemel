Imports System.Data.SqlClient
Public Class Inicial
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents btnLogar As System.Web.UI.WebControls.Button
    Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidTentativas As System.Web.UI.HtmlControls.HtmlInputHidden

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
            Session("codUsu") = ""
            Session("nomeUsu") = ""
            Session("loginUsu") = ""
            Session("usuario") = ""
            Me.hidTentativas.Value = 0
        End If
    End Sub

    Private Sub btnLogar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogar.Click
        Me.logar()
    End Sub

    Public Sub logar()
        Dim data As String = DateString()
        Dim hora As String = Format(Now, "t")
        Dim sucesso As Boolean = False

        Dim dtusu As System.Data.DataTable = executaQuery _
        ("Select * from Usuario where sLoginUsuario = '" & Me.txtUsuario.Text & "'")
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()
        While sucesso = False
            If dtusu.Rows.Count = 0 Then
                Me.exibeMensagem("Usuário Inválido!")
                hidTentativas.Value += 1
                If hidTentativas.Value >= 3 Then
                    strSQL = "Exec PriLogSistema '" & Me.txtUsuario.Text & "', 'Login', '" & _
                    data & " " & hora & "', 'Tentativa de logar mais de 3 vezes'"
                    ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                    ObjCommand.ExecuteReader()
                    Response.Redirect("Deny.aspx?")
                    Exit Sub
                End If
                Exit Sub
            End If
            If Me.txtSenha.Text = Crypt(dtusu.Rows(0).Item("senha")) Then
                sucesso = True
                Session("codUsu") = dtusu.Rows(0).Item("idUsuario")
                Session("nomeUsu") = dtusu.Rows(0).Item("sNomeDeUsuario")
                Session("loginUsu") = dtusu.Rows(0).Item("sLoginUsuario")
                Session("usuario") = dtusu.Rows(0).Item("sLoginUsuario")
                'Nivel: 1 - Administrador // 2 - Usuário
                'Session("nivel") = dtusu.Rows(0).Item("nivel")
                'Module1.UsuLog = dtusu.Rows(0).Item("nomeUsu")
                strSQL = "Exec PriLogSistema '" & Me.txtUsuario.Text & "', 'Login', '" & _
                data & " " & hora & "', 'Usuário " & Session("nomeUsu") & " logou no Sistema'"
                Try
                    ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                    ObjCommand.ExecuteReader()
                Catch ex As Exception
                    StrMsg = ex.Message
                End Try
                Session("logado") = True
                Response.Redirect("Principal.aspx?")
            Else
                sucesso = False
                hidTentativas.Value += 1
                Me.exibeMensagem("Usuário Inválido!")
                If hidTentativas.Value >= 3 Then Response.Redirect("Deny.aspx?")
                Exit Sub
            End If
        End While
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
End Class
