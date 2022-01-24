using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{

    internal struct BaseTickCounter
    {
        private readonly byte[] digits;
        private readonly byte nBase;
        public BaseTickCounter(byte[] arr, byte nBase)
        {
            if (nBase < 2)
                throw new ArgumentOutOfRangeException(nameof(nBase), "进制必须大于等于2");

            if (Array.FindIndex(arr, n => n >= nBase) >= 0)
                throw new ArgumentException($"不正确的{nBase}进制数", nameof(arr));

            digits = arr;
            this.nBase = nBase;
        }

        public static BaseTickCounter operator ++(BaseTickCounter counter)
        {
            var index = counter.digits.Length;
            counter.digits[--index]++;
            while (counter.digits[index] == counter.nBase)
            {
                counter.digits[index] = 0;
                if (index > 0)
                {
                    counter.digits[--index]++;
                }
            }
            return counter;
        }

        public static BaseTickCounter operator --(BaseTickCounter counter)
        {
            var index = counter.digits.Length;
            counter.digits[--index]--;
            while (counter.digits[index] == byte.MaxValue)
            {
                counter.digits[index] = (byte)(counter.nBase - 1);
                if (index > 0)
                {
                    counter.digits[--index]--;
                }
            }
            return counter;
        }

        public byte this[int index] => digits[index];

        public override string ToString() => string.Join(',', digits);

    }
}
