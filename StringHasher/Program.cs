using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StringHasher
{
    class Program
    {

        private static SHA256Managed sha;
        private static MD5 md5;
        static void Main(string[] args)
        {
            Console.WriteLine("C# SHA256 Compute/Check V0.01");
            while (true) { 
            Console.WriteLine("Would you like to compute an hash or check an hash?");
                String a = Console.ReadLine();
            if (a == "Hash")
            {
                Console.WriteLine("Input string to hash:");

                Console.WriteLine("Output: {0}", computeHash(Console.ReadLine()));

                    continue;
            }
            if (a == "Check")
                {
                    Console.WriteLine("Input Hashes to be compared:");
                    Console.WriteLine("Hash 1:");
                    String hash1 = Console.ReadLine();
                    Console.WriteLine("Hash 2:");
                    String hash2 = Console.ReadLine();
                    if (compareHash(hash1, hash2))
                        Console.WriteLine("The hashes are the same. Valid.");
                    else
                        Console.WriteLine("Invalid Check. The hashes are different");
                    continue;
                }
            
            if(a == "MD5")
            {
                Console.WriteLine("Input string to be hashed using MD5:");
                String inputed = Console.ReadLine();
                Console.WriteLine("MD5: {0}", computeMD5(inputed));
                    continue;
            }

             Console.WriteLine("Command not recognized, try again.");
            }
            
        }

        public static String computeHash(String toBeHashed)
        {
            String hashString = "";
            using (sha = new SHA256Managed())
            {
                byte[] stringBytes = Encoding.UTF8.GetBytes(toBeHashed);
                foreach (byte x in stringBytes)
                {
                    hashString += String.Format("{0:x2}", x);
                }
                return hashString;
            }
        }

        public static Boolean compareHash(String hash1, String hash2)
        {
            if (String.Compare(hash1, hash2) == 0)
                return true;
            else
                return false;
        }

        public static String computeMD5(String hash1)
        {
            String hashString = "";

            using (md5 = MD5.Create())
            {
                byte[] input = Encoding.UTF8.GetBytes(hash1);
                byte[] hashedInput = md5.ComputeHash(input);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashedInput.Length; i++)

                {

                    sb.Append(hashedInput[i].ToString("X2"));

                }

                return sb.ToString();
            }
        }
    }
}
