using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Adv_03
{

    public delegate bool CustomFunc<T1 , T2 , Tresult>(T1 arg01 , T2 arg02);
    internal class SortingAlgorithms<T>
    {


            public static void BubbleSort(T[] Numbers , CustomFunc<T ,T , bool> func)
        {
            if (Numbers is null || func is null) return;

            for (int i = 0; i < Numbers.Length; i++)
            {
                for (int j = 0; j < Numbers.Length - 1 - i; j++)
                {
                    // if(comparer.Compare(Numbers[j] , Numbers[j+1]))
                    //if (Numbers[j] > Numbers[j + 1])
                    if (func?.Invoke(Numbers[j], Numbers[j + 1]);
                  
                        SWAP(ref Numbers[j], ref Numbers[j + 1]);
                }

            }
        }
        private static void SWAP(ref int x, ref int y)
        {
            int Temp = x;
            x = y;
            y = Temp;
        }

        class SortingTypes
        {
            public static bool ComapareGrt(int x, int y) => x > y; // sort asc
            public static bool CompareGrt(int x, int y) => x.CompareTo(y) == 1; // sort dec

            public static bool ComapareLes(int x, int y) => x< y; // sort asc
            public static bool CompareLes(int x, int y) => x.CompareTo(y) == -1; // sort dec
        }

    }
}
