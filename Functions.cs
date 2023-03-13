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
        /* Using several dictionaries may not be the most efficient or elegant solution, but it gets the job done. Please bear with me. . . :/  */
        public static readonly string[] runeArray = { "ᚠ", "ᚢ", "ᚦ", "ᚩ", "ᚱ", "ᚳ", "ᚷ", "ᚹ", "ᚻ", "ᚾ", "ᛁ", "ᛂ", "ᛇ", "ᛈ", "ᛉ", "ᛋ", "ᛏ", "ᛒ", "ᛖ", "ᛗ", "ᛚ", "ᛝ", "ᛟ", "ᛞ", "ᚪ", "ᚫ", "ᚣ", "ᛡ", "ᛠ", "ᛄ" };
        public static readonly int[] numericArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
        public static readonly int[] primeArray = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109 };
        public static readonly Dictionary<string, int> gematriaPrimus = new Dictionary<string, int> { { "ᚠ", 0 }, { "ᚢ", 1 }, { "ᚦ", 2 }, { "ᚩ", 3 }, { "ᚱ", 4 }, { "ᚳ", 5 }, { "ᚷ", 6 }, { "ᚹ", 7 }, { "ᚻ", 8 }, { "ᚾ", 9 }, { "ᛁ", 10 }, { "ᛂ", 11 }, { "ᛄ", 11 }, { "ᛇ", 12 }, { "ᛈ", 13 }, { "ᛉ", 14 }, { "ᛋ", 15 }, { "ᛏ", 16 }, { "ᛒ", 17 }, { "ᛖ", 18 }, { "ᛗ", 19 }, { "ᛚ", 20 }, { "ᛝ", 21 }, { "ᛟ", 22 }, { "ᛞ", 23 }, { "ᚪ", 24 }, { "ᚫ", 25 }, { "ᚣ", 26 }, { "ᛡ", 27 }, { "ᛠ", 28 } };
        public static readonly Dictionary<char, int> NumericEquivalent = new Dictionary<char, int> { { 'ᚠ', 0 }, { 'ᚢ', 1 }, { 'ᚦ', 2 }, { 'ᚩ', 3 }, { 'ᚱ', 4 }, { 'ᚳ', 5 }, { 'ᚷ', 6 }, { 'ᚹ', 7 }, { 'ᚻ', 8 }, { 'ᚾ', 9 }, { 'ᛁ', 10 }, { 'ᛂ', 11 }, { 'ᛄ', 11 }, { 'ᛇ', 12 }, { 'ᛈ', 13 }, { 'ᛉ', 14 }, { 'ᛋ', 15 }, { 'ᛏ', 16 }, { 'ᛒ', 17 }, { 'ᛖ', 18 }, { 'ᛗ', 19 }, { 'ᛚ', 20 }, { 'ᛝ', 21 }, { 'ᛟ', 22 }, { 'ᛞ', 23 }, { 'ᚪ', 24 }, { 'ᚫ', 25 }, { 'ᚣ', 26 }, { 'ᛡ', 27 }, { 'ᛠ', 28 } };
        public static readonly Dictionary<char, int> PrimeEquivalent = new Dictionary<char, int> { { 'ᚠ', 2 }, { 'ᚢ', 3 }, { 'ᚦ', 5 }, { 'ᚩ', 7 }, { 'ᚱ', 11 }, { 'ᚳ', 13 }, { 'ᚷ', 17 }, { 'ᚹ', 19 }, { 'ᚻ', 23 }, { 'ᚾ', 29 }, { 'ᛁ', 31 }, { 'ᛂ', 37 }, { 'ᛄ', 37 }, { 'ᛇ', 43 }, { 'ᛈ', 47 }, { 'ᛉ', 53 }, { 'ᛋ', 59 }, { 'ᛏ', 61 }, { 'ᛒ', 67 }, { 'ᛖ', 71 }, { 'ᛗ', 73 }, { 'ᛚ', 79 }, { 'ᛝ', 83 }, { 'ᛟ', 89 }, { 'ᛞ', 97 }, { 'ᚪ', 101 }, { 'ᚫ', 103 }, { 'ᚣ', 107 }, { 'ᛡ', 109 }, { 'ᛠ', 109 } };
        public static readonly Dictionary<string, string> atbashTable = new Dictionary<string, string> { { "ᚠ", "ᛠ" }, { "ᚢ", "ᛡ" }, { "ᚦ", "ᚣ" }, { "ᚩ", "ᚫ" }, { "ᚱ", "ᚪ" }, { "ᚳ", "ᛞ" }, { "ᚷ", "ᛟ" }, { "ᚹ", "ᛝ" }, { "ᚻ", "ᛚ" }, { "ᚾ", "ᛗ" }, { "ᛁ", "ᛖ" }, { "ᛂ", "ᛒ" }, { "ᛇ", "ᛏ" }, { "ᛈ", "ᛋ" }, { "ᛉ", "ᛉ" }, { "ᛋ", "ᛈ" }, { "ᛏ", "ᛇ" }, { "ᛒ", "ᛂ" }, { "ᛖ", "ᛁ" }, { "ᛗ", "ᚾ" }, { "ᛚ", "ᚻ" }, { "ᛝ", "ᚹ" }, { "ᛟ", "ᚷ" }, { "ᛞ", "ᚳ" }, { "ᚪ", "ᚱ" }, { "ᚫ", "ᚩ" }, { "ᚣ", "ᚦ" }, { "ᛡ", "ᚢ" }, { "ᛠ", "ᚠ" }, { "ᛄ", "ᛒ" } };
        public static readonly Dictionary<char, string> DirectTranslation = new Dictionary<char, string> { { 'ᚠ', "F" }, { 'ᚢ', "V(U)" }, { 'ᚦ', "TH" }, { 'ᚩ', "O" }, { 'ᚱ', "R" }, { 'ᚳ', "C(K)" }, { 'ᚷ', "G" }, { 'ᚹ', "W" }, { 'ᚻ', "H" }, { 'ᚾ', "N" }, { 'ᛁ', "I" }, { 'ᛂ', "J" }, { 'ᛇ', "EO" }, { 'ᛈ', "P" }, { 'ᛉ', "X" }, { 'ᛋ', "S(Z)" }, { 'ᛏ', "T" }, { 'ᛒ', "B" }, { 'ᛖ', "E" }, { 'ᛗ', "M" }, { 'ᛚ', "L" }, { 'ᛝ', "NG(ING)" }, { 'ᛟ', "OE" }, { 'ᛞ', "D" }, { 'ᚪ', "A" }, { 'ᚫ', "AE" }, { 'ᚣ', "Y" }, { 'ᛡ', "IA(IO)" }, { 'ᛠ', "EA" }, { 'ᛄ', "J" }, };
        public static readonly Dictionary<string, string> runicEquivalents = new Dictionary<string, string>(); //Pretty bad IK. . . 

        // Get the numeric equivalent of a rune
        public static int GetNumericEquivalent(string rune)
        {
            // Check if the input rune is a comma, which is not valid for the Vigenere key
            if (rune == ",")
            {
                // Throw an ArgumentException with an error message indicating that commas are not valid runes
                throw new ArgumentException("Commas are not valid runes and should not be included in the Vigenere key.");
            }

            // Search for the input rune in the array of runeData objects
            var runeData = runeDataArray.FirstOrDefault(r => r.Rune == rune);
            if (runeData != null)
            {
                // If the input rune is found in the array, return its NumericEquivalent property
                return runeData.NumericEquivalent;
            }
            else
            {
                // If the input rune is not found in the array, display an error message to the user
                MessageBox.Show("Please enter a valid key.");
                // Throw an ArgumentException with an error message indicating that the input rune is invalid
                throw new ArgumentException("Invalid rune: " + rune);
            }
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
            // Define a string of delimiters that will be ignored during encryption/decryption
            const string delimiters = "-.&$§/•ᛄ%\" ";

            // Initialize a StringBuilder to store the output for the given shift and key
            var outputForKey = new StringBuilder();

            // Loop through each line of the input text
            foreach (var line in lines)
            {
                // Initialize a StringBuilder to store the decrypted version of the line
                var decryptedLine = new StringBuilder();

                // Loop through each rune in the line
                foreach (var rune in line)
                {
                    // Convert the rune to a string for processing
                    var runeString = rune.ToString();

                    // If the rune is a delimiter or a duplicate "F", add it to the decrypted line as-is and continue
                    if (delimiters.Contains(runeString) || (runeString == "F" && (decryptedLine.Length == 0 || decryptedLine[decryptedLine.Length - 1] == 'F')))
                    {
                        decryptedLine.Append(runeString);
                        continue;
                    }

                    // Get the decimal value of the rune using the gematriaPrimus dictionary
                    var decimalValue = gematriaPrimus[runeString];

                    // Determine the key value for the current position in the decrypted line
                    var keyValue = 0;
                    if (keyValuesForLine.Length != 0)
                    {
                        keyValue = keyValuesForLine[decryptedLine.Length % keyValuesForLine.Length];
                    }

                    // Apply the shift to the decimal value and key value to obtain the shifted value
                    var shiftedValue = (decimalValue - keyValue + 29 + shift) % 29;

                    // Use the shifted value to get the corresponding shifted rune from the runeArray
                    var shiftedRune = Functions.runeArray[shiftedValue];

                    // Use the GetLatinEquivalent method to get the Latin equivalent of the shifted rune
                    var latinEquivalent = Functions.GetLatinEquivalent(shiftedRune);

                    // Append the Latin equivalent to the decrypted line
                    decryptedLine.Append(latinEquivalent);

                    // If the original rune was an "F", add a duplicate "F" to the decrypted line
                    if (runeString == "F")
                    {
                        decryptedLine.Append(runeString);
                    }
                }

                // Append the decrypted line to the output StringBuilder with a newline character
                outputForKey.AppendLine(decryptedLine.ToString());
            }

            // Return the final decrypted output for the given shift and key
            return outputForKey;
        }
        public static StringBuilder ReverseShift(string[] lines, int shift, int[] keyValuesForLine, Dictionary<string, int> gematriaPrimus)
        {
            // Define a string of delimiters that will be ignored during encryption/decryption
            const string delimiters = "-.&$§/•ᛄ%\" ";

            // Initialize a StringBuilder to store the output for the given shift and key
            var outputForKey = new StringBuilder();

            // Loop through each line of the input text
            foreach (var line in lines)
            {
                // Initialize a StringBuilder to store the decrypted version of the line
                var decryptedLine = new StringBuilder();

                // Loop through each rune in the line
                foreach (var rune in line)
                {
                    // Convert the rune to a string for processing
                    var runeString = rune.ToString();

                    // If the rune is a delimiter or a duplicate "F", add it to the decrypted line as-is and continue
                    if (delimiters.Contains(runeString) || (runeString == "F" && (decryptedLine.Length == 0 || decryptedLine[decryptedLine.Length - 1] == 'F')))
                    {
                        decryptedLine.Append(runeString);
                        continue;
                    }

                    // Get the decimal value of the rune using the gematriaPrimus dictionary
                    var decimalValue = gematriaPrimus[runeString];

                    // Apply the reverse shift to the decimal value if the shift is not zero
                    if (shift != 0)
                    {
                        decimalValue = (decimalValue - shift + 29) % 29;
                    }

                    // Determine the key value for the current position in the decrypted line
                    var keyValue = keyValuesForLine.Length != 0 ? keyValuesForLine[decryptedLine.Length % keyValuesForLine.Length] : 0;

                    // Apply the key value and reverse shift to obtain the shifted value
                    var shiftedValue = (decimalValue - keyValue + 29) % 29;

                    // Use the shifted value to get the corresponding shifted rune from the runeArray
                    var shiftedRune = Functions.runeArray[shiftedValue];

                    // Use the GetLatinEquivalent method to get the Latin equivalent of the shifted rune
                    var latinEquivalent = Functions.GetLatinEquivalent(shiftedRune);

                    // Append the Latin equivalent to the decrypted line
                    decryptedLine.Append(latinEquivalent);

                    // If the original rune was an "F", add a duplicate "F" to the decrypted line
                    if (runeString == "F")
                    {
                        decryptedLine.Append(runeString);
                    }
                }

                // Append the decrypted line to the output StringBuilder with a newline character
                outputForKey.AppendLine(decryptedLine.ToString());
            }

            // Return the final decrypted output for the given shift and key
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
        /*
         * The TranspositionDecrypt function created by alekhya63 yields very similar results to my TranspositionCipher function.
         * 
        private static int[] IndexesPadCharacter(string key)
        {
            int LengthofKey = key.Length;
            int[] countOfIndexes = new int[LengthofKey];
            List<KeyValuePair<int, char>> setKey = new List<KeyValuePair<int, char>>();
            int position;

            for (position = 0; position < LengthofKey; ++position)
                setKey.Add(new KeyValuePair<int, char>(position, key[position]));

            setKey.Sort(
                delegate (KeyValuePair<int, char> pair1, KeyValuePair<int, char> pair2) {
                    return pair1.Value.CompareTo(pair2.Value);
                }
            );

            for (position = 0; position < LengthofKey; ++position)
                countOfIndexes[setKey[position].Key] = position;

            return countOfIndexes;
        }
        
        public static string TranspositionDecrypt(string cipherText, string key)
        {
            StringBuilder plainText = new StringBuilder();
            int countOfChars = cipherText.Length;
            int matrixColumns = (int)Math.Ceiling((double)countOfChars / key.Length);
            int matrixRows = key.Length;
            char[,] charactersOfRows = new char[matrixRows, matrixColumns];
            char[,] charactersOfColumns = new char[matrixColumns, matrixRows];
            char[,] columnCharsUnsorted = new char[matrixColumns, matrixRows];
            int currentRowOfMatrix, currentColumnOfMatrix, i, j;
            int[] Indexes = IndexesPadCharacter(key);

            for (i = 0; i < countOfChars; ++i)
            {
                currentRowOfMatrix = i / matrixColumns;
                currentColumnOfMatrix = i % matrixColumns;
                charactersOfRows[currentRowOfMatrix, currentColumnOfMatrix] = cipherText[i];
            }

            for (i = 0; i < matrixRows; ++i)
                for (j = 0; j < matrixColumns; ++j)
                    charactersOfColumns[j, i] = charactersOfRows[i, j];

            for (i = 0; i < matrixColumns; ++i)
                for (j = 0; j < matrixRows; ++j)
                    columnCharsUnsorted[i, j] = charactersOfColumns[i, Indexes[j]];

            for (i = 0; i < countOfChars; ++i)
            {
                currentRowOfMatrix = i / matrixRows;
                currentColumnOfMatrix = i % matrixRows;
                plainText.Append(columnCharsUnsorted[currentRowOfMatrix, currentColumnOfMatrix]);
            }
            //convert plaintext to string
            return plainText.ToString();
        }
        */
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
            // Remove any spaces from the input text and key
            inputText = inputText.Replace(" ", "");
            keyText = keyText.Replace(" ", "");

            // Convert the key permutation to an integer array
            int[] key = new int[keyText.Length];
            for (int i = 0; i < keyText.Length; i++)
            {
                if (!int.TryParse(keyText[i].ToString(), out key[i]))
                {
                    throw new ArgumentException("Invalid transposition key: " + keyText);
                }
            }

            // Determine the number of rows and columns in the grid
            int numRows = keyText.Length;
            int numCols = (int)Math.Ceiling((double)inputText.Length / numRows);

            // Check if the input text needs padding with spaces to fill the grid
            int numSpaces = numRows * numCols - inputText.Length;
            if (numSpaces > 0)
            {
                inputText += new string(' ', numSpaces);
            }

            // Create a character array to represent the grid
            char[,] grid = new char[numRows, numCols];

            // Fill the grid with the input text, row by row
            int index = 0;
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (index >= inputText.Length)
                    {
                        grid[row, col] = ' ';
                    }
                    else
                    {
                        grid[row, col] = inputText[index];
                    }
                    index++;
                }
            }

            // Rearrange the columns of the grid according to the key permutation
            char[,] newGrid = new char[numRows, numCols];
            for (int i = 0; i < key.Length; i++)
            {
                int oldIndex = key[i] - 1;
                for (int row = 0; row < numRows; row++)
                {
                    newGrid[row, i] = grid[row, oldIndex];
                }
            }

            // Read the plaintext message column by column from the rearranged grid
            StringBuilder plainTextBuilder = new StringBuilder();
            for (int col = 0; col < numCols; col++)
            {
                for (int row = 0; row < numRows; row++)
                {
                    if (newGrid[row, col] != '\0' && newGrid[row, col] != ' ')
                    {
                        plainTextBuilder.Append(newGrid[row, col]);
                    }
                }
            }

            // Convert the StringBuilder to a string
            string plainText = plainTextBuilder.ToString();

            return plainText;
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
