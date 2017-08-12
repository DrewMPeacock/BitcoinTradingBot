﻿using System;
using System.Linq;

namespace TradingBot
{
	public class OutputNeuron : Neuron
	{
		public override double[] InValue
		{
			get { return inValue; }
			set
			{
				inValue = value;
				double sumIn = 0;
				foreach (double val in inValue)
					sumIn += val;
				OutValue = Sigmoid(sumIn);
			}
		}
		private double[] inValue;

		public OutputNeuron(int layer, int height) : base(layer, height)
		{
			this.Layer = layer;
			this.Height = height;
		}

		public static double Sigmoid(double inValue)
		{
			return 1 / (1 + Math.Exp(-inValue));
		}

		// Currently not used: If anyone knows how to use this for the last layer activation, please help.
		public static double[] Softmax(double[] z)
		{
			double[] zExp = new double[z.Length];

			for (int i = 0; i < zExp.Length; i++)
			{
				zExp[i] = Math.Exp(z[i]);
			}

			double sumZExp = 0;

			for (int i = 0; i < zExp.Length; i++)
			{
				sumZExp += zExp[i];
			}

			double[] softmax = new double[z.Length];

			for (int i = 0; i < zExp.Length; i++)
			{
				softmax[i] = zExp[i] / sumZExp;
			}

			return softmax;
		}
	}
}