using System;
using NUnit.Framework;
using PbPTweetAggregator.Communication;

namespace PbPTweetAggregator.Tests.Communication
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
                Assert.Fail(string.Format("The request to {0} should be successful", r.ResourceUrl));
            }
        }
    }
}
