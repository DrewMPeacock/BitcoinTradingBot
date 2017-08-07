﻿namespace TradingLib
{
	public class DatabaseRow
	{
		public double date;
		public double price;
		public double volBid;
		public double volAsk;

		public DatabaseRow(double date, double price, double volBid, double volAsk)
		{
			this.date = date;
			this.price = price;
			this.volBid = volBid;
			this.volAsk = volAsk;
		}
	}
}