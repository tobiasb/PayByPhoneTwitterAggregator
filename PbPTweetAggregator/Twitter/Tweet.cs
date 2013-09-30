using System;

namespace PbPTweetAggregator
{
	public class Tweet : IEquatable<Tweet>
	{
		public long Id { get; set; }
		public DateTime Created { get; set; }
		public string User { get; set; }
		public string Text { get; set; }
		public int Mentions { get; set; }

		
		public bool Equals(Tweet other)
		{
			return Id != null && other.Id != null && Id == other.Id;
		}
	}
}

