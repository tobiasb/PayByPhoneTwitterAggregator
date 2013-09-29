using System;
using NUnit.Framework;
using PbPTweetAggregator.Communication;

namespace PbPTweetAggregator.Tests.Communication
{
	[TestFixture()]
    public class OAuthTest
    {
        [Test()]
        public void TestOauth()
        {
            OauthRequest request = new OauthRequest();
            request.ResourceUrl = "https://api.twitter.com/1.1/account/verify_credentials.json"; //Use Twitter credential verification to test OAuth. Any other OAuth-Site would work too
            request.Method = "GET";
            request.AccessToken = TwitterTestCredentials.AccessToken;
            request.AccessTokenSecret = TwitterTestCredentials.AccessTokenSecret;
            request.ConsumerKey = TwitterTestCredentials.ConsumerKey;
            request.ConsumerKeySecret = TwitterTestCredentials.ConsumerKeySecret;

        }
    }
}
