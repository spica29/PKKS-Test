using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LufthansaForm;

namespace LufthansaTest
{
    [TestClass]
    public class LetTestClass
    {
        [TestMethod]
        public void TestConstructor()
        {
            Let l = new Let(9363, 4, 0.125, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestConstructorEx()
        {
            Let l = new Let(-9363, 4, 0.125, 2);
        }

        [TestMethod]
        public void TestConstructor2()
        {
            Let l = new Let(9363, 4, 0.125, 2, "Sarajevo, BiH", "Zagreb, HR");
        }

        [TestMethod]
        public void TestConstructor3()
        {
            Let l = new Let();
        }

        //getters
        [TestMethod]
        public void TestGet()
        {
            Let l = new Let(9363, 4, 0.125, 2, "Sarajevo, BiH", "Zagreb, HR");
            double distanca = l.distanca;
            int prtljag = l.prtljag;
            double taksa = l.taksa;
            int klasa = l.klasa;
            string od = l._od;
            string _do = l._do;

            Assert.AreEqual(distanca, 9363);
            Assert.AreEqual(prtljag, 4);
            Assert.AreEqual(taksa, 0.125);
            Assert.AreEqual(klasa, 2);
            Assert.AreEqual(od, "Sarajevo, BiH");
            Assert.AreEqual(_do, "Zagreb, HR");
        }

        //izracunaj cijenu
        [TestMethod]
        public void TestIzracunajCijenu()
        {
            Let l = new Let(9363, 4, 0.125, 2);
            double cijena = 1280.15;
            Assert.AreEqual(l.izracunajCijenu(), cijena);
        }

        //klasa ex
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestKlasaEx()
        {
            Let l = new Let(9363, 4, 0.125, 11);
        }
        //klasa ex
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestKlasaEx2()
        {
            Let l = new Let(9363, 4, 0.125, -1);
        }
        //prtljag ex
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestPrtljagEx()
        {
            Let l = new Let(9363, -24, 0.125, 9);
        }
        //taksa ex
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestTaksaEx()
        {
            Let l = new Let(9363, 4, -0.125, 4);
        }
    }
}
