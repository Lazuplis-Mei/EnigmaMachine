namespace EnigmaMachine
{
    public class EnigmaConfig
    {
        private const string defaultPattern1 = "VORBFEZSGYAPWMNHTXJLKUQCID";
        private const string defaultPattern2 = "EINYJTPSXLAVRCFQGMHKUZWDOB";
        private const string defaultPattern3 = "STQFBKRIVHALXUENWODGPYCMJZ";
        private static readonly (char L1, char L2)[] defaultSwitchPairs = {
            ('F', 'G'), ('D', 'E'), ('U', 'B'), ('C', 'Z'), ('Y', 'I'),
            ('X', 'N'), ('J', 'T'), ('A', 'S'), ('V', 'H'), ('R', 'Q')
        };
        private static readonly (char L1, char L2)[] defaultReflection = {
            ('H', 'Q'), ('J', 'W'), ('Y', 'L'), ('I', 'K'), ('V', 'Z'),
            ('U', 'N'), ('A', 'R'), ('M', 'E'), ('T', 'X'), ('D', 'S'),
            ('B', 'P'), ('F', 'O'), ('G', 'C')
        };

        public static readonly EnigmaConfig Default = new();

        public string Pattern1 { get; init; }
        public string Pattern2 { get; init; }
        public string Pattern3 { get; init; }
        public (char L1, char L2)[] SwitchPairs { get; init; }
        public (char L1, char L2)[] Reflection { get; init; }

        public EnigmaConfig()
        {
            SwitchPairs = defaultSwitchPairs;
            Pattern1 = defaultPattern1;
            Pattern2 = defaultPattern2;
            Pattern3 = defaultPattern3;
            Reflection = defaultReflection;
        }

        internal char GetSwitchedLetter(char letter)
        {
            foreach (var (L1, L2) in SwitchPairs)
            {
                if (letter == L1) return L2;
                if (letter == L2) return L1;
            }
            return letter;
        }

        internal char EnterPatten1(char letter, byte offset)
        {
            return Pattern1.MapedLetter(letter, offset);
        }
        internal char OutPatten1(char letter, byte offset)
        {
            return Pattern1.InversedLetter(letter, offset);
        }

        internal char EnterPatten2(char letter, byte offset)
        {
            return Pattern2.MapedLetter(letter, offset);
        }
        internal char OutPatten2(char letter, byte offset)
        {
            return Pattern2.InversedLetter(letter, offset);
        }

        internal char EnterPatten3(char letter, byte offset)
        {
            return Pattern3.MapedLetter(letter, offset);
        }
        internal char OutPatten3(char letter, byte offset)
        {
            return Pattern3.InversedLetter(letter, offset);
        }

        internal char GetReflectedLetter(char letter)
        {
            foreach (var (L1, L2) in Reflection)
            {
                if (letter == L1) return L2;
                if (letter == L2) return L1;
            }
            return letter;
        }

    }
}

