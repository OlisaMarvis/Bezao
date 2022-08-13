using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaDecrptConsoleUI
{
    public class Program
    {
        //public static Char[] alphabets = new char[]
        public static List<Char> alphabets = new List<Char>()
        {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        //public static Char[] encodedletters = new char[]
        public static List<Char> encodedletters = new List<Char>()

        {'#','*','%','&','>','<','!',')','"','(','@','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o'};


         static void Main(string[] args)
        {
            Console.WriteLine("Put letters you wish to decrypt");
            var wordToDecrypt = Console.ReadLine();
            Console.WriteLine(DecryptMessage($"{wordToDecrypt}"));
            //Console.ReadLine();
        }


        public static  string DecryptMessage(string encodedMessage)
        {
            char[] result = new char[] { };
            char[] value = new char[] { };
            var decryptString = "";
            var encodedMessageLetters = encodedMessage.ToArray();

            for(var i = 0; i < encodedMessageLetters.Length; i++)
            {
                for (var j = 0; j < encodedletters.ToArray().Length; j++)
                {
                    if (encodedMessageLetters[i] == encodedletters[j])
                    {
                        var index = encodedletters.ToList().FindIndex(a => a == encodedletters[j]);

                        decryptString += alphabets[index];
                        //for(int k= 0; k <= alphabets.ToArray().Length; k++)
                        //{

                        //}
                        //continue;

                    }
                    else
                    {

                    } 
                }
            }

            //for (int i = 0; i < encodedMessageLetters.Length; i++)
            //{

            //    output += encodedMessageLetters[i];
            //    result = output.ToArray();

            //}
            //List<char> num = new List<char>();
            //for (int i = 0; i < result.Length; i++)
            //{
            //    num.Add(result[i]);
            //    value = num.ToArray();

            //}

            //value.ToList();
            //List<int> numbers = new List<int>();
            //numbers.Clear();
            //foreach (var item in value)
            //{

            //    numbers.Add(encodedletters.ToList<char>().IndexOf(item));

            //}

            //string finalAns = "";
            //foreach (var number in numbers)
            //{
            //    finalAns += alphabets[number].ToString();
            //}

            return decryptString;
        }
    }


}
