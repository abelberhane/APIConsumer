using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIConsumer
{
    // The Enumerations for our http verbs. Only using GET but its good to know.
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestClient
    {
        // Properties for the class
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        // Constructor for the above properties. Instantiating them..
        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        // Logic for Making a Request
        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            // Starting the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            // Retrieving the response. Was it succesful, was it not?
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // If it was not okay, send the error message
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Something went wrong. Hmm.... " + response.StatusCode.ToString());
                }

                // If the strream was not null, get the response and read until the end
                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

                return strResponseValue;
        }
    }
}
