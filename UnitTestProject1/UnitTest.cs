
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        //[TestMethod]
        //public void ZipStrLinq()
        //{
        //    string str = "xxxcccv";
        //    string resulat_wait = "x3c3v";
        //    str = Mystr.ZipStrLinq(str);

        //    Assert.AreEqual(resulat_wait, str);

        //}

        //[TestMethod]
        //public void ZipStr()
        //{
        //    string str = "xxxcccv";
        //    string resulat_wait = "x3c3v"; 
        //    str = Mystr.ZipStr(str);

        //    Assert.AreEqual(resulat_wait, str);

        //}



        //[TestMethod]
        //public void FullLinqZip()
        //{
        //    string str = "xxxcccv";
        //    string resulat_wait = "x3c3v";
        //    str = Mystr.FullLinqZip(str);

        //    Assert.AreEqual(resulat_wait, str);

        //}

        //[TestMethod]
        //public void DeZipStr()
        //{
        //    string str = "x3c3v"; 
        //    string resulat_wait = "xxxcccv";
        //    str = Mystr.DeZipStr(str);

        //    Assert.AreEqual(resulat_wait, str);

        //}

        //[TestMethod]
        //public void DeZipStrLinq()
        //{
        //    string str = "x3c3v";
        //    string resulat_wait = "xxxcccv";
        //    str = Mystr.DeZipStrLinq(str);

        //    Assert.AreEqual(resulat_wait, str);

        //}

        [TestMethod]
        public void GenerateEnumMyEnumerator()
        {
            MyEnumerator.GenerateEnum("1232132131213");
        }

        [TestMethod]
        public void PrintEnemMyEnumerator()
        {
            MyEnumerator.PrintEnem(MyEnumerator.SearchAllNumber("123vxzc".GetEnumerator()));
        }

        [TestMethod]
        public void IsNumberExistMyEnumerator()
        {
            MyEnumerator.IsNumberExist("zxc4nvxze".GetEnumerator());
        }

        [TestMethod]
        public void SearchAllNumberMyEnumerator()
        {
            MyEnumerator.SearchAllNumber("zxc4nvxze".GetEnumerator());
        }

        [TestMethod]
        public void GenerateEnumMyEnumerable()
        {
            MyEnumerable.GenerateEnum("1232132131213");
        }

        [TestMethod]
        public void PrintEnemMyEnumerable()
        {
            MyEnumerable.PrintEnem(MyEnumerable.SearchAllNumber("123vxzc"));
        }

        [TestMethod]
        public void Print_V2_MyEnumerable()
        {
            MyEnumerable.PrintEnemV(MyEnumerable.SearchAllNumber("123vxzc"));
        }

        [TestMethod]
        public void IsNumberExistMyEnumerable()
        {
            MyEnumerable.IsNumberExist("zxc4nvxze");
        }

        [TestMethod]
        public void SearchAllNumberMyEnumerable()
        {
            MyEnumerable.SearchAllNumber("zxc4nvxze");
        }

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
        public static IEnumerable<object> GenerateEnum(string str)//5мс
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
            foreach (var obj in EnumObject)
            {
                Console.WriteLine(obj);
            }
        }


        public static bool IsNumberExist(IEnumerable<char> Enum)//2мс
        {
            return Enum.Where(x => char.IsDigit(x)).Any();
        }

        public static IEnumerable<object> SearchAllNumber(IEnumerable<char> EnumObject)
        {
            foreach (var obj in EnumObject)
                if (char.IsNumber(obj))
                    yield return obj;
        }

    }







    public static class Mystr
    {
        public static string Str { get; set; }

        public static string SerchCountChar()
        {
            return string.Join("",
                Str.ToCharArray().
                 GroupBy(x => x).
                     Select(g => g.Key.ToString() + OneElem(g.Count())));
        }

        private static string OneElem(int i) => i > 1 ? i.ToString() : "";

        public static string ZipStr(string str)
        {
            if (string.IsNullOrEmpty(str))// Если строка пустная воздращаем пустую строку
                return "";

            var counter = 0;
            foreach (var x in str)
            {
                if (x != str[0])
                    break;

                counter++;
            }

            return $"{str[0]}{OneElem(counter)}" + ZipStr(str.Substring(counter));//рекурсивный вызов функции 
        }

        public static string DeZipStr(string str)
        {
            if (string.IsNullOrEmpty(str))// Если строка пустная воздращаем пустую строку
                return "";

            var counter = 0;
            var num = "";
            StringBuilder tempstr = new StringBuilder();

            foreach (var x in str)
            {
                if (char.IsNumber(x))
                {
                    while (counter < str.Length && char.IsNumber(str[counter]))
                        num += str[counter++];
                    tempstr.Append(new string(str[counter - num.Length - 1], Int32.Parse(num) - 1));
                    break;
                }
                tempstr.Append(x);
                counter++;
            }
            return $"{tempstr}" + DeZipStr(str.Substring(counter));
        }

        public static string ZipStrLinq(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var count = str.TakeWhile(x => x == str[0]).Count();

            return $"{str[0]}{OneElem(count)}" + ZipStrLinq(str.Substring(count));
        }

        public static string DeZipStrLinq(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var count = str.TakeWhile(x => !char.IsDigit(x)).Count();

            if (count == str.Length)// Когда неповторяющий последний символ
                return $"{str.Substring(0, count)}";

            var number = GetNumber(str.Substring(count));// получаем число символов, если символ 1 то 0,если страка пустая то -1

            return $"{str.Substring(0, count)}{RepeatChatToStr(str[count - 1], number - 1)}" + DeZipStrLinq(str.Substring(count + number.ToString().Length));
        }

        private static string RepeatChatToStr(char symbol, int count)
        {
            try
            {
                return new string(symbol, count);
            }
            catch
            {
                return "";
            }
        }

        public static int GetNumber(string str)
        {
            if (string.IsNullOrEmpty(str))
                return -1;

            int idx = -1;
            return (int)str.TakeWhile(x => char.IsNumber(x)).Reverse().Sum(x => char.GetNumericValue(x) * Math.Pow(10, ++idx));
        }

        public static string FullLinqZip(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            return str.ToList().TakeWhile(x => x == str[0]).GroupBy(x => x).Select(x => $"{x.First()}{OneElem(x.Count())}" + FullLinqZip(str.Remove(0, x.Count()))).First();
        }


    }


}
