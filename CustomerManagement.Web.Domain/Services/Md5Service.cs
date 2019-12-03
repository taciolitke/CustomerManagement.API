using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CustomerManagement.Web.Domain.Services
{
    public class Md5Service
    {
        private static MD5 _defaultHash
        {
            get
            {
                return MD5.Create();
            }
        }
        public static string GetMd5Hash(string input)
        {
            byte[] data = _defaultHash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMd5Hash(input);

            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hash) == 0;
        }
    }
}
