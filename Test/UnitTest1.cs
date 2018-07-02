using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UFT_Extent_Reports.HTMLReporter hTML_Reporter = new UFT_Extent_Reports.HTMLReporter();
            hTML_Reporter.InitializeReport(@"C:\Temp\Export.Html");
            hTML_Reporter.AddDocumentTitle("Title");
            hTML_Reporter.AddReportName("Test Automation Execution Results");
            hTML_Reporter.CreateTest("Test 1");
            hTML_Reporter.AddPassLog("Log 1", @"C:\Temp\Google.png");
            hTML_Reporter.AddPassLog("Log 2");
            hTML_Reporter.AddPassLog("Log 3", @"C:\Temp\Google.png");

            hTML_Reporter.CreateTest("Test 2");
            hTML_Reporter.GenerateReport();
        }
    }
}
