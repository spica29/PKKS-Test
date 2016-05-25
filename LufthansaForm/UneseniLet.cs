using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LufthansaForm
{
    [Serializable]
    public class UneseniLet
    {
        private Let Let;

        public Let let
        {
            get { return Let; }
            set { Let = value; }
        }

        private Posiljaoc Posiljaoc;

        public Posiljaoc posiljaoc
        {
            get { return Posiljaoc; }
            set {
                if (value == null) throw new ArgumentException("Mora se unijeti posiljaoc");
                Posiljaoc = value;
            }
        }

        private int id;

        public int ID
        {
            get { return id; }
            set {
                if (value < 0) throw new ArgumentException("Pogresan ID");
                id = value;
            }
        }

        private double Cijena;

        public double cijena
        {
            get { return Cijena; }
            set {
                if (value <= 0 || value != let.izracunajCijenu()) throw new ArgumentException("Pogresna cijena");
                Cijena = value;
            }
        }

        public UneseniLet()
        {

        }

        public UneseniLet(Posiljaoc p, Let l, int id, double cijena)
        {
            this.posiljaoc = p;
            this.let = l;
            this.id = id;
            this.cijena = cijena;
        }


    }
}
