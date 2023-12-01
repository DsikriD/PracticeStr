using System.Diagnostics.Metrics;
using System.Formats.Asn1;

namespace ZipDeZipSTR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mystr.Str = "zcccccccczzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzxxxxxxxxxccuikkl";

            Console.WriteLine(Mystr.ZipStr(Mystr.Str));

            Console.WriteLine(Mystr.SerchCountChar());
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

        public static string DeZipStr()
        {
            return "";
        }



 
    }

}