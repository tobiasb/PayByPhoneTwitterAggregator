using System;
using System.Collections.Generic;
using PbPTweetAggregator.Twitter;

namespace PbPTweetAggregator.Aggregator
{
	/**
	 * Tweet aggregator that returns number of tweets per user
	 **/
	public class TweetCountAggregator : IUserBasedTweetAggregator
	{
		public IDictionary<string, int> Aggregate(IList<Tweet> tweets)
		{
			Dictionary<string, int> dict = new Dictionary<string, int> ();

			foreach(Tweet tweet in tweets)
			{
				if (!dict.ContainsKey (tweet.User)) {
					dict.Add (tweet.User, 0);
				}

				dict [tweet.User]++;
			}

			return dict;
		}
	}
}

