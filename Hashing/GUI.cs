using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    internal class GUI
    {
        private HMAC hmac;
        private Hash hash;

        public GUI()
        {
            hmac = new HMAC();
            hash = new Hash();
        }

        public void start()
        {
            Console.WriteLine("Choose Hashing: ");
            Console.WriteLine(" 1.HMAC");
            Console.WriteLine(" 2.HASH");
            char key = Console.ReadKey().KeyChar;
            Console.Clear();
            Console.WriteLine("Choose Sha value: ");
            Console.WriteLine(" 1");
            Console.WriteLine(" 256");
            Console.WriteLine(" 512");
            string shaValue = Console.ReadLine();
            Console.Clear();
            Console.Write("Message you want hashed: ");
            string message = Console.ReadLine();
            hashWord(key, shaValue, message);

        }

        public void hashWord(char hashingAlgorythm, string shaValue, string message)
        {
            Stopwatch  stopwatch = new Stopwatch();
            byte[] hashedMessage = null;
            if (hashingAlgorythm.Equals('1'))
            {
                stopwatch.Restart();
                switch (shaValue)
                {
                    case "1":
                        hashedMessage = hmac.ComputeSha1Hmac(Encoding.UTF8.GetBytes(message));
                        break;
                    case "256":
                        hashedMessage = hmac.ComputeSha256Hmac(Encoding.UTF8.GetBytes(message));
                        break;
                    case "512":
                        hashedMessage = hmac.ComputeSha512Hmac(Encoding.UTF8.GetBytes(message));
                        break ;
                    case null:
                        break;
                }
                stopwatch.Stop();
            }
            else if (hashingAlgorythm.Equals('2'))
            {
                stopwatch.Restart();
                switch (shaValue)
                {
                    case "1":
                        hashedMessage = hash.ComputeSha1Hash(Encoding.UTF8.GetBytes(message));
                        break;
                    case "256":
                        hashedMessage = hash.ComputeSha256Hash(Encoding.UTF8.GetBytes(message));
                        break;
                    case "512":
                        hashedMessage = hash.ComputeSha512Hash(Encoding.UTF8.GetBytes(message));
                        break;
                    case null:
                        break;
                }
                stopwatch.Stop ();
            }
            else
            {
                Console.WriteLine("Error not a valid hash value was inputtet");
            }

            Console.Clear();
            if (hashedMessage != null)
            {
                Console.WriteLine("Message wish to be hashed: " + message);
                Console.WriteLine("Time taken: " + stopwatch.Elapsed);
                if (hashingAlgorythm.Equals('1')) { Console.WriteLine($"HMAC ASCII HASH: {Convert.ToBase64String(hashedMessage)}\nHMAC HEX HASH: {Convert.ToHexString(hashedMessage)}"); }
                else if (hashingAlgorythm.Equals('2')){ Console.WriteLine($"HASH ASCII HASH: {Convert.ToBase64String(hashedMessage)}\nHASH HEX HASH: {Convert.ToHexString(hashedMessage)}"); }
            }
            else
            {
                Console.WriteLine("Couldnt hash");
            }

        }
    }
}
