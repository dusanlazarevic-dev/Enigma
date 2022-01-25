using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaConsoleP
{
    public class Enigma
    {
        static public ERotor Alphabet = new ERotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 'A', null, '0');
        public ERotor R1 { get; set; }
        public ERotor R2 { get; set; }
        public ERotor R3 { get; set; }

        public Reflector LetterReflector { get; set; }
        public Enigma(ERotor r1, ERotor r2, ERotor r3, Reflector letterReflector)
        {
            this.R1 = r1;
            this.R2 = r2;
            this.R3 = r3;
            this.LetterReflector = letterReflector;
        }

        public string PrintRotors()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 26; i++)
                output.AppendFormat("\n{0}|{1}|{2}|{3}|||{4}", R1.ItemAt(i), R2.ItemAt(i), R3.ItemAt(i), Alphabet.ItemAt(i), LetterReflector.ReflectorLetters[Alphabet.ItemAt(i)]);
            return output.ToString() ;
        }

        public string EncodeText(string plainText)
        {
            StringBuilder encodedText = new StringBuilder();

            foreach(char c in plainText)
            {

                //char encodedLetter = R1.EncodeLetter(R2.EncodeLetter(R3.EncodeLetter(c)));
                char afterR3 = R3.EncodeLetter(c);
                //Console.WriteLine("After R3 " + afterR3);

                char afterR2 = R2.EncodeLetter(afterR3);
                //Console.WriteLine("After R2 " + afterR2);

                char afterR1 = R1.EncodeLetter(afterR2);
                //Console.WriteLine("After R1 " + afterR1);

                char encodedLetter = afterR1;

                char reflectedLetter = LetterReflector.ReflectLetter(encodedLetter);
               // Console.WriteLine("After reflect: " + reflectedLetter);

                //char inverseEncodedLetter = R3.EncodeLetterInv(R2.EncodeLetterInv(R1.EncodeLetterInv(reflectedLetter)));

                char afterR1in = R1.EncodeLetterInv(reflectedLetter);
               // Console.WriteLine("After R1 inv " + afterR1in);

                char afterR2in = R2.EncodeLetterInv(afterR1in);
               // Console.WriteLine("After R2 inv " + afterR2in);

                char afterR3in = R3.EncodeLetterInv(afterR2in);
               // Console.WriteLine("After R3 inv " + afterR3in);


                char inverseEncodedLetter = afterR3in;

                encodedText.Append(inverseEncodedLetter);
            }

            return encodedText.ToString() ;
        }

    }
}
