using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;

namespace SBase.Helper
{
    public class CryptographyHelper
    {
        /// <summary>
        /// Hash MD5 algorithm.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns></returns>
        public static string HashMD5(string plainText)
        {
            using var provider = System.Security.Cryptography.MD5.Create();
            StringBuilder builder = new StringBuilder();

            foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(plainText)))
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }

        /// <summary>
        /// Hash SHA256 algorithm.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>The hash string.</returns>
        public static string HashSHA256(string plainText)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // Convert the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// Encode base 64.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string EncodeBase64(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decode base 64.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns>The plain text.</returns>
        public static string DecodeBase64(string cipherText)
        {
            var base64EncodedBytes = Convert.FromBase64String(cipherText);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Encrypts the AES algorithm.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static byte[] EncrypAES(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = aesAlg.Key.Take(16).ToArray(); // Use the first 16 bytes of the key as the IV

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        /// <summary>
        /// Descrypt AES algorithm.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="key">The key.</param>s
        /// <returns></returns>
        public static string DecryptAES(byte[] cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = aesAlg.Key.Take(16).ToArray(); // Use the first 16 bytes of the key as the IV

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        
        public class RSAHelper
        {

            private static RSACryptoServiceProvider RsaCryptoServiceProvider = new RSACryptoServiceProvider(4096);

            private RSAParameters _privateKey;

            public RSAHelper()
            {
                _privateKey = RsaCryptoServiceProvider.ExportParameters(true);
                PrintPublicKey();
                
            }

            private void PrintPublicKey()
            {
                File.WriteAllText("publicKey.txt", RsaCryptoServiceProvider.ToXmlString(true));
            }

            public RSAParameters GeneratePublicKey()
            {
                RSAParameters rsaParameters =  RsaCryptoServiceProvider.ExportParameters(false);
                File.WriteAllText("privateKey.txt", RsaCryptoServiceProvider.ToXmlString(false));
                return rsaParameters;
            }



            /// <summary>
            /// 
            /// </summary>
            /// <param name="data"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public string Encrypt(string data, RSAParameters publicKey)
            {

                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportParameters(publicKey);
                    var byteData = Encoding.UTF8.GetBytes(data);
                    var encryptData = rsa.Encrypt(byteData, false);
                    return Convert.ToBase64String(encryptData);
                }
            } 

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cypherText"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public string Decrypt(string cypherText)
            {

                using (var rsa = new RSACryptoServiceProvider())
                {
                    var cipherByteData = Convert.FromBase64String(cypherText);
                    rsa.ImportParameters(_privateKey);

                    var encryptData = rsa.Decrypt(cipherByteData, false);
                    return Encoding.UTF8.GetString(encryptData);
                }
            }

            public string Decrypt(string cypherText, RSAParameters privateKey)
            {

                    using (var rsa = new RSACryptoServiceProvider())
                    {
                        try
                        {
                            var cipherByteData = Convert.FromBase64String(cypherText);
                            rsa.ImportParameters(privateKey);

                            var encryptData = rsa.Decrypt(cipherByteData, false);
                            return Encoding.UTF8.GetString(encryptData);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                
            }
        }
    }
}
    