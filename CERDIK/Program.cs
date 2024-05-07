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
            HandleNakesMenu();
        }
        else if (pilihMenu == "2" && pilihRole == "2")
        {
            Console.WriteLine("Daftar Sukses!");
            Menus.menuNakes();
            HandleNakesMenu();
        }

        Console.WriteLine("Pilihan:");
        pilihMenu = Console.ReadLine();
    }

    public static void HandleNakesMenu()
    {
        SmJadwal smJadwal = new SmJadwal(); // Membuat instansi baru dari SmJadwal

        Console.WriteLine("Pilih opsi:");
        string pilihan = Console.ReadLine();

        if (pilihan == "1")
        {
            // Lihat Jadwal
        }
        else if (pilihan == "2")
        {
            // Menambahkan Jadwal
            TambahkanJadwal(smJadwal);
            Menus.menuNakes();
            HandleNakesMenu();
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
            HandleNakesMenu();
        }
        else
        {
            Console.WriteLine("Opsi tidak valid!");
        }
    }

    public static void TambahkanJadwal(SmJadwal smJadwal)
    {
        TimeSpan waktuInput;
        do
        {
            Console.WriteLine("Masukkan waktu (format: HH:mm):");
        }
        while (!TimeSpan.TryParseExact(Console.ReadLine(), @"hh\:mm", CultureInfo.InvariantCulture, out waktuInput));

        Console.WriteLine("Masukkan nama penyakit:");
        string penyakit = Console.ReadLine();

        Console.WriteLine("Masukkan nama obat:");
        string obat = Console.ReadLine();

        Console.WriteLine("Masukkan dosis obat:");
        string dosis = Console.ReadLine();

        smJadwal.TambahJadwal(new Jadwal(DateTime.Today.Add(waktuInput), penyakit, obat, dosis));

        Console.WriteLine("Jadwal berhasil ditambahkan!");
    }

    public static void EditJadwal(SmJadwal smJadwal)
    {
        Console.WriteLine("Masukkan waktu jadwal yang ingin diedit (format: HH:mm):");
        TimeSpan waktuInput;
        while (!TimeSpan.TryParseExact(Console.ReadLine(), @"hh\:mm", CultureInfo.InvariantCulture, out waktuInput))
        {
            Console.WriteLine("Format waktu tidak valid. Masukkan waktu dalam format HH:mm:");
        }

        Jadwal jadwalToUpdate = smJadwal.jadwalList.Find(j => j.Waktu.TimeOfDay == waktuInput);

        if (jadwalToUpdate != null)
        {
            Console.WriteLine("Masukkan nama penyakit baru:");
            string penyakit = Console.ReadLine();

            Console.WriteLine("Masukkan nama obat baru:");
            string obat = Console.ReadLine();

            Console.WriteLine("Masukkan dosis obat baru:");
            string dosis = Console.ReadLine();

            Jadwal editedJadwal = new Jadwal(jadwalToUpdate.Waktu, penyakit, obat, dosis);

            if (smJadwal.EditJadwal(waktuInput, editedJadwal))
            {
                Console.WriteLine("Jadwal berhasil diperbarui!");
            }
            else
            {
                Console.WriteLine("Jadwal tidak ditemukan!");
            }
        }
        else
        {
            Console.WriteLine("Jadwal tidak ditemukan!");
        }
    }


}