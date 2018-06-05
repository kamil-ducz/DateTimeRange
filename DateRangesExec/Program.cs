using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            //Current Range
            var CurrentRange = new DateTimeRange();
            CurrentRange.Start = DateTime.Parse("2018, 06, 03");
            CurrentRange.End = CurrentRange.Start.AddDays(30);
            Console.WriteLine("Current:");
            Console.WriteLine("Start Date: " + CurrentRange.Start + " End Date: " + CurrentRange.End);
            var currentDateDiff = CurrentRange.End - CurrentRange.Start;
            Console.WriteLine("From current dates range is: " + currentDateDiff.Days);

            //get Given Range from user
            DateTimeRange GivenRange = new DateTimeRange();
            Console.WriteLine("Type range start(format 'yyyy, mm, dd':");
            GivenRange.Start = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Type range end(format 'yyyy, mm, dd':)");
            GivenRange.End = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Start Date: " + GivenRange.Start + " End Date: " + GivenRange.End);
            var givenRangeDiff = GivenRange.End - GivenRange.Start;
            Console.WriteLine("From given dates range is: " + givenRangeDiff.Days + " days");

            Console.ReadLine();
        }
    }
}
/*bool ifContain = CurrentRange.Contains(GivenRange);
Console.WriteLine("Given Range contains in Current Range? " + ifContain);
*/
