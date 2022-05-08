using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.CrossCuttingConcerns.Helpers
{
    public static class MD5CryptographyHelper
    {
        public static string EncryptToMD5(string input)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);

            ////Convert encoded bytes back to a 'readable' string
            //return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
