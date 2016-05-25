using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LufthansaForm
{
    [Serializable]
    public class Posiljaoc
    {
        private string Ime;

        public string ime
        {
            get { return Ime; }
            set {
                if (value.Length < 2) throw new ArgumentException("Ime mora imati bar 2 slova");
                Ime = value;
            }
        }

        private string Prezime;

        public string prezime
        {
            get { return Prezime; }
            set {
                if (value.Length < 2) throw new ArgumentException("Prezime mora imati bar 2 slova");
                Prezime = value;
            }
        }

        private string Jmbg;

        public string JMBG
        {
            get { return Jmbg; }
            set {
                if (!ValidnostJMBG(value))
                    throw new ArgumentException("Pogrešan matični broj !");
                Jmbg = value;
            }
        }

        private string Kontakt;

        public string kontakt
        {
            get { return Kontakt; }
            set {
                if (!ValidnostKontakta(value)) throw new ArgumentException("Pogresan broj telefona");
                Kontakt = value;
            }
        }

        private string Komentar;

        public string komentar
        {
            get { return Komentar; }
            set { Komentar = value; }
        }

        public static bool ValidnostJMBG(string JMBG)
        {
            List<int> JMBG_N = JMBG.Select(x => Int32.Parse(x.ToString())).ToList();

            if (JMBG_N.Count != 13)
                return false;

            else
            {
                Double eval = 0;
                for (int i = 0; i < 6; i++)
                {
                    eval += (7 - i) * (JMBG_N[i] + JMBG_N[i + 6]);
                }
                return JMBG_N[12] == 11 - eval % 11;
            }
        }

        public static bool ValidnostKontakta(string kontakt)
        {
            Regex telRegex = new Regex("[+][3][8][7][6][0-9][-][0-9]{3}[-][0-9]{3}");

            if (telRegex.IsMatch(kontakt)) return true;
            return false;
        }
        public Posiljaoc(string ime, string prezime, string jmbg, string telefon, string komentar)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.JMBG = jmbg;
            this.kontakt = telefon;
            this.komentar = komentar;
        }

        public Posiljaoc()
        {

        }

        public override string ToString()
        {
            return ime + " " + prezime;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Posiljaoc) || obj == null)
                return false;
            if (ime != (obj as Posiljaoc).ime) return false;
            if (prezime != (obj as Posiljaoc).prezime) return false;
            if (JMBG != (obj as Posiljaoc).JMBG) return false;
            if (kontakt != (obj as Posiljaoc).kontakt) return false;
            if (komentar != (obj as Posiljaoc).komentar) return false;
            return true;
        }
    }
}
