using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPD_Modern
{
    internal class Functions
    {
        /*    Using several dictionaries may not be the most efficient or elegant solution, but it gets the job done. Please bear with me. :/   */
        public static readonly string[] runeArray = { "ᚠ", "ᚢ", "ᚦ", "ᚩ", "ᚱ", "ᚳ", "ᚷ", "ᚹ", "ᚻ", "ᚾ", "ᛁ", "ᛂ", "ᛇ", "ᛈ", "ᛉ", "ᛋ", "ᛏ", "ᛒ", "ᛖ", "ᛗ", "ᛚ", "ᛝ", "ᛟ", "ᛞ", "ᚪ", "ᚫ", "ᚣ", "ᛡ", "ᛠ", "ᛄ" };
        public static readonly int[] numericArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
        public static readonly int[] primeArray = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109 };
        public static readonly Dictionary<string, int> gematriaPrimus = new Dictionary<string, int> { { "ᚠ", 0 }, { "ᚢ", 1 }, { "ᚦ", 2 }, { "ᚩ", 3 }, { "ᚱ", 4 }, { "ᚳ", 5 }, { "ᚷ", 6 }, { "ᚹ", 7 }, { "ᚻ", 8 }, { "ᚾ", 9 }, { "ᛁ", 10 }, { "ᛂ", 11 }, { "ᛄ", 11 }, { "ᛇ", 12 }, { "ᛈ", 13 }, { "ᛉ", 14 }, { "ᛋ", 15 }, { "ᛏ", 16 }, { "ᛒ", 17 }, { "ᛖ", 18 }, { "ᛗ", 19 }, { "ᛚ", 20 }, { "ᛝ", 21 }, { "ᛟ", 22 }, { "ᛞ", 23 }, { "ᚪ", 24 }, { "ᚫ", 25 }, { "ᚣ", 26 }, { "ᛡ", 27 }, { "ᛠ", 28 } };
        public static readonly Dictionary<char, int> NumericEquivalent = new Dictionary<char, int> { { 'ᚠ', 0 }, { 'ᚢ', 1 }, { 'ᚦ', 2 }, { 'ᚩ', 3 }, { 'ᚱ', 4 }, { 'ᚳ', 5 }, { 'ᚷ', 6 }, { 'ᚹ', 7 }, { 'ᚻ', 8 }, { 'ᚾ', 9 }, { 'ᛁ', 10 }, { 'ᛂ', 11 }, { 'ᛄ', 11 }, { 'ᛇ', 12 }, { 'ᛈ', 13 }, { 'ᛉ', 14 }, { 'ᛋ', 15 }, { 'ᛏ', 16 }, { 'ᛒ', 17 }, { 'ᛖ', 18 }, { 'ᛗ', 19 }, { 'ᛚ', 20 }, { 'ᛝ', 21 }, { 'ᛟ', 22 }, { 'ᛞ', 23 }, { 'ᚪ', 24 }, { 'ᚫ', 25 }, { 'ᚣ', 26 }, { 'ᛡ', 27 }, { 'ᛠ', 28 } };
        public static readonly Dictionary<char, int> PrimeEquivalent = new Dictionary<char, int> { { 'ᚠ', 2 }, { 'ᚢ', 3 }, { 'ᚦ', 5 }, { 'ᚩ', 7 }, { 'ᚱ', 11 }, { 'ᚳ', 13 }, { 'ᚷ', 17 }, { 'ᚹ', 19 }, { 'ᚻ', 23 }, { 'ᚾ', 29 }, { 'ᛁ', 31 }, { 'ᛂ', 37 }, { 'ᛄ', 37 }, { 'ᛇ', 41 }, { 'ᛈ', 43 }, { 'ᛉ', 47 }, { 'ᛋ', 53 }, { 'ᛏ', 59 }, { 'ᛒ', 61 }, { 'ᛖ', 67 }, { 'ᛗ', 71 }, { 'ᛚ', 73 }, { 'ᛝ', 79 }, { 'ᛟ', 83 }, { 'ᛞ', 89 }, { 'ᚪ', 97 }, { 'ᚫ', 101 }, { 'ᚣ', 103 }, { 'ᛡ', 107 }, { 'ᛠ', 109 } };
        public static readonly Dictionary<string, string> atbashTable = new Dictionary<string, string> { { "ᚠ", "ᛠ" }, { "ᚢ", "ᛡ" }, { "ᚦ", "ᚣ" }, { "ᚩ", "ᚫ" }, { "ᚱ", "ᚪ" }, { "ᚳ", "ᛞ" }, { "ᚷ", "ᛟ" }, { "ᚹ", "ᛝ" }, { "ᚻ", "ᛚ" }, { "ᚾ", "ᛗ" }, { "ᛁ", "ᛖ" }, { "ᛂ", "ᛒ" }, { "ᛇ", "ᛏ" }, { "ᛈ", "ᛋ" }, { "ᛉ", "ᛉ" }, { "ᛋ", "ᛈ" }, { "ᛏ", "ᛇ" }, { "ᛒ", "ᛂ" }, { "ᛖ", "ᛁ" }, { "ᛗ", "ᚾ" }, { "ᛚ", "ᚻ" }, { "ᛝ", "ᚹ" }, { "ᛟ", "ᚷ" }, { "ᛞ", "ᚳ" }, { "ᚪ", "ᚱ" }, { "ᚫ", "ᚩ" }, { "ᚣ", "ᚦ" }, { "ᛡ", "ᚢ" }, { "ᛠ", "ᚠ" }, { "ᛄ", "ᛒ" } };
        public static readonly Dictionary<char, string> DirectTranslation = new Dictionary<char, string> { { 'ᚠ', "F" }, { 'ᚢ', "V(U)" }, { 'ᚦ', "TH" }, { 'ᚩ', "O" }, { 'ᚱ', "R" }, { 'ᚳ', "C(K)" }, { 'ᚷ', "G" }, { 'ᚹ', "W" }, { 'ᚻ', "H" }, { 'ᚾ', "N" }, { 'ᛁ', "I" }, { 'ᛂ', "J" }, { 'ᛇ', "EO" }, { 'ᛈ', "P" }, { 'ᛉ', "X" }, { 'ᛋ', "S(Z)" }, { 'ᛏ', "T" }, { 'ᛒ', "B" }, { 'ᛖ', "E" }, { 'ᛗ', "M" }, { 'ᛚ', "L" }, { 'ᛝ', "NG(ING)" }, { 'ᛟ', "OE" }, { 'ᛞ', "D" }, { 'ᚪ', "A" }, { 'ᚫ', "AE" }, { 'ᚣ', "Y" }, { 'ᛡ', "IA(IO)" }, { 'ᛠ', "EA" }, { 'ᛄ', "J" }, };
        public static readonly Dictionary<string, string> runicEquivalents = new Dictionary<string, string> { { "ᚪ", "A" }, { "ᚫ", "AE" }, { "ᛒ", "B" }, { "ᚳ", "C" }, { "ᛞ", "D" }, { "ᛖ", "E" }, { "ᛠ", "EA" }, { "ᛇ", "EO" }, { "ᚠ", "F" }, { "ᚷ", "G" }, { "ᚻ", "H" }, { "ᛁ", "I" }, { "ᛡ", "IA" }, { "ᛂ", "J" }, { "ᛚ", "L" }, { "ᛗ", "M" }, { "ᚾ", "N" }, { "ᚩ", "O" }, { "ᛟ", "OE" }, { "ᛈ", "P" }, { "ᚱ", "R" }, { "ᛋ", "S" }, { "ᛏ", "T" }, { "ᚦ", "TH" }, { "ᚢ", "U" }, { "ᚹ", "W" }, { "ᛉ", "X" }, { "ᚣ", "Y" }, { "ᛝ", "NG" } };

        // Get the numeric equivalent of a rune
        public static int GetNumericEquivalent(string rune)
        {
            if (string.IsNullOrEmpty(rune) || rune == ",")
            {
                // Throw an ArgumentException with an error message indicating that the input is invalid
                throw new ArgumentException("Invalid input. Commas and empty strings are not valid runes and should not be included in the Vigenere key.");
            }

            var runeData = runeDataArray.FirstOrDefault(r => r.Rune == rune);
            if (runeData != null)
            {
                return runeData.NumericEquivalent;
            }

            // Throw an ArgumentException with an error message indicating that the input rune is invalid
            throw new ArgumentException($"Invalid rune: {rune}");
        }

        public static string GetLatinEquivalent(string rune)
        {
            switch (rune)
            {
                case "ᚠ": return "F";
                case "ᚢ": return "V(U)";
                case "ᚦ": return "TH";
                case "ᚩ": return "O";
                case "ᚱ": return "R";
                case "ᚳ": return "C";
                case "ᚷ": return "G";
                case "ᚹ": return "W";
                case "ᚻ": return "H";
                case "ᚾ": return "N";
                case "ᛁ": return "I";
                case "ᛄ": return "J";
                case "ᛂ": return "J";
                case "ᛇ": return "EO";
                case "ᛈ": return "P";
                case "ᛉ": return "X";
                case "ᛋ": return "S";
                case "ᛏ": return "T";
                case "ᛒ": return "B";
                case "ᛖ": return "E";
                case "ᛗ": return "M";
                case "ᛚ": return "L";
                case "ᛝ": return "NG";
                case "ᛟ": return "OE";
                case "ᛞ": return "D";
                case "ᚪ": return "A";
                case "ᚫ": return "AE";
                case "ᚣ": return "Y";
                case "ᛡ": return "IA(IO)";
                case "ᛠ": return "EA";
                default: return "";
            }
        }
        public static StringBuilder ForwardShift(string[] lines, int shift, int[] keyValuesForLine, Dictionary<string, int> gematriaPrimus)
        {
            const string delimiters = "-.&$§/•ᛄ%\" ";
            var outputForKey = new StringBuilder();
            int keyLength = keyValuesForLine.Length;
            int keyIndex = 0;

            foreach (var line in lines)
            {
                var decryptedLine = new StringBuilder();

                foreach (var rune in line)
                {
                    var runeString = rune.ToString();

                    // If the rune is a delimiter, a number, or a special character, ignore it
                    if (delimiters.Contains(runeString) || !gematriaPrimus.ContainsKey(runeString) || (runeString == "F" && (decryptedLine.Length == 0 || decryptedLine[decryptedLine.Length - 1] == 'F')))
                    {
                        decryptedLine.Append(runeString);
                        continue;
                    }

                    int decimalValue = gematriaPrimus[runeString];
                    int keyValue = 0;

                    if (keyLength != 0)
                    {
                        keyValue = keyValuesForLine[keyIndex % keyLength];
                        keyIndex++;
                    }

                    int shiftedValue = (decimalValue - keyValue + 29 + shift) % 29;
                    var shiftedRune = Functions.runeArray[shiftedValue];
                    var latinEquivalent = Functions.GetLatinEquivalent(shiftedRune);

                    decryptedLine.Append(latinEquivalent);

                    if (runeString == "F")
                    {
                        decryptedLine.Append(runeString);
                    }
                }

                outputForKey.AppendLine(decryptedLine.ToString());
            }

            return outputForKey;
        }

        public static StringBuilder ReverseShift(string[] lines, int shift, int[] keyValuesForLine, Dictionary<string, int> gematriaPrimus)
        {
            const string delimiters = "-.&$§/•ᛄ%\" ";
            var outputForKey = new StringBuilder();
            int keyLength = keyValuesForLine.Length;
            int keyIndex = 0;

            foreach (var line in lines)
            {
                var decryptedLine = new StringBuilder();

                foreach (var rune in line)
                {
                    var runeString = rune.ToString();

                    // If the rune is a delimiter, a number, or a special character, ignore it
                    if (delimiters.Contains(runeString) || !gematriaPrimus.ContainsKey(runeString) || (runeString == "F" && (decryptedLine.Length == 0 || decryptedLine[decryptedLine.Length - 1] == 'F')))
                    {
                        decryptedLine.Append(runeString);
                        continue;
                    }

                    int decimalValue = gematriaPrimus[runeString];

                    if (shift != 0)
                    {
                        decimalValue = (decimalValue - shift + 29) % 29;
                    }

                    int keyValue = 0;

                    if (keyLength != 0)
                    {
                        keyValue = keyValuesForLine[keyIndex % keyLength];
                        keyIndex++;
                    }

                    int shiftedValue = (decimalValue - keyValue + 29) % 29;
                    var shiftedRune = Functions.runeArray[shiftedValue];
                    var latinEquivalent = Functions.GetLatinEquivalent(shiftedRune);

                    decryptedLine.Append(latinEquivalent);

                    if (runeString == "F")
                    {
                        decryptedLine.Append(runeString);
                    }
                }

                outputForKey.AppendLine(decryptedLine.ToString());
            }

            return outputForKey;
        }

        public class RuneData
        {
            public string Rune { get; set; }
            public string LatinEquivalent { get; set; }

            public int NumericEquivalent { get; set; }
            public int PrimeEquivalent { get; set; }

            // Constructor to create a new RuneData object
            public RuneData(string rune, string latinEquivalent, int numericEquivalent, int primeEquivalent)
            {
                Rune = rune;
                LatinEquivalent = latinEquivalent;
                NumericEquivalent = numericEquivalent;
                PrimeEquivalent = primeEquivalent;

            }
        }
        
        public static char[,] TransposeGrid(char[,] grid, int[] key)
        {
            int numRows = grid.GetLength(0);
            int numCols = grid.GetLength(1);
            char[,] newGrid = new char[numRows, numCols];

            for (int i = 0; i < key.Length; i++)
            {
                int oldIndex = key[i] - 1;
                for (int row = 0; row < numRows; row++)
                {
                    newGrid[row, i] = grid[row, oldIndex];
                }
            }

            return newGrid;
        }

        public static string TranspositionCipher(string inputText, string keyText)
        {
            inputText = inputText.Replace(" ", "");
            keyText = keyText.Replace(" ", "");

            int[] key = keyText.Select(c => int.Parse(c.ToString())).ToArray();

            int numRows = keyText.Length;
            int numCols = (int)Math.Ceiling((double)inputText.Length / numRows);

            int numSpaces = numRows * numCols - inputText.Length;
            if (numSpaces > 0)
            {
                inputText += new string(' ', numSpaces);
            }

            char[,] grid = new char[numRows, numCols];
            int index = 0;
            for (int col = 0; col < numCols; col++)
            {
                for (int row = 0; row < numRows; row++)
                {
                    grid[row, col] = inputText[index++];
                }
            }

            StringBuilder plainTextBuilder = new StringBuilder();
            foreach (int keyIndex in key)
            {
                int oldIndex = keyIndex - 1;
                for (int row = 0; row < numRows; row++)
                {
                    if (grid[row, oldIndex] != ' ')
                    {
                        plainTextBuilder.Append(grid[row, oldIndex]);
                    }
                }
            }

            return plainTextBuilder.ToString();
        }

        // Define an array of RuneData objects to represent each rune
        public static readonly RuneData[] runeDataArray = new RuneData[]
    {
    new RuneData("ᚠ", "F", 0, 2),
    new RuneData("ᚢ", "U", 1, 3),
    new RuneData("ᚦ", "TH", 2, 5),
    new RuneData("ᚩ", "O", 3, 7),
    new RuneData("ᚱ", "R", 4, 11),
    new RuneData("ᚳ", "C", 5, 13),
    new RuneData("ᚷ", "G", 6, 17),
    new RuneData("ᚹ", "W", 7, 19),
    new RuneData("ᚻ", "H", 8, 23),
    new RuneData("ᚾ", "N", 9, 29),
    new RuneData("ᛁ", "I", 10, 31),
    new RuneData("ᛄ", "J", 11, 37),
    new RuneData("ᛂ", "J", 11, 37),
    new RuneData("ᛇ", "EO", 12, 41),
    new RuneData("ᛈ", "P", 13, 43),
    new RuneData("ᛉ", "X", 14, 47),
    new RuneData("ᛋ", "S", 15, 53),
    new RuneData("ᛏ", "T", 16, 59),
    new RuneData("ᛒ", "B", 17, 61),
    new RuneData("ᛖ", "E", 18, 67),
    new RuneData("ᛗ", "M", 19, 71),
    new RuneData("ᛚ", "L", 20, 73),
    new RuneData("ᛝ", "ING", 21, 79),
    new RuneData("ᛟ", "OE", 22, 83),
    new RuneData("ᛞ", "D", 23, 89),
    new RuneData("ᚪ", "A", 24, 97),
    new RuneData("ᚫ", "AE", 25, 101),
    new RuneData("ᚣ", "Y", 26, 103),
    new RuneData("ᛡ", "IO", 27, 107),
    new RuneData("ᛠ", "EA", 28, 109)
};
        public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            // Create a DirectoryInfo object to represent the specified folder
            DirectoryInfo dinfo = new DirectoryInfo(Folder);

            // Get an array of FileInfo objects for all files in the specified folder with the specified file type
            FileInfo[] Files = dinfo.GetFiles(FileType);

            // Loop through each FileInfo object in the array and add its name to the ListBox control
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }
    }
}
