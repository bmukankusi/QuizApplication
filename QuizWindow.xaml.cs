using System.Windows;
using System.Windows.Media.Imaging;

/// <summary>
/// Interaction logic for QuizWindow.xaml
/// </summary>

namespace QuizApplication
{
    public partial class QuizWindow : Window
      
      /// <summary>
      /// Initializes a new instance of the QuizWindow class.
      /// </summary>

    {
        private Dictionary<string, List<Question>> quizzes;
        private List<Question>? currentQuizQuestions; 
        private int currentQuestionIndex = 0;
        private int correctAnswers = 0;

        /// <summary>
        /// Initializes a new instance of the QuizWindow class.
        /// </summary>
        /// <param name="quizTitle">The title of the quiz to be displayed.</param>

        public QuizWindow(string quizTitle)
        {
            InitializeComponent();
            QuizTitleTextBlock.Text = quizTitle;

            try
            {
                InitializeQuizzes();

                // Load selected quiz
                if (quizzes != null && quizzes.ContainsKey(quizTitle))
                {
                    currentQuizQuestions = quizzes[quizTitle];
                    DisplayQuestion();
                }
                else
                {
                    MessageBox.Show("Quiz not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while initializing the quiz: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        /// <summary>
        /// Represents a question in the quiz.
        /// </summary>

        public class Question
        {
            public string QuestionText { get; set; } = string.Empty;
            public List<string> Options { get; set; } = new List<string>();
            public int CorrectAnswerIndex { get; set; }
        }


        private void InitializeQuizzes()
        {

            /// <summary>
            /// Initializes the quizzes dictionary with predefined quiz questions and options.
            /// </summary>

            try
            {
                quizzes = new Dictionary<string, List<Question>>
                    {
                        {
                            "Programming in C#", new List<Question>
                            {
                                new Question
                                {
                                    QuestionText = "Which of the following is the correct syntax to declare a variable in C#?",
                                    Options = new List<string> { "int number := 5", "int number = 5", "var int number = 5", "int number -> 5" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "What is the purpose of the using directive in C#?",
                                    Options = new List<string> { "To define namespaces", "To import namespaces", "To declare variables", "To define classes" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "Which of the following methods would be used to stop a loop in C#?",
                                    Options = new List<string> { "stop", "exit", "break", "end" },
                                    CorrectAnswerIndex = 2
                                },
                                new Question
                                {
                                    QuestionText = "What is the default value of a boolean variable in C#?",
                                    Options = new List<string> { "null", "true", "false", "0" },
                                    CorrectAnswerIndex = 2
                                },
                                new Question
                                {
                                    QuestionText = "What will be the output of the following code snippet?\n" +
                                    "int a = 5;\r\nint b = 10;\r\nConsole.WriteLine(a == b);\r\n",
                                    Options = new List<string> { "true", "false;", "5", "10" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "In C#, what is an array?",
                                    Options = new List<string> { "A collection of integers only", "A collection of values of the same data type;", "A collection of values of different data types;", "A type of loop structure;" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "Which keyword is used to inherit a class in C#?",
                                    Options = new List<string> { "extends", "implements", "inherits", ":" },
                                    CorrectAnswerIndex = 3
                                },
                                new Question
                                {
                                    QuestionText = "Which of the following is NOT a value type in C#?",
                                    Options = new List<string> { "int", "bool", "string", " float" },
                                    CorrectAnswerIndex = 3
                                },
                                new Question
                                {
                                    QuestionText = "What is the correct syntax to declare a method in C# that returns an integer and takes no parameters?",
                                    Options = new List<string> { "int Method() {}", "integer Method() {}", "int Method[] {}", "integer Method[] {}" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "In C#, which of the following is used to handle exceptions?",
                                    Options = new List<string> { "try-catch", "catch-finally", "try-catch-finally", "Both A and C" },
                                    CorrectAnswerIndex = 3
                                }
                            }
                        },
                        {
                            "Math_Linear Algebra", new List<Question>
                            {
                                new Question
                                {
                                    QuestionText = "What is the value of π (pi) to 2 decimal places?",
                                    Options = new List<string> { "3.12", "3.14", "3.16", "3.18" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "What is the determinant of a 2x2 matrix [[a, b], [c, d]]?",
                                    Options = new List<string> { "ad - bc", "ab - cd", "ac - bd", "a + d" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "Which of the following is a scalar quantity?",
                                    Options = new List<string> { "Vector", "Matrix", "Determinant", "Eigenvalue" },
                                    CorrectAnswerIndex = 4
                                },
                                new Question
                                {
                                    QuestionText = "What is the rank of a matrix?",
                                    Options = new List<string> { "The number of rows", "The number of columns", "The number of non-zero rows", "The number of non-zero columns" },
                                    CorrectAnswerIndex = 3
                                },
                                new Question
                                {
                                    QuestionText = "What is the identity matrix?",
                                    Options = new List<string> { "A matrix with all elements as 1", "A matrix with all elements as 0", "A diagonal matrix with 1s on the diagonal", "A matrix with equal rows and columns" },
                                    CorrectAnswerIndex = 3
                                },
                                new Question
                                {
                                    QuestionText = "What is the inverse of a matrix?",
                                    Options = new List<string> { "A matrix that, when multiplied with the original matrix, gives the identity matrix", "A matrix with all elements negated", "A matrix with rows and columns swapped", "A matrix with elements squared" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "What is an eigenvector?",
                                    Options = new List<string> { "A vector that is scaled by a matrix", "A vector that is rotated by a matrix", "A vector that is translated by a matrix", "A vector that is reflected by a matrix" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "What is the trace of a matrix?",
                                    Options = new List<string> { "The sum of all elements", "The sum of the diagonal elements", "The product of the diagonal elements", "The difference of the diagonal elements" },
                                    CorrectAnswerIndex = 2
                                },
                                new Question
                                {
                                    QuestionText = "What is a singular matrix?",
                                    Options = new List<string> { "A matrix with all elements as 1", "A matrix with all elements as 0", "A matrix that does not have an inverse", "A matrix with equal rows and columns" },
                                    CorrectAnswerIndex = 3
                                },
                                new Question
                                {
                                    QuestionText = "What is the dot product of two vectors?",
                                    Options = new List<string> { "The sum of the products of their corresponding components", "The product of their magnitudes", "The sum of their magnitudes", "The difference of their magnitudes" },
                                    CorrectAnswerIndex = 1
                                }
                            }
                        },
                        {
                            "Games", new List<Question>
                            {
                                new Question
                                {
                                    QuestionText = "Which of the following is an example of a life simulation game?",
                                    Options = new List<string> { "The Sims", "Call of Duty", "Minecraft", "Overwatch" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "What is the primary focus of simulation games?",
                                    Options = new List<string> { "Fast-paced action", "Recreating real-world activities or systems", "Puzzle-solving", "Story-driven gameplay" },
                                    CorrectAnswerIndex = 2
                                },
                                new Question
                                {
                                    QuestionText = "In simulation games, what is typically modeled to enhance realism?",
                                    Options = new List<string> { "Physics and environment", "Action sequences", "Character dialogues", "Multiplayer combat" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "Which game is considered a pioneer in farming simulation?",
                                    Options = new List<string> { "FarmVille", "Stardew Valley", "Harvest Moon", "Animal Crossing" },
                                    CorrectAnswerIndex = 3
                                },
                                new Question
                                {
                                    QuestionText = "In business simulation games, what is the player typically responsible for managing?",
                                    Options = new List<string> { "A character's health", "A storyline with branching choices", "Resources, finances, and strategy", "Combat units in real time" },
                                    CorrectAnswerIndex = 3
                                },
                                new Question
                                {
                                    QuestionText = "Which of these is a city-building simulation game?",
                                    Options = new List<string> { "SimCity", "Civilization", "World of Warcraft", "Counter-Strike" },
                                    CorrectAnswerIndex = 1
                                },
                                new Question
                                {
                                    QuestionText = "What kind of simulation is Microsoft Flight Simulator?",
                                    Options = new List<string> { "Life simulation", "Business simulation", "Vehicle simulation", "Combat simulation" },
                                    CorrectAnswerIndex = 3
                                },
                                new Question
                                {
                                    QuestionText = "In chess, which piece has the ability to move in an \"L\" shape?",
                                    Options = new List<string> { "Queen", "Knight", "Bishop", "Rook" },
                                    CorrectAnswerIndex = 2
                                },
                                new Question
                                {
                                    QuestionText = "What is the main objective in the classic board game \"Monopoly\"?",
                                    Options = new List<string> { "Build the tallest skyscrapers.", "Become the wealthiest player by buying, trading, and developing properties.", "Reach the \"GO\" square as many times as possible.", "Avoid landing on opponent-owned properties." },
                                    CorrectAnswerIndex = 2
                                },
                                new Question
                                {
                                    QuestionText = "Which of the following is NOT a type of video game genre?",
                                    Options = new List<string> { "First-Person Shooter", "Role-Playing Game", "Open-World Explorer", "Puzzle" },
                                    CorrectAnswerIndex = 3
                                }
                            }
                        }
                    };

                // Setting the image source based on the quiz title
                try
                {
                    if (QuizTitleTextBlock.Text == "Programming in C#")
                    {
                        QuizImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/laptop.jpg"));
                    }
                    else if (QuizTitleTextBlock.Text == "Math_Linear Algebra")
                    {
                        QuizImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/math.jpg"));
                    }
                    else if (QuizTitleTextBlock.Text == "Games")
                    {
                        QuizImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/game.jpg"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while setting the image source: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while initializing quizzes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Displays the current question on the UI.
        /// Updates the UI with the current question and options.
        /// </summary>

        private void DisplayQuestion()
        {
            try
            {
                if (currentQuizQuestions != null && currentQuestionIndex < currentQuizQuestions.Count)
                {
                    var question = currentQuizQuestions[currentQuestionIndex];
                    QuestionTextBlock.Text = $"Q{currentQuestionIndex + 1}. {question.QuestionText}";
                    Option1Button.Content = $"A) {question.Options[0]}";
                    Option2Button.Content = $"B) {question.Options[1]}";
                    Option3Button.Content = $"C) {question.Options[2]}";
                    Option4Button.Content = $"D) {question.Options[3]}";
                    FeedbackTextBlock.Text = "";
                }
                else
                {
                    ShowResults();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while displaying the question: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedButton = sender as System.Windows.Controls.Button;
                if (selectedButton != null && selectedButton.Tag != null)
                {
                    if (int.TryParse(selectedButton.Tag.ToString(), out int selectedIndex))
                    {
                        if (currentQuizQuestions != null && selectedIndex == currentQuizQuestions[currentQuestionIndex].CorrectAnswerIndex)
                        {
                            FeedbackTextBlock.Text = "Correct!";
                            correctAnswers++;
                        }
                        else
                        {
                            FeedbackTextBlock.Text = "Wrong!";
                        }

                        NextButton.IsEnabled = true;
                    }
                    else
                    {
                        FeedbackTextBlock.Text = "Invalid selection!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the selected option: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentQuestionIndex++;
                NextButton.IsEnabled = false;
                DisplayQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while moving to the next question: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Show the results of the quiz in a new window.
        /// </summary>

        private void ShowResults() 
        {
            try
            {
                if (currentQuizQuestions != null)
                {
                    int totalQuestions = currentQuizQuestions.Count;
                    double percentage = (double)correctAnswers / totalQuestions * 100;

                    string resultsMessage =
                        $"Quiz Completed!\n\nCorrect Answers: {correctAnswers}/{totalQuestions}\n" +
                        $"Score: {percentage:F2}%";

                    ResultsWindow resultsWindow = new ResultsWindow(resultsMessage, new MainWindow());
                    resultsWindow.ShowDialog();

                    if (resultsWindow.RetakeQuiz)
                    {
                        // Redo the quiz
                        currentQuestionIndex = 0;
                        correctAnswers = 0;
                        DisplayQuestion();
                    }
                    else
                    {
                        // Return to main window logic handled in ResultsWindow
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("No questions available to show results.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while showing the results: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }




}

