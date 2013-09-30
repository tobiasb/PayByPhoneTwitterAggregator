using System;
using System.Collections.Generic;
using NUnit.Framework;
using PbPTweetAggregator.Twitter;

namespace PbPTweetAggregator.Tests
{
    [TestFixture()]
    public class OAuthTimelineRequestTest
    {
		private const string twitterTestUser = "twitterapi";

        TwitterCredentials credentials = new TwitterCredentials()
        {
            AccessToken = TwitterTestCredentials.AccessToken,
            AccessTokenSecret = TwitterTestCredentials.AccessTokenSecret,
            ConsumerKey = TwitterTestCredentials.ConsumerKey,
            ConsumerKeySecret = TwitterTestCredentials.ConsumerKeySecret
        };

        [Test()]
        public void TestGetTweets()
		{
			ITimelineRequest request = new OAuthTimelineRequest (credentials, twitterTestUser);
			List<Tweet> tweets = TwitterLib.GetTimeline(request);

            Assert.IsNotNull(tweets);
            Assert.IsTrue(tweets.Count > 0);
        }

        [Test()]
        public void TestGetTweetsGreaterThanDate()
		{
			ITimelineRequest request = new OAuthTimelineRequest (credentials, twitterTestUser);
			//Get all tweets
			List<Tweet> tweets = TwitterLib.GetTimeline(request);

			int tweetCount = tweets.Count;
            Assert.IsNotNull(tweets);
            Assert.IsTrue(tweetCount > 1);

			//Get created date from median element
            DateTime dateLimit = tweets[tweets.Count / 2].Created;

			//Get tweets up from that date
			tweets = TwitterLib.GetTimeline(request, dateLimit);

            Assert.IsNotNull(tweets);
            Assert.IsTrue(tweets.Count > 0);
			Assert.IsTrue (tweets.Count < tweetCount);
            tweets.ForEach(t => Assert.IsTrue(t.Created >= dateLimit));
        }
    }
}
