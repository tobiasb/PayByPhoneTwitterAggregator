using System;
using System.Collections;
using System.Collections.Generic;
using PbPTweetAggregator.Twitter;

namespace PbPTweetAggregator.Twitter
{
	public class PayByPhoneAggregator
	{
		public class Summary
		{
			public IList<TwitterLib.Tweet> Tweets { get; set; }
			public IDictionary<string, int> NumTweets { get; set; }
			public IDictionary<string, int> NumMentions { get; set; }
		}

		private TwitterLib.TwitterCredentials credentials;
		private string[] twitterUsers;

		public PayByPhoneAggregator (TwitterLib.TwitterCredentials credentials, string[] twitterUsers)
		{
			this.credentials = credentials;
			this.twitterUsers = twitterUsers;
		}

		public Summary GetSummary()
		{
			List<TwitterLib.Tweet> tweets = GetTweets ();

			return new Summary () {
				Tweets = tweets,
				NumTweets = new TweetCountAggregator().Aggregate(tweets),
				NumMentions = new MentionsAggregator().Aggregate(tweets)
			};
		}

		private List<TwitterLib.Tweet> GetTweets()
		{
			List<TwitterLib.Tweet> tweets = new List<TwitterLib.Tweet> ();

			foreach (string twitterUser in twitterUsers) {
				tweets.AddRange(TwitterLib.GetTweets(credentials, twitterUser, DateTime.UtcNow.AddDays(-14)));
			}

			tweets.Sort ((t1, t2) => t1.Created.CompareTo (t2.Created));

			return tweets;
		}
	}
}

