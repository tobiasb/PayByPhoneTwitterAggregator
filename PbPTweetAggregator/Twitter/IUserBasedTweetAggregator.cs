using System;
using System.Collections.Generic;
using PbPTweetAggregator.Twitter;

namespace PbPTweetAggregator
{
	public interface IUserBasedTweetAggregator
	{
		IDictionary<string, int> Aggregate(IList<TwitterLib.Tweet> tweets);
	}
}

