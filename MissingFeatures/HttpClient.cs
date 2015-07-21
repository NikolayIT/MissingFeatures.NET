namespace MissingFeatures
{
    using System;
    using System.Net;
    using System.Text;

    public class HttpClient : WebClient
    {
        private CookieContainer cookieContainer;
        private string userAgent;
        private int timeout;

        public HttpClient()
        {
            this.timeout = 3000;
            this.Encoding = Encoding.UTF8;
            this.userAgent = string.Format("MissingFeatures.NET.HttpClient/1.0 ({0})", Environment.Version);
            this.cookieContainer = new CookieContainer();
        }

        public CookieContainer CookieContainer
        {
            get { return this.cookieContainer; }
            set { this.cookieContainer = value; }
        }

        public string UserAgent
        {
            get { return this.userAgent; }
            set { this.userAgent = value; }
        }

        public int Timeout
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);

            if (request != null && request.GetType() == typeof(HttpWebRequest))
            {
                ((HttpWebRequest)request).CookieContainer = this.cookieContainer;
                ((HttpWebRequest)request).UserAgent = this.userAgent;
                request.Timeout = this.timeout;
            }

            return request;
        }
    }
}
