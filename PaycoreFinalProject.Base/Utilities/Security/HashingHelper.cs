using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PaycoreFinalProject.Base.Utilities.Security
{
    //Girilen şifrenin hashlenmesini sağlar
    public class HashingHelper
    {
        public static string CreatePasswordHash(string password, string email)
        {
            using MD5 md5 = MD5.Create();
            password += email;

            byte[] data = Encoding.ASCII.GetBytes(password);
            byte[] passwordHash = md5.ComputeHash(data);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < passwordHash.Length; i++)
            {
                stringBuilder.Append(passwordHash[i].ToString("X2"));
            }

            return stringBuilder.ToString();

        }
        //Db'deki şifre ile karşılaştırma yaparak şiferenin doğruluğu kontrol edilir.
        public static bool VerifyPasswordHash(string loginPassword, string currentPassword )
        {
            for (int i = 0; i < currentPassword.Length; i++)
            {
                if (loginPassword[i]!= currentPassword[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
