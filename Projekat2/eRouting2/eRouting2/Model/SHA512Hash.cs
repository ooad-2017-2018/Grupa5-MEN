using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace eRouting2
{
    public class SHA512Hash : IKodiranje
    {
        public SHA512Hash(){  }

        public String Kodiraj(String s)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(s);
            byte[] result;
            SHA512 shaM = new SHA512Managed();
            result = shaM.ComputeHash(data);
            return result.ToString();
        }
    }
}
