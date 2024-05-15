<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowArtist
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ComboBoxPais = New System.Windows.Forms.ComboBox()
        Me.TextBoxAristaNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonSalir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonELIMINAR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboBoxPais
        '
        Me.ComboBoxPais.FormattingEnabled = True
        Me.ComboBoxPais.Location = New System.Drawing.Point(12, 138)
        Me.ComboBoxPais.Name = "ComboBoxPais"
        Me.ComboBoxPais.Size = New System.Drawing.Size(172, 23)
        Me.ComboBoxPais.TabIndex = 0
        '
        'TextBoxAristaNombre
        '
        Me.TextBoxAristaNombre.Location = New System.Drawing.Point(12, 66)
        Me.TextBoxAristaNombre.Name = "TextBoxAristaNombre"
        Me.TextBoxAristaNombre.Size = New System.Drawing.Size(172, 23)
        Me.TextBoxAristaNombre.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Artist Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Pais"
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(12, 183)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(81, 32)
        Me.ButtonSalir.TabIndex = 10
        Me.ButtonSalir.Text = "Exit"
        Me.ButtonSalir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(190, 183)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 32)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonELIMINAR
        '
        Me.ButtonELIMINAR.Location = New System.Drawing.Point(103, 183)
        Me.ButtonELIMINAR.Name = "ButtonELIMINAR"
        Me.ButtonELIMINAR.Size = New System.Drawing.Size(81, 32)
        Me.ButtonELIMINAR.TabIndex = 12
        Me.ButtonELIMINAR.Text = "Eliminate"
        Me.ButtonELIMINAR.UseVisualStyleBackColor = True
        '
        'ShowArtist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(286, 450)
        Me.Controls.Add(Me.ButtonELIMINAR)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxAristaNombre)
        Me.Controls.Add(Me.ComboBoxPais)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ShowArtist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ShowArtist"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBoxPais As ComboBox
    Friend WithEvents TextBoxAristaNombre As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonSalir As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ButtonELIMINAR As Button
End Class
