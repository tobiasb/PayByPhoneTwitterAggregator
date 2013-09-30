using System;

namespace PbPTweetAggregator.Twitter
{
	public interface ITimelineRequest : IRequest
	{
		string User {
			get;
		}

		TwitterCredentials Credentials {
			get;
		}
	}
}

