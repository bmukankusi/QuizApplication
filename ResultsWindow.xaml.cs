using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace QuizApplication
{
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// Shows the results of the quiz and allows the user to retake the quiz or return to the main window.
    /// RoutedEventArgs is used to handle the click events for the buttons.
    /// </summary>

    public partial class ResultsWindow : Window
    {
        private MainWindow _mainWindow;

        /// <summary>
        /// Gets a value indicating whether the quiz should be retaken.
        /// </summary>
        public bool RetakeQuiz { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultsWindow"/> class.
        /// </summary>
        /// <param name="resultsMessage">The message displaying the results of the quiz.</param>
        /// <param name="mainWindow">The main window instance to return to.</param>
        public ResultsWindow(string resultsMessage, MainWindow mainWindow)
        {
            InitializeComponent();
            ResultsTextBlock.Text = resultsMessage;
            _mainWindow = mainWindow;
        }

        private void RedoQuizButton_Click(object sender, RoutedEventArgs e)
        {
            RetakeQuiz = true;
            Close();
        }

        private void ReturnToMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Show();
            Close();
        }
    }
}
