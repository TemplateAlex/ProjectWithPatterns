using System;
using System.Collections.Generic;

namespace ForAizhulov.Patterns
{
    internal interface ICipher
    {
        string Encrypt(string word);
        string Decrypt(string word);
    }

    internal class FirstCipher: ICipher
    {
        public string Encrypt(string word)
        {
            return word;
        }

        public string Decrypt(string word)
        {
            return word;
        }
    }

    internal class SecondCipher: ICipher
    {
        public string Encrypt(string word)
        {
            return word;
        }

        public string Decrypt(string word)
        {
            return word;
        }
    }
}
