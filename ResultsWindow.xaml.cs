using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        public bool RetakeQuiz { get; private set; }

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
