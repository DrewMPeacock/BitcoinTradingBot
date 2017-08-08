﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TradingLib;
using TensorFlow;

namespace TradingBot
{
	class Program
	{
		private static ApiReader APR;
		private static DatabaseConnector DBC;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			APR = new ApiReader(); // Initialises ApiReader
			DBC = new DatabaseConnector(); // Initialises DatabaseConnector

			using (var graph = new TFGraph())
			{
				List<DatabaseRow> inputData = DBC.SelectAllFromDatabase();

				var one = graph.Const(1);

				var ETHUSD = graph.Const(APR.GetTickerResult(new CurrencyPair(0, 2)).lastPrice);
				var BTCUSD = graph.Const(APR.GetTickerResult(new CurrencyPair(0, 1)).lastPrice);

				var time = graph.Placeholder(TFDataType.Int32, TFShape.Scalar, "time");
				var price = graph.Placeholder(TFDataType.Double, TFShape.Scalar, "price");
				var volBid = graph.Placeholder(TFDataType.Double, TFShape.Scalar, "volBid");
				var volAsk = graph.Placeholder(TFDataType.Double, TFShape.Scalar, "volAsk");

				var ETHBalance = graph.Placeholder(TFDataType.Int32, TFShape.Scalar, "ETHBalance");
				var BTCBalance = graph.Placeholder(TFDataType.Int32, TFShape.Scalar, "BTCBalance");

				var bidValue = graph.Variable(new TFOutput(), "bid"); // ammount of ETH to buy as a fraction of the 
				var askValue = graph.Variable(new TFOutput(), "ask"); // ammount of to buy as a fraction of 1

				var remainingETH = graph.Mul(graph.Sub(one, bidValue), ETHBalance);
				var boughtETH = graph.Div(graph.Mul(askValue, BTCBalance), price);

				var finalETH = graph.Add(boughtETH, remainingETH);

				var remainingBTC = graph.Mul(graph.Sub(one, bidValue), BTCBalance);
				var boughtBTC = graph.Div(graph.Mul(askValue, ETHBalance), price);

				var finalBTC = graph.Add(boughtBTC, remainingBTC);
			}
		}
	}
}
