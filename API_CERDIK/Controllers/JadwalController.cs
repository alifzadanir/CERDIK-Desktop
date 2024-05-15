using API_CERDIK.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_CERDIK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class JadwalController : Controller
    {
        private static List<Jadwal> DataJadwal = new List<Jadwal>();

        public JadwalController()
        {
            string jsonFilePath = "C:\\Users\\Arfan\\OneDrive\\Documents\\Tugas Kuliah\\KPL\\CERDIK-Desktop\\API_CERDIK\\Data\\DataJadwal.json";
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            DataJadwal = JsonConvert.DeserializeObject<List<Jadwal>>(jsonData);
        }
        public static List<Jadwal> getDataJadwal()
        {
            return DataJadwal;
        }

        [HttpGet]
        public IEnumerable<Jadwal> GET()
        {
            return DataJadwal;
        }

        // GET DATA BY Nama
        [HttpGet("{NamaPasien}")]
        public Jadwal GETAnggota(string NamaPasien)
        {
            int id = -1;

            for (int i = 0; i < DataJadwal.Count; i++)
            {
                if (NamaPasien == DataJadwal[i].pasien)
                {
                    id = i;
                }
            }
            return DataJadwal[id];
        }

        // POST DATA
        [HttpPost]
        public void POST([FromBody] Jadwal newJadwal)
        {
            int id = -1;
            Boolean sama = false;

            for (int i = 0; i < DataJadwal.Count; i++)
            {
                if (newJadwal.pasien == DataJadwal[i].pasien)
                {
                    sama = true;
                }
            }

            if (!sama)
            {
                DataJadwal.Add(newJadwal);
                string jsonFilePath = "C:\\Users\\Arfan\\OneDrive\\Documents\\Tugas Kuliah\\KPL\\CERDIK-Desktop\\API_CERDIK\\Data\\DataJadwal.json";
                string jsonContent = JsonConvert.SerializeObject(DataJadwal);
                System.IO.File.WriteAllText(jsonFilePath, jsonContent);
            }
        }

        // DELETE DATA 
        [HttpDelete("{Nama_Pasien}")]
        public void DELETE(String Nama_Pasien)
        {
            int id = -1;

            for (int i = 0; i < DataJadwal.Count; i++)
            {
                if (Nama_Pasien == DataJadwal[i].pasien)
                {
                    DataJadwal.RemoveAt(i);
                    string jsonFilePath = "C:\\Users\\Arfan\\OneDrive\\Documents\\Tugas Kuliah\\KPL\\CERDIK-Desktop\\API_CERDIK\\Data\\DataJadwal.json";
                    string jsonContent = JsonConvert.SerializeObject(DataJadwal);
                    System.IO.File.WriteAllText(jsonFilePath, jsonContent);
                    break;
                }
            }
        }
    }
}
