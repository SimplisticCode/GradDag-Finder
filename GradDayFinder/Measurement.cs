using System;
using System.Collections.Generic;

namespace ProblemSolver
{
    public class Measurement
    {
        public double DRY2013 { get; set; }
        public int Timeno { get; set; }
        public double Dag { get; set; }
        public int Time { get; set; }
        public DateTime Date { get; set; }
        public bool IsGradDay { get; set; }

        public void FromString(List<string> arr)
        {
            DRY2013 = double.Parse(arr[0].Replace(",", "."));
            Timeno = int.Parse(arr[1]);
            Dag = double.Parse(arr[2]);
            Time = int.Parse(arr[3]);
            Date = new DateTime(2013, 1, 1, Time - 1, 0, 0).AddDays(Dag - 1);
        }
    }
}