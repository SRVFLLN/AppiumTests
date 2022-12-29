using System;
using System.IO;

namespace AppiumTests.Utils
{
    public static class AllureReportsUtils
    {
        private const string REPORTS_FOLDER = "allure-results";
        private const string SCRIPT_NAME = "../../../allure_script.bat";
        private static bool isCleared = false;

        public static void ClearFolder()
        {
            try
            {
                if (isCleared) return;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                Logger.Info("Trying to clear directory" + REPORTS_FOLDER);
                DirectoryInfo dir = new DirectoryInfo(REPORTS_FOLDER);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                isCleared = true;
            }
            catch(Exception e)
            {
                Logger.Error("Error when trying to clear directory: " + e.Message);
            }
        }

        public static void RunAllureReports()
        {
            try
            {
                Logger.Info("Trying to run script by path " + SCRIPT_NAME+"\n\n");
                System.Diagnostics.Process.Start(SCRIPT_NAME);
            }
            catch(Exception e)
            {
                Logger.Error($"Error when trying to run script by path {SCRIPT_NAME}. Error: {e.Message}\n\n");
            }
        }
    }
}
