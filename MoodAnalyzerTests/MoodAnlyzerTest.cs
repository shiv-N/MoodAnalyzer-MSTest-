using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerApp;

namespace MoodAnalyzerTests
{
    [TestClass]
    public class MoodAnlyzerTest
    {
        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            // Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyse moodAnalyse = new MoodAnalyse();

            // Act
            string mood = moodAnalyse.AnalyseMood(message);

            // Assert
            Assert.AreEqual(expected, mood);
        }
    }
}
