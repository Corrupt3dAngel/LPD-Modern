using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Krypton.Toolkit;
using System.IO;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LPD_Modern
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            fastColoredTextBox1.TextChanged += fastColoredTextBox1_Load;
            fastColoredTextBox3.TextChanged += fastColoredTextBox3_Load;
        }
        Point lastPoint;
        public string RemoveInterrupterRunes(string inputText) //Can be improved upon
        {
            // Retrieve the dictionary of runic letter equivalents
            Dictionary<string, string> runicEquivalents = Functions.runicEquivalents;

            // Create a list to hold the interrupter runes
            List<string> interrupterRunes = new List<string>();

            // Check if the "All" checkbox is checked
            if (checkBox12.Checked)
            {
                // If it is, add all interrupter runes to the list
                interrupterRunes.AddRange(new string[] { "ᚠ", "ᚢ", "ᚦ", "ᚩ", "ᚱ", "ᚳ", "ᚷ", "ᚹ", "ᚻ", "ᚾ", "ᛁ", "ᛂ", "ᛇ", "ᛈ", "ᛉ", "ᛋ", "ᛏ", "ᛒ", "ᛖ", "ᛗ", "ᛚ", "ᛝ", "ᛟ", "ᛞ", "ᚪ", "ᚫ", "ᚣ", "ᛡ", "ᛠ" });
            }
            else if (checkBox13.Checked)
            {
                // If it is, add all interrupter runes to the list
                interrupterRunes.AddRange(new string[] { "ᚠ" });
            }

            //Don't Ask why. . .
            if (checkBox14.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚤ" });
            }

            if (checkBox15.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚾ" });
            }

            if (checkBox16.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛁ" });
            }

            if (checkBox17.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛂ", "ᛄ" });
            }

            if (checkBox18.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚦ" });
            }

            if (checkBox19.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚩ" });
            }

            if (checkBox20.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚱ" });
            }

            if (checkBox21.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚳ" });
            }

            if (checkBox22.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚷ" });
            }

            if (checkBox23.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚹ" });
            }

            if (checkBox24.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚺ" });
            }

            if (checkBox25.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛇ" });
            }

            if (checkBox26.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛈ" });
            }

            if (checkBox27.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛉ" });
            }

            if (checkBox28.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛋ" });
            }

            if (checkBox29.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛏ" });
            }

            if (checkBox30.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛒ" });
            }

            if (checkBox31.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛖ" });
            }

            if (checkBox32.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛗ" });
            }

            if (checkBox33.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛚ" });
            }

            if (checkBox34.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛝ" });
            }

            if (checkBox35.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛟ" });
            }

            if (checkBox36.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛞ" });
            }

            if (checkBox37.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚪ" });
            }

            if (checkBox38.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚫ" });
            }

            if (checkBox39.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᚣ" });
            }

            if (checkBox40.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛡ" });
            }
            //Don't Ask why. . .
            if (checkBox41.Checked)
            {
                interrupterRunes.AddRange(new string[] { "ᛠ" });
            }


            // Iterate through each interrupter rune in the list
            foreach (string rune in interrupterRunes)
            {
                // Create a regex pattern that matches the runic letter
                string escapedRune = Regex.Escape(rune);
                string regexPattern = $"{escapedRune}";

                // Replace all instances of the runic letter in the input text
                inputText = Regex.Replace(inputText, regexPattern, "");
            }

            // Return the updated input text
            return inputText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox1.Text);
                }
            }
        }
        private void materialButton8_Click(object sender, EventArgs e)
        {
            // Set the desired line length for the output text (change this value as needed)
            const int lineLength = 20;

            // Initialize variables for counting the number of characters and the sum of numeric equivalents
            int count = 0;
            int totalSum = 0;

            // Create a StringBuilder to efficiently build up the output text
            StringBuilder outputTextBuilder = new StringBuilder();

            // Iterate over each character in the input text of the "fastColoredTextBox1" control
            foreach (char c in fastColoredTextBox1.Text)
            {
                // Retrieve the numeric equivalent of the current character from the cipher table
                if (Functions.NumericEquivalent.TryGetValue(c, out int numericValue))
                {
                    // If the line is longer than the desired line length, start a new line
                    if (count >= lineLength)
                    {
                        outputTextBuilder.AppendLine();
                        count = 0;
                    }

                    // Add the numeric equivalent to the output text and update the count and total sum
                    outputTextBuilder.Append(numericValue).Append(' ');
                    totalSum += numericValue;
                    count++;
                }
            }

            // Add a newline character and the total sum to the end of the output text
            outputTextBuilder.AppendLine().AppendFormat("Total Sum = {0}", totalSum);

            // Set the text of the "fastColoredTextBox1" control to the output text
            fastColoredTextBox1.Text = outputTextBuilder.ToString().TrimEnd();
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            // Get the input text from the "fastColoredTextBox1" control
            string inputText = fastColoredTextBox1.Text;

            // Retrieve the set of keys in the cipher table from a static class called "Functions"
            HashSet<char> cipherTableKeys = new HashSet<char>(Functions.PrimeEquivalent.Keys);

            // Set the desired line length for the output text (change this value as needed)
            const int lineLength = 20;

            // Initialize variables for counting the number of characters and the sum of prime equivalents
            int count = 0;
            int totalSum = 0;

            // Create a StringBuilder to efficiently build up the output text
            StringBuilder outputTextBuilder = inputText
                .Where(cipherTableKeys.Contains) // Filter out characters not in the cipher table
                .Aggregate(new StringBuilder(inputText.Length), (builder, c) => // Aggregate characters into a StringBuilder object
                {
                    // If the line is longer than the desired line length, start a new line
                    if (count >= lineLength)
                    {
                        builder.AppendLine();
                        count = 0;
                    }

                    // Retrieve the prime equivalent of the current character from the cipher table
                    int primeEquivalent = Functions.PrimeEquivalent[c];

                    // Add the prime equivalent to the output text and update the count and total sum
                    builder.Append(primeEquivalent).Append(' ');
                    totalSum += primeEquivalent;
                    count++;

                    // Return the StringBuilder object with the new character added
                    return builder;
                });

            // Add a newline character and the total sum to the end of the output text
            outputTextBuilder.AppendLine();
            outputTextBuilder.AppendFormat("Total Sum = {0}", totalSum);

            // Set the text of the "fastColoredTextBox1" control to the output text
            fastColoredTextBox1.Text = outputTextBuilder.ToString().TrimEnd();
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Pages", "*.txt");
            Functions.PopulateListBox(listBox1, "./Pages", "*.lua");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = File.ReadAllText($"./Pages/{listBox1.SelectedItem}");
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox2.Text = File.ReadAllText($"./Keys/{listBox4.SelectedItem}");
        }

        private void materialButton22_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox4, "./Keys", "*.txt");
            Functions.PopulateListBox(listBox4, "./Keys", "*.lua");
        }

        private void materialButton15_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox3, "./Pages", "*.txt");
            Functions.PopulateListBox(listBox3, "./Pages", "*.lua");
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox4.Text = File.ReadAllText($"./Pages/{listBox3.SelectedItem}");
        }

        private void materialButton16_Click(object sender, EventArgs e)
        {
            fastColoredTextBox4.Clear();
        }

        private void materialButton17_Click(object sender, EventArgs e)
        {
            // Retrieve the Atbash table from a static class called "Functions"
            Dictionary<string, string> atbashTable = Functions.atbashTable;

            // Create a StringBuilder to efficiently build up the Atbash cipher text
            StringBuilder atbashedText = new StringBuilder();

            // Iterate over each line in the "fastColoredTextBox4" control
            foreach (string line in fastColoredTextBox4.Lines)
            {
                // Create a new string to hold the Atbash cipher line
                string atbashedLine = "";

                // Iterate over each character (rune) in the current line
                foreach (char rune in line)
                {
                    // Convert the current rune to a string
                    string runeString = rune.ToString();

                    // If the rune is in the Atbash table, replace it with its Atbash equivalent
                    if (atbashTable.ContainsKey(runeString))
                    {
                        atbashedLine += atbashTable[runeString];
                    }
                    else
                    {
                        // Otherwise, just add the original rune to the Atbash cipher line
                        atbashedLine += runeString;
                    }
                }

                // Add the Atbash cipher line (with a newline character) to the StringBuilder
                atbashedText.AppendLine(atbashedLine);
            }

            // Clear the text of the "fastColoredTextBox4" control and set its text to the Atbash cipher text
            fastColoredTextBox4.Clear();
            fastColoredTextBox4.AppendText(atbashedText.ToString());
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(fastColoredTextBox3.Text);
        }

        private void materialButton23_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(fastColoredTextBox2.Text);
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(fastColoredTextBox1.Text);
        }

        private void materialButton27_Click(object sender, EventArgs e)
        {
            fastColoredTextBox2.Clear();
        }

        private void materialButton26_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox2.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void materialButton25_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox2.Text);
                }
            }
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox3.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox3.Text);
                }
            }
        }

        private void materialButton13_Click(object sender, EventArgs e)
        {
            fastColoredTextBox3.Clear();
        }

        private void tabPage_Modern_Black1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialButton32_Click(object sender, EventArgs e)
        {

        }

        private void materialButton31_Click(object sender, EventArgs e)
        {

        }

        public async void fastColoredTextBox1_Load(object sender, EventArgs e) //Gonna optimize this soon. . .
        {
            // Get the user input from the FastColoredTextBox1 control
            string userInput = fastColoredTextBox1.Text;

            // Calculate the frequency of each rune in the input in parallel
            Dictionary<char, int> runeFrequency = await Task.Run(() => Cryptanalysis.GetRuneFrequency(userInput));

            // Calculate the IoC of the input
            double ioc = Cryptanalysis.CalculateIoC(runeFrequency, userInput.Length);

            // Calculate the entropy of the input
            double entropy = Cryptanalysis.CalculateEntropy(runeFrequency, userInput.Length);

            // Calculate the bigram ratio of the input in parallel
            Dictionary<string, int> bigramFrequency = await Task.Run(() => Cryptanalysis.GetBigramFrequency(userInput));
            double bigramRatio = Cryptanalysis.CalculateBigramRatio(bigramFrequency, bigramFrequency.Sum(pair => pair.Value));

            // Calculate the bigram peak and bigram low of the input in parallel
            (double BigramPeak, double BigramLow) bigramPeakAndLow = await Task.Run(() => Cryptanalysis.CalculateBigramPeakAndLow(bigramFrequency, userInput.Length));
            double bigramPeak = bigramPeakAndLow.Item1;
            double bigramLow = bigramPeakAndLow.Item2;

            // Calculate the same-GP ratio of the input in parallel
            Dictionary<string, int> sameGPFrequency = await Task.Run(() => Cryptanalysis.GetSameGPFrequency(userInput, runeFrequency));
            double sameGPRatio = Cryptanalysis.CalculateSameGPRatio(sameGPFrequency, sameGPFrequency.Sum(pair => pair.Value));

            // Calculate the average letter distance of the input in parallel
            double avgLetterDistance = await Task.Run(() => Cryptanalysis.CalculateAvgLetterDistance(userInput));

            // Calculate the average rune repeat distance of the input in parallel
            double avgRuneRepeatDistance = await Task.Run(() => Cryptanalysis.CalculateAvgRuneRepeatDistance(userInput));

            // Calculate the average double rune distance of the input in parallel
            double avgDblRuneDistance = await Task.Run(() => Cryptanalysis.CalculateAvgDblRuneDistance(userInput));

            // Calculate the average letter X repeat distance of the input in parallel
            double avgLetterXRepeatDistance = await Task.Run(() => Cryptanalysis.CalculateAvgLetterXRepeatDistance(userInput));

            // Calculate the average letter F repeat distance of the input in parallel
            double avgLetterFRepeatDistance = await Task.Run(() => Cryptanalysis.CalculateAvgLetterFRepeatDistance(userInput));

            // Calculate the median letter F repeat distance of the input in parallel
            double medLetterFRepeatDistance = await Task.Run(() => Cryptanalysis.CalculateMedianLetterFRepeatDistance(userInput));

            // Calculate the median letter F repeat distance of the input in parallel
            double ShannonsEntropy = await Task.Run(() => Cryptanalysis.ShannonEntropy(userInput));

            // Calculate the bigram frequency of the input in parallel
            Dictionary<string, int> bigramFrequency2 = await Task.Run(() => Cryptanalysis.GetBigramFrequency(userInput));

            // Calculate the trigram frequency of the input in parallel
            Dictionary<string, int> trigramFrequency = await Task.Run(() => Cryptanalysis.GetTrigramFrequency(userInput));

            // Calculate the letter frequency of the input in parallel
            Dictionary<char, int> letterFrequency = await Task.Run(() => Cryptanalysis.GetRuneFrequency(userInput));

            // Calculate the letterFrequencyPercentage of the input in parallel
            Dictionary<char, int> letterFrequencyCounts = await Task.Run(() => Cryptanalysis.GetRuneFrequency(userInput));

            // Calculate the latinFrequencyPercentage of the input in parallel
            Dictionary<char, int> RunetoLatinFrequencyCounts = await Task.Run(() => Cryptanalysis.GetRuneFrequency(userInput));

            // Calculate the repeated grams of length 3 in the input in parallel
            Dictionary<string, int> repeatedGrams = await Task.Run(() => Cryptanalysis.CalculateRepeatedGrams(userInput, 3));

            // Calculate the similar grams of length 3 in the input in parallel
            Dictionary<string, int> similarGrams = await Task.Run(() => Cryptanalysis.CalculateSimilarGrams(userInput));

            // Calculate the trigram ratio of the input in parallel
            double trigramRatio = 0;
            if (trigramFrequency.Count > 0)
            {
                trigramRatio = Cryptanalysis.CalculateTrigramRatio(trigramFrequency, trigramFrequency.Sum(pair => pair.Value));
            }

            // Calculate the total number of letters
            int totalRunes = letterFrequencyCounts.Values.Sum();

            // Convert the letterFrequencyCounts to store percentage values
            Dictionary<char, double> letterFrequencyPercentage = letterFrequencyCounts.ToDictionary(
                pair => pair.Key,
                pair => (double)pair.Value / totalRunes * 100
            );

            // Convert the runes to Latin characters using the gematriaPrimus dictionary
            Dictionary<char, string> gematriaPrimus = Functions.DirectTranslation;
            Dictionary<string, int> latinFrequencyCounts = new Dictionary<string, int>();

            foreach (var runeCount in RunetoLatinFrequencyCounts)
            {
                if (gematriaPrimus.TryGetValue(runeCount.Key, out string latinChar))
                {
                    string latin = latinChar;

                    // Custom Latin character combinations
                    if (latin == "C" || latin == "K") latin = "C/K";
                    else if (latin == "S" || latin == "Z") latin = "S/Z";
                    else if (latin == "NG" || latin == "ING") latin = "NG/ING";
                    else if (latin == "IA" || latin == "IO") latin = "IA/IO";

                    if (latinFrequencyCounts.ContainsKey(latin))
                    {
                        latinFrequencyCounts[latin] += runeCount.Value;
                    }
                    else
                    {
                        latinFrequencyCounts.Add(latin, runeCount.Value);
                    }
                }
            }

            // Calculate the total number of Latin strings
            int totalLetters = latinFrequencyCounts.Values.Sum();

            // Convert the latinFrequencyCounts to store percentage values
            Dictionary<string, double> latinFrequencyPercentage = latinFrequencyCounts.ToDictionary(
                pair => pair.Key,
                pair => (double)pair.Value / totalLetters * 100
            );


            // Sort the dictionaries in descending order / AKA from greatest to least
            var bigramFrequencySorted = bigramFrequency2.OrderByDescending(pair => pair.Value);
            var trigramFrequencySorted = trigramFrequency.OrderByDescending(pair => pair.Value);
            var letterFrequencySorted = letterFrequency.OrderByDescending(pair => pair.Value);
            var repeatedGramsSorted = repeatedGrams.OrderByDescending(pair => pair.Value);
            var similarGramsSorted = similarGrams.OrderByDescending(pair => pair.Value);

            // Display the results in the appropriate textboxes with identifiers
            flatTextBox1.Text = "Entropy: " + entropy.ToString();
            flatTextBox25.Text = "Shannon's Entropy: " + ShannonsEntropy.ToString();
            flatTextBox4.Text = "IoC: " + ioc.ToString();
            flatTextBox7.Text = "Bigram Ratio: " + bigramRatio.ToString();
            flatTextBox10.Text = "Bigram Peak: " + bigramPeak.ToString();
            flatTextBox13.Text = "Bigram Low: " + bigramLow.ToString();
            flatTextBox15.Text = "Same-GP Ratio: " + sameGPRatio.ToString();
            flatTextBox2.Text = "Average Letter Distance: " + avgLetterDistance.ToString();
            flatTextBox5.Text = "Average Rune Repeat Distance: " + avgRuneRepeatDistance.ToString();
            flatTextBox8.Text = "Average Dbl/Double Rune Distance: " + avgDblRuneDistance.ToString();
            flatTextBox11.Text = "Average Letter X Repeat Distance: " + avgLetterXRepeatDistance.ToString();
            flatTextBox14.Text = "Average Letter F Repeat Distance: " + avgLetterFRepeatDistance.ToString();
            flatTextBox18.Text = "Bigram Frequency: " + string.Join(", ", bigramFrequencySorted.Select(pair => $"{pair.Key}:{pair.Value}"));
            flatTextBox3.Text = "Trigram Frequency: " + string.Join(", ", trigramFrequencySorted.Select(pair => $"{pair.Key}:{pair.Value}"));
            flatTextBox6.Text = "Letter Frequency: " + string.Join(", ", letterFrequencySorted.Select(pair => $"{pair.Key}:{pair.Value}"));
            flatTextBox28.Text = "Letter Frequency (%): " + string.Join(", ", letterFrequencyPercentage.Select(pair => $"{pair.Key}: {pair.Value:0.00}%"));
            flatTextBox27.Text = "Converted Latin Frequency (%): " + string.Join(", ", latinFrequencyPercentage.Select(pair => $"{pair.Key}: {pair.Value:0.00}%"));
            flatTextBox9.Text = "Repeated Grams (length 3): " + string.Join(", ", repeatedGramsSorted.Select(pair => $"{pair.Key}:{pair.Value}"));
            flatTextBox12.Text = "Similar Grams (length 3): " + string.Join(", ", similarGramsSorted.Select(pair => $"{pair.Key}:{pair.Value}"));
            flatTextBox16.Text = "Trigram Ratio: " + trigramRatio.ToString();
            flatTextBox17.Text = "Median Letter F Repeat Distance: " + medLetterFRepeatDistance.ToString();
        }

        private void flatTextBox1_TextChanged(object sender, EventArgs e)
        {
            flatTextBox1.ReadOnly = true;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Read input values
            if (!int.TryParse(Interaction.InputBox("Enter shift value:", "Shift"), out int shift))
            {
                MessageBox.Show("Please enter a valid shift value.");
                return;
            }

            string key = string.IsNullOrEmpty(fastColoredTextBox2.Text) ? "" : fastColoredTextBox2.Text.Replace("\r\n", "").Replace(" ", "");
            var lines = fastColoredTextBox1.Lines.Select(RemoveInterrupterRunes).ToArray();
            Dictionary<string, int> gematriaPrimus = Functions.gematriaPrimus;
            int[][] keyValues = key.Equals("Keys are applied automatically") ? new int[][] { new int[0] } : key.Split(',').Select(k => k.ToCharArray().Select(c => Functions.GetNumericEquivalent(c.ToString())).ToArray()).ToArray();

            // Generate output
            StringBuilder output = new StringBuilder();
            for (int keyIndex = 0; keyIndex < keyValues.Length; keyIndex++)
            {
                for (int currentShift = 0; currentShift <= shift; currentShift++)
                {
                    var shiftType = currentShift == 0 ? "No-Shift" : $"Shift-{currentShift}";
                    var forwardShiftOutput = Functions.ForwardShift(lines, currentShift, keyValues[keyIndex], gematriaPrimus);
                    var reverseShiftOutput = Functions.ReverseShift(lines, currentShift, keyValues[keyIndex], gematriaPrimus);

                    output.AppendLine($"(Key-{keyIndex + 1}) ({shiftType}) (Forward Shift)");
                    output.AppendLine(forwardShiftOutput.ToString());

                    if (currentShift > 0)
                    {
                        output.AppendLine($"(Key-{keyIndex + 1}) ({shiftType}) (Reverse Shift)");
                        output.AppendLine(reverseShiftOutput.ToString());
                    }
                }
            }

            // Display output
            fastColoredTextBox3.Clear();
            fastColoredTextBox3.Text = output.ToString();
        }

        private void materialButton21_Click(object sender, EventArgs e)
        {
            // Get the text entered by the user in the "fastColoredTextBox4" control
            string inputText = fastColoredTextBox4.Text;

            // Remove interrupter runes from the input text
            for (int i = 0; i < inputText.Length; i++)
            {
                inputText = RemoveInterrupterRunes(inputText);
            }

            // Create a new StringBuilder instance to efficiently build up the output string
            StringBuilder outputTextBuilder = new StringBuilder(inputText.Length);

            // Retrieve a dictionary of character-to-string mappings for replacing certain characters
            Dictionary<char, string> gematriaPrimus = Functions.DirectTranslation;

            // Replace each rune in the input text with its Latin equivalent
            foreach (char c in inputText)
            {
                // Check if the current character is in the gematriaPrimus dictionary
                if (gematriaPrimus.TryGetValue(c, out string latinEquivalent))
                {
                    // If it is, append the corresponding Latin equivalent to the outputTextBuilder
                    outputTextBuilder.Append(latinEquivalent);
                }
                else
                {
                    // Otherwise, append the original character to the outputTextBuilder
                    outputTextBuilder.Append(c);
                }
            }

            // Clear the text of the "fastColoredTextBox3" control
            fastColoredTextBox3.Clear();

            // Set the text of the "fastColoredTextBox3" control to the resulting string
            fastColoredTextBox3.Text = outputTextBuilder.ToString();
        }

        private void materialButton20_Click(object sender, EventArgs e)
        {
            // Get the delimiters and the Vigenere key from the text boxes
            string delimiters = "-.&$§/•%\" ";
            string key = fastColoredTextBox2.Text.Replace("\r\n", "");

            // Split the cipher text into lines and create a dictionary for the Gematria Primus values
            string[] lines = fastColoredTextBox4.Lines.ToArray();

            // Remove interrupter runes from the input text
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = RemoveInterrupterRunes(lines[i]);
            }

            Dictionary<string, int> gematriaPrimus = Functions.gematriaPrimus;

            // Create an array of key values by converting each character to its numeric equivalent
            int[] keyValues = key.ToCharArray().Select(c => Functions.GetNumericEquivalent(c.ToString())).ToArray();

            // Decrypt the entire cipher text using the key
            string output = "";
            string decryptedText = "";
            int keyIndex = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                // Decrypt the current line using the current key
                string line = lines[i];
                string decryptedLine = "";
                for (int j = 0; j < line.Length; j++)
                {
                    string rune = line[j].ToString();

                    // If the rune is a delimiter, add it to the decrypted line and continue to the next character
                    if (delimiters.Contains(rune))
                    {
                        decryptedLine += rune;
                        continue;
                    }

                    // If the rune is 'F' and the previous character is also 'F', add it to the decrypted line and continue to the next character
                    if (rune == "F" && (j == 0 || line[j - 1] == 'F'))
                    {
                        decryptedLine += "F";
                        continue;
                    }

                    // Convert the current rune to its decimal value using the Gematria Primus dictionary
                    int decimalValue = gematriaPrimus[rune];

                    // Get the key value for the current index and shift the decimal value by the key value
                    int keyValue = keyValues[keyIndex % keyValues.Length];
                    int shiftedValue = (decimalValue - keyValue + 29) % 29;

                    // Get the shifted rune and its Latin equivalent and add the Latin equivalent to the decrypted line
                    string shiftedRune = Functions.runeArray[shiftedValue];
                    string latinEquivalent = Functions.GetLatinEquivalent(shiftedRune);
                    decryptedLine += latinEquivalent;

                    // Increment the key index
                    keyIndex++;

                    // If the current character is 'F' and the next character is also 'F', add it to the decrypted line and skip the next character
                    if (j < line.Length - 1 && line[j + 1] == 'F')
                    {
                        decryptedLine += "F";
                        j++;
                    }
                }

                // Add the decrypted line to the decrypted text, adding a line break if it is not the last line
                decryptedText += decryptedLine;
                if (i < lines.Length - 1)
                {
                    decryptedText += "\r\n";
                }
            }

            // Add the decrypted text to the output
            output += decryptedText.TrimEnd();

            // Display the output in the result text box
            fastColoredTextBox3.Clear();
            fastColoredTextBox3.Text = output;
            //MatchInterrupterRunes();
        }


        private void fastColoredTextBox3_Load(object sender, EventArgs e)
        {
            // Define an array of delimiters to use for word counting
            string[] delimiters = { " ", "\r\n", "\t", "\n", "\r", ",", ".", "!", "?", ";", ":", "-", "_", "\"", "'", "(", ")", "{", "}", "[", "]" };

            // Get the text from the fastColoredTextBox3 control
            string text1 = fastColoredTextBox3.Text;

            // Trim the text to remove any leading or trailing whitespaces
            string trimmedText = text1.Trim();

            // Split the text into sentences using regular expressions
            string[] sentences = Regex.Split(text1, @"(?<=[./!?]|[\u2026]|[\u203D]|[\u2047-\u2049]|[\u3002]|[\uFE52-\uFE56])\s+(?=\p{Lu})");

            // Count the number of words, characters, characters excluding whitespaces, sentences, lines, and paragraphs in the text
            int sentenceCount = sentences.Length;
            int wordCount = trimmedText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            int characterCount = text1.Length;
            int characterCountExcludingWhitespaces = Regex.Replace(trimmedText, @"\s+", "").Length;
            int lineCount = CountTotalLines(fastColoredTextBox3);
            int paragraphCount = CountParagraphs(text1);

            // Update the various text boxes with the counts
            flatTextBox23.Text = String.Format("Words: {0}", wordCount);
            flatTextBox22.Text = String.Format("Characters: {0}", characterCount);
            flatTextBox21.Text = String.Format("Characters (excluding whitespaces): {0}", characterCountExcludingWhitespaces);
            flatTextBox20.Text = String.Format("Sentences: {0}", sentenceCount);
            flatTextBox19.Text = String.Format("Total Lines: {0}", lineCount);
            flatTextBox24.Text = String.Format("Paragraphs: {0}", paragraphCount);

            // Refresh the form to update the text boxes
            this.Refresh();
        }

        private int CountTotalLines(FastColoredTextBox textBox)
        {
            return textBox.Lines.Count();
        }

        private int CountParagraphs(string text)
        {
            string[] paragraphs = text.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None);
            int paragraphCount = 0;
            foreach (string paragraph in paragraphs)
            {
                if (!string.IsNullOrWhiteSpace(paragraph))
                {
                    paragraphCount++;
                }
            }
            return paragraphCount;
        }

        private void materialButton30_Click(object sender, EventArgs e)
        {
            // Set the desired line length for the output text (change this value as needed)
            const int lineLength = 20;

            // Initialize variables for counting the number of characters and the sum of numeric equivalents
            int count = 0;
            int totalSum = 0;

            // Create a StringBuilder to efficiently build up the output text
            StringBuilder outputTextBuilder = new StringBuilder();

            // Iterate over each character in the input text of the "fastColoredTextBox2" control
            foreach (char c in fastColoredTextBox2.Text)
            {
                // Retrieve the numeric equivalent of the current character from the cipher table
                if (Functions.NumericEquivalent.TryGetValue(c, out int numericValue))
                {
                    // If the line is longer than the desired line length, start a new line
                    if (count >= lineLength)
                    {
                        outputTextBuilder.AppendLine();
                        count = 0;
                    }

                    // Add the numeric equivalent to the output text and update the count and total sum
                    outputTextBuilder.Append(numericValue).Append(' ');
                    totalSum += numericValue;
                    count++;
                }
            }

            // Add a newline character and the total sum to the end of the output text
            outputTextBuilder.AppendLine().AppendFormat("Total Sum = {0}", totalSum);

            // Set the text of the "fastColoredTextBox2" control to the output text
            fastColoredTextBox2.Text = outputTextBuilder.ToString().TrimEnd();
        }

        private void materialButton34_Click(object sender, EventArgs e)
        {
            // Set the desired line length for the output text (change this value as needed)
            const int lineLength = 20;

            // Initialize variables for counting the number of characters and the sum of numeric equivalents
            int count = 0;
            int totalSum = 0;

            // Create a StringBuilder to efficiently build up the output text
            StringBuilder outputTextBuilder = new StringBuilder();

            // Iterate over each character in the input text of the "fastColoredTextBox4" control
            foreach (char c in fastColoredTextBox4.Text)
            {
                // Retrieve the numeric equivalent of the current character from the cipher table
                if (Functions.NumericEquivalent.TryGetValue(c, out int numericValue))
                {
                    // If the line is longer than the desired line length, start a new line
                    if (count >= lineLength)
                    {
                        outputTextBuilder.AppendLine();
                        count = 0;
                    }

                    // Add the numeric equivalent to the output text and update the count and total sum
                    outputTextBuilder.Append(numericValue).Append(' ');
                    totalSum += numericValue;
                    count++;
                }
            }

            // Add a newline character and the total sum to the end of the output text
            outputTextBuilder.AppendLine().AppendFormat("Total Sum = {0}", totalSum);

            // Set the text of the "fastColoredTextBox4" control to the output text
            fastColoredTextBox4.Text = outputTextBuilder.ToString().TrimEnd();
        }

        private void materialButton29_Click(object sender, EventArgs e)
        {
            // Get the input text from the "fastColoredTextBox2" control
            string inputText = fastColoredTextBox2.Text;

            // Retrieve the set of keys in the cipher table from a static class called "Functions"
            HashSet<char> cipherTableKeys = new HashSet<char>(Functions.PrimeEquivalent.Keys);

            // Set the desired line length for the output text (change this value as needed)
            const int lineLength = 20;

            // Initialize variables for counting the number of characters and the sum of prime equivalents
            int count = 0;
            int totalSum = 0;

            // Create a StringBuilder to efficiently build up the output text
            StringBuilder outputTextBuilder = inputText
                .Where(cipherTableKeys.Contains) // Filter out characters not in the cipher table
                .Aggregate(new StringBuilder(inputText.Length), (builder, c) => // Aggregate characters into a StringBuilder object
                {
                    // If the line is longer than the desired line length, start a new line
                    if (count >= lineLength)
                    {
                        builder.AppendLine();
                        count = 0;
                    }

                    // Retrieve the prime equivalent of the current character from the cipher table
                    int primeEquivalent = Functions.PrimeEquivalent[c];

                    // Add the prime equivalent to the output text and update the count and total sum
                    builder.Append(primeEquivalent).Append(' ');
                    totalSum += primeEquivalent;
                    count++;

                    // Return the StringBuilder object with the new character added
                    return builder;
                });

            // Add a newline character and the total sum to the end of the output text
            outputTextBuilder.AppendLine();
            outputTextBuilder.AppendFormat("Total Sum = {0}", totalSum);

            // Set the text of the "fastColoredTextBox2" control to the output text
            fastColoredTextBox2.Text = outputTextBuilder.ToString().TrimEnd();
        }

        private void materialButton33_Click(object sender, EventArgs e)
        {
            // Get the input text from the "fastColoredTextBox4" control
            string inputText = fastColoredTextBox4.Text;

            // Retrieve the set of keys in the cipher table from a static class called "Functions"
            HashSet<char> cipherTableKeys = new HashSet<char>(Functions.PrimeEquivalent.Keys);

            // Set the desired line length for the output text (change this value as needed)
            const int lineLength = 20;

            // Initialize variables for counting the number of characters and the sum of prime equivalents
            int count = 0;
            int totalSum = 0;

            // Create a StringBuilder to efficiently build up the output text
            StringBuilder outputTextBuilder = inputText
                .Where(cipherTableKeys.Contains) // Filter out characters not in the cipher table
                .Aggregate(new StringBuilder(inputText.Length), (builder, c) => // Aggregate characters into a StringBuilder object
                {
                    // If the line is longer than the desired line length, start a new line
                    if (count >= lineLength)
                    {
                        builder.AppendLine();
                        count = 0;
                    }

                    // Retrieve the prime equivalent of the current character from the cipher table
                    int primeEquivalent = Functions.PrimeEquivalent[c];

                    // Add the prime equivalent to the output text and update the count and total sum
                    builder.Append(primeEquivalent).Append(' ');
                    totalSum += primeEquivalent;
                    count++;

                    // Return the StringBuilder object with the new character added
                    return builder;
                });

            // Add a newline character and the total sum to the end of the output text
            outputTextBuilder.AppendLine();
            outputTextBuilder.AppendFormat("Total Sum = {0}", totalSum);

            // Set the text of the "fastColoredTextBox4" control to the output text
            fastColoredTextBox4.Text = outputTextBuilder.ToString().TrimEnd();
        }

        private void materialButton24_Click(object sender, EventArgs e)
        {
            // Retrieve the Atbash table from a static class called "Functions"
            Dictionary<string, string> atbashTable = Functions.atbashTable;

            // Create a StringBuilder to efficiently build up the Atbash cipher text
            StringBuilder atbashedText = new StringBuilder();

            // Iterate over each line in the "fastColoredTextBox2" control
            foreach (string line in fastColoredTextBox2.Lines)
            {
                // Create a new string to hold the Atbash cipher line
                string atbashedLine = "";

                // Iterate over each character (rune) in the current line
                foreach (char rune in line)
                {
                    // Convert the current rune to a string
                    string runeString = rune.ToString();

                    // If the rune is in the Atbash table, replace it with its Atbash equivalent
                    if (atbashTable.ContainsKey(runeString))
                    {
                        atbashedLine += atbashTable[runeString];
                    }
                    else
                    {
                        // Otherwise, just add the original rune to the Atbash cipher line
                        atbashedLine += runeString;
                    }
                }

                // Add the Atbash cipher line (with a newline character) to the StringBuilder
                atbashedText.AppendLine(atbashedLine);
            }

            // Clear the text of the "fastColoredTextBox2" control and set its text to the Atbash cipher text
            fastColoredTextBox2.Clear();
            fastColoredTextBox2.AppendText(atbashedText.ToString());
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            // Retrieve the Atbash table from a static class called "Functions"
            Dictionary<string, string> atbashTable = Functions.atbashTable;

            // Create a StringBuilder to efficiently build up the Atbash cipher text
            StringBuilder atbashedText = new StringBuilder();

            // Iterate over each line in the "fastColoredTextBox1" control
            foreach (string line in fastColoredTextBox1.Lines)
            {
                // Create a new string to hold the Atbash cipher line
                string atbashedLine = "";

                // Iterate over each character (rune) in the current line
                foreach (char rune in line)
                {
                    // Convert the current rune to a string
                    string runeString = rune.ToString();

                    // If the rune is in the Atbash table, replace it with its Atbash equivalent
                    if (atbashTable.ContainsKey(runeString))
                    {
                        atbashedLine += atbashTable[runeString];
                    }
                    else
                    {
                        // Otherwise, just add the original rune to the Atbash cipher line
                        atbashedLine += runeString;
                    }
                }

                // Add the Atbash cipher line (with a newline character) to the StringBuilder
                atbashedText.AppendLine(atbashedLine);
            }

            // Clear the text of the "fastColoredTextBox1" control and set its text to the Atbash cipher text
            fastColoredTextBox1.Clear();
            fastColoredTextBox1.AppendText(atbashedText.ToString());
        }

        private void fastColoredTextBox2_Load(object sender, EventArgs e)
        {

        }

        private void flatTextBox23_TextChanged(object sender, EventArgs e)
        {
            flatTextBox23.ReadOnly = true;
        }

        private void materialButton36_Click(object sender, EventArgs e)
        {
            // Get the current text in the fastColoredTextBox3 control
            string originalText = fastColoredTextBox3.Text;

            // Split the text into lines
            string[] lines = originalText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // Reverse each line of the text
            for (int i = 0; i < lines.Length; i++)
            {
                char[] chars = lines[i].ToCharArray();
                Array.Reverse(chars);
                lines[i] = new string(chars);
            }

            // Join the reversed lines back into a single string
            string reversedText = string.Join(Environment.NewLine, lines);

            // Set the text of the fastColoredTextBox3 control to the reversed text
            fastColoredTextBox3.Text = reversedText;
        }

        private void materialButton37_Click(object sender, EventArgs e)
        {
            // Get the current text in the fastColoredTextBox3 control
            string originalText = fastColoredTextBox3.Text;

            // Split the text into lines
            string[] lines = originalText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // Flip each line of the text horizontally
            for (int i = 0; i < lines.Length; i++)
            {
                char[] chars = lines[i].ToCharArray();
                Array.Reverse(chars);
                lines[i] = new string(chars);
            }

            // Reverse the order of the lines to flip the text vertically
            Array.Reverse(lines);

            // Join the flipped lines back into a single string
            string flippedText = string.Join(Environment.NewLine, lines);

            // Set the text of the fastColoredTextBox3 control to the flipped text
            fastColoredTextBox3.Text = flippedText;
        }

        private void materialButton38_Click(object sender, EventArgs e)
        {
            fastColoredTextBox3.Multiline = true;
            fastColoredTextBox3.WordWrap = true;

            // Get the text from the fastColoredTextBox3 control
            string originalText = fastColoredTextBox3.Text;

            // Split the text into lines
            string[] lines = originalText.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Create a single instance of the Random object to be reused
            Random random = new Random();

            // Apply the permutation to each word on each line
            List<string> permutedLines = new List<string>();
            foreach (string line in lines)
            {
                // Split the line into separate words
                string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Apply the permutation to each word
                List<string> permutedWords = new List<string>();
                foreach (string word in words)
                {
                    // Convert the word to a list of characters
                    List<char> chars = word.ToCharArray().ToList();

                    // Randomly shuffle the list of characters using the same Random object
                    for (int i = chars.Count - 1; i > 0; i--)
                    {
                        int j = random.Next(0, i + 1);
                        char temp = chars[i];
                        chars[i] = chars[j];
                        chars[j] = temp;
                    }

                    // Convert the shuffled list of characters back to a string and add it to the list of permuted words
                    string permutedWord = new string(chars.ToArray());
                    permutedWords.Add(permutedWord);
                }

                // Join the permuted words back together on the line and add the line to the list of permuted lines
                string permutedLine = string.Join(" ", permutedWords);
                permutedLines.Add(permutedLine);
            }

            // Join the permuted lines back together to form the new text
            string permutedText = string.Join(Environment.NewLine, permutedLines);

            // Output the result of the permutation in the fastColoredTextBox3 control, maintaining the original format of the text
            fastColoredTextBox3.Text = permutedText;
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox4.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void materialButton18_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox4.Text);
                }
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialButton28_Click(object sender, EventArgs e)
        {
            // Get the current text in the fastColoredTextBox2 control
            string originalText = fastColoredTextBox2.Text;

            // Split the text into lines
            string[] lines = originalText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // Reverse each line of the text
            for (int i = 0; i < lines.Length; i++)
            {
                char[] chars = lines[i].ToCharArray();
                Array.Reverse(chars);
                lines[i] = new string(chars);
            }

            // Join the reversed lines back into a single string
            string reversedText = string.Join(Environment.NewLine, lines);

            // Set the text of the fastColoredTextBox2 control to the reversed text
            fastColoredTextBox2.Text = reversedText;
        }

        private void flatTextBox2_TextChanged(object sender, EventArgs e)
        {
            flatTextBox2.ReadOnly = true;
        }

        private void flatTextBox3_TextChanged(object sender, EventArgs e)
        {
            flatTextBox3.ReadOnly = true;
        }

        private void flatTextBox4_TextChanged(object sender, EventArgs e)
        {
            flatTextBox4.ReadOnly = true;
        }

        private void flatTextBox5_TextChanged(object sender, EventArgs e)
        {
            flatTextBox5.ReadOnly = true;
        }

        private void flatTextBox6_TextChanged(object sender, EventArgs e)
        {
            flatTextBox6.ReadOnly = true;
        }

        private void flatTextBox7_TextChanged(object sender, EventArgs e)
        {
            flatTextBox7.ReadOnly = true;
        }

        private void flatTextBox8_TextChanged(object sender, EventArgs e)
        {
            flatTextBox8.ReadOnly = true;
        }

        private void flatTextBox9_TextChanged(object sender, EventArgs e)
        {
            flatTextBox9.ReadOnly = true;
        }

        private void flatTextBox10_TextChanged(object sender, EventArgs e)
        {
            flatTextBox10.ReadOnly = true;
        }

        private void flatTextBox11_TextChanged(object sender, EventArgs e)
        {
            flatTextBox11.ReadOnly = true;
        }

        private void flatTextBox12_TextChanged(object sender, EventArgs e)
        {
            flatTextBox12.ReadOnly = true;
        }

        private void flatTextBox13_TextChanged(object sender, EventArgs e)
        {
            flatTextBox13.ReadOnly = true;
        }

        private void flatTextBox14_TextChanged(object sender, EventArgs e)
        {
            flatTextBox14.ReadOnly = true;
        }

        private void flatTextBox15_TextChanged(object sender, EventArgs e)
        {
            flatTextBox15.ReadOnly = true;
        }

        private void flatTextBox16_TextChanged(object sender, EventArgs e)
        {
            flatTextBox16.ReadOnly = true;
        }

        private void flatTextBox17_TextChanged(object sender, EventArgs e)
        {
            flatTextBox17.ReadOnly = true;
        }

        private void flatTextBox18_TextChanged(object sender, EventArgs e)
        {
            flatTextBox18.ReadOnly = true;
        }

        private void flatTextBox22_TextChanged(object sender, EventArgs e)
        {
            flatTextBox22.ReadOnly = true;
        }

        private void flatTextBox21_TextChanged(object sender, EventArgs e)
        {
            flatTextBox21.ReadOnly = true;
        }

        private void flatTextBox20_TextChanged(object sender, EventArgs e)
        {
            flatTextBox20.ReadOnly = true;
        }

        private void flatTextBox19_TextChanged(object sender, EventArgs e)
        {
            flatTextBox19.ReadOnly = true;
        }

        private void flatTextBox24_TextChanged(object sender, EventArgs e)
        {
            flatTextBox24.ReadOnly = true;
        }

        private void materialButton40_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox2, "./Pages", "*.txt");
            Functions.PopulateListBox(listBox2, "./Pages", "*.lua");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox5.Text = File.ReadAllText($"./Pages/{listBox2.SelectedItem}");
        }
        private void materialButton46_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the input text from fastColoredTextBox5
                string inputText = fastColoredTextBox5.Text;

                // Split the input text into lines
                string[] inputLines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                // Prepare the output StringBuilder
                StringBuilder outputTextBuilder = new StringBuilder();

                // Process each line
                foreach (string line in inputLines)
                {
                    // Convert the input text to its Latin format using the runicToLatin dictionary
                    Dictionary<char, string> runicToLatin = Functions.DirectTranslation;
                    StringBuilder latinInputBuilder = new StringBuilder();
                    foreach (char c in line)
                    {
                        string latinChar;
                        if (runicToLatin.TryGetValue(c, out latinChar))
                        {
                            latinInputBuilder.Append(latinChar);
                        }
                        else
                        {
                            latinInputBuilder.Append(c);
                        }
                    }
                    string latinInputText = latinInputBuilder.ToString();

                    // Get the transposition key from flatTextBox26
                    string keyText = flatTextBox26.Text;

                    // Remove interrupter runes from the Latin input text
                    for (int i = 0; i < latinInputText.Length; i++)
                    {
                        latinInputText = RemoveInterrupterRunes(latinInputText);
                    }

                    // Decrypt the Latin input text using the transposition cipher and key
                    string plainText = Functions.TranspositionCipher(latinInputText, keyText);

                    // Append the decrypted plaintext to the output text
                    outputTextBuilder.AppendLine(plainText);
                }

                // Set the output text to the decrypted plaintext
                fastColoredTextBox3.Text = outputTextBuilder.ToString();
            }
            catch (ArgumentException ex)
            {
                // If there was an error with the transposition key, display an error message
                MessageBox.Show(ex.Message);
            }

            // Display an alert message
            MessageBox.Show("Please note that this feature is still a work in progress and may not produce accurate results. Use the output with caution and report any issues or errors you encounter.");
        }

        private void flatTextBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialButton41_Click(object sender, EventArgs e)
        {
            fastColoredTextBox5.Clear();
        }

        private void materialButton39_Click(object sender, EventArgs e)
        {
            // Set the desired line length for the output text (change this value as needed)
            const int lineLength = 20;

            // Initialize variables for counting the number of characters and the sum of numeric equivalents
            int count = 0;
            int totalSum = 0;

            // Create a StringBuilder to efficiently build up the output text
            StringBuilder outputTextBuilder = new StringBuilder();

            // Iterate over each character in the input text of the "fastColoredTextBox5" control
            foreach (char c in fastColoredTextBox5.Text)
            {
                // Retrieve the numeric equivalent of the current character from the cipher table
                if (Functions.NumericEquivalent.TryGetValue(c, out int numericValue))
                {
                    // If the line is longer than the desired line length, start a new line
                    if (count >= lineLength)
                    {
                        outputTextBuilder.AppendLine();
                        count = 0;
                    }

                    // Add the numeric equivalent to the output text and update the count and total sum
                    outputTextBuilder.Append(numericValue).Append(' ');
                    totalSum += numericValue;
                    count++;
                }
            }

            // Add a newline character and the total sum to the end of the output text
            outputTextBuilder.AppendLine().AppendFormat("Total Sum = {0}", totalSum);

            // Set the text of the "fastColoredTextBox5" control to the output text
            fastColoredTextBox5.Text = outputTextBuilder.ToString().TrimEnd();
        }

        private void materialButton14_Click(object sender, EventArgs e)
        {
            // Get the input text from the "fastColoredTextBox5" control
            string inputText = fastColoredTextBox5.Text;

            // Retrieve the set of keys in the cipher table from a static class called "Functions"
            HashSet<char> cipherTableKeys = new HashSet<char>(Functions.PrimeEquivalent.Keys);

            // Set the desired line length for the output text (change this value as needed)
            const int lineLength = 20;

            // Initialize variables for counting the number of characters and the sum of prime equivalents
            int count = 0;
            int totalSum = 0;

            // Create a StringBuilder to efficiently build up the output text
            StringBuilder outputTextBuilder = inputText
                .Where(cipherTableKeys.Contains) // Filter out characters not in the cipher table
                .Aggregate(new StringBuilder(inputText.Length), (builder, c) => // Aggregate characters into a StringBuilder object
                {
                    // If the line is longer than the desired line length, start a new line
                    if (count >= lineLength)
                    {
                        builder.AppendLine();
                        count = 0;
                    }

                    // Retrieve the prime equivalent of the current character from the cipher table
                    int primeEquivalent = Functions.PrimeEquivalent[c];

                    // Add the prime equivalent to the output text and update the count and total sum
                    builder.Append(primeEquivalent).Append(' ');
                    totalSum += primeEquivalent;
                    count++;

                    // Return the StringBuilder object with the new character added
                    return builder;
                });

            // Add a newline character and the total sum to the end of the output text
            outputTextBuilder.AppendLine();
            outputTextBuilder.AppendFormat("Total Sum = {0}", totalSum);

            // Set the text of the "fastColoredTextBox5" control to the output text
            fastColoredTextBox5.Text = outputTextBuilder.ToString().TrimEnd();
        }

        private void materialButton44_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox5.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void materialButton43_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox5.Text);
                }
            }
        }

        private void materialButton42_Click(object sender, EventArgs e)
        {
            // Retrieve the Atbash table from a static class called "Functions"
            Dictionary<string, string> atbashTable = Functions.atbashTable;

            // Create a StringBuilder to efficiently build up the Atbash cipher text
            StringBuilder atbashedText = new StringBuilder();

            // Iterate over each line in the "fastColoredTextBox5" control
            foreach (string line in fastColoredTextBox5.Lines)
            {
                // Create a new string to hold the Atbash cipher line
                string atbashedLine = "";

                // Iterate over each character (rune) in the current line
                foreach (char rune in line)
                {
                    // Convert the current rune to a string
                    string runeString = rune.ToString();

                    // If the rune is in the Atbash table, replace it with its Atbash equivalent
                    if (atbashTable.ContainsKey(runeString))
                    {
                        atbashedLine += atbashTable[runeString];
                    }
                    else
                    {
                        // Otherwise, just add the original rune to the Atbash cipher line
                        atbashedLine += runeString;
                    }
                }

                // Add the Atbash cipher line (with a newline character) to the StringBuilder
                atbashedText.AppendLine(atbashedLine);
            }

            // Clear the text of the "fastColoredTextBox5" control and set its text to the Atbash cipher text
            fastColoredTextBox5.Clear();
            fastColoredTextBox5.AppendText(atbashedText.ToString());
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void materialButton31_Click_1(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Desktop", "LPDecrypt-Modern", "criblist.txt");
            string[] words;

            if (File.Exists(filePath))
            {
                words = File.ReadAllLines(filePath);
            }
            else
            {
                MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FindReadableWords(words);
        }

        private void FindReadableWords(string[] words)
        {
            fastColoredTextBox3.Range.ClearStyle(StyleIndex.All);
            fastColoredTextBox3.Range.ClearFoldingMarkers();

            TextStyle readableWordStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);

            foreach (string word in words)
            {
                string trimmedWord = word.Trim();
                if (!string.IsNullOrEmpty(trimmedWord))
                {
                    string pattern = @"\b" + Regex.Escape(trimmedWord) + @"\b";
                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

                    var matches = regex.Matches(fastColoredTextBox3.Text);
                    foreach (Match match in matches)
                    {
                        Place start = fastColoredTextBox3.PositionToPlace(match.Index);
                        Place end = fastColoredTextBox3.PositionToPlace(match.Index + match.Length);
                        Range range = new Range(fastColoredTextBox3, start, end);
                        range.SetStyle(readableWordStyle);
                    }
                }
            }
        }
    }
}
