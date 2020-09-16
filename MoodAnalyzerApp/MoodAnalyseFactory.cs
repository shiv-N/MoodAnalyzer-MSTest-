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

        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className,string constructorName,string message)
        {
            Type type = typeof(MoodAnalyse);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
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

        public static string InvokeAnalyseMood(string message,string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerApp.MoodAnalyse");
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerApp.MoodAnalyse",
                    "MoodAnalyse", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }
    }
}
