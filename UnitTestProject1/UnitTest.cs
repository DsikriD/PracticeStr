
using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void ZipStrLinq()
        {
            string str = "xxxcccv";
            string resulat_wait = "x3c3v";
            str = Mystr.ZipStrLinq(str);

            Assert.AreEqual(resulat_wait, str);

        }

        [TestMethod]
        public void ZipStr()
        {
            string str = "xxxcccv";
            string resulat_wait = "x3c3v"; 
            str = Mystr.ZipStr(str);

            Assert.AreEqual(resulat_wait, str);

        }

       

        [TestMethod]
        public void FullLinqZip()
        {
            string str = "xxxcccv";
            string resulat_wait = "x3c3v";
            str = Mystr.FullLinqZip(str);

            Assert.AreEqual(resulat_wait, str);

        }

        [TestMethod]
        public void DeZipStr()
        {
            string str = "x3c3v"; 
            string resulat_wait = "xxxcccv";
            str = Mystr.DeZipStr(str);

            Assert.AreEqual(resulat_wait, str);

        }

        [TestMethod]
        public void DeZipStrLinq()
        {
            string str = "x3c3v";
            string resulat_wait = "xxxcccv";
            str = Mystr.DeZipStrLinq(str);

            Assert.AreEqual(resulat_wait, str);

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
                return $"{str.Substring(0, count - 1)}";

            var number = GetNumber(str.Substring(count));// получаем число символов, если символ 1 то 0,если страка пустая то -1

            return $"{str.Substring(0, count - 1)}{RepeatChatToStr(str[count - 1], number - 1)}" + DeZipStrLinq(str.Substring(count + number.ToString().Length));
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
