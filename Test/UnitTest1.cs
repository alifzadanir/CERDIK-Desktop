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
        public void TestTambahJadwal()
        {
            SmJadwal smJadwal = new SmJadwal();
            Jadwal jadwal = new Jadwal("Flu", "Paracetamol", "500 mg");
            smJadwal.TambahJadwal(jadwal);
            Jadwal[] jadwalArray = smJadwal.GetJadwalArray();
            Assert.AreEqual(1, jadwalArray.Length);
        }

        [TestMethod]
        public void TestLihatJadwal()
        {
            SmJadwal smJadwal = new SmJadwal();
            Jadwal jadwal1 = new Jadwal("Flu", "Paracetamol", "500 mg");
            Jadwal jadwal2 = new Jadwal("Demam", "Ibuprofen", "400 mg");
            smJadwal.TambahJadwal(jadwal1);
            smJadwal.TambahJadwal(jadwal2);
            Jadwal[] jadwalArray = smJadwal.GetJadwalArray();
            Assert.AreEqual(2, jadwalArray.Length);
        }

        [TestMethod]
        public void TestEditJadwal()
        {
            SmJadwal smJadwal = new SmJadwal();
            Jadwal jadwal1 = new Jadwal("Flu", "Paracetamol", "500 mg");
            smJadwal.TambahJadwal(jadwal1);
            Jadwal[] jadwalArray = smJadwal.GetJadwalArray();
            Jadwal editedJadwal = new Jadwal(jadwalArray[0].IdJadwal, "Demam", "Ibuprofen", "400 mg");
            smJadwal.EditJadwal(jadwalArray[0].IdJadwal, editedJadwal);
            Jadwal[] editedJadwalArray = smJadwal.GetJadwalArray();
            Assert.AreEqual("Demam", editedJadwalArray[0].Penyakit);
        }
    }
    
}
