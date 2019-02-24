using System.Collections.Generic;
using System.Linq;

namespace ProblemSolver
{
    public class GradDaysFinder
    {
        public GradDayModel FindGradDays(List<Measurement> data)
        {
            var daysSinceGradDag = 0;
            var gradDagInARow = 0;
            var avgTempGradDays = new List<double>();
            var result = new GradDayModel();
            var gradPerYear = 0.0;
            for (var i = 1; i < 365; i++)
            {
                var day = new ModelDay {Day = data.Where(o => o.Dag == i).ToList()};
                var averageTemp = day.Day.Sum(o => o.DRY2013) / 24;
                if (IsGradDay(averageTemp, day.Day.FirstOrDefault().Date.Month))
                {
                    if (!(daysSinceGradDag >= 3) && gradDagInARow >= 3)
                    {
                        day.Day.ForEach(o => o.IsGradDay = true);
                        var temp = day.Day.Where(o => o.DRY2013 >= -2).ToList();
                        result.GradDays.Add(day);
                        result.AverageTempGradDay += 17 - averageTemp;
                        ;
                        if (temp.Any())
                            avgTempGradDays.Add(17 - temp.Sum(o => o.DRY2013) / temp.Count);
                    }

                    daysSinceGradDag = 0;
                    gradDagInARow++;
                }
                else
                {
                    gradDagInARow = 0;
                    daysSinceGradDag++;
                }
            }

            result.AverageTempGradWithOutMinus2 = avgTempGradDays.Sum();
            return result;
        }

        private bool IsGradDay(double averageTemp, int month)
        {
            return averageTemp < 10 && month < 6 ||
                   averageTemp < 12 && month >= 6;
        }
    }
}