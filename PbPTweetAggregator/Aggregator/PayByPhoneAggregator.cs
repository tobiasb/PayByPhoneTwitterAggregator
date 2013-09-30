using System;
using System.Collections;
using System.Collections.Generic;
using PbPTweetAggregator.Twitter;

namespace PbPTweetAggregator.Aggregator
{
	/**
	 * High level Twitter aggregator for PayByPhone that uses the TwitterLib to get tweets from 
	 * twitter users, combines and sorts them and enriches the summary with aggregated information.
	 **/
	public class PayByPhoneAggregator
	{
		private TwitterCredentials credentials;
		private string[] twitterUsers;

		public PayByPhoneAggregator (TwitterCredentials credentials, string[] twitterUsers)
		{
			this.credentials = credentials;
			this.twitterUsers = twitterUsers;
		}

		public Summary GetSummary()
		{
			List<Tweet> tweets = GetTweets ();

			return new Summary () {
				Tweets = tweets,
				NumTweets = new TweetCountAggregator().Aggregate(tweets),
				NumMentions = new MentionsAggregator().Aggregate(tweets)
			};
		}

		private List<Tweet> GetTweets()
		{
			List<Tweet> tweets = new List<Tweet> ();

			//Combine tweets for all twitter users
			foreach (string twitterUser in twitterUsers) {
				ITimelineRequest request = new OAuthTimelineRequest (credentials, twitterUser);
				tweets.AddRange(TwitterLib.GetTimeline(request, DateTime.Now.AddDays(-14)));
			}

			//Sort by created-date in descending order
			tweets.Sort ((t1, t2) => t2.Created.CompareTo (t1.Created));

			return tweets;
		}
	}
}

