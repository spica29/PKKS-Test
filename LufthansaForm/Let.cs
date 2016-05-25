using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LufthansaForm
{
    [Serializable]
    public class Let
    {
        private string Od;

        public string _od
        {
            get { return Od; }
            set {
                if (value != null && this.Do == value) throw new ArgumentException("Nevalidna destinacija"); 
                Od = value;
            }
        }

        private string Do;

        public string _do
        {
            get { return Do; }
            set {
                if (value != null && this.Od == value) throw new ArgumentException("Nevalidna destinacija");
                Do = value;
            }
        }


        private double Distanca;

        public double distanca
        {
            get { return Distanca; }
            set {
                if (value <= 0) throw new ArgumentException("Distanca mora biti pozitivna");
                Distanca = value;
            }
        }

        private int Prtljag;

        public int prtljag
        {
            get { return Prtljag; }
            set {
                if (value <= 0) throw new ArgumentException("Pogresna kolicina prtljaga");
                Prtljag = value;
            }
        }

        private double Taksa;

        public double taksa
        {
            get { return Taksa; }
            set {
                if (value < 0) throw new ArgumentException("Pogresna taksa");
                Taksa = value;
            }
        }

        private int Klasa;

        public int klasa
        {
            //broj od 0-10
            get { return Klasa; }
            set {
                if (value < 0 || value > 10)
                    throw new ArgumentException("Pogresna klasa");
                Klasa = value;
            }
        }

        public Let(double distanca, int prtljag, double taksa, int klasa)
        {
            this.distanca = distanca;
            this.prtljag = prtljag;
            this.taksa = taksa;
            this.klasa = klasa;
        }

        public Let(double distanca, int prtljag, double taksa, int klasa, string od, string Do)
        {
            this.distanca = distanca;
            this.prtljag = prtljag;
            this.taksa = taksa;
            this.klasa = klasa;
            if (od == Do) throw new ArgumentException("Nevalidne destinacije");
            this._od = od;
            this._do = Do;
        }

        public Let()
        {

        }

        public double izracunajCijenu()
        {
            //MessageBox.Show("klasa" + klasa.ToString());
            double cijenaBezTakse = (distanca / 8.88) + (double) prtljag * 10 * (((double)klasa * 0.1) + distanca) * 0.000223;
            double cijena = cijenaBezTakse + (cijenaBezTakse * taksa);
            return Math.Round(cijena, 2);
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Let) || obj == null)
                return false;
            if (distanca != (obj as Let).distanca) return false;
            if (prtljag != (obj as Let).prtljag) return false;
            if (taksa != (obj as Let).taksa) return false;
            if (klasa != (obj as Let).klasa) return false;
            return true;
        }

        internal double izracunajTaksu(double konacnaCijena, int prtljag, double distanca, int klasa)
        {
            double cijenaBezTakse = (distanca / 8.88) + prtljag * 10 * ((klasa * 0.1) + distanca) * 0.000223;
            return konacnaCijena / cijenaBezTakse - 1;
        }
    }
}
