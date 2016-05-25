using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LufthansaServices;
using LufthansaForm;

namespace LufthansaTest
{
    [TestClass]
    public class DataDrivenTestClass
    {
        ILetoviService service = null;
        public DataDrivenTestClass()
        {
            //
            // TODO: Add constructor logic here
            //
            service = new MockLetoviService();
        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod, DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        "|DataDirectory|\\UneseniLetovi.CSV", "UneseniLetovi#csv", DataAccessMethod.Sequential),
        DeploymentItem("UneseniLetovi.csv")]
        public void CSVCitanje_DataDrivenTest()
        {
            int id = Convert.ToInt32(TestContext.DataRow["ID"]);
            string ime = Convert.ToString(TestContext.DataRow["ime"]);
            string prezime = Convert.ToString(TestContext.DataRow["prezime"]);
            string jmbg = TestContext.DataRow["JMBG"].ToString();
            double distanca = Convert.ToDouble(TestContext.DataRow["distanca"]);
            int klasa = Convert.ToInt32(TestContext.DataRow["klasa"]);
            Let l = new Let(Convert.ToDouble(TestContext.DataRow["distanca"]), 
                Convert.ToInt32(TestContext.DataRow["prtljag"]), 
                Convert.ToDouble(TestContext.DataRow["taksa"]), 
                Convert.ToInt32(TestContext.DataRow["klasa"]));
            Posiljaoc p = new Posiljaoc(ime, prezime, jmbg, 
                TestContext.DataRow["kontakt"].ToString(), 
                TestContext.DataRow["komentar"].ToString());
            double cijena = Convert.ToDouble(TestContext.DataRow["cijena"]);
            UneseniLet ul = new UneseniLet(p, l, id, cijena);
            service.evidentirajLet(ul);
            //provjera da li postoji let
            Assert.IsTrue(service.letPostoji(id));
            Assert.IsTrue(service.potvrdiLet(jmbg, distanca, klasa));
        }

        [DeploymentItem("UneseniLetovi.xml"), TestMethod()]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"|DataDirectory|\UneseniLetovi.xml", "Row", DataAccessMethod.Sequential)]
        public void XMLCitanje_DataDrivenTest()
        {
            int id = Convert.ToInt32(TestContext.DataRow["ID"]);
            string ime = Convert.ToString(TestContext.DataRow["ime"]);
            string prezime = Convert.ToString(TestContext.DataRow["prezime"]);
            string jmbg = TestContext.DataRow["JMBG"].ToString();
            double distanca = Convert.ToDouble(TestContext.DataRow["distanca"]);
            int klasa = Convert.ToInt32(TestContext.DataRow["klasa"]);
            Let l = new Let(Convert.ToDouble(TestContext.DataRow["distanca"]),
                Convert.ToInt32(TestContext.DataRow["prtljag"]),
                Convert.ToDouble(TestContext.DataRow["taksa"]),
                Convert.ToInt32(TestContext.DataRow["klasa"]));
            Posiljaoc p = new Posiljaoc(ime, prezime, jmbg,
                TestContext.DataRow["kontakt"].ToString(),
                TestContext.DataRow["komentar"].ToString());
            double cijena = Convert.ToDouble(TestContext.DataRow["cijena"]);
            UneseniLet ul = new UneseniLet(p, l, id, cijena);
            service.evidentirajLet(ul);
            //provjera da li postoji let
            Assert.IsTrue(service.letPostoji(id));
            Assert.IsTrue(service.potvrdiLet(jmbg, distanca, klasa));
        }
    }
}
