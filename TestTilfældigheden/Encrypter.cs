using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTilfældigheden
{
    internal class Encrypter
    {
        public string Encrypt(string messageToBeEncrypted)
        {
            char[] message = messageToBeEncrypted.ToCharArray();
            string encrypted = "";
            for (int i = 0; i < message.Length; i++)
            {
                message[i] = (char)(Convert.ToInt32(message[i]) + 1);
                encrypted += message[i];
            }
            return encrypted;
        }

        public string Decrypt(string messageToBeDecrypted)
        {
            char[] message = messageToBeDecrypted.ToCharArray();
            string encrypted = "";
            for (int i = 0; i < message.Length; i++)
            {
                message[i] = (char)(Convert.ToInt32(message[i]) - 1);
                encrypted += message[i];
            }
            return encrypted;
        }
    }
}
