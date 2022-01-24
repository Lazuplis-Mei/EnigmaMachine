using static EnigmaMachine.StringExtension;

namespace EnigmaMachine
{
    internal static class EnigmaTool
    {
        public static (char L1, char L2)[] GenerateSwitchPairs(int count = 10)
        {
            if (count < 0 || count > 13)
                throw new ArgumentOutOfRangeException(nameof(count), "交换字母对至少0对，最多13对。");
            
            var result = new (char L1, char L2)[count];
            var list = new List<char>(ALPHABET);
            for (int i = 0; i < count; i++)
            {
                result[i].L1 = list.RandomRemove();
                result[i].L2 = list.RandomRemove();
            }
            return result;
        }

        public static (char L1, char L2)[] GenerateReflections() => GenerateSwitchPairs(13);


        public static string GeneratePattern()
        {
            return string.Concat(new List<char>(ALPHABET).Disorder());
        }

    }
}

