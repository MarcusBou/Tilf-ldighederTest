using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hashing
{
    internal class HMAC
    {
        private byte[] key;

        public HMAC()
        {
            this.key = GenerateKey();
        }

        private byte[] GenerateKey() {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                rng.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public byte[] ComputeSha1Hmac(byte[] toBeHashed)
        {
            using (var hmac = new HMACSHA1(this.key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }

        public byte[] ComputeSha256Hmac(byte[] toBeHashed)
        {
            using (var hmac = new HMACSHA256(this.key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }

        public byte[] ComputeSha512Hmac(byte[] toBeHashed)
        {
            using (var hmac = new HMACSHA512(this.key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
    }
}
