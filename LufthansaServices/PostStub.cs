using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LufthansaServices
{
    public class PostStub : IPost
    {
        public double konverzijaValuta(string valuta, double iznos)
        {
            return 2 * iznos;
        }

        public int maksimalnaTezina()
        {
            return 50;
        }

        public double racunanjeDistance(string _od, string _do)
        {
            return 5050.3;
        }

    }
}
