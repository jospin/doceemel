Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.Page

Module FuncoesGenericas
    Public ObjCommand As SqlCommand
    Public objAdapter As SqlDataAdapter
    Public objDataSet As DataSet
    Public strSQL As String
    Public objDataReader As SqlDataReader
    Public objDataTable As DataTable
    Private _strCnn As String
    Private Cnn As SqlConnection
    Public StrMsg As String
    Public Const Consultar As String = "C"
    Public Const Incluir As String = "I"
    Public Const Alterar As String = "A"
    Public Const Excluir As String = "E"
    Public Const Liberar As String = "L"
    Public Const AlterarParam As String = "P"
    Public Const AlterarPrecoM2 As String = "M"
    Public Const AprovOrcamento As String = "O"
    Public Const AlterarEtapa As String = "T"
    Public Const ReprogramarData As String = "R"

    Public Property strCnn() As String
        Get
            Return _strCnn
        End Get
        Set(ByVal Value As String)
            'do nothing
        End Set
    End Property

    Public Function createConnection() As SqlConnection
        createConnection = New SqlConnection(strCnn)
    End Function

    Sub New()
        _strCnn = ConfigurationSettings.AppSettings("dbPcpArtfix")
        Cnn = New SqlConnection(_strCnn)
    End Sub

    Public Function CreateScriptVar(ByVal sVarName As String, ByVal sVarValue As String) As String
        CreateScriptVar = vbCrLf & "<script language='JavaScript'>" & _
                          vbCrLf & "    " & sVarName & " = '" & sVarValue & "'" & _
                          vbCrLf & "</script>"
    End Function

    Public Function DescSisStatus(ByVal cdStatus As Char) As String
        Select Case cdStatus
            Case "H" : DescSisStatus = "Habilitado"
            Case "D" : DescSisStatus = "Desabilitado"
            Case "N" : DescSisStatus = "Novo"
        End Select
    End Function

    Public Function substituiVazio(ByVal sValorOrigem As String, ByVal sValorAlternativo As String) As String
        Return IIf(sValorOrigem = "", sValorAlternativo, sValorOrigem)
    End Function

    Public Function substituiVazioPorZero(ByVal sValorOrigem As String) As String
        Return IIf(sValorOrigem = "", "0", sValorOrigem)
    End Function

    Public Function substituiZeroPorVazio(ByVal sValorOrigem As String) As String
        Return IIf(sValorOrigem = "0", "", sValorOrigem)
    End Function

    Public Function mensagemDeExcecao(ByVal ex As Exception)
        Dim sMsg As String = ex.ToString
        sMsg = Replace(sMsg, "\", "\\")
        sMsg = Replace(sMsg, vbCrLf, "\n")
        sMsg = Replace(sMsg, vbCr, "\n")
        sMsg = Replace(sMsg, vbLf, "\n")
        sMsg = Replace(sMsg, "'", "\'")
        Return sMsg
    End Function

    Public Sub CarregaDataGrid(ByVal pStrSql As String, ByVal pDataGrid As DataGrid)
        'Instancia a classe SqlConnection
        Dim cnPrivateConnection As SqlConnection = createConnection()
        'Abre a conexão com o Banco
        cnPrivateConnection.Open()
        ' Cria um objeto Command e o passa a consulta SQL para executar
        ObjCommand = New SqlCommand(pStrSql, cnPrivateConnection)
        ' Obtem um DataSet
        objAdapter = New SqlDataAdapter(ObjCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)
        cnPrivateConnection.Close()
        cnPrivateConnection = Nothing
        ' Vincula o datagr
        pDataGrid.DataSource = objDataSet
        pDataGrid.DataBind()
        objAdapter.Dispose()
    End Sub

    Public Function createDataReader(ByVal sSQL As String, ByVal myConnection As SqlConnection) As SqlDataReader
        Dim myCommand As SqlCommand = myConnection.CreateCommand
        myCommand.CommandText = sSQL
        createDataReader = myCommand.ExecuteReader
    End Function

    Public Function executaQuery(ByVal sSQL As String, ByRef DT As DataTable)
        Try
            Dim cnPrivateConnection As SqlConnection = createConnection()
            cnPrivateConnection.Open()
            Dim cmd As SqlCommand = cnPrivateConnection.CreateCommand
            cmd.CommandText = sSQL
            Dim DA As New SqlDataAdapter
            DA.SelectCommand = cmd
            DA.Fill(DT)
            cnPrivateConnection.Close()
            cnPrivateConnection = Nothing
            DA.Dispose()
            Return DT
        Catch ex As Exception
            'Dim x As String = sSQL
            DT.Columns.Add("Exception")
            Dim msg As DataRow
            msg = DT.NewRow
            DT.Rows.Add(msg)
            msg.Item(0) = ex.Message
            Return DT
        End Try
    End Function

    Public Sub executaQuery(ByVal sqlCmd As SqlCommand, ByVal DT As DataTable)
        Dim myDA As New SqlDataAdapter

        If sqlCmd.Connection Is Nothing Then
            sqlCmd.Connection = createConnection()
        End If

        myDA.SelectCommand = sqlCmd
        myDA.Fill(DT)
        sqlCmd.Connection.Close()
        sqlCmd.Dispose()
        myDA.Dispose()
    End Sub

    Public Function executaScalar(ByVal sSQL As String)
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()
        Dim cmd As SqlCommand = cnPrivateConnection.CreateCommand
        cmd.CommandText = sSQL
        executaScalar = cmd.ExecuteScalar
        cnPrivateConnection.Close()
        cnPrivateConnection = Nothing
    End Function

    Public Function executaQuery(ByVal sSQL As String) As DataTable
        Dim DT As New DataTable
        executaQuery(sSQL, DT)
        Return DT
    End Function

    Public Function executaReader(ByVal sSQL As String) As SqlDataReader
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()
        Dim cmd As SqlCommand = cnPrivateConnection.CreateCommand
        cmd.CommandText = sSQL
        executaReader = cmd.ExecuteReader()
        cnPrivateConnection = Nothing
    End Function

    Public Function executaNonQuery(ByVal sSQL As String)
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()
        Dim cmd As SqlCommand = cnPrivateConnection.CreateCommand
        cmd.CommandText = sSQL
        cmd.ExecuteNonQuery()
        cnPrivateConnection.Close()
        cnPrivateConnection = Nothing
    End Function

    Public Sub transfereValoresParametros(ByVal drDados As DataRow, ByVal sqlCmd As SqlCommand)
        Dim oParam As SqlParameter
        For Each oParam In sqlCmd.Parameters
            oParam.Value = drDados.Item(oParam.SourceColumn)
        Next
    End Sub

    Public Function clausulaWhere(ByVal drDados As DataRow) As String
        Dim I As Integer = 0, N As Integer = drDados.ItemArray.Length - 1
        Dim sFormatedValue As String, sFieldName As String
        clausulaWhere = ""
        Dim sSeparador As String = ""
        Dim sIgualdade As String = " = "
        For I = 0 To N
            sFieldName = ""
            sFormatedValue = ""
            sIgualdade = " = "
            If Not IsDBNull(drDados.ItemArray(I)) Then
                sFieldName = drDados.Table.Columns(I).ColumnName
                If Left(drDados.ItemArray(I).GetType.Name, 4) = "Date" Then
                    Dim dtValue As Date = drDados.ItemArray(I)
                    sFormatedValue = "convert(datetime,  '" & dtValue.ToString("yyyy-MM-dd") & "' ,102)"
                ElseIf drDados.ItemArray(I).GetType.Name = "String" Then
                    sFormatedValue = "'%" & drDados.ItemArray(I) & "%'"
                    sIgualdade = " Like "
                ElseIf drDados.ItemArray(I).GetType.Name = "Char" Then
                    sFormatedValue = "'" & drDados.ItemArray(I) & "'"
                ElseIf Left(drDados.ItemArray(I).GetType.Name, 3) = "Int" Then
                    sFormatedValue = drDados.ItemArray(I)
                ElseIf drDados.ItemArray(I).GetType.Name = "Boolean" Then
                    sFormatedValue = IIf(drDados.ItemArray(I), "1", "0")
                Else
                    sFormatedValue = " Tipo não previsto [" & drDados.ItemArray(I).GetType.Name & "]"
                End If
            End If
            If sFieldName.Length > 0 Then
                clausulaWhere += sSeparador + sFieldName + sIgualdade + sFormatedValue
                sSeparador = " and "
            End If
        Next
    End Function

    'Public Sub Habilita(ByVal ctrl As System.Web.UI.WebControls.DropDownList)
    '    ctrl.Enabled = True
    '    Dim sEstiloAtual = ctrl.CssClass
    '    If Left(sEstiloAtual, 6) = "Numero" Then
    '        ctrl.CssClass = "Numero"
    '    Else
    '        ctrl.CssClass = "Texto"
    '    End If
    'End Sub

    'Public Sub Habilita(ByVal ctrl As System.Web.UI.WebControls.TextBox)
    '    ctrl.Enabled = True
    '    Dim sEstiloAtual = ctrl.CssClass
    '    If Left(sEstiloAtual, 6) = "Numero" Then
    '        ctrl.CssClass = "Numero"
    '    Else
    '        ctrl.CssClass = "Texto"
    '    End If
    'End Sub

    Public Sub Habilita(ByVal ctrl As System.Web.UI.WebControls.WebControl)
        ctrl.Enabled = True
        Dim sEstiloAtual = ctrl.CssClass
        If Left(sEstiloAtual, 6) = "Numero" Then
            ctrl.CssClass = "Numero"
        Else
            ctrl.CssClass = "Texto"
        End If
    End Sub

    Public Sub Desabilita(ByVal ctrl As System.Web.UI.WebControls.WebControl)
        ctrl.Enabled = False
        Dim sEstiloAtual = ctrl.CssClass
        If Left(sEstiloAtual, 6) = "Numero" Then
            ctrl.CssClass = "Numero_desab"
        Else
            ctrl.CssClass = "Texto_desab"
        End If
    End Sub


    'Public Sub Desabilita(ByVal ctrl As System.Web.UI.WebControls.DropDownList)
    '    ctrl.Enabled = False
    '    Dim sEstiloAtual = ctrl.CssClass
    '    If Left(sEstiloAtual, 6) = "Numero" Then
    '        ctrl.CssClass = "Numero_desab"
    '    Else
    '        ctrl.CssClass = "Texto_desab"
    '    End If
    'End Sub
    'Public Sub Desabilita(ByVal ctrl As System.Web.UI.WebControls.TextBox)
    '    ctrl.Enabled = False
    '    Dim sEstiloAtual = ctrl.CssClass
    '    If Left(sEstiloAtual, 6) = "Numero" Then
    '        ctrl.CssClass = "Numero_desab"
    '    Else
    '        ctrl.CssClass = "Texto_desab"
    '    End If
    'End Sub

    '*** Funções de Combo
    Public Sub ExcluiItemCombo(ByRef pCombo As DropDownList, ByVal psValor As String)
        pCombo.Items.Remove(pCombo.Items.FindByValue(psValor))
    End Sub

    Public Sub CarregaCombo(ByVal pCombo As DropDownList, ByVal pSQL As String, ByVal ValorCombo As String, ByVal TextoCombo As String, ByVal Linha As Boolean)
        Dim objCommand As SqlCommand
        Dim objAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        Dim objDataRow As DataRow
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()

        ' Cria um objeto Command e o passa a consulta SQL para executar
        objCommand = New SqlCommand(pSQL, cnPrivateConnection)
        ' Obtem um DataSet
        objAdapter = New SqlDataAdapter(objCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)

        pCombo.DataTextField = TextoCombo
        pCombo.DataValueField = ValorCombo

        'Inicio Teste Sort

        objDataSet.Tables(0).DefaultView.Sort = TextoCombo
        pCombo.DataSource = objDataSet.Tables(0).DefaultView()

        'Fim Teste Sort

        ' Vincula o datagrid ao dataset
        'pCombo.DataSource = objDataSet


        Try
            pCombo.DataBind()
        Catch ex As Exception

        End Try

        If Linha = True Then pCombo.Items.Insert(0, "")
        'objConnection.Close()
        cnPrivateConnection.Close()
        cnPrivateConnection = Nothing
    End Sub


    Public Sub CarregaComboSemOrdenacao(ByVal pCombo As DropDownList, ByVal pSQL As String, ByVal ValorCombo As String, ByVal TextoCombo As String, ByVal Linha As Boolean)
        Dim objCommand As SqlCommand
        Dim objAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        Dim objDataRow As DataRow
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()

        ' Cria um objeto Command e o passa a consulta SQL para executar
        objCommand = New SqlCommand(pSQL, cnPrivateConnection)
        ' Obtem um DataSet
        objAdapter = New SqlDataAdapter(objCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)
        pCombo.DataTextField = TextoCombo
        pCombo.DataValueField = ValorCombo

        'Teste Sorte
        'objDataSet.Tables(0).DefaultView.Sort = ValorCombo
        pCombo.DataSource = objDataSet.Tables(0).DefaultView()
        'Fim Teste Sort

        ' Vincula o datagrid ao dataset
        'pCombo.DataSource = objDataSet
        pCombo.DataBind()
        If Linha = True Then pCombo.Items.Insert(0, "")
        'objConnection.Close()
        cnPrivateConnection.Close()
        cnPrivateConnection = Nothing
    End Sub

    Public Sub CarregaListBox(ByVal pList As ListBox, ByVal pSQL As String, ByVal ValorList As String, ByVal TextoList As String)
        Dim objCommand As SqlCommand
        Dim objAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        Dim objDataRow As DataRow
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()

        ' Cria um objeto Command e o passa a consulta SQL para executar
        objCommand = New SqlCommand(pSQL, cnPrivateConnection)
        ' Obtem um DataSet
        objAdapter = New SqlDataAdapter(objCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)




        pList.DataTextField = TextoList
        pList.DataValueField = ValorList

        'Inicio Teste Sort
        objDataSet.Tables(0).DefaultView.Sort = TextoList
        pList.DataSource = objDataSet.Tables(0).DefaultView()

        Try
            pList.DataBind()
        Catch ex As Exception

        End Try

        'objConnection.Close()
        cnPrivateConnection.Close()
        cnPrivateConnection = Nothing
    End Sub

    Public Function convData(ByVal data As Date) As String
        Dim dia As Integer
        Dim mes As Integer
        Dim ano As Integer

        'dia = Microsoft.VisualBasic.Day(data)
        'mes = Microsoft.VisualBasic.Month(data)
        'ano = Microsoft.VisualBasic.Year(data)

        dia = data.Day
        mes = data.Month
        ano = data.Year

        Return ano & "-" & mes & "-" & dia
    End Function

    Public Function convDataHora(ByVal data As DateTime) As String
        Dim dia As Integer
        Dim mes As Integer
        Dim ano As Integer
        Dim time As String

        dia = data.Day
        mes = data.Month
        ano = data.Year
        time = data.Hour & ":" & data.Minute & ":" & data.Second
        Return ano & "-" & mes & "-" & dia & " " & time
    End Function

    Public Function Crypt(ByVal Text As String) As String
        Dim a As String
        Dim strTempChar As String
        Dim i As Integer
        For i = 1 To Len(Text)

            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) + 128
                'a = Mid$(Text, i, 1)
                'a = Asc(Mid$(Text, i, 1))
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) - 128
            End If

            Mid$(Text, i, 1) = Chr(strTempChar)
            a = Chr(strTempChar)
        Next i

        Crypt = Text
    End Function
End Module
