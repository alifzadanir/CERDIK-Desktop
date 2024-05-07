using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpanJadwal;
using CERDIK;
using System;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestTambahkanJadwal_ValidInput()
        {
            // Arrange
            var smJadwal = new SmJadwal();
            var input = new StringReader("12:00\nFlu\nParacetamol\n500mg\n");
            Console.SetIn(input);
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            // Act
            Program.TambahkanJadwal(smJadwal);

            // Assert
            StringAssert.Contains(output.ToString(), "Jadwal berhasil ditambahkan!");
        }

        [TestMethod]
        public void TestTambahkanJadwal_InvalidTimeFormat()
        {
            // Arrange
            var smJadwal = new SmJadwal();
            var input = new StringReader("12:00:00\n12:00 AM\n");
            Console.SetIn(input);
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            // Act
            Program.TambahkanJadwal(smJadwal);

            // Assert
            StringAssert.Contains(output.ToString(), "Masukkan jam (format: HH:mm):");
        }
        [TestMethod]
        public void Test_EditJadwal()
        {
            SmJadwal smJadwal = new SmJadwal();
            TimeSpan waktu = new TimeSpan(12, 0, 0); // Waktu contoh: 12:00 PM
            Jadwal jadwalBaru = new Jadwal(DateTime.Today.Add(waktu), "Flu", "Obat Flu", "2 pil");

            smJadwal.TambahJadwal(jadwalBaru);

            Jadwal jadwalSetelahEdit = new Jadwal(DateTime.Today.Add(waktu), "Demam", "Obat Demam", "3 pil");
            bool editSuccess = smJadwal.EditJadwal(waktu, jadwalSetelahEdit);

            Assert.IsTrue(editSuccess); // Pastikan edit berhasil dilakukan
            Assert.AreEqual("Demam", jadwalBaru.Penyakit); // Verifikasi bahwa penyakit telah diubah
            Assert.AreEqual("Obat Demam", jadwalBaru.Obat); // Verifikasi bahwa obat telah diubah
            Assert.AreEqual("3 pil", jadwalBaru.Dosis); // Verifikasi bahwa dosis telah diubah
        }
    }
}
