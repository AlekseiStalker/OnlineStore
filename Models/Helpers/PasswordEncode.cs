using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Models.Helpers
{
    public class PasswordEncode
    {
        //MD5
        public static string Encoder(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                 
                StringBuilder sBuilder = new StringBuilder();
                 
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                 
                return sBuilder.ToString();
            }
        } 
    }
}
