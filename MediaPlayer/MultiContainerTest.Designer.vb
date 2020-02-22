<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiContainerTest
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
        Me.左右分割ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.上下分割ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.削除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripPublic.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStripPublic
        '
        Me.ContextMenuStripPublic.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.左右分割ToolStripMenuItem, Me.上下分割ToolStripMenuItem, Me.削除ToolStripMenuItem})
        Me.ContextMenuStripPublic.Name = "ContextMenuStrip1"
        Me.ContextMenuStripPublic.Size = New System.Drawing.Size(153, 92)
        '
        '左右分割ToolStripMenuItem
        '
        Me.左右分割ToolStripMenuItem.Name = "左右分割ToolStripMenuItem"
        Me.左右分割ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.左右分割ToolStripMenuItem.Text = "左右分割"
        '
        '上下分割ToolStripMenuItem
        '
        Me.上下分割ToolStripMenuItem.Name = "上下分割ToolStripMenuItem"
        Me.上下分割ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.上下分割ToolStripMenuItem.Text = "上下分割"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Lime
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStripPublic
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(672, 268)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        '削除ToolStripMenuItem
        '
        Me.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem"
        Me.削除ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.削除ToolStripMenuItem.Text = "削除"
        '
        'MultiContainerTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 268)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "MultiContainerTest"
        Me.Text = "MultiContainerTest"
        Me.ContextMenuStripPublic.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStripPublic As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 左右分割ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 上下分割ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents 削除ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
