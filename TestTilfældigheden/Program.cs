using System;
using System.Security.Cryptography;

namespace TestTilfældigheden
{
    internal class Program
    {
        static void Main(string[] args)
         {
            RandomEncryptvsRandom encryptvsRandom = new RandomEncryptvsRandom();
            Encrypter encrypter = new Encrypter();
            encryptvsRandom.RNGCryptRandomTest();
            Console.WriteLine("");
            encryptvsRandom.RandomTest();
            Console.WriteLine(encrypter.Encrypt("Hello"));
            Console.WriteLine(encrypter.Decrypt("Ifmmp"));
        }
    }
}
