using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerApp
{
    public class MoodAnalyse
    {
        public string AnalyseMood(string message)
        {
            if (message.Contains("Sad"))
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
    }
}
