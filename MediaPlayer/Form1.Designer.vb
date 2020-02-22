<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStripPublic = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSet1 = New MediaPlayer.ViewSet()
        Me.ContextMenuStripPublic.SuspendLayout()
        CType(Me.ViewSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStripPublic
        '
        Me.ContextMenuStripPublic.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSettings, Me.MenuVertical, Me.MenuHorizontal, Me.MenuDelete})
        Me.ContextMenuStripPublic.Name = "ContextMenuStripPublic"
        Me.ContextMenuStripPublic.Size = New System.Drawing.Size(123, 92)
        '
        'MenuSettings
        '
        Me.MenuSettings.Name = "MenuSettings"
        Me.MenuSettings.Size = New System.Drawing.Size(122, 22)
        Me.MenuSettings.Text = "設定画面"
        '
        'MenuVertical
        '
        Me.MenuVertical.Name = "MenuVertical"
        Me.MenuVertical.Size = New System.Drawing.Size(122, 22)
        Me.MenuVertical.Text = "左右分割"
        '
        'MenuHorizontal
        '
        Me.MenuHorizontal.Name = "MenuHorizontal"
        Me.MenuHorizontal.Size = New System.Drawing.Size(122, 22)
        Me.MenuHorizontal.Text = "上下分割"
        '
        'MenuDelete
        '
        Me.MenuDelete.Name = "MenuDelete"
        Me.MenuDelete.Size = New System.Drawing.Size(122, 22)
        Me.MenuDelete.Text = "削除"
        '
        'ViewSet1
        '
        Me.ViewSet1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ViewSet1.ContextMenuStrip = Me.ContextMenuStripPublic
        Me.ViewSet1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewSet1.Location = New System.Drawing.Point(0, 0)
        Me.ViewSet1.Name = "ViewSet1"
        Me.ViewSet1.Size = New System.Drawing.Size(429, 204)
        Me.ViewSet1.TabIndex = 1
        Me.ViewSet1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 204)
        Me.Controls.Add(Me.ViewSet1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ContextMenuStripPublic.ResumeLayout(False)
        CType(Me.ViewSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStripPublic As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewSet1 As MediaPlayer.ViewSet

End Class
