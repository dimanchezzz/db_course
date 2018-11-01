using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Course_kepeer_1
{
    class Hash
    {
        public static string GetHash(string  password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password.ToString());
            MD5CryptoServiceProvider cSP = new MD5CryptoServiceProvider();
            byte[] byteHash = cSP.ComputeHash(bytes);
            string hash = String.Empty;
            foreach(byte b in byteHash)
            {
                hash += String.Format("{0:x2}", b);
            }
            return hash;
        }
    }
}
