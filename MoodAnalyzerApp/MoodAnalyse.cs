using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerApp
{
    public class MoodAnalyse
    {
        private string message;

        /// <summary>
        /// Parameterised Constructor.
        /// </summary>
        /// <param name="message"></param>
        public MoodAnalyse(string message)
        {
            this.message = message;
        }

        public string AnalyseMood()
        {
            if (this.message.Contains("Sad"))
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
