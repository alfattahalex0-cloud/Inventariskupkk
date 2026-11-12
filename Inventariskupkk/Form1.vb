
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbHakAkses.Items.Clear()
        cmbHakAkses.Items.Add("Admin")
        cmbHakAkses.Items.Add("Peminjam")

        cmbHakAkses.SelectedIndex = 0

        txtPass.UseSystemPasswordChar = True

    End Sub

    ' TOMBOL RESET
    Private Sub Btnreset_Click(sender As Object, e As EventArgs) Handles Btnreset.Click

        txtPass.Clear()
        cmbHakAkses.SelectedIndex = 0
        txtPass.Focus()

    End Sub

    ' TOMBOL LOGIN
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtPass.Text.Trim() = "" Then

            MessageBox.Show("Masukkan password terlebih dahulu!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

            txtPass.Focus()
            Exit Sub

        End If

        ' LOGIN ADMIN
        If cmbHakAkses.Text = "Admin" AndAlso txtPass.Text = "telesandi" Then

            Form3.Show()
            Me.Hide()

            ' LOGIN PEMINJAM
        ElseIf cmbHakAkses.Text = "Peminjam" AndAlso txtPass.Text = "pinjam123" Then

            Form2.Show()
            Me.Hide()

        Else

            MessageBox.Show("Password salah!",
                            "Login Gagal",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

            txtPass.Clear()
            txtPass.Focus()

        End If

    End Sub

End Class
