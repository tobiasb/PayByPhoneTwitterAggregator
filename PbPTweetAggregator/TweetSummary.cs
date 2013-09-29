using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using PbPTweetAggregator.Twitter;
using PbPTweetAggregator.Properties;

namespace PbPTweetAggregator
{		
	public class TweetSummary
	{
		public string Name { get; set; }
	}

	public class TweetSummaryResponse
	{
		public PayByPhoneAggregator.Summary Result { get; set; }
	}

	public class TweetSummaryService : IService
	{
		public object Any(TweetSummary request)
		{
			TwitterLib.TwitterCredentials credentials = new TwitterLib.TwitterCredentials()
			{
				AccessToken = Settings.Default.TwitterAccessToken,
				AccessTokenSecret = Settings.Default.TwitterAccessTokenSecret,
				ConsumerKey = Settings.Default.TwitterConsumerKey,
				ConsumerKeySecret = Settings.Default.TwitterConsumerKeySecret
			};

			string[] twitterUsers = Settings.Default.TwitterUsers.Split (',');
			PayByPhoneAggregator aggregator = new PayByPhoneAggregator (credentials, twitterUsers);

			return new TweetSummaryResponse() { Result = aggregator.GetSummary() };
		}
	}
}

