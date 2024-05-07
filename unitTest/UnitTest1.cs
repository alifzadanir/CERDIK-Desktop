using NUnit.Framework;
using System;

namespace Program.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TambahkanJadwal_InputValid_JadwalTersimpan()
        {
            // Arrange
            var smJadwal = new SmJadwal();
            string jam = "10:00";
            string penyakit = "Demam";
            string obat = "Paracetamol";
            string dosis = "500 mg";

            // Act
            Program.TambahkanJadwal(smJadwal, jam, penyakit, obat, dosis);

            // Assert
            Assert.AreEqual(1, smJadwal.JadwalList.Count);
        }

        [Test]
        public void TambahkanJadwal_InputWaktuInvalid_ExceptionDilempar()
        {
            // Arrange
            var smJadwal = new SmJadwal();
            string jam = "10:00x"; // Jam tidak valid

            // Act & Assert
            Assert.Throws<FormatException>(() => Program.TambahkanJadwal(smJadwal, jam, "Demam", "Paracetamol", "500 mg"));
        }

        // Test lainnya sesuai kebutuhan dapat ditambahkan di sini
    }
}
