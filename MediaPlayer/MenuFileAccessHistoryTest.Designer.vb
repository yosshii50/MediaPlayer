<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuFileAccessHistoryTest
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
        Me.MenuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLoadSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ContextMenuStripPublic.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStripPublic
        '
        Me.ContextMenuStripPublic.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSave, Me.MenuLoad})
        Me.ContextMenuStripPublic.Name = "ContextMenuStripPublic"
        Me.ContextMenuStripPublic.Size = New System.Drawing.Size(123, 48)
        '
        'MenuSave
        '
        Me.MenuSave.Name = "MenuSave"
        Me.MenuSave.Size = New System.Drawing.Size(152, 22)
        Me.MenuSave.Text = "設定保存"
        '
        'MenuLoad
        '
        Me.MenuLoad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuLoadSelect, Me.ToolStripMenuItem3})
        Me.MenuLoad.Name = "MenuLoad"
        Me.MenuLoad.Size = New System.Drawing.Size(152, 22)
        Me.MenuLoad.Text = "設定読込"
        '
        'MenuLoadSelect
        '
        Me.MenuLoadSelect.Name = "MenuLoadSelect"
        Me.MenuLoadSelect.Size = New System.Drawing.Size(152, 22)
        Me.MenuLoadSelect.Text = "選択"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(149, 6)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(233, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 42)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "履歴読込"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(27, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(191, 179)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "aaa.txt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "bbb.txt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ccc.txt"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(233, 149)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 42)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "履歴保存"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(233, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(144, 42)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "最大値変更"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'MenuFileAccessHistoryTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 203)
        Me.ContextMenuStrip = Me.ContextMenuStripPublic
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "MenuFileAccessHistoryTest"
        Me.Text = "MenuFileAccessHistoryTest"
        Me.ContextMenuStripPublic.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStripPublic As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuLoad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuLoadSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
