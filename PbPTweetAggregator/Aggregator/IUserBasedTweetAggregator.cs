using System;
using System.Collections.Generic;
using PbPTweetAggregator.Twitter;

namespace PbPTweetAggregator.Aggregator
{
	public interface IUserBasedTweetAggregator
	{
		IDictionary<string, int> Aggregate(IList<Tweet> tweets);
	}
}

