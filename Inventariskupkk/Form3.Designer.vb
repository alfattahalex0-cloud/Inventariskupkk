<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbKondisi = New System.Windows.Forms.ComboBox()
        Me.txtNamaBarang = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvBarang = New System.Windows.Forms.DataGridView()
        Me.dgvPeminjaman = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnTambah = New System.Windows.Forms.Button()
        Me.btnUbah = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnBersihkan = New System.Windows.Forms.Button()
        Me.btnTerima = New System.Windows.Forms.Button()
        Me.btnPengembalian = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        CType(Me.dgvBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPeminjaman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbKondisi
        '
        Me.cmbKondisi.FormattingEnabled = True
        Me.cmbKondisi.Items.AddRange(New Object() {"Baru", "Bekas", "Rusak"})
        Me.cmbKondisi.Location = New System.Drawing.Point(39, 287)
        Me.cmbKondisi.Name = "cmbKondisi"
        Me.cmbKondisi.Size = New System.Drawing.Size(223, 24)
        Me.cmbKondisi.TabIndex = 27
        '
        'txtNamaBarang
        '
        Me.txtNamaBarang.Location = New System.Drawing.Point(39, 156)
        Me.txtNamaBarang.Name = "txtNamaBarang"
        Me.txtNamaBarang.Size = New System.Drawing.Size(223, 22)
        Me.txtNamaBarang.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(35, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 20)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Kondisi :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "NAMA BARANG :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Impact", 19.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(36, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 41)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Halaman Admin"
        '
        'txtStock
        '
        Me.txtStock.Location = New System.Drawing.Point(322, 156)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(223, 22)
        Me.txtStock.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(318, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Stock :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(35, 419)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "DAFTAR BARANG"
        '
        'dgvBarang
        '
        Me.dgvBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBarang.Location = New System.Drawing.Point(39, 442)
        Me.dgvBarang.Name = "dgvBarang"
        Me.dgvBarang.RowHeadersWidth = 51
        Me.dgvBarang.RowTemplate.Height = 24
        Me.dgvBarang.Size = New System.Drawing.Size(388, 165)
        Me.dgvBarang.TabIndex = 31
        '
        'dgvPeminjaman
        '
        Me.dgvPeminjaman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPeminjaman.Location = New System.Drawing.Point(39, 691)
        Me.dgvPeminjaman.Name = "dgvPeminjaman"
        Me.dgvPeminjaman.RowHeadersWidth = 51
        Me.dgvPeminjaman.RowTemplate.Height = 24
        Me.dgvPeminjaman.Size = New System.Drawing.Size(388, 214)
        Me.dgvPeminjaman.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 658)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 20)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "DATA PEMINJAM"
        '
        'btnTambah
        '
        Me.btnTambah.Location = New System.Drawing.Point(43, 359)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New System.Drawing.Size(75, 23)
        Me.btnTambah.TabIndex = 34
        Me.btnTambah.Text = "Tambah"
        Me.btnTambah.UseVisualStyleBackColor = True
        '
        'btnUbah
        '
        Me.btnUbah.Location = New System.Drawing.Point(136, 359)
        Me.btnUbah.Name = "btnUbah"
        Me.btnUbah.Size = New System.Drawing.Size(75, 23)
        Me.btnUbah.TabIndex = 35
        Me.btnUbah.Text = "Ubah"
        Me.btnUbah.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(230, 359)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(75, 23)
        Me.btnHapus.TabIndex = 36
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnBersihkan
        '
        Me.btnBersihkan.Location = New System.Drawing.Point(322, 359)
        Me.btnBersihkan.Name = "btnBersihkan"
        Me.btnBersihkan.Size = New System.Drawing.Size(75, 23)
        Me.btnBersihkan.TabIndex = 37
        Me.btnBersihkan.Text = "Bersihkan"
        Me.btnBersihkan.UseVisualStyleBackColor = True
        '
        'btnTerima
        '
        Me.btnTerima.Location = New System.Drawing.Point(230, 397)
        Me.btnTerima.Name = "btnTerima"
        Me.btnTerima.Size = New System.Drawing.Size(136, 28)
        Me.btnTerima.TabIndex = 38
        Me.btnTerima.Text = "Terima Peminjaman"
        Me.btnTerima.UseVisualStyleBackColor = True
        '
        'btnPengembalian
        '
        Me.btnPengembalian.Location = New System.Drawing.Point(385, 397)
        Me.btnPengembalian.Name = "btnPengembalian"
        Me.btnPengembalian.Size = New System.Drawing.Size(136, 28)
        Me.btnPengembalian.TabIndex = 39
        Me.btnPengembalian.Text = "Pengembalian"
        Me.btnPengembalian.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(429, 359)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(82, 23)
        Me.btnLogout.TabIndex = 40
        Me.btnLogout.Text = "LOGOUT"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 931)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnPengembalian)
        Me.Controls.Add(Me.btnTerima)
        Me.Controls.Add(Me.btnBersihkan)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnUbah)
        Me.Controls.Add(Me.btnTambah)
        Me.Controls.Add(Me.dgvPeminjaman)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvBarang)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbKondisi)
        Me.Controls.Add(Me.txtNamaBarang)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.dgvBarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPeminjaman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbKondisi As ComboBox
    Friend WithEvents txtNamaBarang As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStock As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvBarang As DataGridView
    Friend WithEvents dgvPeminjaman As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnUbah As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents btnTerima As Button
    Friend WithEvents btnPengembalian As Button
    Friend WithEvents btnLogout As Button
End Class
