using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberTowordsConverter
{
    public class NumberToWords
    {
        private static String[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static String ConvertAmount(double amount)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return Convert(amount_int) + " Only.";
                }
                else
                {
                    return Convert(amount_int) + " Point " + Convert(amount_dec) + " Naira Only.";
                }
            }
            catch (Exception e)
            {
                // TODO: handle exception  
            }
            return "";
        }

        public static String Convert(Int64 i)
        {
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + Convert(i % 10) : "");
            }
            if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + Convert(i % 100) : "");
            }
            if (i < 100000)
            {
                return Convert(i / 1000) + " Thousand "
                        + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");
            }
            if (i < 1000000)
            {
                return Convert(i / 100000) + " Hundred"
                        + ((i % 100000 > 0) ? " And " + Convert(i % 100000) : "");
            }
            if (i < 100000000)
            {
                return Convert(i / 1000000) + " Million"
                        + ((i % 1000000 > 0) ? " " + Convert(i % 1000000) : "");
            }
            if (i < 1000000000)
            {
                return Convert(i / 100000000) + " Hundred  "
                        + ((i % 100000000 > 0) ? " And " + Convert(i % 100000000) : "");
            }
            if (i < 100000000000)
            {
                return Convert(i / 1000000000) + " Billion "
                    + ((i % 1000000000 > 0) ? " " + Convert(i % 1000000000) : "");
            }
            if (i < 1000000000000)
            {
                return Convert(i / 100000000000) + " Hundred  "
                    + ((i % 100000000000 > 0) ? " And " + Convert(i % 100000000000) : "");
            }
            return Convert(i / 1000000000000) + " Trillion "
                    + ((i % 1000000000000 > 0) ? " " + Convert(i % 1000000000000) : "");
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a Number to convert to words");
                string number = Console.ReadLine();
                number = ConvertAmount(double.Parse(number));
                Console.WriteLine("Number in words is \n{0}", number);

                Console.WriteLine("Enter a Number in words to convert to number");
                string numInWords = Console.ReadLine();

                var newNum = ConvertToNumbers(numInWords.ToLower());
                Console.WriteLine("Number in words is \n{0}", newNum);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public static long ConvertToNumbers(string numberString)
        {
            var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                    .Select(m => m.Value.ToLowerInvariant())
                    .Where(v => WordsToNumbers.numberTable.ContainsKey(v))
                    .Select(v => WordsToNumbers.numberTable[v]);
            long acc = 0, total = 0L;
            foreach (var n in numbers)
            {
                if (n >= 1000)
                {
                    total += acc * n;
                    acc = 0;
                }
                else if (n >= 100)
                {
                    acc *= n;
                }
                else acc += n;
            }
            return (total + acc) * (numberString.StartsWith("minus",
                    StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);
        }
    }

    public class WordsToNumbers
    {
        public static Dictionary<string, long> numberTable = new Dictionary<string, long>{
        {"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},{"five",5},{"six",6},
        {"seven",7},{"eight",8},{"nine",9},{"ten",10},{"eleven",11},{"twelve",12},
        {"thirteen",13},{"fourteen",14},{"fifteen",15},{"sixteen",16},{"seventeen",17},
        {"eighteen",18},{"nineteen",19},{"twenty",20},{"thirty",30},{"forty",40},
        {"fifty",50},{"sixty",60},{"seventy",70},{"eighty",80},{"ninety",90},
        {"hundred",100},{"thousand",1000},{"hundred thousand",100000},{"million",1000000},
        {"billion",1000000000},{"trillion",1000000000000},{"quadrillion",1000000000000000},
        {"quintillion",1000000000000000000}
    };

    }


}
