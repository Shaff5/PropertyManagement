namespace PropertyManagement.Common.Tests.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Common.Extensions;

    [TestClass]
    public class DateTimeExtensionsTests
    {

        /// <summary>
        /// Tests the GetLastMonthEndDate method.
        /// </summary>
        [TestMethod]
        public void GetLastMonthEndDateTest()
        {
            var input1 = new DateTime(2014, 1, 1);
            var input2 = new DateTime(2014, 12, 31);

            Assert.AreEqual(new DateTime(2013, 12, 31), input1.GetLastMonthEndDate());
            Assert.AreEqual(new DateTime(2014, 11, 30), input2.GetLastMonthEndDate());
        }
    }
}
