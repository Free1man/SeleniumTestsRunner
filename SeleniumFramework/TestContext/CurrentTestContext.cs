using System;
using System.IO;


namespace SeleniumFramework.SpecflowContext
{
    public class CurrentTestContext
    {
        private static string testName;

        public static string TestName
        {
            get
            {
                 return RemoveInvalidCharacters(testName);
            }
            set { testName = value; }
        }
        public static void SetTestName(string testName)
        {
            TestName = testName;
        }

        private static string RemoveInvalidCharacters(string stringToClean)
        {
            string invalidCharacters = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalidCharacters)
            {
                stringToClean = stringToClean.Replace(c.ToString(), "");
            }
            return stringToClean;

        }

        private static string testOutcome;

        public static string TestOutcome
        {
            get { return RemoveInvalidCharacters(testOutcome); }
            set { testOutcome = value; }
        }


        public static void SetTestOutcome(string result)
        {
            TestOutcome = result;
        }
    }
}
