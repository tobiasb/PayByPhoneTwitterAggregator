using System;

namespace PbPTweetAggregator
{
	public class Tweet
	{
		public DateTime Created { get; set; }
		public string User { get; set; }
		public string Text { get; set; }
		public int Mentions { get; set; }
	}
}

