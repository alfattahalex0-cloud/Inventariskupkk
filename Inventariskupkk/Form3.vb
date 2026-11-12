Imports System.Data
Imports System.Data.SqlClient

Public Class Form3

    ' =================================
    ' KONEKSI DATABASE
    ' =================================

    Private koneksi As String =
        "Data Source=ALEX-ROG\SQLEXPRESS;Initial Catalog=DB_INVENTARISKU;Integrated Security=True;TrustServerCertificate=True"

    Private idBarang As Integer = 0

    ' =================================
    ' FORM LOAD
    ' =================================

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbKondisi.Items.Clear()
        cmbKondisi.Items.Add("Baik")
        cmbKondisi.Items.Add("Rusak Ringan")
        cmbKondisi.Items.Add("Rusak Berat")

        dgvBarang.ReadOnly = True
        dgvBarang.AllowUserToAddRows = False
        dgvBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBarang.MultiSelect = False

        dgvPeminjaman.ReadOnly = True
        dgvPeminjaman.AllowUserToAddRows = False
        dgvPeminjaman.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPeminjaman.MultiSelect = False

        TampilBarang()
        TampilPeminjaman()

    End Sub

    ' =================================
    ' MENAMPILKAN DATA BARANG
    ' =================================

    Private Sub TampilBarang()

        Try
            Using con As New SqlConnection(koneksi)

                Dim query As String =
                    "SELECT ID_Barang, Nama_Barang, Stok, Kondisi FROM Barang"

                Dim da As New SqlDataAdapter(query, con)
                Dim dt As New DataTable

                da.Fill(dt)

                dgvBarang.DataSource = dt

            End Using

        Catch ex As Exception

            MessageBox.Show("Gagal menampilkan barang: " & ex.Message)

        End Try

    End Sub

    ' =================================
    ' MENAMPILKAN DATA PEMINJAMAN
    ' =================================


    Private Sub TampilPeminjaman()
        Try
            Using con As New SqlConnection(koneksi)

                Dim query As String =
                "SELECT P.ID_Peminjaman, " &
                "P.ID_Barang, " &
                "PM.Nama_Peminjam, " &
                "PM.Kelas, " &
                "B.Nama_Barang, " &
                "P.Jumlah, " &
                "P.Tanggal_Pinjam, " &
                "P.Tanggal_Kembali, " &
                "P.Status " &
                "FROM Peminjaman P " &
                "LEFT JOIN Peminjam PM ON P.ID_Peminjam = PM.ID_Peminjam " &
                "LEFT JOIN Barang B ON P.ID_Barang = B.ID_Barang"

                Dim da As New SqlDataAdapter(query, con)
                Dim dt As New DataTable
                da.Fill(dt)

                dgvPeminjaman.DataSource = dt

                ' Sembunyikan ID Barang
                dgvPeminjaman.Columns("ID_Barang").Visible = False

            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan peminjaman: " & ex.Message)
        End Try
    End Sub


    ' =================================
    ' TOMBOL TAMBAH BARANG
    ' =================================

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click

        Dim stok As Integer

        If txtNamaBarang.Text.Trim() = "" OrElse
           txtStock.Text.Trim() = "" OrElse
           cmbKondisi.SelectedIndex = -1 Then

            MessageBox.Show("Lengkapi semua data barang!")
            Exit Sub

        End If

        If Not Integer.TryParse(txtStock.Text, stok) OrElse stok < 0 Then

            MessageBox.Show("Stok harus berupa angka dan tidak boleh negatif!")
            Exit Sub

        End If

        Try
            Using con As New SqlConnection(koneksi)

                con.Open()

                Dim query As String =
                    "INSERT INTO Barang (Nama_Barang, Stok, Kondisi) " &
                    "VALUES (@nama, @stok, @kondisi)"

                Using cmd As New SqlCommand(query, con)

                    cmd.Parameters.AddWithValue("@nama", txtNamaBarang.Text.Trim())
                    cmd.Parameters.AddWithValue("@stok", stok)
                    cmd.Parameters.AddWithValue("@kondisi", cmbKondisi.Text)

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show("Barang berhasil ditambahkan!")

            Bersihkan()
            TampilBarang()

        Catch ex As Exception

            MessageBox.Show("Gagal menambah barang: " & ex.Message)

        End Try

    End Sub

    ' =================================
    ' MEMILIH BARANG DARI DGV
    ' =================================

    Private Sub dgvBarang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBarang.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim baris As DataGridViewRow = dgvBarang.Rows(e.RowIndex)

        idBarang = Convert.ToInt32(baris.Cells("ID_Barang").Value)

        txtNamaBarang.Text = baris.Cells("Nama_Barang").Value.ToString()
        txtStock.Text = baris.Cells("Stok").Value.ToString()
        cmbKondisi.Text = baris.Cells("Kondisi").Value.ToString()

    End Sub

    ' =================================
    ' TOMBOL UBAH BARANG
    ' =================================

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click

        If idBarang = 0 Then

            MessageBox.Show("Pilih barang dari tabel terlebih dahulu!")
            Exit Sub

        End If

        Dim stok As Integer

        If txtNamaBarang.Text.Trim() = "" OrElse
           Not Integer.TryParse(txtStock.Text, stok) OrElse
           stok < 0 OrElse
           cmbKondisi.SelectedIndex = -1 Then

            MessageBox.Show("Periksa kembali data barang!")
            Exit Sub

        End If

        Try
            Using con As New SqlConnection(koneksi)

                con.Open()

                Dim query As String =
                    "UPDATE Barang SET " &
                    "Nama_Barang=@nama, " &
                    "Stok=@stok, " &
                    "Kondisi=@kondisi " &
                    "WHERE ID_Barang=@id"

                Using cmd As New SqlCommand(query, con)

                    cmd.Parameters.AddWithValue("@nama", txtNamaBarang.Text.Trim())
                    cmd.Parameters.AddWithValue("@stok", stok)
                    cmd.Parameters.AddWithValue("@kondisi", cmbKondisi.Text)
                    cmd.Parameters.AddWithValue("@id", idBarang)

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show("Data barang berhasil diubah!")

            Bersihkan()
            TampilBarang()

        Catch ex As Exception

            MessageBox.Show("Gagal mengubah barang: " & ex.Message)

        End Try

    End Sub

    ' =================================
    ' TOMBOL HAPUS BARANG
    ' =================================

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click

        If idBarang = 0 Then

            MessageBox.Show("Pilih barang yang ingin dihapus!")
            Exit Sub

        End If

        Dim hasil As DialogResult = MessageBox.Show(
            "Apakah kamu yakin ingin menghapus barang ini?",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If hasil = DialogResult.No Then Exit Sub

        Try
            Using con As New SqlConnection(koneksi)

                con.Open()

                Dim query As String =
                    "DELETE FROM Barang WHERE ID_Barang=@id"

                Using cmd As New SqlCommand(query, con)

                    cmd.Parameters.AddWithValue("@id", idBarang)
                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show("Barang berhasil dihapus!")

            Bersihkan()
            TampilBarang()
            TampilPeminjaman()

        Catch ex As Exception

            MessageBox.Show(
                "Barang tidak dapat dihapus. Mungkin masih memiliki riwayat peminjaman." &
                vbCrLf & ex.Message)

        End Try

    End Sub

    ' =================================
    ' MEMBERSIHKAN INPUT
    ' =================================

    Private Sub Bersihkan()

        idBarang = 0

        txtNamaBarang.Clear()
        txtStock.Clear()
        cmbKondisi.SelectedIndex = -1

        dgvBarang.ClearSelection()

    End Sub

    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click

        Bersihkan()

    End Sub


    Private Sub btnTerima_Click(sender As Object, e As EventArgs) Handles btnTerima.Click

        If dgvPeminjaman.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih data peminjaman terlebih dahulu!")
            Return
        End If

        Dim baris As DataGridViewRow = dgvPeminjaman.CurrentRow

        Dim idPinjam As Integer = CInt(baris.Cells("ID_Peminjaman").Value)
        Dim idBarang As Integer = CInt(baris.Cells("ID_Barang").Value)
        Dim jumlah As Integer = CInt(baris.Cells("Jumlah").Value)
        Dim status As String = baris.Cells("Status").Value.ToString()

        If status = "Diterima" OrElse status = "Dikembalikan" Then
            MessageBox.Show("Peminjaman ini sudah diproses!")
            Return
        End If

        Using con As New SqlConnection(koneksi)
            con.Open()

            Using trans As SqlTransaction = con.BeginTransaction()

                Try
                    ' Kurangi stok barang
                    Dim queryStok As String =
                    "UPDATE Barang SET Stok = Stok - @jumlah " &
                    "WHERE ID_Barang = @idBarang AND Stok >= @jumlah"

                    Using cmd As New SqlCommand(queryStok, con, trans)
                        cmd.Parameters.AddWithValue("@jumlah", jumlah)
                        cmd.Parameters.AddWithValue("@idBarang", idBarang)

                        If cmd.ExecuteNonQuery() = 0 Then
                            Throw New Exception("Stok barang tidak mencukupi!")
                        End If
                    End Using

                    ' Ubah status peminjaman
                    Dim queryStatus As String =
                    "UPDATE Peminjaman SET Status = 'Diterima' " &
                    "WHERE ID_Peminjaman = @id AND Status = @status"

                    Using cmd As New SqlCommand(queryStatus, con, trans)
                        cmd.Parameters.AddWithValue("@id", idPinjam)
                        cmd.Parameters.AddWithValue("@status", status)

                        If cmd.ExecuteNonQuery() = 0 Then
                            Throw New Exception("Status peminjaman gagal diperbarui!")
                        End If
                    End Using

                    trans.Commit()

                    MessageBox.Show("Peminjaman berhasil diterima dan stok berhasil dikurangi!")

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Gagal menerima peminjaman: " & ex.Message)
                End Try

            End Using
        End Using

        TampilBarang()
        TampilPeminjaman()

    End Sub



    Private Sub btnPengembalian_Click(sender As Object, e As EventArgs) Handles btnPengembalian.Click

        If dgvPeminjaman.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih data peminjaman terlebih dahulu!")
            Return
        End If

        Dim baris As DataGridViewRow = dgvPeminjaman.CurrentRow

        Dim idPinjam As Integer = CInt(baris.Cells("ID_Peminjaman").Value)
        Dim idBarang As Integer = CInt(baris.Cells("ID_Barang").Value)
        Dim jumlah As Integer = CInt(baris.Cells("Jumlah").Value)
        Dim status As String = baris.Cells("Status").Value.ToString()

        If status <> "Diterima" Then
            MessageBox.Show("Barang hanya bisa dikembalikan jika statusnya Diterima!")
            Return
        End If

        If MessageBox.Show("Yakin ingin memproses pengembalian barang?",
                       "Konfirmasi",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Using con As New SqlConnection(koneksi)
            con.Open()

            Using trans As SqlTransaction = con.BeginTransaction()

                Try
                    ' Ubah status menjadi Dikembalikan
                    Dim queryStatus As String =
                    "UPDATE Peminjaman SET Status = 'Dikembalikan' " &
                    "WHERE ID_Peminjaman = @id AND Status = 'Diterima'"

                    Using cmd As New SqlCommand(queryStatus, con, trans)
                        cmd.Parameters.AddWithValue("@id", idPinjam)

                        If cmd.ExecuteNonQuery() = 0 Then
                            Throw New Exception("Peminjaman sudah diproses atau status tidak sesuai!")
                        End If
                    End Using

                    ' Tambahkan stok barang kembali
                    Dim queryStok As String =
                    "UPDATE Barang SET Stok = Stok + @jumlah " &
                    "WHERE ID_Barang = @idBarang"

                    Using cmd As New SqlCommand(queryStok, con, trans)
                        cmd.Parameters.AddWithValue("@jumlah", jumlah)
                        cmd.Parameters.AddWithValue("@idBarang", idBarang)

                        If cmd.ExecuteNonQuery() = 0 Then
                            Throw New Exception("Barang tidak ditemukan!")
                        End If
                    End Using

                    trans.Commit()

                    MessageBox.Show("Pengembalian berhasil! Stok barang sudah dikembalikan.")

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Gagal memproses pengembalian: " & ex.Message)
                End Try

            End Using
        End Using

        TampilBarang()
        TampilPeminjaman()

    End Sub


    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim hasil As DialogResult = MessageBox.Show(
            "Apakah kamu yakin ingin logout?",
            "Konfirmasi Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If hasil = DialogResult.Yes Then
            Form1.Show()
            Me.Hide()
        End If

    End Sub
End Class