using System;
using System.Collections.Generic;

namespace PbPTweetAggregator.Aggregator
{
	public class Summary
	{
		public IList<Tweet> Tweets { get; set; }
		public IDictionary<string, int> NumTweets { get; set; }
		public IDictionary<string, int> NumMentions { get; set; }
	}
}

