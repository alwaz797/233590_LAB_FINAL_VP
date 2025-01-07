using System;
using System.Windows;
using System.Windows.Controls;

namespace QuizApp
{
    public partial class MainWindow : Window
    {
      
        private string[] easyQuestions = {
            "What is 2 + 2?",
            "What is the capital of France?",
            "What color is the sky?",
            "How many continents are there?",
            "What is 5 + 3?"
        };

        private string[,] easyOptions = {
            { "3", "4", "5", "6" },
            { "Berlin", "Madrid", "Paris", "London" },
            { "Blue", "Red", "Green", "Yellow" },
            { "6", "7", "8", "9" },
            { "6", "7", "8", "9" }
        };

        private int[] easyCorrectAnswers = { 1, 2, 0, 2, 1 };

        private string[] hardQuestions = {
            "What is 15 * 8?",
            "What is the square root of 256?",
            "Who developed the theory of relativity?",
            "What is the atomic number of gold?",
            "What is the capital of Japan?"
        };

        private string[,] hardOptions = {
            { "100", "120", "110", "130" },
            { "10", "12", "14", "16" },
            { "Isaac Newton", "Albert Einstein", "Nikola Tesla", "Marie Curie" },
            { "79", "80", "81", "82" },
            { "Tokyo", "Seoul", "Beijing", "Hanoi" }
        };

        private int[] hardCorrectAnswers = { 1, 3, 1, 0, 0 };

        private int currentQuestion = 0;
        private int score = 0;
        private string[] currentQuestions;
        private string[,] currentOptions;
        private int[] currentCorrectAnswers;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
        
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string level = ((ComboBoxItem)LevelComboBox.SelectedItem).Content.ToString();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (level == "Easy")
                {
                    currentQuestions = easyQuestions;
                    currentOptions = easyOptions;
                    currentCorrectAnswers = easyCorrectAnswers;
                }
                else if (level == "Hard")
                {
                    currentQuestions = hardQuestions;
                    currentOptions = hardOptions;
                    currentCorrectAnswers = hardCorrectAnswers;
                }

               
                LoginPanel.Visibility = Visibility.Collapsed;
                QuizPanel.Visibility = Visibility.Visible;

             
                LoadQuestion();
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
        }

        private void LoadQuestion()
        {
            if (currentQuestion < currentQuestions.Length)
            {
                QuestionTextBlock.Text = currentQuestions[currentQuestion];
                Option1.Content = currentOptions[currentQuestion, 0];
                Option2.Content = currentOptions[currentQuestion, 1];
                Option3.Content = currentOptions[currentQuestion, 2];
                Option4.Content = currentOptions[currentQuestion, 3];
            }
            else
            {
               
                QuizPanel.Visibility = Visibility.Collapsed;
                ResultPanel.Visibility = Visibility.Visible;
                ResultTextBlock.Text = $"Your Score: {score}/{currentQuestions.Length * 10}";
            }
        }

   
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
         
            int selectedAnswer = -1;
            if (Option1.IsChecked == true)
                selectedAnswer = 0;
            else if (Option2.IsChecked == true)
                selectedAnswer = 1;
            else if (Option3.IsChecked == true)
                selectedAnswer = 2;
            else if (Option4.IsChecked == true)
                selectedAnswer = 3;

           
            if (selectedAnswer == currentCorrectAnswers[currentQuestion])
            {
                score += 10; 
            }

      
            currentQuestion++;
            LoadQuestion();
        }


        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            
            currentQuestion = 0;
            score = 0;
            LoginPanel.Visibility = Visibility.Visible;
            ResultPanel.Visibility = Visibility.Collapsed;
        }
    }
}
