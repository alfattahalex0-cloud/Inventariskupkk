# Inventarisku — Sistem Informasi Inventaris & Peminjaman Barang

Aplikasi desktop **Inventarisku** adalah aplikasi pencatatan inventaris barang beserta
proses peminjaman dan pengembaliannya. Aplikasi ini dibuat sebagai **proyek PKK
(Produk Kreatif dan Kewirausahaan)** untuk menggantikan pencatatan peminjaman barang
secara manual (buku/kertas) pada lab, bengkel, atau ruang praktik sekolah.

Masalah yang diselesaikan:

- Barang yang dipinjam sering tidak tercatat, sehingga stok fisik dan catatan tidak cocok.
- Tidak ada data siapa yang meminjam, kelasnya, dan kapan harus dikembalikan.
- Petugas tidak tahu peminjaman mana yang masih menunggu persetujuan.

Dengan aplikasi ini, setiap peminjaman diajukan lewat aplikasi, diverifikasi oleh
admin, dan stok barang otomatis berkurang saat disetujui serta kembali bertambah saat
barang dikembalikan.

---

## Fitur Utama

Aplikasi memiliki dua hak akses: **Admin** (petugas inventaris) dan **Peminjam** (siswa).

### 1. Login (Form1)
- Memilih hak akses (Admin / Peminjam) dan memasukkan password.
- Tombol **Reset** untuk mengosongkan form, tombol **Login** untuk masuk.
- Halaman login akan muncul kembali setiap kali pengguna logout.

### 2. Halaman Peminjam (Form2)
- Melihat daftar barang yang tersedia beserta stok dan kondisinya.
- Mengajukan peminjaman: nama peminjam, kelas, barang, jumlah, tanggal pinjam, dan tanggal kembali.
- Validasi input: nama/kelas wajib diisi, jumlah harus angka > 0, tanggal kembali tidak boleh sebelum tanggal pinjam.
- Peminjaman baru berstatus **Menunggu** dan **belum mengurangi stok** — stok hanya berkurang setelah admin menyetujui.
- Nama peminjam yang sama (nama + kelas) otomatis memakai data peminjam yang sudah ada, jadi tidak terjadi duplikasi data siswa.
- Logout dengan konfirmasi.

### 3. Halaman Admin (Form3)
- **Kelola data barang (CRUD)**: tambah, ubah, dan hapus barang (nama barang, stok, kondisi).
  Kondisi barang: `Baik`, `Rusak Ringan`, `Rusak Berat`.
- **Daftar peminjaman** lengkap dengan nama peminjam, kelas, nama barang, jumlah, tanggal pinjam/kembali, dan status.
- **Terima peminjaman**: status berubah menjadi `Diterima` dan stok barang otomatis dikurangi (dibatalkan semua jika stok tidak cukup).
- **Proses pengembalian**: status berubah menjadi `Dikembalikan` dan stok barang otomatis ditambahkan kembali.
- Barang yang masih punya riwayat peminjaman tidak bisa dihapus (dijaga oleh relasi database).
- Logout dengan konfirmasi.

### Alur status peminjaman

```
Menunggu  →  Diterima  →  Dikembalikan
   │            │
   │            └─ stok barang dikurangi
   └─ stok belum berubah (peminjaman masih diajukan)
                 stok dikembalikan saat barang kembali
```

---

## Teknologi yang Digunakan

| Bagian | Teknologi |
| --- | --- |
| Bahasa | Visual Basic .NET (VB.NET) |
| Antarmuka | Windows Forms (WinForms) |
| Framework | .NET Framework 4.7.2 |
| Database | Microsoft SQL Server (SQL Server Express) |
| Akses data | ADO.NET (`System.Data.SqlClient`) + typed DataSet |

---

## Struktur Project

```
Inventariskupkk.sln                  Solution Visual Studio
Inventariskupkk/
├── Form1.vb / Form1.Designer.vb     Form login (pemilihan hak akses + password)
├── Form2.vb / Form2.Designer.vb     Form peminjam (pengajuan peminjaman)
├── Form3.vb / Form3.Designer.vb     Form admin (CRUD barang, terima, pengembalian)
├── DB_INVENTARISKUDataSet.xsd       Skema DataSet (Barang, Peminjam, Peminjaman)
├── App.config                       Konfigurasi aplikasi
└── My Project/                      Setting project, resource, assembly info
```

