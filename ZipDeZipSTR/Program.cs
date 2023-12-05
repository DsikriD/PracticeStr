using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;

namespace ZipDeZipSTR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mystr.Str = "zc3g5c";
            //Console.WriteLine(Mystr.Str);
            ////Console.WriteLine(Mystr.Str);
            //Console.WriteLine(Mystr.ZipStrLinq(Mystr.Str));

            //Mystr.Str = Mystr.ZipStr(Mystr.Str);
            //Console.WriteLine(Mystr.Str);

            //Console.WriteLine(Mystr.DeZipStrLinq(Mystr.Str));

            //Console.WriteLine(Mystr.FullLinqZip(Mystr.Str));
            Console.WriteLine(Mystr.FullLinqZip(Mystr.Str));

            //Mystr.Str = Mystr.DeZipStr(Mystr.Str);
            //Console.WriteLine(Mystr.Str);   
        }
    }

    public static class Mystr
    {
        public static string ?Str {get;set;}

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
            foreach(var x in str)
            {
                if (x != str[0])
                    break;

                counter++;
            }

            return $"{str[0]}{OneElem(counter)}" + ZipStr(str[(counter)..]);//рекурсивный вызов функции 
        }

        public static string DeZipStr(string str)
        {
            if (string.IsNullOrEmpty(str))// Если строка пустная воздращаем пустую строку
                return "";

            var counter = 0;
            var num = "";
            StringBuilder tempstr = new StringBuilder();

            foreach(var x in str)
            {
                if (char.IsNumber(x))
                {
                    while (counter<str.Length && char.IsNumber(str[counter]))
                        num += str[counter++];
                    tempstr.Append(new string(str[counter-num.Length-1], Int32.Parse(num)-1));
                    break;
                }
                tempstr.Append(x);
                counter++;
            }
            return $"{tempstr}" + DeZipStr(str[(counter)..]);
        }

        public static string ZipStrLinq(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var count = str.TakeWhile(x => x == str[0]).Count();

            return $"{str[0]}{OneElem(count)}" + ZipStrLinq(str[(count)..]) ;
        }

        public static string DeZipStrLinq(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var count = str.TakeWhile(x => !char.IsDigit(x)).Count();

            if (count == str.Length)// Когда неповторяющий последний символ
                return $"{str[..(count)]}";

            var number = GetNumber(str[(count)..]);// получаем число символов, если символ 1 то 0,если страка пустая то -1

            return $"{str[..(count)]}{RepeatChatToStr(str[count - 1], number-1)}" + DeZipStrLinq(str[(count+number.ToString().Length)..]);
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
            return (int)str.TakeWhile(x=>char.IsNumber(x)).Reverse().Sum(x=>char.GetNumericValue(x)*Math.Pow(10,++idx));
        }

        public static string FullLinqZip(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            return str.ToList().TakeWhile(x=>x == str[0]).GroupBy(x=>x).Select(x=> $"{x.First()}{OneElem(x.Count())}" + FullLinqZip(str.Remove(0,x.Count()))).First();
        }


    }

}