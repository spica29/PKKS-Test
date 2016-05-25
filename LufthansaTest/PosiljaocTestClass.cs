using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LufthansaForm;

namespace LufthansaTest
{
    [TestClass]
    public class PosiljaocTestClass
    {
        [TestMethod]
        public void TestConstructor()
        {
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");

        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestConstructorEx()
        {
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901997175003", "+38762-282-330", "bla");
        }

        [TestMethod]
        public void TestToString()
        {
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            Assert.AreEqual(p.ToString(), "Amela Spica");
        }

        [TestMethod]
        public void TestGet()
        {
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");
            Posiljaoc p2 = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");

            Assert.AreEqual(p, p2);
        }

        [TestMethod]
        public void TestEqualEx()
        {
            Posiljaoc p = new Posiljaoc("Ame", "Spica", "2901994175003", "+38762-282-330", "bla");
            Posiljaoc p2 = new Posiljaoc("Amela", "Spica", "2901994175003", "+38762-282-330", "bla");

            Assert.IsFalse(p == p2);
        }

        [TestMethod]
        public void TestCons()
        {
            Posiljaoc p = new Posiljaoc();
            Assert.IsTrue(p != null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestInvalidDigitsNumberJMBG()
        {
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "201994175003", "+38762-282-330", "bla");
        }

        //set ime
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestImeEx()
        {
            Posiljaoc p = new Posiljaoc("A", "Spica", "201994175003", "+38762-282-330", "bla");
        }
        //set kontakt
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestKontaktEx()
        {
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "201994175003", "+38762282-330", "bla");
        }
        //set prezime
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestPrezimeEx()
        {
            Posiljaoc p = new Posiljaoc("Amela", "S", "201994175003", "+38762-282-330", "bla");
        }
        //validnost broja
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestInvalidDigitsNumber()
        {
            Posiljaoc p = new Posiljaoc("Amela", "Spica", "201994175003", "+287682-330", "bla");
            //Assert.IsFalse(p)
        }
    }
}
