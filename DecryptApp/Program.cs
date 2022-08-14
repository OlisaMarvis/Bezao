using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaDecrptConsoleUI
{
    public class Program
    {
        public static List<Char> alphabets = new List<Char>()
        {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        public static List<Char> encodedletters = new List<Char>()

        {'#','*','%','&','>','<','!',')','"','(','@','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o'};


         static void Main(string[] args)
        {
            Console.WriteLine("Put letters you wish to decrypt");
            var wordToDecrypt = Console.ReadLine();
            Console.WriteLine(DecryptMessage($"{wordToDecrypt}"));
        }


        public static  string DecryptMessage(string encodedMessage)
        {
            
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
                        

                    }
                    else
                    {

                    } 
                }
            }

            
            return decryptString;
        }
    }


}
