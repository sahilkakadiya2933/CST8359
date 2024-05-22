/*
 * Student name: Sahil Kakadiya
 * Student number: 041052919
 * Assignment: Lab2
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace Lab2
{
    class Program
    {
        public static void LoadWords(List<string> words)
        {
            try
            {

                //using text file
                using (StreamReader reader = new StreamReader("C:\\Users\\sahil\\Desktop\\Lab2Demo\\Words.txt"))
                {
                   
                    string word;
                    while ((word = reader.ReadLine()) != null)
                    {
                        words.Add(word);
                    }
                    Console.WriteLine($"The number of words is {words.Count}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(ex.Message);
            }
        }

        // Bubble Sort Method
        public static string[] SortWordsBubble(List<string> words)
        {
            string[] wordsArray = words.ToArray();
            bool swapped = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < wordsArray.Length - 1 && swapped; i++)
            {
                swapped = false;
                for (int j = 0; j < wordsArray.Length - 1 - i; j++)
                {
                    if (string.Compare(wordsArray[j], wordsArray[j + 1]) > 0)
                    {
                        (wordsArray[j], wordsArray[j + 1]) = (wordsArray[j + 1], wordsArray[j]);
                        swapped = true;
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds}ms\n");
            return wordsArray;
        }

        // Soft with Linq
        public static void SortWordsLinq(List<string> words)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var sortedWords = words.OrderBy(word => word).ToList();

            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms\n\n");
        }

        //Count dinstict words from text file
        public static void CountUniqueWords(List<string> words)
        {
            int uniqueWordCount = words.Distinct().Count();
            Console.WriteLine($"Distinct count is {uniqueWordCount}\n\n");
        }

        //print last ten words of this text file
        public static void LastTenWords(List<string> words)
        {
            var lastTenWords = words.Skip(Math.Max(0, words.Count - 10));
            Console.WriteLine("The last ten words are:\n");
            foreach (var word in lastTenWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }

        // Display all words which ius starting with Q
        public static void DisplayWordsStartingWithQ(List<string> words)
        {
            var qWords = words.Where(word => word.StartsWith("q", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"The  {qWords.Count()} words that start with 'q' are:\n"); 
            foreach (var word in qWords)
            {
                Console.WriteLine(word);
            }
            
        }

        // Display all words which is starting with D
        public static void DisplayWordsEndingWithD(List<string> words)
        {
            var dWords = words.Where(word => word.EndsWith("d", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"The {dWords.Count()} words that end with 'd' are: \n");
            foreach (var word in dWords)
            {
                Console.WriteLine(word);
            }
           
        }

        // convert the words into reverse order and display words
        public static void ReverseAndDisplayWords(List<string> words)
        {
            Console.WriteLine("The words printed from end to beginning are:\n"); 
            foreach (var word in words.AsEnumerable().Reverse())
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }

        // print all words who has more than three chars and it has a A
        public static void DisplayWordsMoreThanThreeCharsContainingA(List<string> words)
        {
            var aWords = words.Where(word => word.Length > 3 && word.Contains('a', StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"The {aWords.Count()} words that have more than 3 characters and contain the letter 'a' are:\n");
            foreach (var word in aWords)
            {
                Console.WriteLine(word);
            }
           
        }
       
        // Main Method
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.ForegroundColor = ConsoleColor.White;

                // Print Menu
                Console.Write("Choose an option:\n" +
                              "1 - Import Words From File\n" +
                              "2 - Bubble Sort words\n" +
                              "3 - LINQ/Lambda sort words\n" +
                              "4 - Count the Distinct Words\n" +
                              "5 - Take the first 10 words\n" +
                              "6 - Reverse print the words\n" +
                              "7 - Get and display words that end with 'd' and display the count\n" +
                              "8 - Get and display words that start with ‘q’ and display the count\n" +
                              "9 - Get and display words less than 3 characters long and start with 'a', and display the count\n" +
                              "x - Exit\n\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LoadWords(words); 
                        break;
                    case "2":
                        SortWordsBubble(words);
                        break;
                    case "3":
                        SortWordsLinq(words);
                        break;
                    case "4":
                        CountUniqueWords(words);
                        break;
                    case "5":
                        LastTenWords(words);
                        break;
                    case "6":
                        ReverseAndDisplayWords(words);
                        break;
                    case "7":
                        DisplayWordsEndingWithD(words);
                        break;
                    case "8":
                        DisplayWordsStartingWithQ(words);
                        break;
                    case "9":
                        DisplayWordsMoreThanThreeCharsContainingA(words);
                        break;
                    case "x":
                        continueProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection\n\n");
                        break;
                } // end switch case
            } //end while loop
        } // end main method
    }
}
