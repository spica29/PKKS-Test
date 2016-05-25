using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LufthansaServices
{
    public interface IPost
    {
        double konverzijaValuta(string valuta, double iznos);
        double racunanjeDistance(string _od, string _do);
        int maksimalnaTezina();
    }
}
