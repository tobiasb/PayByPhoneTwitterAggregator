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
using PbPTweetAggregator.Aggregator;

namespace PbPTweetAggregator
{		
	public class TweetSummary
	{
		public string Name { get; set; }
	}

	public class TweetSummaryResponse
	{
		public Summary Result { get; set; }
	}
	
	/**
	 * ServiceStack class
	 **/
	public class TweetSummaryService : IService
	{
		public object Any(TweetSummary request)
		{
			TwitterCredentials credentials = new TwitterCredentials()
			{
				AccessToken = Settings.Default.TwitterAccessToken,
				AccessTokenSecret = Settings.Default.TwitterAccessTokenSecret,
				ConsumerKey = Settings.Default.TwitterConsumerKey,
				ConsumerKeySecret = Settings.Default.TwitterConsumerKeySecret
			};

			//The Twitter-Users that are included in the aggregation can be administered in the AppSettings
			string[] twitterUsers = Settings.Default.TwitterUsers.Split (',');

			//Trigger aggregation and return result through framework to browser
			PayByPhoneAggregator aggregator = new PayByPhoneAggregator(credentials, twitterUsers);
			return new TweetSummaryResponse() { Result = aggregator.GetSummary() };
		}
	}
}

