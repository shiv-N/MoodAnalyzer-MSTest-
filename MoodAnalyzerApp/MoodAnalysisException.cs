using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerApp
{
    /// <summary>
    /// MoodAnalysisException Class For Handling Exception.
    /// </summary>
    public class MoodAnalysisException : Exception
    {
        /// <summary>
        /// Enum for Exception Type.
        /// </summary>
        public enum ExceptionType
        {
            NULL_MESSAGE, Empty_Message, NO_SUCH_CLASS, NO_SUCH_METHOD
        }

        ////Creating 'type' variable of type ExceptionType
        private readonly ExceptionType type;

        /// <summary>
        /// Parameterized Constructor sets the Exception Type and message.
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="message"></param>
        public MoodAnalysisException(ExceptionType Type, string message) : base(message)
        {
            this.type = Type;
        }
    }
}
