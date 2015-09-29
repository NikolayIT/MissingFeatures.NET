namespace MissingFeatures
{
    using System;
    using System.Net;
    using System.Text;

    public class HttpClient : WebClient
    {
        private const int DefaultTimeout = 3000;

        public HttpClient()
        {
            this.Timeout = DefaultTimeout;
            this.Encoding = Encoding.UTF8;
            this.UserAgent = UserAgentStrings.AssemblyUserAgent;
            this.CookieContainer = new CookieContainer();
        }

        public CookieContainer CookieContainer { get; set; }

        public string UserAgent { get; set; }

        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);

            var httpWebRequest = request as HttpWebRequest;

            if (httpWebRequest != null)
            {
                httpWebRequest.CookieContainer = this.CookieContainer;
                httpWebRequest.UserAgent = this.UserAgent;
                httpWebRequest.Timeout = this.Timeout;
            }

            return httpWebRequest ?? request;
        }
    }
}
