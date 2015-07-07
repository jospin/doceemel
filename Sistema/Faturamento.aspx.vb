Public Class Faturamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblSubMenu As System.Web.UI.WebControls.Label
    Protected WithEvents drpVendedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnFiltrar As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents drpPeriodo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblVendedor As System.Web.UI.WebControls.Label
    Protected WithEvents lblPeriodo As System.Web.UI.WebControls.Label
    Protected WithEvents lblComissao As System.Web.UI.WebControls.Label
    Protected WithEvents lblMeta As System.Web.UI.WebControls.Label
    Protected WithEvents lblPercentual As System.Web.UI.WebControls.Label
    Protected WithEvents lblPercMeta As System.Web.UI.WebControls.Label
    Protected WithEvents lnkFaturamento As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkFatConjunto As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Table3 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tbFaturamento As System.Web.UI.HtmlControls.HtmlTable

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
        Dim i As Integer
        If Session("logado") = False Then
            Response.Redirect("Login.aspx?")
        End If
        If Not IsPostBack Then
            If Session("nivel") = 0 Then
                Module1.CarregaCombo(Me.drpVendedor, "Select * from Vendedores Where ativo = 1 and intext in (1,2)", "codRm", "Nome", True, True)
            Else
                Me.drpVendedor.Visible = False
            End If
            CarregaCombo(Me.drpPeriodo, "select idPeriodo, convert(varchar(10),inicio,103) + ' a ' + convert(varchar(10),final,103) as periodo from Periodo order by periodo.inicio, final", "idPeriodo", "periodo", True, False)
            For i = 0 To Me.tbFaturamento.Rows.Count
                If i Mod 2 <> 0 Then
                    Me.tbFaturamento.Rows(i).Visible = False
                End If
            Next
            'Me.txtDtIni.Text = dataInicioFat()
            'Me.txtDtFim.Text = dataFinalFat()
        End If 'Put user code to initialize the page here
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        Me.DataGrid1.CurrentPageIndex = e.NewPageIndex
        Me.DataGrid1.DataSource = objDataSet
        Me.DataGrid1.DataBind()
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

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        If Session("nivel") = 0 Then
            If Me.drpVendedor.SelectedIndex <= 0 Then
                exibeMensagem("Selecione um vendedor")
                Exit Sub
            End If
        End If

        Me.Label1.Text = ""
        Me.lblComissao.Text = ""
        Me.lblMeta.Text = ""
        Me.lblPercentual.Text = ""
        Me.lblPercMeta.Text = ""
        Me.lblPeriodo.Text = ""

        If Me.drpPeriodo.SelectedIndex <= 0 Then
            exibeMensagem("Selecione um periodo")
            Exit Sub
        End If
        Dim dtPer As DataTable = Module1.executaQuery("Select inicio, final From Periodo Where idPeriodo = " & Me.drpPeriodo.SelectedValue)
        Dim dtIni As Date = dtPer.Rows(0).Item(0)
        Dim dtFim As Date = dtPer.Rows(0).Item(1)
        Dim dtini1 As String = conv_data(dtIni)
        Dim dtfim1 As String = conv_data(dtFim)
        Dim dtVend As DataTable
        Dim codRm As System.Data.DataTable = _
        Module1.executaQuery("Select codRm from Vendedores Where codVen = " & Session("CodVen"))

        If Session("nivel") = 0 Then
            Carrega_Grid("Exec corpore.dbo.rel_com " & Me.drpVendedor.SelectedValue & _
            ", '" & conv_data(dtini1) & "', '" & conv_data(dtfim1) & "'", Me.DataGrid1)
            Carrega_Grid("Exec corpore.dbo.rel_com_2 " & Me.drpVendedor.SelectedValue & _
            ", '" & conv_data(dtini1) & "', '" & conv_data(dtfim1) & "'", Me.Datagrid2)
        Else
            Carrega_Grid("Exec corpore.dbo.rel_com " & codRm.Rows(0).Item(0) & _
            ", '" & conv_data(dtini1) & "', '" & conv_data(dtfim1) & "'", Me.DataGrid1)
            Carrega_Grid("Exec corpore.dbo.rel_com_2 " & codRm.Rows(0).Item(0) & _
            ", '" & conv_data(dtini1) & "', '" & conv_data(dtfim1) & "'", Me.Datagrid2)
        End If

        Session("objDataSet1") = Nothing
        Session("objDataSet1") = objDataSet
        Dim dt1 As System.Data.DataTable

        If Session("nivel") = 0 Then
            dt1 = Module1.executaQuery("Exec corpore.dbo.rel_com " & Me.drpVendedor.SelectedValue & _
             ", '" & conv_data(dtini1) & "', '" & conv_data(dtfim1) & "'")
        Else
            dt1 = Module1.executaQuery("Exec corpore.dbo.rel_com " & codRm.Rows(0).Item(0) & _
            ", '" & conv_data(dtini1) & "', '" & conv_data(dtfim1) & "'")
        End If

        Dim i As Integer = 0
        Dim valor As Single = 0
        For i = 0 To dt1.Rows.Count - 1 Step 1
            valor = valor + dt1.Rows(i).Item("valorliquido")
        Next
        'exibindo o total de faturamento
        Me.Label1.Text = "R$ " & FormatNumber(valor, 2, TriState.True)

        'Fazer verificação de erro
        If Session("nivel") = 0 Then
            dtVend = Module1.executaQuery("Select codVen, intext From Vendedores Where codRm = " & Me.drpVendedor.SelectedValue)
            'Fazer verificação de erro
        Else
            dtVend = Module1.executaQuery("Select codVen, intext From Vendedores Where codVen = " & Session("codVen"))
        End If
        Dim dtMeta As DataTable = Module1.executaQuery("Select valor, idComissao from Metas Where codVen = " & _
        dtVend.Rows(0).Item(0) & " and idperiodo = " & Me.drpPeriodo.SelectedValue)

        'Fazer verificação de erro
        If dtMeta.Rows.Count <= 0 Then
            exibeMensagem("Nao existe meta cadastrada para este vendedor. Entre em Cadastros>Metas para calcular a comissao")
            Exit Sub
        End If
        Dim percentual As Single = (valor / dtMeta.Rows(0).Item(0)) * 100

        'Fazer verificação de erro
        'mudar para Select Case
        Select Case dtVend.Rows(0).Item(1)
            Case Is = 1  'interno
                Dim dtPerc As DataTable = Module1.executaQuery("Select percentual From Faixas Where idComissao = " & dtMeta.Rows(0).Item(1))
                Me.lblComissao.Text = "R$ " & FormatNumber((valor * dtPerc.Rows(0).Item(0)) / 100, 2, TriState.True)
                Me.lblPercentual.Text = dtPerc.Rows(0).Item(0)
            Case Is = 2  'externo
                'Fazer verificação de erro
                Dim dtPerc As DataTable = Module1.executaQuery("Select metaIni, metaFim, percentual From Faixas Where idComissao = " & dtMeta.Rows(0).Item(1))
                If dtperc.Rows.Count <= 0 Then
                    exibeMensagem("Nao existem faixas cadastradas")
                    Exit Sub
                End If
                If dtperc.Rows.Count > 1 Then
                    For i = 0 To dtPerc.Rows.Count - 1
                        If percentual >= dtPerc.Rows(i).Item(0) And percentual <= dtPerc.Rows(i).Item(1) Then
                            Me.lblComissao.Text = "R$ " & FormatNumber((valor * dtPerc.Rows(i).Item(2)) / 100, 2, TriState.True)
                            Me.lblPercentual.Text = dtPerc.Rows(i).Item(2)
                        End If
                    Next
                Else
                    dtPerc = Module1.executaQuery("Select percentual From Faixas Where idComissao = " & dtMeta.Rows(0).Item(1))
                    Me.lblComissao.Text = "R$ " & FormatNumber((valor * dtPerc.Rows(0).Item(0)) / 100, 2, TriState.True)
                    Me.lblPercentual.Text = dtPerc.Rows(0).Item(0)
                End If

            Case Is = 7
                    Dim dtPerc As DataTable = Module1.executaQuery("Select percentual From Faixas Where idComissao = " & dtMeta.Rows(0).Item(1))
                    Me.lblComissao.Text = "R$ " & FormatNumber((valor * dtPerc.Rows(0).Item(0)) / 100, 2, TriState.True)
                    Me.lblPercentual.Text = dtPerc.Rows(0).Item(0)
        End Select
        Me.lblMeta.Text = "R$ " & FormatNumber(dtMeta.Rows(0).Item(0), 2, TriState.True)
        Me.lblPercMeta.Text = FormatNumber(percentual, 2, TriState.True)
    End Sub

    Private Sub lnkFaturamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkFaturamento.Click
        If Me.tbFaturamento.Rows(1).Visible = False Then
            Me.tbFaturamento.Rows(1).Visible = True
            Me.lnkFaturamento.Text = "(-) Faturamento"
        Else
            Me.tbFaturamento.Rows(1).Visible = False
            Me.lnkFaturamento.Text = "(+) Faturamento"
        End If
    End Sub

    Private Sub lnkFatConjunto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkFatConjunto.Click
        If Me.tbFaturamento.Rows(3).Visible = False Then
            Me.tbFaturamento.Rows(3).Visible = True
            Me.lnkFatConjunto.Text = "(-) Faturamento em Conjunto"
        Else
            Me.tbFaturamento.Rows(3).Visible = False
            Me.lnkFatConjunto.Text = "(+) Faturamento em Conjunto"
        End If
    End Sub
End Class
