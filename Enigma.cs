using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnigmaMachine.StringExtension;

namespace EnigmaMachine
{
    public class Enigma
    {
        public static readonly Enigma Default = new(EnigmaConfig.Default);

        public readonly EnigmaConfig Config;
        private BaseTickCounter keyCounter;
        public Enigma(EnigmaConfig config)
        {
            Config = config;
        }

        private static BaseTickCounter GetKeyCounter(string key)
        {
            if (key.Length != 3 || !key.IsPureUpperLetters())
                throw new ArgumentException("密钥不是3个大写字母");

            var result = new byte[3];
            result[0] = (byte)ALPHABET.IndexOf(key[0]);
            result[1] = (byte)ALPHABET.IndexOf(key[1]);
            result[2] = (byte)ALPHABET.IndexOf(key[2]);
            return new BaseTickCounter(result, 26);
        }

        public string Encrypt(string text, string key)
        {
            if (!text.IsPureUpperLetters())
                throw new FormatException($"文本不是纯英文大写字母构成");

            keyCounter = GetKeyCounter(key);

            var encryptText = new StringBuilder(text.Length);

            foreach (var letter in text)
            {
                encryptText.Append(InternalEncrypt(letter));
            }

            return encryptText.ToString();
        }

        private char InternalEncrypt(char letter)
        {
            keyCounter++;
            var temp = Config.GetSwitchedLetter(letter);
            temp = Config.EnterPatten3(temp, keyCounter[2]);
            temp = Config.EnterPatten2(temp, keyCounter[1]);
            temp = Config.EnterPatten1(temp, keyCounter[0]);
            temp = Config.GetReflectedLetter(temp);
            temp = Config.OutPatten1(temp, keyCounter[0]);
            temp = Config.OutPatten2(temp, keyCounter[1]);
            temp = Config.OutPatten3(temp, keyCounter[2]);
            return Config.GetSwitchedLetter(temp);
        }

        public string Decrypt(string text, string key) => Encrypt(text, key);

    }
}

