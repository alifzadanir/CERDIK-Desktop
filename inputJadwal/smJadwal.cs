//Library jadwal

namespace SimpanJadwal
{
    public class Jadwal
    {
        public int IdJadwal { get; set; } // Properti IdJadwal

        public string Penyakit { get; set; }
        public string Obat { get; set; }
        public string Dosis { get; set; }

        public Jadwal(string penyakit, string obat, string dosis)
        {
            Penyakit = penyakit;
            Obat = obat;
            Dosis = dosis;
        }

        public Jadwal(int idJadwal, string penyakit, string obat, string dosis)
        {
            IdJadwal = idJadwal;
            Penyakit = penyakit;
            Obat = obat;
            Dosis = dosis;
        }
    }

    public class SmJadwal
    {
        private int nextId = 1; // Menyimpan id untuk jadwal berikutnya
        public Jadwal[] jadwalArray; // Menggunakan array Jadwal[]

        public SmJadwal()
        {
            jadwalArray = new Jadwal[0]; // Menginisialisasi array kosong
        }

        // Metode untuk menambahkan jadwal ke dalam array
        public void TambahJadwal(Jadwal jadwal)
        {
            jadwal.IdJadwal = nextId++; // Atur id jadwal dan tingkatkan id untuk jadwal berikutnya
            Array.Resize(ref jadwalArray, jadwalArray.Length + 1);
            jadwalArray[jadwalArray.Length - 1] = jadwal;
        }

        // Metode untuk memperbarui jadwal dalam array
        public bool EditJadwal(int idJadwal, Jadwal editedJadwal)
        {
            for (int i = 0; i < jadwalArray.Length; i++)
            {
                if (jadwalArray[i].IdJadwal == idJadwal)
                {
                    jadwalArray[i] = editedJadwal;
                    return true;
                }
            }
            return false;
        }

        public Jadwal[] GetJadwalArray()
        {
            return jadwalArray; // Mengembalikan array jadwalArray
        }
    }
}

