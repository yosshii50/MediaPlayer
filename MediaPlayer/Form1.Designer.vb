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
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuMaxView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLoadSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuHelpVersionInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSet1 = New MediaPlayer.ViewSet()
        Me.ContextMenuStripPublic.SuspendLayout()
        CType(Me.ViewSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStripPublic
        '
        Me.ContextMenuStripPublic.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSettings, Me.MenuVertical, Me.MenuHorizontal, Me.MenuDelete, Me.ToolStripMenuItem1, Me.MenuMaxView, Me.MenuSp, Me.ToolStripMenuItem2, Me.MenuSave, Me.MenuLoad, Me.MenuNew, Me.ToolStripMenuItem4, Me.MenuHelp, Me.MenuExit})
        Me.ContextMenuStripPublic.Name = "ContextMenuStripPublic"
        Me.ContextMenuStripPublic.Size = New System.Drawing.Size(123, 264)
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
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(119, 6)
        '
        'MenuMaxView
        '
        Me.MenuMaxView.Name = "MenuMaxView"
        Me.MenuMaxView.Size = New System.Drawing.Size(122, 22)
        Me.MenuMaxView.Text = "最大表示"
        '
        'MenuSp
        '
        Me.MenuSp.Checked = True
        Me.MenuSp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MenuSp.Name = "MenuSp"
        Me.MenuSp.Size = New System.Drawing.Size(122, 22)
        Me.MenuSp.Text = "枠線表示"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(119, 6)
        '
        'MenuSave
        '
        Me.MenuSave.Name = "MenuSave"
        Me.MenuSave.Size = New System.Drawing.Size(122, 22)
        Me.MenuSave.Text = "設定保存"
        '
        'MenuLoad
        '
        Me.MenuLoad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuLoadSelect, Me.ToolStripMenuItem3})
        Me.MenuLoad.Name = "MenuLoad"
        Me.MenuLoad.Size = New System.Drawing.Size(122, 22)
        Me.MenuLoad.Text = "設定読込"
        '
        'MenuLoadSelect
        '
        Me.MenuLoadSelect.Name = "MenuLoadSelect"
        Me.MenuLoadSelect.Size = New System.Drawing.Size(98, 22)
        Me.MenuLoadSelect.Text = "選択"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(95, 6)
        '
        'MenuNew
        '
        Me.MenuNew.Name = "MenuNew"
        Me.MenuNew.Size = New System.Drawing.Size(122, 22)
        Me.MenuNew.Text = "新規"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(119, 6)
        '
        'MenuHelp
        '
        Me.MenuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuHelpVersionInfo})
        Me.MenuHelp.Name = "MenuHelp"
        Me.MenuHelp.Size = New System.Drawing.Size(122, 22)
        Me.MenuHelp.Text = "ヘルプ"
        '
        'MenuHelpVersionInfo
        '
        Me.MenuHelpVersionInfo.Name = "MenuHelpVersionInfo"
        Me.MenuHelpVersionInfo.Size = New System.Drawing.Size(142, 22)
        Me.MenuHelpVersionInfo.Text = "バージョン情報"
        '
        'MenuExit
        '
        Me.MenuExit.Name = "MenuExit"
        Me.MenuExit.Size = New System.Drawing.Size(122, 22)
        Me.MenuExit.Text = "終了"
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
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuMaxView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuLoad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuLoadSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuHelpVersionInfo As System.Windows.Forms.ToolStripMenuItem

End Class
