using System;
using System.Collections.Generic;
using System.IO;

namespace ProblemSolver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = new List<Measurement>();
            using (var reader = new StreamReader(@"/Users/simonthranehansen/Downloads/Optimering.csv"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var temp = new Measurement();
                    var values = new List<string>(line.Split(';'));
                    if (string.IsNullOrEmpty(values[0])) continue;
                    temp.FromString(values);
                    data.Add(temp);
                }
            }


            var calculator = new GradDaysFinder();
            var gradDage = calculator.FindGradDays(data);
            Console.WriteLine($"Antallet af graddage: {gradDage.GradDays.Count}");
            Console.WriteLine($"Gennemsnitlig temperatur på graddage: {gradDage.AverageTempGradDay}");
            Console.WriteLine(
                $"Gennemsnitlig temperatur på graddage, hvor temperaturer under minus to er frasorteret: {gradDage.AverageTempGradWithOutMinus2}");
        }
    }
}