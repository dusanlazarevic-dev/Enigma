using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaConsoleP
{
    public class Reflector
    {
        public Dictionary<char, char> ReflectorLetters{ get; set; }

        public Reflector(string letters)
        {
            ReflectorLetters = new Dictionary<char, char>();
            StringBuilder lettersBuilder = new StringBuilder(letters);

            for (int i = 0; i < 26; i++)
            {
                char sideA = letters[i];
                char sideB = letters[sideA - 'A'];
                ReflectorLetters.Add(sideA, sideB);
            }

        }

        public string PrintReflector()
        {
            StringBuilder output = new StringBuilder();

            foreach (KeyValuePair<char, char> kvp in ReflectorLetters)
                output.AppendFormat("\n {0} | {1}", kvp.Key, kvp.Value);
            return output.ToString();
        }

        public char ReflectLetter(char letter)
        {
            return ReflectorLetters[letter];
        }
    }
}
