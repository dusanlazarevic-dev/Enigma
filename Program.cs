using System;

namespace EnigmaConsoleP
{
    class Program
    {
        static void Main(string[] args)
        {
            ERotor rI = new ERotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'A', null, 'Q', 'A'); // letters | pos | nextRot | notchPos | ringSet
            ERotor rII = new ERotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'A', rI, 'E', 'A');
            ERotor rIII = new ERotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', rII, 'V', 'A');


            Reflector rB = new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");

            Enigma e = new Enigma(rI, rII, rIII, rB);
            rI.e = rII.e = rIII.e = e;


            string encodedText = e.EncodeText("RXJ");
            Console.WriteLine("Encoded text:" + encodedText);


        }
    }
}
