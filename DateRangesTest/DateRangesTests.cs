using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateRanges;

namespace DateRangesTest
{
    [TestClass]
    public class DateRangesTests
    {
        [TestMethod]
        public void MaxDateCheck()
        {
            DateTime d1 = DateTime.Parse("2018, 03, 04");
            DateTime d2 = DateTime.Parse("2018, 03, 05");
            DateTimeRange maximDate = new DateTimeRange(d1, d2); 
            
            Assert.AreEqual(DateTime.Parse("2018, 03, 05"), maximDate.MaxDate(d1,d2));
        }
    }
}
