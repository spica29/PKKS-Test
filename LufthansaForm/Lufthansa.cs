using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LufthansaForm
{
    [Serializable]
    public class Lufthansa
    {
        private List<UneseniLet> Letovi;

        public List<UneseniLet> letovi
        {
            get { return Letovi; }
            set {
                // (value == null) throw new ArgumentException("Prazna lista letova");
                //ID
                Letovi = value;
            }
        }

        public Lufthansa()
        {
            if(letovi == null)
                letovi = new List<UneseniLet>();
        }
    }
}
