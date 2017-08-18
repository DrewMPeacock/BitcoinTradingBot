﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradingBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingBot.Tests
{
    [TestClass()]
    public class NeuralNetworkTests
    {
        [TestMethod()]
        public void NeuralNetwork_NeuralNetwork_ForwardTest()
        {
            NeuralNetwork ANN = new NeuralNetwork();

            double[] input = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7 };
            double output = ANN.Forward(input);

            Assert.AreEqual(0.998, Math.Round(output, 3));
        }

        [TestMethod()]
        public void NeuralNetwork_NeuralNetwork_ImportWeightsTest()
        {
            NeuralNetwork ANN = new NeuralNetwork();

            double[] inputs =
            {
                0.412921726048422,
                0.392921726048422,
                0.392921726048422,
                0.362921726048422,
                0.382921726048422,
                0.322921726048422,
                0.212921726048422,
                0.302921726048422,
                0.322921726048422,
                0.352921726048422,
                0.332921726048422,
                0.342921726048422,
                0.342921726048422,
                0.242921726048422,
                0.222921726048422,
                -0.327078273951578,
                0.392921726048422,
                0.392921726048422,
                0.392921726048422,
                0.392921726048422,
                0.332921726048422,
                0.282921726048422,
                0.312921726048422,
                0.282921726048422,
                0.302921726048422,
                0.312921726048422,
                0.382921726048422,
                0.262921726048422,
                0.322921726048422,
                0.232921726048422,
                0.262921726048422,
                -0.357078273951579,
                0.402921726048422,
                0.402921726048422,
                0.362921726048422,
                0.272921726048422,
                0.342921726048422,
                0.252921726048422,
                0.352921726048422,
                0.332921726048422,
                0.352921726048422,
                0.372921726048422,
                0.332921726048422,
                0.252921726048422,
                0.372921726048422,
                0.222921726048422,
                0.232921726048422,
                0.0629217260484218,
                0.422921726048422,
                0.392921726048422,
                0.312921726048422,
                0.322921726048422,
                0.372921726048422,
                0.362921726048422,
                0.382921726048422,
                0.312921726048422,
                0.382921726048422,
                0.302921726048422,
                0.312921726048422,
                0.302921726048422,
                0.392921726048422,
                0.282921726048422,
                0.232921726048422,
                -0.0670782739515781,
                0.412921726048422,
                0.402921726048422,
                0.412921726048422,
                0.362921726048422,
                0.262921726048422,
                0.262921726048422,
                0.332921726048422,
                0.322921726048422,
                0.342921726048422,
                0.202921726048422,
                0.352921726048422,
                0.262921726048422,
                0.312921726048422,
                0.252921726048422,
                0.172921726048422,
                -0.0970782739515779,
                0.382921726048422,
                0.362921726048422,
                0.362921726048422,
                0.332921726048422,
                0.192921726048422,
                0.292921726048422,
                0.252921726048422,
                0.352921726048422,
                0.342921726048422,
                0.252921726048422,
                0.352921726048422,
                0.262921726048422,
                0.272921726048422,
                0.112921726048422,
                0.00292172604842178,
                -0.987078273951579,
                0.412921726048422,
                0.412921726048422,
                0.342921726048422,
                0.332921726048422,
                0.332921726048422,
                0.332921726048422,
                0.282921726048422,
                0.292921726048422,
                0.312921726048422,
                0.272921726048422,
                0.352921726048422,
                0.212921726048422,
                0.222921726048422,
                0.102921726048422,
                0.00292172604842181,
                -0.157078273951578,
                0.322921726048422,
                0.332921726048422,
                0.232921726048422,
                0.242921726048422,
                0.172921726048422,
                0.162921726048422,
                0.202921726048422,
                0.182921726048422,
                0.172921726048422,
                0.0729217260484218,
                0.0829217260484218,
                0.0129217260484219,
                -0.0670782739515781,
                -0.087078273951578,
                -0.287078273951578,
                -0.727078273951579};
            List<double> inputWeights = new List<double>(inputs);

            ANN.ImportWeights(inputWeights);

            for (int i = 0; i < ANN.Synapses.Count; i++)
            {
                Assert.AreEqual(inputWeights[i], ANN.Synapses[i].Weight);
            }
        }
    }
}