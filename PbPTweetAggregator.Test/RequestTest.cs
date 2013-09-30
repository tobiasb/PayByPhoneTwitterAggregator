using System;
using NUnit.Framework;
using PbPTweetAggregator.Communication;

namespace PbPTweetAggregator.Tests
{
    [TestFixture()]
    public class RequestTest
    {
        [Test()]
        public void TestExampleRequest()
        {
            Request r = new Request();
            r.Method = "GET";
            r.ResourceUrl = "http://www.example.com/";

            try
            {
                r.GetResponse();
            }
            catch(Exception ex)
            {
				Assert.Fail(string.Format("The request to {0} should be successful but was not: {1}", r.ResourceUrl, ex));
            }
        }
    }
}
