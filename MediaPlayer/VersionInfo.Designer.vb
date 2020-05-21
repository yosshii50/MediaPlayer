<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VersionInfo
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Version = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(395, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(262, 36)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "画面表示のテスト"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(395, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(262, 36)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "ViewPictureコントロールのテスト"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(395, 96)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(262, 36)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "MultiContainerTest"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(395, 138)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(262, 36)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "MenuFileAccessHistoryTest"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(395, 180)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(262, 36)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "時間経過で次の画像"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Version
        '
        Me.Version.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Version.Location = New System.Drawing.Point(12, 12)
        Me.Version.Multiline = True
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        Me.Version.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Version.Size = New System.Drawing.Size(368, 255)
        Me.Version.TabIndex = 5
        '
        'VersionInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 279)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "VersionInfo"
        Me.Text = "バージョン情報"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Version As System.Windows.Forms.TextBox
End Class
