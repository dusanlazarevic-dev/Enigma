using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaConsoleP
{
    public class ERotor
    {
        public Enigma e { get; set; }
        public int currentLetterIndex;
        public ERotor Next { get; set; }
        public string RotorLetters { get; set; }

        public char RotationNotch { get; set; }

        public int RotorRingSetting { get; set; }
        public ERotor(string letters, char currentLetter, ERotor next, char notch, char RotorRingSetting)
        {
            RotorLetters = letters;
            currentLetterIndex = currentLetter - 'A';
            this.Next = next;
            this.RotationNotch = notch;
            this.RotorRingSetting = RotorRingSetting - 'A';
        }

        public ERotor(string letters, int currentLetterIndex, ERotor next, char notch)
        {
            RotorLetters =  letters;
            this.currentLetterIndex = currentLetterIndex;
            this.Next = next;
            this.RotationNotch = notch;
        }

        public void Rotate()
        {
            currentLetterIndex = currentLetterIndex + 1;
            if (currentLetterIndex > 25) 
            currentLetterIndex = (currentLetterIndex % 25 ) - 1;
        }

        public char ItemAt(int index)
        {
            int calculatedIndex = currentLetterIndex + index ;
            if (calculatedIndex > 25)
                calculatedIndex = (calculatedIndex % 25) ;
            return RotorLetters[calculatedIndex];
        }

        public virtual char EncodeLetter(char letter)
        {
         
            if (this.Next != null && this.RotorLetters[currentLetterIndex] == RotationNotch) // each rotor rotates next when notch letter is reached
                this.Next.Rotate();
            Rotate();
            //Console.WriteLine(e.PrintRotors());
            int letterIndexInAlphabet = letter - 'A';

            letterIndexInAlphabet -= RotorRingSetting;
            if (letterIndexInAlphabet < 0)
                letterIndexInAlphabet = 26 - Math.Abs(letterIndexInAlphabet);


            int encodedLetterIndex = currentLetterIndex + letterIndexInAlphabet;
            if (encodedLetterIndex > 25)
                encodedLetterIndex = (encodedLetterIndex % 25) - 1;
            char encodedLetter = RotorLetters[encodedLetterIndex];
            return encodedLetter;
        }

        public char EncodeLetterInv(char letter)
        {
            int indexInAlphabet = RotorLetters.IndexOf(letter) - currentLetterIndex ;
            if (indexInAlphabet < 0)
                indexInAlphabet = 26 - Math.Abs(indexInAlphabet);

            indexInAlphabet -= RotorRingSetting;
            if (indexInAlphabet < 0)
                indexInAlphabet = 26 - Math.Abs(indexInAlphabet);

            return Enigma.Alphabet.RotorLetters[indexInAlphabet];
        }

    }
}
