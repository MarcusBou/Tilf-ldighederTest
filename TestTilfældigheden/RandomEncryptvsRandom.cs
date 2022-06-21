using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;

namespace TestTilfældigheden
{
    internal class RandomEncryptvsRandom
    {
        private Stopwatch stopwatch = new Stopwatch();

        public void RNGCryptRandomTest()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[1000];
                stopwatch.Restart();
                for (int i = 0; i < data.Length; i++)
                {
                    rng.GetBytes(data);
                    Console.WriteLine(BitConverter.ToInt32(data,0));
                }
                stopwatch.Stop();
                Console.WriteLine("Time elapsed for secured random: " + stopwatch.Elapsed);
            }
        }

        public void  RandomTest()
        {
            Random rng = new Random();
            stopwatch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(rng.Next());
            }
            stopwatch.Stop();
            Console.WriteLine("Time lapsed for random: " + stopwatch.Elapsed);
        }
    }
}
