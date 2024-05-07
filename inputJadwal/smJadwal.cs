//Library jadwal

namespace SimpanJadwal
{
    public class Jadwal
    {
        public DateTime Waktu { get; set; }
        public string Penyakit { get; set; }
        public string Obat { get; set; }
        public string Dosis { get; set; }

        public Jadwal(DateTime waktu, string penyakit, string obat, string dosis)
        {
            Waktu = waktu;
            Penyakit = penyakit;
            Obat = obat;
            Dosis = dosis;
        }
    }

    public class SmJadwal
    {
        public List<Jadwal> jadwalList;

        public SmJadwal()
        {
            jadwalList = new List<Jadwal>();
        }

        public void TambahJadwal(Jadwal jadwal)
        {
            jadwalList.Add(jadwal);
        }

        public bool EditJadwal(TimeSpan waktu, Jadwal editedJadwal)
        {
            Jadwal existingJadwal = jadwalList.Find(j => j.Waktu.TimeOfDay == waktu);

            if (existingJadwal != null)
            {
                existingJadwal.Penyakit = editedJadwal.Penyakit;
                existingJadwal.Obat = editedJadwal.Obat;
                existingJadwal.Dosis = editedJadwal.Dosis;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

