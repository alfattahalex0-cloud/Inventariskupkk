<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtJumlah = New System.Windows.Forms.TextBox()
        Me.dtpKembali = New System.Windows.Forms.DateTimePicker()
        Me.dgvBarang = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBarang = New System.Windows.Forms.ComboBox()
        Me.dtpPinjam = New System.Windows.Forms.DateTimePicker()
        Me.btnPinjaman = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.txtKelas = New System.Windows.Forms.TextBox()
        CType(Me.dgvBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Impact", 19.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(97, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(447, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Peminjaman Barang Ke Sarpras"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(84, 322)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "TANGGAL PINJAM :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(169, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "JUMLAH :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 374)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(258, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TANGGAL PENGEMBALIAN :"
        '
        'txtJumlah
        '
        Me.txtJumlah.Location = New System.Drawing.Point(271, 274)
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Size = New System.Drawing.Size(367, 22)
        Me.txtJumlah.TabIndex = 5
        '
        'dtpKembali
        '
        Me.dtpKembali.Location = New System.Drawing.Point(272, 372)
        Me.dtpKembali.Name = "dtpKembali"
        Me.dtpKembali.Size = New System.Drawing.Size(367, 22)
        Me.dtpKembali.TabIndex = 7
        '
        'dgvBarang
        '
        Me.dgvBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBarang.Location = New System.Drawing.Point(113, 475)
        Me.dgvBarang.Name = "dgvBarang"
        Me.dgvBarang.RowHeadersWidth = 51
        Me.dgvBarang.RowTemplate.Height = 24
        Me.dgvBarang.Size = New System.Drawing.Size(457, 257)
        Me.dgvBarang.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(109, 231)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NAMA BARANG :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 16)
        Me.Label5.TabIndex = 21
        '
        'cmbBarang
        '
        Me.cmbBarang.FormattingEnabled = True
        Me.cmbBarang.Items.AddRange(New Object() {"Laptop", "Proyektor", "Mouse", "Keyboard"})
        Me.cmbBarang.Location = New System.Drawing.Point(272, 226)
        Me.cmbBarang.Name = "cmbBarang"
        Me.cmbBarang.Size = New System.Drawing.Size(366, 24)
        Me.cmbBarang.TabIndex = 22
        '
        'dtpPinjam
        '
        Me.dtpPinjam.Location = New System.Drawing.Point(272, 320)
        Me.dtpPinjam.Name = "dtpPinjam"
        Me.dtpPinjam.Size = New System.Drawing.Size(367, 22)
        Me.dtpPinjam.TabIndex = 23
        '
        'btnPinjaman
        '
        Me.btnPinjaman.Location = New System.Drawing.Point(318, 416)
        Me.btnPinjaman.Name = "btnPinjaman"
        Me.btnPinjaman.Size = New System.Drawing.Size(82, 33)
        Me.btnPinjaman.TabIndex = 24
        Me.btnPinjaman.Text = "PINJAM"
        Me.btnPinjaman.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(425, 416)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(82, 33)
        Me.btnLogout.TabIndex = 25
        Me.btnLogout.Text = "LOGOUT"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(101, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "NAMA PEMINJAM:"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(192, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "KELAS:"
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(274, 148)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(365, 22)
        Me.txtNama.TabIndex = 28
        '
        'txtKelas
        '
        Me.txtKelas.Location = New System.Drawing.Point(272, 191)
        Me.txtKelas.Name = "txtKelas"
        Me.txtKelas.Size = New System.Drawing.Size(367, 22)
        Me.txtKelas.TabIndex = 29
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(675, 791)
        Me.Controls.Add(Me.txtKelas)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnPinjaman)
        Me.Controls.Add(Me.dtpPinjam)
        Me.Controls.Add(Me.cmbBarang)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvBarang)
        Me.Controls.Add(Me.dtpKembali)
        Me.Controls.Add(Me.txtJumlah)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form2"
        Me.Text = " "
        CType(Me.dgvBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtJumlah As TextBox
    Friend WithEvents dtpKembali As DateTimePicker
    Friend WithEvents dgvBarang As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbBarang As ComboBox
    Friend WithEvents dtpPinjam As DateTimePicker
    Friend WithEvents btnPinjaman As Button
    Friend WithEvents btnLogout As Button

    Private Sub Peminjam_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtKelas As TextBox
End Class
