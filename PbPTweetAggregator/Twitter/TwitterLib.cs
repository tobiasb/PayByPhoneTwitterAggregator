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
            JArray timeline = JArray.Parse(request.GetResponse());

			//Get basic information of each tweet
            var tweets = from JObject tweet in timeline 
                         select new Tweet() { 
												User = request.User, 
												Created = ParseTwitterDateTime(tweet.GetValue("created_at").ToString()), 
												Text = tweet.GetValue("text").ToString(),
												Mentions = tweet["entities"]["user_mentions"].Children().Count()
											};

            return tweets.ToList();
        }

		public static List<Tweet> GetTimeline(ITimelineRequest request, DateTime minDate)
        {
            IEnumerable<Tweet> tweets = GetTimeline(request);
            return tweets.Where(t => t.Created >= minDate).ToList();
        }

        private static DateTime ParseTwitterDateTime(string date)
        {
            const string format = "ddd MMM dd HH:mm:ss zzzz yyyy";
            return DateTime.SpecifyKind(DateTime.ParseExact(date, format, CultureInfo.InvariantCulture), DateTimeKind.Utc);
        }


    }
}