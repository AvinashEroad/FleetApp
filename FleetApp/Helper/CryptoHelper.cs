using FernBusinessBase;
using System;
using System.Diagnostics;
using static FleetApp.Helper.Constants;

namespace FleetApp.Helper
{
    public class CryptoHelper
    {
        public static string Decrypt(string key, string cipher)
        {
            if(Guid.TryParse(key, out Guid guidKey))
            {
                try
                {
                    return EncryptionHelper.Decrypt(guidKey, cipher);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return ($"{InvalidRequestMessage} to Decrypt");
                }
            }
            return $"{InvalidGuidKeyMessage}: {key}";
        }

        public static string Encrypt(string key, string raw)
        {
            if (Guid.TryParse(key, out Guid guidKey))
            {
                try
                {
                    return EncryptionHelper.Encrypt(guidKey, raw, 0);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return ($"{InvalidRequestMessage} to Encrypt");
                }
            }
            return $"{InvalidGuidKeyMessage}: {key}";
        }
    }
}
