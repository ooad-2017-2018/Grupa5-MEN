using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace eRouting2
{
    public class MD5Hash : IKodiranje
    {
        public MD5Hash() { }

        public String Kodiraj(String s)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
                str.Append(result[i].ToString("x2"));
            return str.ToString();
        }
    }
}
