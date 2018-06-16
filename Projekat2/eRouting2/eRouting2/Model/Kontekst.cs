using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRouting2
{
    class Kontekst
    {
        IKodiranje kodiranje = new MD5Hash();

        public void PromjenaStrategije(int i)
        {
            if (i == 0) kodiranje = new MD5Hash();
            else kodiranje = new SHA512Hash();
        }
        public string kodiraj(string s)
        {
            return kodiranje.Kodiraj(s);
        }
    }
}
