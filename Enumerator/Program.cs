using System.Reflection.Emit;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;

internal class Program
{
    static void Main(string[] args)
    {
        MyEnumerator.PrintEnem(MyEnumerator.GenerateEnum("zxcz3dsfq"));
        Console.WriteLine(MyEnumerator.IsNumberExist("zxc4nvxze".GetEnumerator()));
        MyEnumerator.PrintEnem(MyEnumerator.SearchAllNumber("123vxzc".GetEnumerator()));

        MyEnumerable.PrintEnem(MyEnumerable.GenerateEnum("zxcz3dsfq"));
        Console.WriteLine(MyEnumerable.IsNumberExist("zxc4nvxze"));
        MyEnumerable.PrintEnem(MyEnumerable.SearchAllNumber("123vxzc"));
    }

    public static class MyEnumerator
    {
        public static IEnumerator<object> GenerateEnum(string str)
        {
            foreach (var a in str)
                yield return a;
        }

        public static void PrintEnem(IEnumerator<object> EnumOdject)
        {
            while (EnumOdject.MoveNext())
                Console.Write(EnumOdject.Current);
            Console.WriteLine();
        }

        public static bool IsNumberExist(IEnumerator<char> Enum)
        {
            while (Enum.MoveNext())
                if (char.IsNumber(Enum.Current))
                    return true;

            return false;
        }

        public static IEnumerator<object> SearchAllNumber(IEnumerator<char> EnumObject)
        {
            while (EnumObject.MoveNext())
                if (char.IsNumber(EnumObject.Current))
                    yield return EnumObject.Current;
        }
    }

    public class MyEnumerable
    {
        public static IEnumerable<object> GenerateEnum(string str)
        {
            foreach (var a in str)
                yield return a;
        }

        public static void PrintEnem(IEnumerable<object> EnumObject)
        {
            EnumObject.ToList().ForEach(x => Console.WriteLine(x));
        }

        public static void PrintEnemV(IEnumerable<object> EnumObject)
        {
            foreach(var obj in EnumObject)
            {
                Console.WriteLine(obj);
            }
        }


            public static bool IsNumberExist(IEnumerable<char> Enum)
            {
                return Enum.Where(x => char.IsDigit(x)).Any();
            }

        public static IEnumerable<object> SearchAllNumber(IEnumerable<char> EnumObject)
        {
           foreach(var obj in EnumObject)
                if (char.IsNumber(obj))
                    yield return obj;
        }

    }

}


   