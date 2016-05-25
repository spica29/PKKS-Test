using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LufthansaForm;

namespace LufthansaTest
{
    [TestClass]
    public class LufthansaTestClass
    {
        [TestMethod]
        public void TestCons()
        {
            Let l = new Let(9363, 4, 0.125, 2);
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            double cijena = l.izracunajCijenu();
            UneseniLet ul = new UneseniLet(p, l, 1, cijena);
            Lufthansa lf = new Lufthansa();
            lf.letovi.Add(ul);
        }
    }
}
