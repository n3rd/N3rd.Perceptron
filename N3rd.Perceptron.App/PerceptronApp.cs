using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N3rd.Perceptron;

namespace N3rd.Perceptron.App
{

    /// <summary>
    /// Source:
    /// http://visualstudiomagazine.com/articles/2013/03/01/pattern-recognition-with-perceptrons.aspx
    /// </summary>
    class PerceptronApp
    {

        private int[][] _TrainingData = new int[][] { 
            new int[] { 0, 1, 1, 0,
                        1, 0, 0, 1,
                        1, 1, 1, 1,
                        1, 0, 0, 1,
                        1, 0, 0, 1},
            new int[] { 1, 1, 1, 0,
                        1, 0, 0, 1,
                        1, 1, 1, 0,
                        1, 0, 0, 1,
                        1, 1, 1, 0},
            new int[] { 0, 1, 1, 1,
                        1, 0, 0, 0,
                        1, 0, 0, 0,
                        1, 0, 0, 0,
                        0, 1, 1, 1},
            new int[] { 1, 1, 1, 0,
                        1, 0, 0, 1,
                        1, 0, 0, 1,
                        1, 0, 0, 1,
                        1, 1, 1, 0},
            new int[] { 1, 1, 1, 1,
                        1, 0, 0, 0,
                        1, 1, 1, 0,
                        1, 0, 0, 0,
                        1, 1, 1, 1},
        };

        private bool[] _TrainingDataResult = new bool[] {
            false,
            true,
            false,
            false,
            false,
        };

        private int[][] _ClassificationExamples = new int[][] {
            new int[] { 0, 1, 1, 0,
                        0, 0, 0, 1,
                        1, 1, 1, 0,
                        1, 0, 0, 1,
                        1, 1, 1, 0},
            new int[] { 0, 1, 1, 0,
                        0, 0, 0, 1,
                        1, 1, 1, 0,
                        1, 0, 0, 1,
                        1, 1, 0, 0},
            new int[] { 0, 1, 1, 0,
                        0, 0, 0, 1,
                        1, 1, 1, 1,
                        1, 0, 0, 1,
                        1, 0, 0, 0},
        };

        static void Main(string[] args)
        {
            PerceptronApp pApp = new PerceptronApp();

            pApp.Run();

            Console.ReadKey();
        }

        public void Run()
        {
            Perceptron p = new Perceptron();

            Console.WriteLine("Training data:");
            Console.WriteLine("==============");
            _TrainingData
                .ToList()
                .ForEach(d => PrintDataSet(d));

            p.Learn(_TrainingData, _TrainingDataResult);

            for (int i = 0; i < _ClassificationExamples.Length; i++)
            {
                Console.WriteLine("Classification Example (" + i + "):");
                Console.WriteLine("===========================");
                PrintDataSet(_ClassificationExamples[i]);

                bool result = p.Classify(_ClassificationExamples[i]);

                Console.WriteLine("Output (" + i + "):");
                Console.WriteLine("===========");
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = result ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(result ? "Positive" : "Negative");
                Console.ForegroundColor = originalColor;
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        void PrintDataSet(int[] dataSet)
        {
            for (int i = 0; i < dataSet.Length; i += 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(dataSet[i + j] == 1 ? "1" : " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
