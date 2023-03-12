using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPD_Modern
{
    internal class Cryptanalysis
    {
        public static Dictionary<char, int> GetRuneFrequency(string userInput)
        {
            // Create a new dictionary to store the frequency of each rune in the user input
            Dictionary<char, int> runeFrequency = new Dictionary<char, int>();

            // Loop through each character in the user input
            foreach (char c in userInput)
            {
                // If the current character already exists in the dictionary, increment its frequency
                if (runeFrequency.ContainsKey(c))
                {
                    runeFrequency[c]++;
                }
                // Otherwise, add it to the dictionary with a frequency of 1
                else
                {
                    runeFrequency[c] = 1;
                }
            }

            // Return the rune frequency dictionary
            return runeFrequency;
        }

        public static double CalculateIoC(Dictionary<char, int> runeFrequency, int totalRuneCount)
        {
            // Initialize the index of coincidence (IoC) to 0
            double ioc = 0;

            // Loop through each key-value pair in the rune frequency dictionary
            foreach (var pair in runeFrequency)
            {
                // Calculate the contribution of the current rune to the IoC formula
                ioc += pair.Value * (pair.Value - 1);
            }

            // Complete the IoC formula by dividing by the total number of rune pairs in the text
            ioc /= totalRuneCount * (totalRuneCount - 1);

            // Return the calculated IoC value
            return ioc;
        }
        public static double CalculateEntropy(Dictionary<char, int> runeFrequency, int totalRuneCount)
        {
            // Initialize the entropy to 0
            double entropy = 0;

            // Check if the dictionary is empty
            if (!runeFrequency.Any())
            {
                return entropy;
            }

            // Get the character frequencies and calculate the total
            var occurences = runeFrequency.Values;
            int total = occurences.Sum();

            // Loop through each frequency in the list and calculate the entropy
            foreach (var occurence in occurences)
            {
                // Calculate the probability of the current rune occurring in the text
                double probability = (double)occurence / total;

                // Cache the result of total / (double)occurence
                double inverseProbability = total / (double)occurence;

                // Update the entropy by adding the current probability times the logarithm (base e) of the inverse probability
                if (probability != 0)
                {
                    entropy += probability * Math.Log(inverseProbability);
                }
            }

            // Return the calculated entropy value
            return entropy;
        }
        public static double ShannonEntropy(string input)
        {
            int inputLength = input.Length;
            HashSet<char> uniqueChars = new HashSet<char>(input);

            var charFrequencies = uniqueChars.Select(c => new {
                Character = c,
                Frequency = (double)input.Count(ch => ch == c) / inputLength
            });

            double entropy = charFrequencies.Sum(cf => -cf.Frequency * Math.Log(cf.Frequency, 2));

            return entropy;
        }

        public static Dictionary<string, int> GetBigramFrequency(string userInput)
        {
            // Create a new dictionary to store the frequency of each bigram in the user input
            Dictionary<string, int> bigramFrequency = new Dictionary<string, int>();

            // Get the total number of runes in the user input
            int totalRuneCount = userInput.Length;

            // Loop through each pair of adjacent runes in the user input
            for (int i = 0; i < totalRuneCount - 1; i++)
            {
                // Extract the current bigram from the user input
                string bigram = userInput.Substring(i, 2);

                // If the current bigram already exists in the dictionary, increment its frequency
                if (bigramFrequency.ContainsKey(bigram))
                {
                    bigramFrequency[bigram]++;
                }
                // Otherwise, add it to the dictionary with a frequency of 1
                else
                {
                    bigramFrequency[bigram] = 1;
                }
            }

            // Return the bigram frequency dictionary
            return bigramFrequency;
        }

        public static double CalculateBigramRatio(Dictionary<string, int> bigramFrequency, int totalBigramCount)
        {
            // Initialize the bigram ratio to 0
            double bigramRatio = 0;

            // If there are bigrams in the text, calculate the ratio of unique bigrams to total bigrams
            if (totalBigramCount > 0)
            {
                bigramRatio = (double)bigramFrequency.Count() / totalBigramCount;
            }

            // Return the calculated bigram ratio
            return bigramRatio;
        }

        public static Tuple<double, double> CalculateBigramPeakAndLow(Dictionary<string, int> bigramFrequency, int totalBigramCount)
        {
            // Initialize the bigram peak and low values to 0
            double bigramPeak = 0;
            double bigramLow = 0;

            // If there are bigrams in the text, calculate the maximum and minimum bigram frequencies
            if (totalBigramCount > 0)
            {
                double maxBigramFrequency = bigramFrequency.Max(pair => pair.Value);
                double minBigramFrequency = bigramFrequency.Min(pair => pair.Value);

                // Calculate the bigram peak and low values as a fraction of the total number of bigrams
                bigramPeak = maxBigramFrequency / totalBigramCount;
                bigramLow = minBigramFrequency / totalBigramCount;
            }

            // Return a tuple containing the calculated bigram peak and low values
            return Tuple.Create(bigramPeak, bigramLow);
        }

        public static Dictionary<string, int> GetTrigramFrequency(string userInput)
        {
            // Create a new dictionary to store the frequency of each trigram in the user input
            Dictionary<string, int> trigramFrequency = new Dictionary<string, int>();

            // Get the total number of runes in the user input
            int totalRuneCount = userInput.Length;

            // Loop through each set of three adjacent runes in the user input
            for (int i = 0; i < totalRuneCount - 2; i++)
            {
                // Extract the current trigram from the user input
                string trigram = userInput.Substring(i, 3);

                // If the current trigram already exists in the dictionary, increment its frequency
                if (trigramFrequency.ContainsKey(trigram))
                {
                    trigramFrequency[trigram]++;
                }
                // Otherwise, add it to the dictionary with a frequency of 1
                else
                {
                    trigramFrequency.Add(trigram, 1);
                }

                // Debugging code to print out the trigram and its frequency
                //Debug.WriteLine($"Trigram: {trigram}, Frequency: {trigramFrequency[trigram]}");
            }

            // Return the trigram frequency dictionary
            return trigramFrequency;
        }

        public static double CalculateTrigramRatio(Dictionary<string, int> trigramFrequency, int totalTrigramCount)
        {
            // Initialize the trigramRatio variable to 0
            double trigramRatio = 0;

            // Check if the totalTrigramCount is greater than 0
            if (totalTrigramCount > 0)
            {
                // Calculate the ratio of unique trigrams in the text compared to the total count of trigrams 
                trigramRatio = (double)trigramFrequency.Count() / totalTrigramCount;
            }

            // Return the calculated trigram ratio
            return trigramRatio;
        }

        public static Dictionary<string, int> GetSameGPFrequency(string userInput, Dictionary<char, int> runeFrequency)
        {
            // Create a new empty dictionary named sameGPFrequency
            Dictionary<string, int> sameGPFrequency = new Dictionary<string, int>();

            // Get the total number of runes in the userInput string
            int totalRuneCount = userInput.Length;

            // Iterate over the runes in the userInput string
            for (int i = 0; i < totalRuneCount - 1; i++)
            {
                // Initialize an empty string to hold the rune pair
                string runePair = "";

                // Check if the frequency of the current rune is greater than 1 in the runeFrequency dictionary
                if (runeFrequency[userInput[i]] > 1)
                {
                    // Add the current rune to the runePair string twice
                    runePair += userInput[i];
                    runePair += userInput[i];

                    // Check if the sameGPFrequency dictionary already contains the current rune pair
                    if (sameGPFrequency.ContainsKey(runePair))
                    {
                        // If it does, increment the count for the current rune pair
                        sameGPFrequency[runePair]++;
                    }
                    else
                    {
                        // If it doesn't, add the current rune pair to the sameGPFrequency dictionary with a count of 1
                        sameGPFrequency[runePair] = 1;
                    }
                }
            }

            // Return the sameGPFrequency dictionary containing the frequency of same rune pairs (GPFs) in the userInput string
            return sameGPFrequency;
        }

        public static double CalculateSameGPRatio(Dictionary<string, int> sameGPFrequency, int totalSameGPCount)
        {
            // Initialize the sameGPRatio variable to 0
            double sameGPRatio = 0;

            if (totalSameGPCount > 0)
            {
                // Calculate the ratio of unique same GPFs in the text compared to the total count of same GPFs 
                sameGPRatio = (double)sameGPFrequency.Count() / totalSameGPCount;
            }

            // Return the calculated same GPF ratio
            return sameGPRatio;
        }

        public static Dictionary<char, double> CalculateLetterFrequency(string text)
        {
            // Create a new empty dictionary named letterFrequency
            Dictionary<char, double> letterFrequency = new Dictionary<char, double>();

            // Initialize the total number of letters to 0
            int totalLetters = 0;

            // Count the number of occurrences of each letter in the text
            foreach (char c in text)
            {
                // Check if the current character is a letter
                if (char.IsLetter(c))
                {
                    // Check if the letterFrequency dictionary already contains the current letter
                    if (letterFrequency.ContainsKey(c))
                    {
                        // If it does, increment the count for the current letter
                        letterFrequency[c]++;
                    }
                    else
                    {
                        // If it doesn't, add the current letter to the letterFrequency dictionary with a count of 1
                        letterFrequency.Add(c, 1);
                    }
                    // Increment the total number of letters
                    totalLetters++;
                }
            }

            // Calculate the frequency of each letter as a percentage
            foreach (char c in letterFrequency.Keys.ToList())
            {
                letterFrequency[c] = letterFrequency[c] / totalLetters * 100;
            }

            // Return the letterFrequency dictionary containing the frequency of each letter in the text
            return letterFrequency;
        }

        public static Dictionary<string, int> CalculateRepeatedGrams(string text, int n)
        {
            // Create a new empty dictionary named repeatedGrams
            Dictionary<string, int> repeatedGrams = new Dictionary<string, int>();

            // Iterate over the text in n-gram chunks and count the occurrences of each n-gram
            for (int i = 0; i <= text.Length - n; i++)
            {
                // Get the n-gram at the current position
                string gram = text.Substring(i, n);

                // Check if the repeatedGrams dictionary already contains the current n-gram
                if (repeatedGrams.ContainsKey(gram))
                {
                    // If it does, increment the count for the current n-gram
                    repeatedGrams[gram]++;
                }
                else
                {
                    // If it doesn't, add the current n-gram to the repeatedGrams dictionary with a count of 1
                    repeatedGrams.Add(gram, 1);
                }
            }

            // Return the repeatedGrams dictionary containing the frequency of repeated n-grams in the text
            return repeatedGrams;
        }

        public static Dictionary<string, int> CalculateSimilarGrams(string text)
        {
            // Create a new dictionary named similarGrams to store the similar grams in the input text
            Dictionary<string, int> similarGrams = new Dictionary<string, int>();

            // Create arrays of runes, numerics, and primes
            string[] runeArrayStr = Functions.runeArray;
            char[] runeArray = new char[runeArrayStr.Length];
            for (int i = 0; i < runeArrayStr.Length; i++)
            {
                runeArray[i] = runeArrayStr[i][0];
            }
            int[] numericArray = Functions.numericArray;
            int[] primeArray = Functions.primeArray;

            // Iterate over the text in 3-gram chunks and count the occurrences of each similar gram
            for (int i = 0; i <= text.Length - 3; i++)
            {
                // Get the 3-gram at the current position
                string gram = text.Substring(i, 3);

                // Calculate the numeric value of the gram using the numericArray
                int gramValue = 1;
                foreach (char c in gram)
                {
                    int index = Array.IndexOf(runeArray, c);
                    if (index != -1 && index < numericArray.Length)
                    {
                        gramValue *= numericArray[index];
                    }
                }

                // Generate all possible similar grams by changing one rune
                for (int j = 0; j < 3; j++)
                {
                    foreach (char c in runeArray)
                    {
                        if (c != gram[j])
                        {
                            char[] gramChars = gram.ToCharArray();
                            gramChars[j] = c;
                            string similarGram = new string(gramChars);

                            // Calculate the numeric value of the similar gram using the numericArray
                            int similarGramValue = 1;
                            foreach (char sc in similarGram)
                            {
                                int index = Array.IndexOf(runeArray, sc);
                                if (index != -1 && index < numericArray.Length)
                                {
                                    similarGramValue *= numericArray[index];
                                }
                            }

                            // Check if the text contains the similar gram and add it to the similarGrams dictionary if it does
                            if (text.Contains(similarGram))
                            {
                                if (similarGrams.ContainsKey(similarGram))
                                {
                                    similarGrams[similarGram]++;
                                }
                                else
                                {
                                    similarGrams.Add(similarGram, 1);
                                }
                            }
                        }
                    }
                }
            }

            // Debug statements
            //Console.WriteLine($"Found {similarGrams.Count} similar grams for 3-grams in text of length {text.Length}.");
            //foreach (KeyValuePair<string, int> pair in similarGrams)
            //{
            //    Console.WriteLine($"{pair.Key}: {pair.Value}");
            //}

            //Return the dictionary of similar grams in the input text
            return similarGrams;
        }


        public static double CalculateAvgLetterDistance(string userInput)
        {
            // Initialize the avgLetterDistance variable to 0
            double avgLetterDistance = 0;

            // Initialize the letterCount and totalRuneCount variables to 0
            int letterCount = 0;
            int totalRuneCount = userInput.Length;

            // Iterate over the runes in the userInput string
            for (int i = 0; i < totalRuneCount - 1; i++)
            {
                // Check if the current and next runes are letters
                if (System.Char.IsLetter(userInput[i]) && System.Char.IsLetter(userInput[i + 1]))
                {
                    // Calculate the distance between the current and next letters
                    avgLetterDistance += Math.Abs(userInput[i] - userInput[i + 1]);

                    // Increment the letterCount variable
                    letterCount++;
                }
            }

            // Check if the letterCount is greater than 0
            if (letterCount > 0)
            {
                // If it is, calculate the average distance between adjacent letters
                avgLetterDistance /= letterCount;
            }

            // Return the calculated average distance between adjacent letters
            return avgLetterDistance;
        }

        public static double CalculateAvgRuneRepeatDistance(string userInput)
        {
            // Initialize the avgRuneRepeatDistance variable to 0
            double avgRuneRepeatDistance = 0;

            // Initialize the repeatCount and totalRuneCount variables to 0
            int repeatCount = 0;
            int totalRuneCount = userInput.Length;

            // Iterate over the runes in the userInput string
            for (int i = 0; i < totalRuneCount - 1; i++)
            {
                // Check if the current and next runes are the same
                if (userInput[i] == userInput[i + 1])
                {
                    // Find the index of the next non-repeating rune
                    int j = i + 1;
                    while (j < totalRuneCount && userInput[j] == userInput[i])
                    {
                        j++;
                    }

                    // Check if there is a non-repeating rune after the repeated runes
                    if (j < totalRuneCount)
                    {
                        // Calculate the distance between the repeated runes and the next non-repeating rune
                        avgRuneRepeatDistance += j - i;

                        // Increment the repeatCount variable
                        repeatCount++;
                    }

                    // Update the i variable to the index of the next non-repeating rune minus 1
                    i = j - 1;
                }
            }

            // Check if the repeatCount is greater than 0
            if (repeatCount > 0)
            {
                // If it is, calculate the average distance between repeated runes
                avgRuneRepeatDistance /= repeatCount;
            }

            // Return the calculated average distance between repeated runes
            return avgRuneRepeatDistance;
        }

        public static double CalculateAvgDblRuneDistance(string input)
        {
            // Create a new list named distances to store the distances between double runes
            List<int> distances = new List<int>();

            // Iterate over the runes in the input string
            for (int i = 0; i < input.Length - 1; i++)
            {
                // Check if the current and next runes are the same
                if (input[i] == input[i + 1])
                {
                    // Find the index of the next non-repeating rune
                    int j = i + 2;
                    while (j < input.Length && input[j] != input[i])
                    {
                        j++;
                    }

                    // Check if there is a non-repeating rune after the double runes
                    if (j < input.Length)
                    {
                        // Calculate the distance between the double runes and the next non-repeating rune
                        distances.Add(j - i);

                        // Update the i variable to the index of the next non-repeating rune minus 1
                        i = j - 1;
                    }
                }
            }

            // Calculate the average distance between double runes using the Average() method of the distances list
            double avgDistance = distances.Count > 0 ? distances.Average() : 0;

            // Debugging code to print out the list of distances between double runes
            //Debug.WriteLine($"List of distances between double runes: {string.Join(", ", distances)}");

            // Return the calculated average distance between double runes
            return avgDistance;
        }

        public static double CalculateAvgLetterXRepeatDistance(string userInput)
        {
            // Initialize variables
            double avgLetterXRepeatDistance = 0;
            int letterXRepeatCount = 0;
            int totalRuneCount = userInput.Length;

            // Iterate through each character in the input string
            for (int i = 0; i < totalRuneCount - 1; i++)
            {
                // Check if the current character is ᛉ and if the next character is also ᛉ
                if (userInput[i] == 'ᛉ' && userInput[i + 1] == 'ᛉ')
                {
                    // Continue iterating until we find a character that is not ᛉ
                    int j = i + 1;
                    while (j < totalRuneCount && userInput[j] == 'ᛉ')
                    {
                        j++;
                    }

                    // Calculate the distance between the starting position and the ending position of the repeated ᛉ characters,
                    // add it to avgLetterXRepeatDistance, and increment letterXRepeatCount
                    if (j < totalRuneCount)
                    {
                        avgLetterXRepeatDistance += j - i;
                        letterXRepeatCount++;
                    }

                    i = j - 1;
                }
            }

            // Calculate the average distance between repeated instances of the rune ᛉ
            if (letterXRepeatCount > 0)
            {
                avgLetterXRepeatDistance /= letterXRepeatCount;
            }
            return avgLetterXRepeatDistance;
        }
        public static double CalculateAvgLetterFRepeatDistance(string userInput)
        {
            // Initialize variables to store the average distance between letter Fs and the number of letter Fs found
            double avgLetterFRepeatDistance = 0;
            int letterFCount = 0;

            // Get the total number of letters F in the user input
            int totalLetterFCount = 0;
            foreach (char c in userInput)
            {
                if (char.ToLower(c) == 'f' || c == '\u16A0')
                {
                    totalLetterFCount++;
                }
            }

            // If there are less than two letter F's, return 0
            if (totalLetterFCount < 2)
            {
                return 0;
            }

            // Loop through each letter F in the user input
            int previousIndex = -1;
            for (int i = 0; i < userInput.Length; i++)
            {
                if (char.ToLower(userInput[i]) == 'f' || userInput[i] == '\u16A0')
                {
                    if (previousIndex >= 0)
                    {
                        int distance = i - previousIndex;
                        avgLetterFRepeatDistance += distance;
                        letterFCount++;
                    }
                    previousIndex = i;
                }
            }

            // If at least one letter F was found, calculate the average distance between letter Fs
            if (letterFCount > 0)
            {
                avgLetterFRepeatDistance /= letterFCount - 1;
            }

            // Return the average letter F repeat distance
            return avgLetterFRepeatDistance;
        }

        public static double CalculateMedianLetterFRepeatDistance(string userInput)
        {
            // Create a list to store the distances between letter Fs
            List<int> distances = new List<int>();

            // Loop through each letter F in the user input
            int previousIndex = -1;
            for (int i = 0; i < userInput.Length; i++)
            {
                if (char.ToLower(userInput[i]) == 'f' || userInput[i] == '\u16A0')
                {
                    if (previousIndex >= 0)
                    {
                        int distance = i - previousIndex;
                        distances.Add(distance);
                    }
                    previousIndex = i;
                }
            }

            // If there are less than two letter F's, return 0
            if (distances.Count < 2)
            {
                return 0;
            }

            // Sort the list of distances
            distances.Sort();

            // If the list has an odd number of elements, return the middle value
            if (distances.Count % 2 == 1)
            {
                return distances[distances.Count / 2];
            }
            // If the list has an even number of elements, return the average of the middle two values
            else
            {
                int index1 = distances.Count / 2 - 1;
                int index2 = distances.Count / 2;
                return (distances[index1] + distances[index2]) / 2.0;
            }
        }
    }
}