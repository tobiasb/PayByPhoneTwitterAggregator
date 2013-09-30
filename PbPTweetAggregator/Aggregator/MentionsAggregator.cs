using System;
using System.Collections.Generic;
using PbPTweetAggregator.Twitter;
using System.Text.RegularExpressions;

namespace PbPTweetAggregator.Aggregator
{
	/**
	 * Tweet aggregator that returns number of mentions of other twitter users per user
	 **/
	public class MentionsAggregator : IUserBasedTweetAggregator
	{
		public IDictionary<string, int> Aggregate(IList<Tweet> tweets)
		{
			Dictionary<string, int> dict = new Dictionary<string, int> ();

			foreach(Tweet tweet in tweets)
			{
				if (!dict.ContainsKey (tweet.User)) {
					dict.Add (tweet.User, 0);
				}

				dict [tweet.User] += tweet.Mentions;
			}

			return dict;
		}
	}
}