### Struktur database `DB_INVENTARISKU`

| Tabel | Kolom | Keterangan |
| --- | --- | --- |
| `Barang` | `ID_Barang`, `Nama_Barang`, `Stok`, `Kondisi` | Master data barang inventaris |
| `Peminjam` | `ID_Peminjam`, `Nama_Peminjam`, `Kelas`, `Username`, `Password` | Data siswa/peminjam |
| `Peminjaman` | `ID_Peminjaman`, `ID_Peminjam`, `ID_Barang`, `Jumlah`, `Tanggal_Pinjam`, `Tanggal_Kembali`, `Status` | Transaksi peminjaman |

`Peminjaman` terhubung ke `Peminjam` dan `Barang` melalui foreign key.

---

## Cara Menjalankan

### Kebutuhan
- Windows 10/11
- Visual Studio 2019/2022 (workload **.NET desktop development**)
- SQL Server Express (misalnya `SQLEXPRESS`)

### Langkah

1. Clone repository:
   ```bash
   git clone https://github.com/alfattahalex0-cloud/Inventariskupkk.git
   ```
2. Buat database `DB_INVENTARISKU` di SQL Server. Skema tabelnya sesuai tabel di atas, contoh:
   ```sql
   CREATE DATABASE DB_INVENTARISKU;
   GO
   USE DB_INVENTARISKU;
   GO

   CREATE TABLE Barang (
       ID_Barang   INT IDENTITY(1,1) PRIMARY KEY,
       Nama_Barang VARCHAR(100) NOT NULL,
       Stok        INT NOT NULL DEFAULT 0,
       Kondisi     VARCHAR(50) NOT NULL
   );

   CREATE TABLE Peminjam (
       ID_Peminjam   INT IDENTITY(1,1) PRIMARY KEY,
       Nama_Peminjam VARCHAR(100) NOT NULL,
       Kelas         VARCHAR(50) NOT NULL,
       Username      VARCHAR(50) NULL,
       Password      VARCHAR(50) NULL
   );

   CREATE TABLE Peminjaman (
       ID_Peminjaman   INT IDENTITY(1,1) PRIMARY KEY,
       ID_Peminjam     INT NOT NULL REFERENCES Peminjam(ID_Peminjam),
       ID_Barang       INT NOT NULL REFERENCES Barang(ID_Barang),
       Jumlah          INT NOT NULL,
       Tanggal_Pinjam  DATE NOT NULL,
       Tanggal_Kembali DATE NOT NULL,
       Status          VARCHAR(20) NOT NULL DEFAULT 'Menunggu'
   );
   ```
3. Sesuaikan **connection string** dengan server SQL Server di komputer Anda.
   Saat ini connection string masih ditulis langsung di dalam kode, di dua tempat:
   - `Inventariskupkk/Form2.vb` (variabel `CONN`)
   - `Inventariskupkk/Form3.vb` (variabel `koneksi`)

   Contoh:
   ```vb
   "Data Source=NAMA-PC\SQLEXPRESS;Initial Catalog=DB_INVENTARISKU;Integrated Security=True;TrustServerCertificate=True"
   ```
4. Buka `Inventariskupkk.sln` di Visual Studio, lalu jalankan dengan **F5** (Start).

### Akun demo

| Hak Akses | Password |
| --- | --- |
| Admin | `telesandi` |
| Peminjam | `pinjam123` |

> Password masih ditulis langsung (hardcoded) di `Form1.vb`. Untuk penggunaan nyata,
> sebaiknya dipindahkan ke database (`tabel Peminjam`) dan disimpan dalam bentuk hash.

---

## Catatan Pengembangan

Beberapa hal yang bisa dikembangkan selanjutnya:

- Memindahkan password dan connection string ke tempat yang aman (database terenkripsi / `App.config`).
- Menambahkan fitur pencarian barang dan filter status peminjaman.
- Menambahkan laporan peminjaman (cetak/export ke Excel atau PDF) dan perhitungan denda keterlambatan.
- Menambahkan pengingat jatuh tempo pengembalian.

---

## Lisensi

Project ini dibuat untuk keperluan pembelajaran (tugas PKK) dan bebas digunakan
sebagai referensi belajar.
