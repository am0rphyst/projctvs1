using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace projctvs1
{
    class SaltHash
    {
        public static string getHash(string plainText, string hashAlgo, byte[] saltBytes)
        {
            saltBytes = null;
            if (saltBytes == null)
            {
                int minSalt = 5;
                int maxSalt = 8;

                Random rnd = new Random();
                int saltSize = rnd.Next(minSalt, maxSalt);

                saltBytes = new byte[saltSize];

                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                rng.GetNonZeroBytes(saltBytes);
            }

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

            for (int x = 0; x < plainTextBytes.Length; x++)
                plainTextWithSaltBytes[x] = plainTextBytes[x];

            for (int x = 0; x < saltBytes.Length; x++)
                plainTextWithSaltBytes[plainTextBytes.Length + x] = saltBytes[x];

            HashAlgorithm hash;

            if(hashAlgo == null)
            { 
                hashAlgo = "";
            }
          
        
            hash = new SHA256Managed();

            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

            for (int x = 0; x < hashBytes.Length; x++)
                hashWithSaltBytes[x] = hashBytes[x];

            for (int x = 0; x < saltBytes.Length; x++)
                hashWithSaltBytes[hashBytes.Length + x] = saltBytes[x];

            string hashValue =  Convert.ToBase64String(hashWithSaltBytes);

            return hashValue;

        }

        public static bool compareHash(string plainText, string hashAlgo, string hashValue)
        {
            
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            int hashSizeInBits, hashSizeInBytes;

           
            if (hashAlgo == null)
                hashAlgo = "";

            hashSizeInBits = 256;
            hashSizeInBytes = hashSizeInBits / 8;

            if (hashWithSaltBytes.Length < hashSizeInBytes)
            {
                return false;
            }

            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            for (int x = 0; x < saltBytes.Length; x++)
                saltBytes[x] = hashWithSaltBytes[hashSizeInBytes + x];

            string comparingHashString = getHash(plainText, hashAlgo, saltBytes);

            return (hashValue == comparingHashString);

        }


    }
}