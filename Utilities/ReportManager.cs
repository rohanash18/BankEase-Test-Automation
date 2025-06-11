
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Utilities.ReportManager
{
    public class ReportManager
    {
        private static ExtentReports extent;
        private static ExtentSparkReporter sparkReporter;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {

                // string reportDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                // string reportPath = Path.Combine(reportDir, "TestReport.html");

                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
                string reportDir = Path.Combine(projectRoot, "Reports");
                string reportPath = Path.Combine(reportDir, "TestReport.html");


                sparkReporter = new ExtentSparkReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(sparkReporter);
            }
            return extent;
        }
    }
}