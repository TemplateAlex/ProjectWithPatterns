using System;
using System.Collections.Generic;
using System.Text;

namespace ForAizhulov.Patterns
{
    internal interface ICipher
    {
        string Encrypt(string word);
        string Encrypt(string word, string key);
        string Encrypt(string word, int key);
        string Decrypt(string word);
        string Decrypt(string word, string key);
    }

    internal class VisinerCipher : ICipher
    {
        public string Encrypt(string word)
        {
            return "";
        }
        public string Encrypt(string word, string key)
        {
            StringBuilder sbWord = new StringBuilder(word);
            StringBuilder sbKey = new StringBuilder(key);
            StringBuilder sbResult = new StringBuilder();

            int wallForKey = 0;
            int lengthSbKey = sbKey.Length;

            if (sbWord.Length > sbKey.Length)
            {
                for (int i = lengthSbKey; i < sbWord.Length; i++)
                {
                    if (wallForKey >= lengthSbKey) wallForKey = 0;
                    sbKey.Append(sbKey[wallForKey]);
                    wallForKey++;
                }
            }


            for (int i = 0; i < sbWord.Length; i++)
            {
                char modifiedChar;
                int delta = (int)sbKey[i] - (int)'a';

                if (delta + sbWord[i] > (int)'z')
                {
                    modifiedChar = (char)(delta - ((int)'z' - (int)sbWord[i]) + (int)'a');
                }
                else modifiedChar = (char)((int)sbWord[i] + delta);

                sbResult.Append(modifiedChar);
            }

            return sbResult.ToString();
        }

        public string Decrypt(string word)
        {
            return "";
        }

        public string Encrypt(string word, int key)
        {
            return "";
        }

        public string Decrypt(string word, string key)
        {
            throw new NotImplementedException();
        }
    }

    internal class AtbashCipher : ICipher
    {
        public string Decrypt(string word)
        {
            return "";
        }

        public string Decrypt(string word, string key)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string word)
        {
            return "";
        }

        public string Encrypt(string word, string key)
        {
            StringBuilder sbResult = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                sbResult.Append((char)((int)'z' - ((int)word[i] - (int)'a')));
            }

            return sbResult.ToString();
        }

        public string Encrypt(string word, int key)
        {
            return "";
        }
    }

    internal class XORCipher : ICipher
    {
        public string Decrypt(string word)
        {
            return "";
        }

        public string Decrypt(string word, string key)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string word)
        {
            return "";
        }

        public string Encrypt(string word, string key)
        {
            return "";
        }

        public string Encrypt(string word, int key)
        {
            StringBuilder sbResult = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                int codeASCIIForChangedChar = (int)((int)word[i] ^ key);
                sbResult.Append((char)codeASCIIForChangedChar);
            }

            return sbResult.ToString();
        }
    }

    internal class ADFGXCipher : ICipher
    {
        public string Decrypt(string word)
        {
            return "";
        }

        public string Decrypt(string word, string key)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string word)
        {
            return "";
        }

        public string Encrypt(string word, string key)
        {
            StringBuilder sbResult = new StringBuilder("");
            StringBuilder firstStepString = new StringBuilder();

            char[,] cipherMatrix = new char[6, 6] { {'-', 'a', 'd', 'f', 'g', 'x' },
                                                    {'a', 'f', 'n', 'h', 'e', 'q' },
                                                    {'d', 'r', 'd', 'z', 'o', 'c' },
                                                    {'f', 'i', 's', 'a', 'g', 'u' },
                                                    {'g', 'b', 'v', 'k', 'p', 'w'},
                                                    {'x', 'x', 'm', 'y', 't', 'l'} };

            for (int i = 0; i < word.Length; i++)
            {
                char tmpChar = word[i];

                for (int j = 1; j < 6; j++)
                {
                    for (int k = 1; k < 6; k++)
                    {
                        if (cipherMatrix[j, k] == tmpChar)
                        {
                            firstStepString.Append(cipherMatrix[j, 0]);
                            firstStepString.Append(cipherMatrix[0, k]);
                        }
                    }
                }
            }

            if (key == null) key = "";

            int lengthKey = key.Length;

            int tmpRows = (int)Math.Ceiling((double)firstStepString.Length / (double)lengthKey);
            int wall = 0;

            char[,] secondCipherMatrix = new char[tmpRows + 1, lengthKey];

            for (int i = 0; i < lengthKey; i++)
            {
                secondCipherMatrix[0, i] = key[i];
            }

            for (int i = 1; i < tmpRows + 1; i++)
            {
                for (int j = 0; j < lengthKey; j++)
                {
                    if (wall < firstStepString.Length) secondCipherMatrix[i, j] = firstStepString[wall];
                    else secondCipherMatrix[i, j] = 'x';
                    wall++;
                }
            }

            bool flag = true;

            while (flag)
            {
                flag = false;

                for (int i = 1; i < lengthKey; i++)
                {
                    if ((int)secondCipherMatrix[0, i - 1] > (int)secondCipherMatrix[0, i])
                    {
                        for (int j = 0; j < tmpRows + 1; j++)
                        {
                            char tmp = secondCipherMatrix[j, i - 1];
                            secondCipherMatrix[j, i - 1] = secondCipherMatrix[j, i];
                            secondCipherMatrix[j, i] = tmp;
                        }
                        flag = true;
                    }
                }

            }


            for (int i = 0; i < lengthKey; i++)
            {
                for (int j = 1; j < tmpRows + 1; j++)
                {
                    sbResult.Append(secondCipherMatrix[j, i]);
                }
            }

            return sbResult.ToString();
        }

        public string Encrypt(string word, int key)
        {
            return "";
        }
    }
}
