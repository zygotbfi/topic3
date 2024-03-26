using System;

namespace ArithmeticQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numQuestions = random.Next(5, 16);
            int correctAnswers = 0;

            Console.WriteLine("Welcome to the Arithmetic Quiz!");
            Console.WriteLine($"You have {numQuestions} questions to answer.\n");

            for (int i = 1; i <= numQuestions; i++)
            {
                int num1 = random.Next(1, 101);
                int num2 = random.Next(1, 101);
                char[] operators = { '+', '-', '*', '/' };
                char op = operators[random.Next(0, 4)];

                Console.Write($"Question {i}: {num1} {op} {num2} = ");

                double userAnswer;
                bool parsed = double.TryParse(Console.ReadLine(), out userAnswer);
                if (!parsed)
                {
                    Console.WriteLine("Invalid input. Skipping this question.");
                    continue;
                }

                double correctAnswer = 0;
                switch (op)
                {
                    case '+':
                        correctAnswer = num1 + num2;
                        break;
                    case '-':
                        correctAnswer = num1 - num2;
                        break;
                    case '*':
                        correctAnswer = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                            correctAnswer = (double)num1 / num2;
                        else
                        {
                            Console.WriteLine("Cannot divide by zero. Skipping this question.");
                            continue;
                        }
                        break;
                }

                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
                }
            }

            double percentage = (double)correctAnswers / numQuestions * 100;
            Console.WriteLine($"\nYou answered {correctAnswers} out of {numQuestions} questions correctly.");
            Console.WriteLine($"Your percentage score: {percentage}%");
        }
    }
}
