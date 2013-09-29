using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using PbPTweetAggregator.Communication;

namespace PbPTweetAggregator.Twitter
{
    public class TwitterLib
    {
        private const string twitterApiBaseUrl = "https://api.twitter.com/1.1";

        public class TwitterCredentials
        {
            public string AccessToken { get; set; }
            public string AccessTokenSecret { get; set; }
            public string ConsumerKey { get; set; }
            public string ConsumerKeySecret { get; set; }
        }

        public class Tweet
        {
            public DateTime Created { get; set; }
            public string User { get; set; }
            public string Text { get; set; }
			public int Mentions { get; set; }
        }

        public static List<Tweet> GetTweets(TwitterCredentials credentials, string user)
        {
            OauthRequest request = new OauthRequest();
            request.ResourceUrl = twitterApiBaseUrl + "/statuses/user_timeline.json";
            request.Method = "GET";
            request.AccessToken = credentials.AccessToken;
            request.AccessTokenSecret = credentials.AccessTokenSecret;
            request.ConsumerKey = credentials.ConsumerKey;
            request.ConsumerKeySecret = credentials.ConsumerKeySecret;

            var requestParameters = new SortedDictionary<string, string>();
			//requestParameters.Add("include_rts", "false");
            requestParameters.Add("screen_name", user);

            request.RequestParameters = requestParameters;
            var response = request.GetResponse();

            JArray timeline = JArray.Parse(response);

            var tweets = from JObject tweet in timeline 
                         select new Tweet() { 
												User = user, 
												Created = ParseTwitterDateTime(tweet.GetValue("created_at").ToString()), 
												Text = tweet.GetValue("text").ToString(),
												Mentions = tweet["entities"]["user_mentions"].Children().Count()
											};

            return tweets.ToList();
        }

        public static List<Tweet> GetTweets(TwitterCredentials credentials, string user, DateTime minDate)
        {
            IEnumerable<Tweet> tweets = GetTweets(credentials, user);
            return tweets.Where(t => t.Created >= minDate).ToList();
        }

        private static DateTime ParseTwitterDateTime(string date)
        {
            const string format = "ddd MMM dd HH:mm:ss zzzz yyyy";
            return DateTime.SpecifyKind(DateTime.ParseExact(date, format, CultureInfo.InvariantCulture), DateTimeKind.Utc);
        }


    }
}