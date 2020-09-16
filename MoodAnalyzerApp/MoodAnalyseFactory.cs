using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace MoodAnalyzerApp
{
    public class MoodAnalyseFactory
    {
        /// <summary>
        /// CreateMoodAnalyse method to create object of MoodAnalyse class.
        /// </summary>
        public static object CreateMoodAnalyse(string className,string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnaylseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnaylseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }

        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className,string constructorName)
        {
            Type type = typeof(MoodAnalyse);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
                }
               
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
            }
            
        }
    }
}
