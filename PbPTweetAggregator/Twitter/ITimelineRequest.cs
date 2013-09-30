using System;

namespace PbPTweetAggregator.Twitter
{
	public interface ITimelineRequest : IRequest
	{
		long MaxId { 
			get; 
			set; 
		}

		string User {
			get;
		}

		TwitterCredentials Credentials {
			get;
		}

		int? Max {
			get;
			set;
		}
	}
}

