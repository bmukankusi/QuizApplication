using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using QuizApplication;

namespace QuizApplication.Tests
{
  [TestClass]
  public class QuizWindowTests
  {
    [TestMethod]
    public void QuizWindow_Constructor_ValidQuizTitle_ShouldInitializeCorrectly()
    {
      // Arrange
      string quizTitle = "Programming in C#";

      // Act
      var quizWindow = new QuizWindow(quizTitle);

      // Assert
      Assert.AreEqual(quizTitle, quizWindow.QuizTitleTextBlock.Text);
      Assert.IsNotNull(quizWindow.currentQuizQuestions);
      Assert.AreEqual(0, quizWindow.currentQuestionIndex);
      Assert.AreEqual(0, quizWindow.correctAnswers);
    }

    [TestMethod]
    public void QuizWindow_Constructor_InvalidQuizTitle_ShouldShowErrorAndClose()
    {
      // Arrange
      string quizTitle = "Nonexistent Quiz";
      bool isClosed = false;

      // Act
      var quizWindow = new QuizWindow(quizTitle);
      quizWindow.Closed += (s, e) => isClosed = true;

      // Assert
      Assert.IsTrue(isClosed);
    }

    [TestMethod]
    public void QuizWindow_Constructor_Exception_ShouldShowErrorAndClose()
    {
      // Arrange
      string quizTitle = null; // This will cause an exception
      bool isClosed = false;

      // Act
      var quizWindow = new QuizWindow(quizTitle);
      quizWindow.Closed += (s, e) => isClosed = true;

      // Assert
      Assert.IsTrue(isClosed);
    }
  }
}