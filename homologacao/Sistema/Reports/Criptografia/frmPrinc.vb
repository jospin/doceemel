Public Class frmPrinc
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnDesdendar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnDesdendar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 8)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(280, 104)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'btnDesdendar
        '
        Me.btnDesdendar.Location = New System.Drawing.Point(8, 120)
        Me.btnDesdendar.Name = "btnDesdendar"
        Me.btnDesdendar.Size = New System.Drawing.Size(280, 23)
        Me.btnDesdendar.TabIndex = 1
        Me.btnDesdendar.Text = "Desvendar"
        '
        'frmPrinc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 150)
        Me.Controls.Add(Me.btnDesdendar)
        Me.Controls.Add(Me.TextBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrinc"
        Me.Text = "frmPrinc"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnDesdendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesdendar.Click
        MsgBox(Module1.Crypt(Me.TextBox1.Text))
    End Sub
End Class
