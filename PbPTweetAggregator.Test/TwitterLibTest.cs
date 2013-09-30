using NUnit.Framework;
using PbPTweetAggregator.Twitter;
using System.Collections.Generic;
using System;

namespace PbPTweetAggregator.Tests.Communication
{
    [TestFixture()]
    public class TwitterLibTest
    {
        TwitterLib.TwitterCredentials credentials = new TwitterLib.TwitterCredentials()
        {
            AccessToken = TwitterTestCredentials.AccessToken,
            AccessTokenSecret = TwitterTestCredentials.AccessTokenSecret,
            ConsumerKey = TwitterTestCredentials.ConsumerKey,
            ConsumerKeySecret = TwitterTestCredentials.ConsumerKeySecret
        };

        [Test()]
        public void TestGetTweets()
        {
            List<TwitterLib.Tweet> tweets = TwitterLib.GetTimeline(credentials, "twitter");

            Assert.IsNotNull(tweets);
            Assert.IsTrue(tweets.Count > 0);
        }

        [Test()]
        public void TestGetTweetsGreaterThanDate()
        {
            List<TwitterLib.Tweet> tweets = TwitterLib.GetTimeline(credentials, "twitter");

            Assert.IsNotNull(tweets);
            Assert.IsTrue(tweets.Count > 1);

            DateTime dateLimit = tweets[tweets.Count / 2].Created;

            tweets = TwitterLib.GetTimeline(credentials, "twitter", dateLimit);

            Assert.IsNotNull(tweets);
            Assert.IsTrue(tweets.Count > 0);
            tweets.ForEach(t => Assert.IsTrue(t.Created >= dateLimit));
        }
    }
}
