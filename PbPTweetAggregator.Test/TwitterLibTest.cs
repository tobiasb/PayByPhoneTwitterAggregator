using System;
using NUnit.Framework;
using PbPTweetAggregator.Twitter;
using Moq;
using System.Collections.Generic;

namespace PbPTweetAggregator.Test
{
	[TestFixture()]
	public class TwitterLibTest
	{
		[Test()]
		public void TestJsonDataExtraction ()
		{
			var requestWrapper = new Mock<ITimelineRequest>();
			requestWrapper
				.Setup (x => x.GetResponse ())
				.Returns(TwitterTestResponses.Response1);

			List<Tweet> tweets = TwitterLib.GetTimeline (requestWrapper.Object);

			Assert.AreEqual (5, tweets.Count);

			Assert.AreEqual (0, tweets [0].Mentions);
			Assert.AreEqual ("Today, Twitter is updating embedded Tweets to enable a richer photo experience: https://t.co/XdXRudPXH5", tweets [0].Text);
			Assert.AreEqual (new DateTime (2013, 09, 26, 19, 2, 42).ToLocalTime(), tweets [0].Created);

			//...
		}
	}
}

