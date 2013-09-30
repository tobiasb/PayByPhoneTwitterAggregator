PayByPhone Interview Task
===========================

C# .NET Webservice that gathers timelines of twitter users, combines them and aggregates information before returning the Json response. Service Provided by REST Framework [ServiceStack](http://www.servicestack.net/), testing is implemented with NUnit and [Moq](https://github.com/Moq) and Json.NET is used for Json decoding.

Twitter API credentials as well as list of relevant twitter users (pay_by_phone, PayByPhone and PayByPhone_UK) are configurable via the AppSettings. 

The webservice is accessible at appharbor. The pretty-printed version can be found [here](http://pbptweetaggr.apphb.com/tweetSummary), the raw json [here](http://pbptweetaggr.apphb.com/tweetSummary?format=json).
