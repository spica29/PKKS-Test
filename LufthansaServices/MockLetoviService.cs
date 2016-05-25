using LufthansaForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LufthansaServices
{
    public class MockLetoviService:ILetoviService
    {
        private List<UneseniLet> Letovi;

        public List<UneseniLet> letovi
        {
            get { return Letovi; }
            set { Letovi = value; }
        }

        public MockLetoviService()
        {
            letovi = new List<UneseniLet>();
        }

        public bool letPostoji(int id)
        {
            return letovi.Find(x => x.ID == id) != null;
        }

        public bool potvrdiLet(string jmbg, double distance, int klasa)
        {
            List<int> JMBG_N = jmbg.Select(x => Int32.Parse(x.ToString())).ToList();
            bool jmbgOK = false;
            if (JMBG_N.Count != 13)
                jmbgOK = false;

            else
            {
                Double eval = 0;
                for (int i = 0; i < 6; i++)
                {
                    eval += (7 - i) * (JMBG_N[i] + JMBG_N[i + 6]);
                }
                jmbgOK = JMBG_N[12] == 11 - eval % 11;
            }

            return jmbgOK && distance > 0 && (klasa <= 10 && klasa > 0);
        }
        public void evidentirajLet(UneseniLet ul)
        {
            if (potvrdiLet(ul.posiljaoc.JMBG, ul.let.distanca, ul.let.klasa) && !letPostoji(ul.ID))
            {
                letovi.Add(ul);
            }
        }

        public int brojac()
        {
            return letovi.Count();
        }
    }
}
