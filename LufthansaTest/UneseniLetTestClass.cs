using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LufthansaForm;
using LufthansaServices;

namespace LufthansaTest
{
    [TestClass]
    public class UneseniLetTestClass
    {
        [TestMethod]
        public void TestGet()
        {
            UneseniLet ul = new UneseniLet();
            UneseniLet ul2 = new UneseniLet();
            Let l = new Let(9363, 4, 0.125, 2);
            Let l2 = new Let(9363, 4, 0.125, 2);
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            Posiljaoc p2 = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");

            int id = 0;

            ul.let = l;
            ul2.let = l2;

            ul.ID = id;

            ul.posiljaoc = p;
            ul2.posiljaoc = p2;

            Assert.AreEqual(ul.let, ul2.let);
            Assert.AreEqual(ul.posiljaoc, ul2.posiljaoc);
            Assert.AreEqual(ul.ID, 0);
        }

        //cijena
        [TestMethod]
        public void TestCijena()
        {
            UneseniLet ul = new UneseniLet();
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            Let l = new Let(9363, 4, 0.125, 2);
            ul.posiljaoc = p;
            ul.let = l;
            ul.cijena = ul.let.izracunajCijenu();
            double cijena = 1280.15;
            Assert.AreEqual(ul.cijena, cijena);
        }


        //const
        [TestMethod]
        public void TestConst2()
        {
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            Let l = new Let(9363, 4, 0.125, 2);
            double cijena = l.izracunajCijenu();
            UneseniLet ul = new UneseniLet(p, l, 1, cijena);
        }
        //set id ex
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestIDex()
        {
            UneseniLet ul = new UneseniLet();
            ul.ID = -1;
        }
        //set cijena ex
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestCijenaEx()
        {
            UneseniLet ul = new UneseniLet();
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            Let l = new Let(9363, 4, 0.125, 2);
            ul.posiljaoc = p;
            ul.let = l;
            ul.cijena = -20;
            double cijena = 1280.15;
            Assert.AreEqual(ul.cijena, cijena);
        }

        //set cijena ex
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestCijenaEx2()
        {
            UneseniLet ul = new UneseniLet();
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            Let l = new Let(9363, 4, 0.125, 2);
            ul.posiljaoc = p;
            ul.let = l;
            ul.cijena = 1220;
            double cijena = 1280.15;
            Assert.AreEqual(ul.cijena, cijena);
        }
        //set posiljaoc ex
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestPosiljalacEx()
        {
            UneseniLet ul = new UneseniLet();
            Posiljaoc p = null;
            Let l = new Let(9363, 4, 0.125, 2);
            ul.posiljaoc = p;
            Assert.AreEqual(ul.posiljaoc, p);
        }

        ILetoviService service = null;
        IPost post = null;
        //mock
        [TestMethod]
        public void TestMock()
        {
            Lufthansa lf = new Lufthansa();
            service = new MockLetoviService();

            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            Let l = new Let(9363, 4, 0.125, 2);
            UneseniLet ul = new UneseniLet(p, l, 20, l.izracunajCijenu());
            lf.letovi.Add(ul);
            if (service.potvrdiLet(p.JMBG, l.distanca, l.klasa))
            {
                service.evidentirajLet(ul);
            }

            Assert.AreEqual(lf.letovi.Count, service.brojac()); //spy
            Assert.IsTrue(service.letPostoji(ul.ID));
        }

        //Poststub
        [TestMethod]
        public void TestStub()
        {
            post = new PostStub();

            double distanca = post.racunanjeDistance("Sarajevo, BiH", "Zagreb, HR");
            int max = post.maksimalnaTezina();
            Let l = new Let(distanca, max, 0.125, 2);
        }

    }

}
