using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string json = File.ReadAllText("/Users/joshuabode/RiderProjects/ConsoleApplication2/ConsoleApplication2/questions.json");
            List<QuizQuestion> obj = JsonConvert.DeserializeObject<List<QuizQuestion>>(json);
            int correctCounter = 0;
            int incorrectCounter = 0;
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            foreach (QuizQuestion question in obj)
            {
                
                Console.WriteLine(question.question);
                for (int i = 0; i < question.answers.Length; i++)
                {
                    int iplus1 = i + 1;
                    Console.WriteLine(iplus1 + " )" + question.answers[i]);
                }
                string uAnswer = Console.ReadLine();
                if (int.Parse(uAnswer) == question.correctIndex)
                {
                    correctCounter++;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    incorrectCounter++;
                    Console.WriteLine("incorrect!");
                }

            }

            double total = (double)correctCounter + (double)incorrectCounter;
            double percentage = (double)correctCounter / total * 100;

            String dashes = "";

            for (int i = 0; i < 105; i++)
            {
                dashes += "-";
            }

            Console.WriteLine(dashes);
            Console.WriteLine("|{0, -25}|{1, -25}|{2, -25}|{3, -25}|" , "Name", "Total Correct Answers","Total Incorrect Answers", "Percentage");
            Console.WriteLine(dashes);
            Console.WriteLine("|{0, -25}|{1, -25}|{2, -25}|{3, -25}|" , name, correctCounter,incorrectCounter, percentage);
            Console.WriteLine(dashes);
            
        }
        
    }
}

class QuizQuestion
{
    public string question { get; set; }
    public string[] answers { get; set; }
    public int correctIndex { get; set; }
}