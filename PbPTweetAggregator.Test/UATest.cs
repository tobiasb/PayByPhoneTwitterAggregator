using System;
using NUnit.Framework;
using PbPTweetAggregator.Aggregator;
using PbPTweetAggregator.Tests;
using System.Linq;

namespace PbPTweetAggregator.Tests
{
	[TestFixture()]
	public class UATest
	{
		string[] twitterUsers = { "pay_by_phone","PayByPhone","PayByPhone_UK" };

		TwitterCredentials credentials = new TwitterCredentials()
		{
			AccessToken = TwitterTestCredentials.AccessToken,
			AccessTokenSecret = TwitterTestCredentials.AccessTokenSecret,
			ConsumerKey = TwitterTestCredentials.ConsumerKey,
			ConsumerKeySecret = TwitterTestCredentials.ConsumerKeySecret
		};

		[Test()]
		public void TestTweets()
		{
			PayByPhoneAggregator aggregator = new PayByPhoneAggregator (credentials, twitterUsers);
			Summary summary = aggregator.GetSummary ();

			//More than one tweet per user
			foreach(string user in twitterUsers) {
				Assert.IsTrue (summary.Tweets.Where (t => t.User == user).ToList().Count > 0);
			}
		}

		[Test()]
		public void TestAggregateData()
		{
			PayByPhoneAggregator aggregator = new PayByPhoneAggregator (credentials, twitterUsers);
			Summary summary = aggregator.GetSummary ();

			//Each user has aggretate information
			foreach(string user in twitterUsers) {
				Assert.IsTrue (summary.NumMentions[user] >= 0);
				Assert.IsTrue (summary.NumTweets[user] >= 0);
			}
		}

		[Test()]
		public void TestMaxTwoWeeks()
		{
			PayByPhoneAggregator aggregator = new PayByPhoneAggregator (credentials, twitterUsers);
			Summary summary = aggregator.GetSummary ();

			Assert.IsFalse(summary.Tweets.Where(t => t.Created < DateTime.UtcNow.AddDays(-14)).ToList().Count > 0);
		}
	}
}

