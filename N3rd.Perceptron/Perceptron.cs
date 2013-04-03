using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N3rd.Perceptron
{
    public class Perceptron
    {

        int MaxEpochs = 1000;
        double LearningRate = 0.075;
        double TargetError = 0.0;

        double[] Weights;
        double Bias;

        public void Learn(int[][] trainingData, bool[] trainingDataResult)
        {
            Weights = new double[trainingData[0].Length];
            Bias = 0.05;

            double totalError = double.MaxValue;

            for (int i = 0; i < MaxEpochs && totalError > TargetError; i++)
            {
                for(int j=0;j<trainingData.Length; j++)
                {
                    int output = Classify(trainingData[j]) ? 1 : 0;
                    int desired = trainingDataResult[j] ? 1 : 0;
                    int delta = desired - output;

                    AdjustWeights(trainingData[j], delta);
                }
            }
        }

        private double CalculateErrors(int[][] trainingData, bool[] trainingDataResult)
        {
            double sum = 0.0;

            for (int i = 0; i < trainingData.Length; i++)
            {
                bool desired = trainingDataResult[i];
                bool output = Classify(trainingData[i]);
                sum += output == desired ? 1 : 0;
            }

            return 0.5 * sum;
        }

        private void AdjustWeights(int[] dataSet, int delta)
        {
            for(int i = 0; i < dataSet.Length; i++)
            {
                Weights[i] += (LearningRate * (double)delta * (double)dataSet[i]); 
            }

            Bias += (LearningRate * delta);
        }

        public bool Classify(int[] dataSet)
        {
            double dotProduct = 0.0;

            for (int i = 0; i < Weights.Length; i++)
            {
                dotProduct += Weights[i] * (double)dataSet[i];
            }
            dotProduct += Bias;

            return ActivationFunction(dotProduct);
        }

       private bool ActivationFunction(double x)
        {
            return x > 0.5;
        }

    }
}
