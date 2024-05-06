//Generic

using System.ComponentModel.Design;
using CERDIK;


public class Program
{
    public static void Main(string[] args)
    {
        List<DevicesAddConfig> devices = new List<DevicesAddConfig>();
        string pilihMenu;
        string pilihRole;
        Menu.Menus.menuUtama();

        Console.WriteLine("Pilih role sesuai dengan kebutuhanmu!");
        pilihRole = Console.ReadLine();
        if (pilihRole == "1" || pilihRole == "2")
        {
            Menu.Menus.menuLogin();
        }

        Console.WriteLine("Pilih:");
        pilihMenu = Console.ReadLine();
        if (pilihMenu == "1" && pilihRole == "1")
        {
            Console.WriteLine("Login Sukses!");
            Menu.Menus.menuPasien();
        }
        else if (pilihMenu == "2" && pilihRole == "1")
        {
            Console.WriteLine("Daftar Sukses!");
            Menu.Menus.menuPasien();
        }
        else if (pilihMenu == "1" && pilihRole == "2")
        {
            Console.WriteLine("Login Sukses!");
            Menu.Menus.menuNakes();
        }
        else if (pilihMenu == "2" && pilihRole == "2")
        {
            Console.WriteLine("Daftar Sukses!");
            Menu.Menus.menuNakes();
        }
        Console.WriteLine("Pilihan:");
        pilihMenu = Console.ReadLine();

    }
}