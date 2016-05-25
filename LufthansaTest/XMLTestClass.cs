using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LufthansaForm;
using System.Collections.Generic;

namespace LufthansaTest
{
    [TestClass]
    public class XMLTestClass
    {
        [TestMethod]
        public void TestWriteXML()
        {
            Let l = new Let(9363, 4, 0.125, 2);
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            double cijena = l.izracunajCijenu();
            UneseniLet ul = new UneseniLet(p, l, 1, cijena);
            Lufthansa lf = new Lufthansa();
            lf.letovi.Add(ul);
            XMLSerialization.WriteXML<List<UneseniLet>>(lf.letovi);
        }

        [TestMethod]
        public void TestReadXML()
        {
            Lufthansa lf = new Lufthansa();
            lf.letovi = XMLSerialization.ReadXML<List<UneseniLet>>();
        }
    }
}
