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
        public static List<Tweet> GetTimeline(ITimelineRequest request)
        {
			return GetTimeline (request, DateTime.MinValue);
        }

		public static List<Tweet> GetTimeline(ITimelineRequest request, DateTime minDate)
        {
			List<Tweet> relevantTweets = null;
			List<Tweet> result = new List<Tweet> ();

			request.MaxId = long.MaxValue;

			do {
				JArray timeline = JArray.Parse (request.GetResponse ());

				//Get basic information of each tweet
				var tweets = from JObject tweet in timeline 
					select new Tweet () { 
					Id = long.Parse(tweet["id_str"].ToString()),
					User = request.User, 
					Created = ParseTwitterDateTime(tweet["created_at"].ToString()), 
					Text = tweet["text"].ToString(),
					Mentions = tweet["entities"]["user_mentions"].Children().Count()
				};

				relevantTweets = 
					tweets.Where (t => t.Created >= minDate && !result.Contains(t)).ToList ();

				result.AddRange (relevantTweets);
				request.MaxId =
					result.Aggregate((curmin, x) => (curmin == null || x.Id < curmin.Id ? x : curmin)).Id;

			} while (relevantTweets.Count > 0 && result.Count <= (request.Max ?? int.MaxValue));

			return result;
        }

        private static DateTime ParseTwitterDateTime(string date)
        {
            const string format = "ddd MMM dd HH:mm:ss zzzz yyyy";
            return DateTime.SpecifyKind(DateTime.ParseExact(date, format, CultureInfo.InvariantCulture), DateTimeKind.Utc);
        }


    }
}