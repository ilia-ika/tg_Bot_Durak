using System;
using System.Collections.Specialized;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Напиши своё имя: ");
            string nameUser = "";
            nameUser = Console.ReadLine();
            List<string> questions = new List<string>()
            {
                "ты дурак?",
                "сколько будет 1+1?",
                "сколько будет 3*1?",
                "сколько будет 2^2?",
                "сколько будет 6-1?",
                "сколько будет 6-0?"
            };
            List<int> answers = new List<int>()
            {
                1,2,3,4,5,6
            };
            Random rand = new Random();
            double countCorrectAnswers = 0;
            double countQuestions = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                int numberAnswerAndQuestions = rand.Next(0, questions.Count);
                Console.WriteLine(questions[numberAnswerAndQuestions]);
                
                int userAnswers = Convert.ToInt32(Console.ReadLine());
                if (userAnswers == answers[numberAnswerAndQuestions]) 
                {
                    countQuestions++;
                    countCorrectAnswers++;
                }
                else
                {
                    countQuestions++;
                }
               
                Console.WriteLine(answers[numberAnswerAndQuestions]); 
                Console.WriteLine(questions[numberAnswerAndQuestions]);
                questions.RemoveAt(numberAnswerAndQuestions);
                answers.RemoveAt(numberAnswerAndQuestions);
            }
            string usserDiagnos=Diagnostics(countCorrectAnswers, countQuestions);
            Console.WriteLine(nameUser+", ваш диагнозготов. Вы "+usserDiagnos+"!");
            SaveResult(nameUser, countCorrectAnswers, usserDiagnos);

        }
        static string Diagnostics(double countCorrectAnswer, double countQuestions)
        {
            string usserDiagnos = "";
            if (countCorrectAnswer/countQuestions==0)
            {
                usserDiagnos = "безмозглое одноклеточное";
            }
            if (countCorrectAnswer / countQuestions < 0.2 && countCorrectAnswer / countQuestions > 0)
            {
                usserDiagnos = "идеот";
            }
            if (countCorrectAnswer / countQuestions < 0.4 && countCorrectAnswer / countQuestions > 0.2)
            {
                usserDiagnos = "кретин";
            }
            if (countCorrectAnswer / countQuestions<0.6&& countCorrectAnswer / countQuestions>0.4)
            {
                usserDiagnos = "тупой";
            }
            if (countCorrectAnswer / countQuestions<0.8&& countCorrectAnswer / countQuestions>0.6)
            {
                usserDiagnos = "нормальный";
            }
            if (countCorrectAnswer / countQuestions <1&& countCorrectAnswer / countQuestions>0.8)
            {
                usserDiagnos = "талант";
            }
            if (countCorrectAnswer / countQuestions == 1)
            {
                usserDiagnos = "гений";
            }
            return usserDiagnos;
        }
        static void SaveResult(string nameUser, double countCorrectAnswers, string usserDiagnos)
        {
            string result = $"{nameUser}#{countCorrectAnswers}#{usserDiagnos}";
            File.AppendAllText("result.txt", result);
        }
    }
}