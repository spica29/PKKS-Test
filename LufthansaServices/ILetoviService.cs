using LufthansaForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LufthansaServices
{
    public interface ILetoviService
    {
        bool potvrdiLet(string jmbg, double distance, int klasa);
        bool letPostoji(int id);
        void evidentirajLet(UneseniLet ul);
        int brojac();
    }
}
