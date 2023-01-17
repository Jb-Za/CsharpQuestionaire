using System;
using System.Collections.Generic;
using System.IO;
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
                    Console.WriteLine(i + " )" + question.answers[i]);
                }
                string uAnswer = Console.ReadLine();
                if (int.Parse(uAnswer) == question.correctIndex - 1)
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
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|\t Name \t| \t Total Correct Answers \t | \t Total incorrect Answers \t | \t Percentage \t | ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|\t"+ name +"\t| \t\t" + correctCounter+ "\t\t | \t\t" + incorrectCounter+ "\t\t\t | \t"+  correctCounter/(correctCounter + incorrectCounter) * 100+"\t\t | ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            
        }
        
    }
}

class QuizQuestion
{
    public string question { get; set; }
    public string[] answers { get; set; }
    public int correctIndex { get; set; }
}