using Microsoft.AspNetCore.Components.Routing;

namespace API_CERDIK.Model
{
    public class Jadwal
    {
        public string tanggal { get; set; }

        public string waktu_mulai { get; set; }

        public string waktu_selesai { get; set; }

        public string dokter { get; set; }

        public string pasien { get; set; }
        public string keterangan { get; set; }

        public Jadwal(string tanggal, string waktu_mulai, string waktu_selesai, string dokter, string pasien, string keterangan)
        {
            this.tanggal = tanggal;
            this.waktu_mulai = waktu_mulai;
            this.waktu_selesai = waktu_selesai;
            this.dokter = dokter;
            this.pasien = pasien;
            this.keterangan = keterangan;
        }



    }
}
