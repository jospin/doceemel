Imports System.Data
Imports System.Data.SqlClient

Public Class verificaLogin
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtPermissao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContextoDeSeguranca As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Property contextoDeSeguranca() As String
        Get
            Return Me.txtContextoDeSeguranca.Text
        End Get
        Set(ByVal Value As String)
            Me.txtContextoDeSeguranca.Text = Value
            If Session("usuario") <> "" Then
                txtPermissao.Text = ObtemPermissoes(Me.txtContextoDeSeguranca.Text, Session("usuario")).ToString
            Else
                Response.Redirect("Inicial.aspx?")
            End If
        End Set
    End Property

    Public Property loginUsuario() As String
        Get
            Return Session("usuario")
        End Get
        Set(ByVal Value As String)
            'Do nothing
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Session("usuario") = "" Then
        '    Session("CaminhoInicial") = Request.Url.ToString
        '    'Response.Redirect("loginFrame.html")
        '    Response.Redirect(Session("CaminhoInicial"))
        'Else
            Dim sRaiz As String
            Dim iDivisor As Integer = Request.Url.AbsolutePath.LastIndexOf("/")
            sRaiz = Request.Url.AbsolutePath.Substring(1, iDivisor - 1)

            Dim pagina As String = Request.Url.AbsolutePath.Substring(iDivisor + 1) 'Replace(LCase(Request.Url.AbsolutePath), sRaiz, "")
            If Me.contextoDeSeguranca.Length = 0 Then
                Me.contextoDeSeguranca = pagina
            End If
        ' End If
    End Sub

    Private Function ObtemPermissoes(ByVal psContexto As String, ByVal psUsuario As String) As String
        Dim strSQL As String = "exec Dbo.prs_PermissaoAcesso '" & psContexto & "', '" & psUsuario & "'"
        Dim DT As DataTable = FuncoesGenericas.executaQuery(strSQL)
        If DT.Rows.Count > 0 Then
            ObtemPermissoes = DT.Rows(0).Item("Permissao")
        Else
            ObtemPermissoes = ""
        End If
    End Function

    Public Function TemPermissao(ByVal item As String) As Boolean
        item = " " & item & " "
        Dim x As String
        If InStr(txtPermissao.Text, item) > 0 Then
            TemPermissao = True
        Else
            TemPermissao = False
        End If
    End Function
End Class
