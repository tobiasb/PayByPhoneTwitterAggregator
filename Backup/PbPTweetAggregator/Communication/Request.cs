using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PbPTweetAggregator.Communication
{
    public class Request
    {
        public string ResourceUrl { get; set; }
        public string Method { get; set; }
        public IDictionary<string, string> RequestParameters { get; set; }

        protected virtual void AddHeader(WebRequest request)
        {
            //Do nothing here. Can be overridden by specialising types
        }

        public string GetResponse()
        {
            ServicePointManager.Expect100Continue = false;
            WebRequest request = null;
            string resultString = string.Empty;

            if (Method == "POST")
            {
                var postBody = ToWebString(RequestParameters);

                request = (HttpWebRequest)WebRequest.Create(ResourceUrl);
                request.Method = Method.ToString();
                request.ContentType = "application/x-www-form-urlencoded";

                using (var stream = request.GetRequestStream())
                {
                    byte[] content = Encoding.ASCII.GetBytes(postBody);
                    stream.Write(content, 0, content.Length);
                }
            }
            else if (Method == "GET")
            {
                request = (HttpWebRequest)WebRequest.Create(ResourceUrl + "?"
                    + ToWebString(RequestParameters));
                request.Method = Method.ToString();
            }
            else
            {
                //other verbs can be addressed here...
            }

            if (request != null)
            {
                AddHeader(request);
                var response = request.GetResponse();

                using (var sd = new StreamReader(response.GetResponseStream()))
                {
                    resultString = sd.ReadToEnd();
                    response.Close();
                }
            }

            return resultString;
        }

        protected static string ToWebString(IDictionary<string, string> source)
        {
            if (source == null) return string.Empty;

            var body = new StringBuilder();

            foreach (var requestParameter in source)
            {
                body.Append(requestParameter.Key);
                body.Append("=");
                body.Append(Uri.EscapeDataString(requestParameter.Value));
                body.Append("&");
            }
            //remove trailing '&'
            body.Remove(body.Length - 1, 1);

            return body.ToString();
        }
    }
}