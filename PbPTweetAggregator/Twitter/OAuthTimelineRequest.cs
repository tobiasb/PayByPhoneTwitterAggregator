using System;
using PbPTweetAggregator.Twitter;
using PbPTweetAggregator.Communication;
using System.Collections.Generic;

namespace PbPTweetAggregator
{
	public class OAuthTimelineRequest : ITimelineRequest
	{
		private const string twitterApiBaseUrl = "https://api.twitter.com/1.1";

		private TwitterCredentials credentials;
		private string user;

		public long MaxId { get; set; }
		public string User { get { return user; } }
		public TwitterCredentials Credentials { get { return credentials; } }
		public int? Max { get; set; }

		public OAuthTimelineRequest (TwitterCredentials credentials, string user)
		{
			this.credentials = credentials;
			this.user = user;
		}

		public string GetResponse()
		{
			OauthRequest request = new OauthRequest();
			request.ResourceUrl = twitterApiBaseUrl + "/statuses/user_timeline.json";
			request.Method = "GET";
			request.AccessToken = credentials.AccessToken;
			request.AccessTokenSecret = credentials.AccessTokenSecret;
			request.ConsumerKey = credentials.ConsumerKey;
			request.ConsumerKeySecret = credentials.ConsumerKeySecret;

			var requestParameters = new SortedDictionary<string, string>();
			requestParameters.Add("count", "20");
			//requestParameters.Add("include_rts", "false");

			if(MaxId < long.MaxValue) {
				requestParameters.Add("max_id", MaxId.ToString());
			}

			requestParameters.Add("screen_name", user);

			request.RequestParameters = requestParameters;
			var response = request.GetResponse(); //Response contains the result in json

			return response;
		}
	}
}

