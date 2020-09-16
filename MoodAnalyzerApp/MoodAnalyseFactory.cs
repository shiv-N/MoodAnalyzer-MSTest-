using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace MoodAnalyzerApp
{
    public class MoodAnalyseFactory
    {
        /// <summary>
        /// CreateMoodAnalyse method to create object of MoodAnalyse class.
        /// </summary>
        public static object CreateMoodAnalyse(string className)
        {
            if (className.Equals("MoodAnalyzerApp.MoodAnalyse"))
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnaylseType = executing.GetType(className);
                return Activator.CreateInstance(moodAnaylseType);
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
            }
        }
    }
}
