//Generic

using System.ComponentModel.Design;
using System.Globalization;
using CERDIK;
using Menu;
using SimpanJadwal;


public class Program
{
    public static void Main(string[] args)
    {
        SmJadwal smJadwal = new SmJadwal();
        string pilihMenu;
        string pilihRole;

        Menus.menuUtama();

        Console.WriteLine("Pilih role sesuai dengan kebutuhanmu!");
        pilihRole = Console.ReadLine();

        if (pilihRole == "1" || pilihRole == "2")
        {
            Menus.menuLogin();
        }

        Console.WriteLine("Pilih:");
        pilihMenu = Console.ReadLine();

        if (pilihMenu == "1" && pilihRole == "1")
        {
            Console.WriteLine("Login Sukses!");
            Menus.menuPasien();
        }
        else if (pilihMenu == "2" && pilihRole == "1")
        {
            Console.WriteLine("Daftar Sukses!");
            Menus.menuPasien();
        }
        else if (pilihMenu == "1" && pilihRole == "2")
        {
            Console.WriteLine("Login Sukses!");
            Menus.menuNakes();
            HandleNakesMenu(smJadwal);
        }
        else if (pilihMenu == "2" && pilihRole == "2")
        {
            Console.WriteLine("Daftar Sukses!");
            Menus.menuNakes();
            HandleNakesMenu(smJadwal);

        }

        Console.WriteLine("Pilihan:");
        pilihMenu = Console.ReadLine();
    }

    public static void HandleNakesMenu(SmJadwal smJadwal)
    {
        Console.WriteLine("Pilih opsi:");
        string pilihan = Console.ReadLine();

        if (pilihan == "1")
        {
            // Lihat Jadwal
            LihatJadwal(smJadwal);
            Menus.menuNakes();
            HandleNakesMenu(smJadwal);
        }
        else if (pilihan == "2")
        {
            // Menambahkan Jadwal
            TambahkanJadwal(smJadwal);
            Menus.menuNakes();
            HandleNakesMenu(smJadwal);
        }
        else if (pilihan == "3")
        {
            // Lihat Device Yang Terhubung
        }
        else if (pilihan == "4")
        {
            // Daftarkan Device
        }
        else if (pilihan == "5")
        {
            // Edit Jadwal
            EditJadwal(smJadwal);
            Menus.menuNakes();
            HandleNakesMenu(smJadwal);
        }
        else
        {
            Console.WriteLine("Opsi tidak valid!");
        }
    }

    public static void TambahkanJadwal(SmJadwal smJadwal)
    {
        Console.WriteLine("Masukkan nama penyakit:");
        string penyakit = Console.ReadLine();

        Console.WriteLine("Masukkan nama obat:");
        string obat = Console.ReadLine();

        Console.WriteLine("Masukkan dosis obat:");
        string dosis = Console.ReadLine();

        smJadwal.TambahJadwal(new Jadwal(penyakit, obat, dosis));
        Console.WriteLine("Jadwal berhasil ditambahkan!");
    }

    public static void LihatJadwal(SmJadwal smJadwal)
    {
        var jadwalArray = smJadwal.GetJadwalArray();

        if (jadwalArray.Length > 0)
        {
            Console.WriteLine("Daftar Jadwal:");

            foreach (var jadwal in jadwalArray)
            {
                Console.WriteLine($"ID Jadwal: {jadwal.IdJadwal}");
                Console.WriteLine($"Penyakit: {jadwal.Penyakit}");
                Console.WriteLine($"Obat: {jadwal.Obat}");
                Console.WriteLine($"Dosis: {jadwal.Dosis}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Tidak ada jadwal yang tersedia.");
        }
    }

    public static void EditJadwal(SmJadwal smJadwal)
    {
        var jadwalArray = smJadwal.GetJadwalArray();

        if (jadwalArray.Length > 0)
        {
            Console.WriteLine("Daftar Jadwal:");

            for (int i = 0; i < jadwalArray.Length; i++)
            {
                Console.WriteLine($"ID Jadwal: {jadwalArray[i].IdJadwal}");
                Console.WriteLine($"Penyakit: {jadwalArray[i].Penyakit}");
                Console.WriteLine($"Obat: {jadwalArray[i].Obat}");
                Console.WriteLine($"Dosis: {jadwalArray[i].Dosis}");
                Console.WriteLine();
            }

            // Meminta input untuk memilih jadwal yang akan diedit
            Console.WriteLine("Masukkan ID Jadwal yang ingin diedit:");
            int idJadwal;
            while (!int.TryParse(Console.ReadLine(), out idJadwal))
            {
                Console.WriteLine("Input tidak valid. Masukkan ID Jadwal dengan angka:");
            }

            // Mencari jadwal yang sesuai dengan ID yang dimasukkan pengguna
            Jadwal jadwalToEdit = jadwalArray.FirstOrDefault(j => j.IdJadwal == idJadwal);

            if (jadwalToEdit != null)
            {
                // Meminta input untuk informasi jadwal yang diperbarui
                Console.WriteLine("Masukkan informasi baru:");

                Console.WriteLine("Masukkan nama penyakit baru:");
                string newPenyakit = Console.ReadLine();

                Console.WriteLine("Masukkan nama obat baru:");
                string newObat = Console.ReadLine();

                Console.WriteLine("Masukkan dosis obat baru:");
                string newDosis = Console.ReadLine();

                // Mengupdate informasi jadwal
                jadwalToEdit.Penyakit = newPenyakit;
                jadwalToEdit.Obat = newObat;
                jadwalToEdit.Dosis = newDosis;

                Console.WriteLine("Jadwal berhasil diperbarui!");
            }
            else
            {
                Console.WriteLine("Jadwal tidak ditemukan!");
            }
        }
        else
        {
            Console.WriteLine("Tidak ada jadwal yang tersedia.");
        }
    }


}