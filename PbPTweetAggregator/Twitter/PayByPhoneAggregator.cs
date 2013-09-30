using System;
using System.Collections;
using System.Collections.Generic;
using PbPTweetAggregator.Twitter;

namespace PbPTweetAggregator.Twitter
{
	/**
	 * High level Twitter aggregator for PayByPhone that uses the TwitterLib to get tweets from 
	 * twitter users, combines and sorts them and enriches the summary with aggregated information.
	 **/
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

			//Combine tweets for all twitter users
			foreach (string twitterUser in twitterUsers) {
				tweets.AddRange(TwitterLib.GetTimeline(credentials, twitterUser, DateTime.UtcNow.AddDays(-14)));
			}

			//Sort by created-date descending
			tweets.Sort ((t1, t2) => t2.Created.CompareTo (t1.Created));

			return tweets;
		}
	}
}

