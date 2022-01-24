using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
    internal static class RandomHelper
    {
        private static readonly Random rnd = new();
        public static T RandomRemove<T>(this List<T> list)
        {
            int ri = rnd.Next(list.Count);
            var result = list[ri];
            list.RemoveAt(ri);
            return result;
        }

        public static List<T> Disorder<T>(this List<T> list)
        {
            var result = new List<T>(list.Count);
            for (int i = 0; i < result.Capacity; i++)
            {
                result.Add(list.RandomRemove());
            }
            return result;
        }
    }

}
