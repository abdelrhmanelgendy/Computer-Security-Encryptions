using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chifers_K
{
    class railFence
    {

        
            public static string Encrypt(string text, int rails)
            {

                text = text.ToUpper();
                text = Regex.Replace(text, @"[^A-Z0-9]", string.Empty);

                var lines = new List<StringBuilder>();

                for (int i = 0; i < rails; i++)
                    lines.Add(new StringBuilder());

                int currentLine = 0;
                int direction = 1;

                for (int i = 0; i < text.Length; i++)
                {
                    lines[currentLine].Append(text[i]);

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == rails - 1)
                        direction = -1;

                    currentLine += direction;
                }


                StringBuilder result = new StringBuilder();

                for (int i = 0; i < rails; i++)
                    result.Append(lines[i].ToString());

                return result.ToString();
            }


            public static string Decrypt(string text, int rails)
            {

                text = text.ToUpper();
                text = Regex.Replace(text, @"[^A-Z0-9]", string.Empty);

                var lines = new List<StringBuilder>();

                for (int i = 0; i < rails; i++)
                    lines.Add(new StringBuilder());


                int[] linesLenght = Enumerable.Repeat(0, rails).ToArray();


                int currentLine = 0;
                int direction = 1;

                for (int i = 0; i < text.Length; i++)
                {
                    linesLenght[currentLine]++;

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == rails - 1)
                        direction = -1;

                    currentLine += direction;
                }

                int currentChar = 0;

                for (int line = 0; line < rails; line++)
                {
                    for (int c = 0; c < linesLenght[line]; c++)
                    {
                        lines[line].Append(text[currentChar]);
                        currentChar++;
                    }
                }

                StringBuilder result = new StringBuilder();

                currentLine = 0;
                direction = 1;


                int[] currentReadLine = Enumerable.Repeat(0, rails).ToArray();

                for (int i = 0; i < text.Length; i++)
                {

                    result.Append(lines[currentLine][currentReadLine[currentLine]]);
                    currentReadLine[currentLine]++;

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == rails - 1)
                        direction = -1;

                    currentLine += direction;
                }

                return result.ToString();

            }
        }
    
}
