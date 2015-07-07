Public Class Relatorios
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
    Protected WithEvents lnkUsuEmail As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkRelMaquinasIP As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkMaquinas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkHubSw As System.Web.UI.WebControls.LinkButton
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Function internetIntranet() As String
        'verificando se a URL digitada é da internet ou intranet
        Dim a As String = LCase(Request.Url.Host)
        If a = "artfixserver" Or a = "celso" Or a = "localhost" Or a = "notecelso" Then
            Return ConfigurationSettings.AppSettings("reportRootURLIntranet")
        Else
            Return ConfigurationSettings.AppSettings("reportRootURLInternet")
        End If
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
            End If

            If Request("item") <> "" Then
                Me.wucLateral1.selecionarItemLateral = Request("item")
            End If
            'Me.carregaDadosGrid()
        End If
        Me.lblPagina.Text = "Relatórios"
    End Sub

    Private Sub lnkUsuEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkUsuEmail.Click
        If Me.VerificaLogin1.TemPermissao("C") Then
            Response.Write("<script languague=javascript>window.open('" & Me.internetIntranet & "UsuariosEMail','retorno','toolbar=no,location=yes,directories=no,status=no,menubar=no,scrollbars=yes,fullscreen=no,resizable=yes,menubar=yes,width=900,height=500');</script>")
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub lnkRelMaquinasIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkRelMaquinasIP.Click
        If Me.VerificaLogin1.TemPermissao("C") Then
            Response.Write("<script languague=javascript>window.open('" & Me.internetIntranet & "RelacaoDeMaquinas1','retorno','toolbar=no,location=yes,directories=no,status=no,menubar=no,scrollbars=yes,fullscreen=no,resizable=yes,menubar=yes,width=900,height=500');</script>")
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub lnkMaquinas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkMaquinas.Click
        If Me.VerificaLogin1.TemPermissao("C") Then
            Response.Write("<script languague=javascript>window.open('" & Me.internetIntranet & "RelacaoComputadores','retorno','toolbar=no,location=yes,directories=no,status=no,menubar=no,scrollbars=yes,fullscreen=no,resizable=yes,menubar=yes,width=900,height=500');</script>")
        Else
            RemeterUsuario("Incluir")
        End If
    End Sub

    Private Sub lnkHubSw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkHubSw.Click
        If Me.VerificaLogin1.TemPermissao("C") Then
            Response.Write("<script languague=javascript>window.open('" & Me.internetIntranet & "Hubs e Switches','retorno','toolbar=no,location=yes,directories=no,status=no,menubar=no,scrollbars=yes,fullscreen=no,resizable=yes,menubar=yes,width=900,height=500');</script>")
        Else
            RemeterUsuario("Incluir")
        End If

    End Sub
End Class
