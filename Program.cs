using System.Net.Http.Headers;

namespace C__Adv_03
{
    // step 0. Delegate Declaration
    public delegate int CustomFunc(string arg01);

    // New Delegate ( Class ) , the Reference from this Delegate can Refer to a Functuin or more
    // these functions Can be Class Member [ static] or Object Member [ Non- Static]
    // these Functions must have the same signature of the delegate : int ( string)
    // Regardles Function Access Modifier RegardLess Naming (function , Parameters).

    public delegate bool CustomPredicate(int Obj);
    internal class Program
    {
        public static List<int> FindNumbers<T>(List<int> Numbers , CustomPredicate predicate )
        {
            List<int> Result = new List<int>();

            if (Numbers?.Count > 0)
            {
                foreach (int number in Numbers)
                //    if (number % 2 == 1)
                if(predicate(number))
                        Result.Add(number);
            }
            return Result;
        }

      //  public static List<int> FindEvens(List<int> Numbers)
     //   {
     //       List<int> Result = new List<int>();
     //
     //       if (Numbers?.Count > 0)
     //       {
     //           foreach (int number in Numbers)
     //               if (number % 2 == 0)
     //                   Result.Add(number);
     //       }
     //       return Result;
     //   }
        static void Main(string[] args)
        {

            /// Delegate is a C# Language Feature
            /// Has 2 Usages :
            /// 1. Functional Programming 
            /// 2. Event-Driven Programming
            /// 


            #region Delegate Example 01


            // stet 1. Declare Delegate Reference

            CustomFunc reference;

            // step 2. Initialize the Delegate Reference [ Pointer to Function ]
            reference = new CustomFunc(StringFunctions.GetCountOfUpperCaseChars);

           reference = StringFunctions.GetCountOfUpperCaseChars; // syntax sugar

            reference += StringFunctions.GetCoutOfLowerCaseChars;

            reference -= StringFunctions.GetCountOfUpperCaseChars;

            // step 3. use the delegate reference
            int Result = reference.Invoke("Bassem Khaled");
            Result = reference("Bassem khaled"); // syntax sugar

            Console.WriteLine($"Resu;t = {Result}");

            #endregion

            #region Delegate Example 02
            // int[] Numbers = { 1, 2, 3 , 6 ,7  ,8, 0 ,5};
            //
            // CustomFunc<int> func = SortingTypes.ComareGet;
            // SortingAlgorithms.BubbleSort(Numbers, func);
            ////SortingAlgorithms.BubbleSort(Numbers, (x, y) => x > y);
            //
            //
            // foreach (var numbers in Numbers) 
            //                 {
            //     Console.WriteLine(Numbers);
            // }
            //

            ///  string[ ]  Names = [ "Omar" , "Nada" , "Amer" , " Bassem" , " Ahmed" , "Yaml"]
            ///
            ///  CustomFunc<string, string, bool> func02 = ComparsionTypes.Compareless;         
            ///  SortingAlgorithms<string>.BubbleSort(Names, func02);
            ///
            ///  foreach(string Name in Names)
            ///      Console.WriteLine(Name);
            #endregion

            #region Delegate Example 03

            List<int> Numbers = Enumerable.Range(0, 100).ToList(); // 0..99

            CustomPredicate predicate = ConditionFunctions.IsOdd;
            #region Find Odd


            List<int> Odds = FindNumbers(Numbers , ConditionFunctions.IsOdd);

            foreach(int number in Odds) 
                Console.WriteLine(number);

            Console.WriteLine();
            Console.WriteLine();

            #endregion

            #region find Even
            List<int> Evens = FindNumbers(Numbers, ConditionFunctions.IsEven);

            foreach (int number in Evens)
                Console.WriteLine(number);

            Console.WriteLine();
            Console.WriteLine();

            #endregion

            #region find Seven
            List<int> NumberDivisibleBySeven = FindNumbers(Numbers, ConditionFunctions.NumberDivisibleBySeven);

                  foreach (int number in NumberDivisibleBySeven)
                Console.WriteLine(number);

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Find NAmes with legth more than 04
         //  List<string> Names = new List<string>(10) { "Ahmed ", " Nadia", "BASSEM", "Mahmoud" };
         //
         //  List<string> NamesWithLenghtMoreThan04 = FindNumbers<T>(Names, ConditionFunctions.IsLengthEquals04);
         //
         //  foreach (int number in NamesWithLenghtMoreThan04)
         //      Console.WriteLine(number);
         //
         //  Console.WriteLine();
         //  Console.WriteLine();


            #endregion

            #endregion







        }


    }

    class StringFunctions
    {
        public static int GetCountOfUpperCaseChars(string Name)
        {
            Console.WriteLine("GetCountOfUpperCaseChars");
            int Count = 0;
            for (int i = 0; i < Name.Length; i++)
            {
                if (char.IsUpper(Name[i]))
                    Count++;
            }
            return Count;

        }

        public static int GetCoutOfLowerCaseChars(string Name) 
        {
            Console.WriteLine("GetCountOfUpperCaseChars");
            int Count = 0;
            for (int i = 0; i < Name.Length; i++)
            {
                if (char.IsLower(Name[i]))
                    Count++;
            }
            return Count;

        }
    }

    class ConditionFunctions
    {
        public static bool IsOdd(int Number) => Number % 2 == 1;
        public static bool IsEven( int Number) => Number %2 == 0;
        public static bool NumberDivisibleBySeven(int Number) => Number % 7 == 0;

        public static bool IsLengthEquals04(string Name) => Name?.Length > 4;
    }

}

