using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerApp;

namespace MoodAnalyzerTests
{
    [TestClass]
    public class MoodAnlyzerTest
    {
        /// <summary>
        /// TC 1.1: Given �I am in Sad Mood� message Should Return SAD.
        /// </summary>
        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            // Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);

            // Act
            string mood = moodAnalyse.AnalyseMood();

            // Assert
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// TC 1.2  & 2.1: Given �I am in HAPPY Mood� and null message Should Return HAPPY
        /// </summary>
        [TestMethod]
        [DataRow("I am in HAPPY Mood")]
        public void GivenHAPPYMoodShouldReturnHappy(string message)
        {
            // Arrange
            string expected = "HAPPY";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);

            // Act
            string mood = moodAnalyse.AnalyseMood();

            // Assert
            Assert.AreEqual(expected, mood);
        }

        [TestMethod]
        public void Given_NULL_Mood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string message = null;
                MoodAnalyse moodAnalyse = new MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }
    }
}
