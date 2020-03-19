namespace SynapseCore.Security
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// 
    /// 
    /// </summary>
    /// <<see cref="http://stackoverflow.com/questions/165808/simple-2-way-encryption-for-c-sharp"/>
    public class SimpleAES
    {
        private const int Seed = 11254;
        private static byte[] Key; 
        private static byte[] Vector;
        private ICryptoTransform encryptor, decryptor;
        private UTF8Encoding encoder;

        static SimpleAES()
        {
            Key = new byte[32] { 12, 27, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 237, 112, 22, 209, 241, 24, 175, 144, 173, 53, 196, 129, 224, 226, 117, 18, 91, 236, 153, 209 };
            Vector = new byte[16];
            Random pseudoRandom = new Random(Seed);
            // Fill the vector from pseudo-random generator so that value are not hardcoded - you need to run the code to get the key !
            // Proper encryption would do the same but with a new vector on every encryption. However this requires embedding the vector in the stream which is a bit more complex...
            pseudoRandom.NextBytes(Vector);
        }

        public SimpleAES()
        {
            RijndaelManaged rm = new RijndaelManaged();
            encryptor = rm.CreateEncryptor(Key, Vector);
            decryptor = rm.CreateDecryptor(Key, Vector);
            encoder = new UTF8Encoding();
        }

        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
        }

        public string Decrypt(string encrypted)
        {
            return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }

        public string EncryptToUrl(string unencrypted)
        {
            throw new NotImplementedException("Encoding to URL not implemented to avoid dependency on 'System.Web'");
            return null; // Original code: HttpUtility.UrlEncode(Encrypt(unencrypted));
        }

        public string DecryptFromUrl(string encrypted)
        {
            throw new NotImplementedException("Encoding to URL not implemented to avoid dependency on 'System.Web'");
            return null; // Original code: Decrypt(HttpUtility.UrlDecode(encrypted));
        }

        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, encryptor);
        }

        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}