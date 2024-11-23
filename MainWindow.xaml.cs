using System.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>


namespace QuizApplication
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event for the Programming Quiz button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void ProgrammingQuiz_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow quizWindow = new QuizWindow("Programming in C#");
            quizWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the click event for the Math Quiz button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void MathQuiz_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow quizWindow = new QuizWindow("Math_Linear Algebra");
            quizWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the click event for the Games Quiz button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void GamesQuiz_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow quizWindow = new QuizWindow("Games");
            quizWindow.Show();
            this.Close();
        }
    }
}
