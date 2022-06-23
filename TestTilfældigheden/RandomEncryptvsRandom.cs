using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;
using IronXL;

namespace TestTilfældigheden
{
    internal class RandomEncryptvsRandom
    {
        private Stopwatch stopwatch = new Stopwatch();
        private Stopwatch randomStopwatch = new Stopwatch();
        private int iterations = 100000;
        public void RNGCryptRandomTest()
        {
            WorkBook workBook = new WorkBook();
            var sheet = workBook.CreateWorkSheet("RNGSecureNumbers");
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[iterations];
                stopwatch.Restart();
                for (int i = 0; i < data.Length; i++)
                {
                    randomStopwatch.Restart();
                    rng.GetBytes(data);
                    randomStopwatch.Stop();
                    sheet[$"A{i + 1}"].Value = BitConverter.ToInt32(data, 0);
                    sheet[$"B{i + 1}"].Value = randomStopwatch.ElapsedMilliseconds;
                }
                stopwatch.Stop();
                sheet[$"A{iterations + 2}"].Value = stopwatch.ElapsedMilliseconds;
                Console.WriteLine("Time elapsed for secured random: " + stopwatch.Elapsed);
            }
            sheet.SaveAs("SecureNumbers.xlsx");
        }

        public void RandomTest()
        {
            WorkBook workBook = new WorkBook();
            var sheet = workBook.CreateWorkSheet("RNGNumbers");
            Random rng = new Random();
            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                randomStopwatch.Restart();
                int random = rng.Next();
                randomStopwatch.Stop();
                sheet[$"A{i + 1}"].Value = random;
                sheet[$"B{i + 1}"].Value = randomStopwatch.ElapsedMilliseconds;
            }
            stopwatch.Stop();
            Console.WriteLine("Time lapsed for random: " + stopwatch.Elapsed);
            sheet.SaveAs("RandomNumbers.xlsx");
        }
    }
}
