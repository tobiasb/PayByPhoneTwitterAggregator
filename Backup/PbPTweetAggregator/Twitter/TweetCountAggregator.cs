using System;
using System.Collections.Generic;
using PbPTweetAggregator.Twitter;

namespace PbPTweetAggregator.Twitter
{
	public class TweetCountAggregator : IUserBasedTweetAggregator
	{
		public IDictionary<string, int> Aggregate(IList<TwitterLib.Tweet> tweets)
		{
			Dictionary<string, int> dict = new Dictionary<string, int> ();

			foreach(TwitterLib.Tweet tweet in tweets)
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

