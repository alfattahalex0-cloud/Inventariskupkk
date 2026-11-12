
Imports System.Data.SqlClient
Imports System.Data

Public Class Form2

    ' KONEKSI DATABASE SQL SERVER
    Private CONN As New SqlConnection(
        "Data Source=ALEX-ROG\SQLEXPRESS;Initial Catalog=DB_INVENTARISKU;Integrated Security=True;TrustServerCertificate=True"
    )

    ' MEMBUKA KONEKSI
    Private Sub BukaKoneksi()
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If
    End Sub

    ' MENUTUP KONEKSI
    Private Sub TutupKoneksi()
        If CONN.State = ConnectionState.Open Then
            CONN.Close()
        End If
    End Sub

    ' MENAMPILKAN DATA BARANG
    Private Sub TampilBarang()

        Try
            BukaKoneksi()

            Dim DA As New SqlDataAdapter(
                "SELECT ID_Barang, Nama_Barang, Stok, Kondisi FROM Barang", CONN)

            Dim DT As New DataTable
            DA.Fill(DT)

            dgvBarang.DataSource = DT

            cmbBarang.DataSource = DT.Copy()
            cmbBarang.DisplayMember = "Nama_Barang"
            cmbBarang.ValueMember = "ID_Barang"
            cmbBarang.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan barang: " & ex.Message)

        Finally
            TutupKoneksi()
        End Try

    End Sub

    ' SAAT FORM DIBUKA
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpPinjam.Value = Date.Today
        dtpKembali.Value = Date.Today.AddDays(1)

        TampilBarang()

    End Sub

    ' TOMBOL PEMINJAMAN
    Private Sub btnPinjaman_Click(sender As Object, e As EventArgs) Handles btnPinjaman.Click

        ' CEK NAMA
        If txtNama.Text.Trim() = "" Then
            MessageBox.Show("Masukkan nama peminjam!")
            txtNama.Focus()
            Exit Sub
        End If

        ' CEK KELAS
        If txtKelas.Text.Trim() = "" Then
            MessageBox.Show("Masukkan kelas!")
            txtKelas.Focus()
            Exit Sub
        End If

        ' CEK BARANG
        If cmbBarang.SelectedIndex = -1 Then
            MessageBox.Show("Pilih barang terlebih dahulu!")
            Exit Sub
        End If

        ' CEK JUMLAH
        Dim jumlah As Integer

        If Not Integer.TryParse(txtJumlah.Text, jumlah) OrElse jumlah <= 0 Then
            MessageBox.Show("Masukkan jumlah barang dengan benar!")
            Exit Sub
        End If

        ' CEK TANGGAL
        If dtpKembali.Value.Date < dtpPinjam.Value.Date Then
            MessageBox.Show("Tanggal kembali tidak boleh sebelum tanggal pinjam!")
            Exit Sub
        End If

        Dim transaksi As SqlTransaction = Nothing

        Try
            BukaKoneksi()

            transaksi = CONN.BeginTransaction()

            Dim nama As String = txtNama.Text.Trim()
            Dim kelas As String = txtKelas.Text.Trim()
            Dim idBarang As Integer = CInt(cmbBarang.SelectedValue)

            ' CARI ID PEMINJAM BERDASARKAN NAMA DAN KELAS
            Dim idPeminjam As Integer

            Dim queryCari As String =
                "SELECT TOP 1 ID_Peminjam FROM Peminjam " &
                "WHERE Nama_Peminjam = @nama AND Kelas = @kelas"

            Using cmdCari As New SqlCommand(queryCari, CONN, transaksi)

                cmdCari.Parameters.AddWithValue("@nama", nama)
                cmdCari.Parameters.AddWithValue("@kelas", kelas)

                Dim hasil As Object = cmdCari.ExecuteScalar()

                If hasil IsNot Nothing Then

                    ' JIKA PEMINJAM SUDAH ADA
                    idPeminjam = Convert.ToInt32(hasil)

                Else

                    ' JIKA PEMINJAM BELUM ADA
                    Dim queryTambah As String =
                        "INSERT INTO Peminjam (Nama_Peminjam, Kelas) " &
                        "VALUES (@nama, @kelas); " &
                        "SELECT CAST(SCOPE_IDENTITY() AS INT)"

                    Using cmdTambah As New SqlCommand(queryTambah, CONN, transaksi)

                        cmdTambah.Parameters.AddWithValue("@nama", nama)
                        cmdTambah.Parameters.AddWithValue("@kelas", kelas)

                        idPeminjam = Convert.ToInt32(cmdTambah.ExecuteScalar())

                    End Using

                End If

            End Using

            ' CEK STOK BARANG
            Dim queryStok As String =
                "SELECT Stok FROM Barang WHERE ID_Barang = @id"

            Dim stok As Integer

            Using cmdStok As New SqlCommand(queryStok, CONN, transaksi)

                cmdStok.Parameters.AddWithValue("@id", idBarang)

                Dim hasilStok As Object = cmdStok.ExecuteScalar()

                If hasilStok Is Nothing Then
                    Throw New Exception("Barang tidak ditemukan!")
                End If

                stok = Convert.ToInt32(hasilStok)

            End Using

            If jumlah > stok Then
                Throw New Exception("Stok barang tidak mencukupi!")
            End If

            ' SIMPAN DATA PEMINJAMAN
            Dim querySimpan As String =
                "INSERT INTO Peminjaman " &
                "(ID_Peminjam, ID_Barang, Jumlah, Tanggal_Pinjam, Tanggal_Kembali, Status) " &
                "VALUES (@peminjam, @barang, @jumlah, @pinjam, @kembali, @status)"

            Using cmdSimpan As New SqlCommand(querySimpan, CONN, transaksi)

                cmdSimpan.Parameters.AddWithValue("@peminjam", idPeminjam)
                cmdSimpan.Parameters.AddWithValue("@barang", idBarang)
                cmdSimpan.Parameters.AddWithValue("@jumlah", jumlah)
                cmdSimpan.Parameters.AddWithValue("@pinjam", dtpPinjam.Value.Date)
                cmdSimpan.Parameters.AddWithValue("@kembali", dtpKembali.Value.Date)
                cmdSimpan.Parameters.AddWithValue("@status", "Menunggu")

                cmdSimpan.ExecuteNonQuery()

            End Using

            ' STOK TIDAK DIKURANGI DI FORM2
            ' STOK DIKURANGI KETIKA ADMIN MENEKAN TERIMA PEMINJAMAN

            transaksi.Commit()

            MessageBox.Show("Peminjaman berhasil diajukan!")

            ' BERSIHKAN INPUT
            txtNama.Clear()
            txtKelas.Clear()
            txtJumlah.Clear()
            cmbBarang.SelectedIndex = -1

            TampilBarang()

        Catch ex As Exception

            If transaksi IsNot Nothing Then
                Try
                    transaksi.Rollback()
                Catch
                End Try
            End If

            MessageBox.Show("Terjadi kesalahan: " & ex.Message)

        Finally
            TutupKoneksi()
        End Try

    End Sub

    ' TOMBOL LOGOUT
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

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

End Class
