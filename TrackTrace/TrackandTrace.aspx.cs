using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using TrackTrace.CreateLog;

namespace TrackTrace
{
    public partial class TrackandTrace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string awb = Request.QueryString["awb"];

            if (!string.IsNullOrEmpty(awb))
            {
                if (awb.Contains("_"))
                {
                    string[] allawbs = awb.Split('_');
                    foreach (string singleAWB in allawbs)
                    {

                    }
                }
                else
                {

                }


            }
            else
            {

            }



        }
        public XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                // maker the request to an external server
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //set teh request to an xml document
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                // return the document
                return (xmlDoc);
                //Literal1.Text = xmlDoc.ToString();
                //CreateLog.Log("ERROR", "XMLDoc" + "What I am" + xmlDoc.ToString());
                Log("ERROR", xmlDoc.ToString());
                //CreateLog.CreateLog.Log("ERROR", xmlDoc.ToString());
            }
            catch (Exception e)
            {

                //return null if an error occurs (possibly due to a non existent awbnumber)
                Console.WriteLine(e.Message);
                Console.Read();
                return null;
            }
        }
        public static void Log(string type, string msg)
        {
            var dir = HttpContext.Current.Server.MapPath("~/logs");
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
            System.IO.StreamWriter wrtr = null;
            {
                try
                {
                    wrtr = new System.IO.StreamWriter(dir + "/" + type + "-logs" + DateTime.Now.ToString("yyyyMMdd") + ".log", true);
                    wrtr.WriteLine(DateTime.Now.ToString() + "\t" + "\t" + msg);
                }
                finally
                {
                    if (wrtr != null)
                    {
                        wrtr.Close();
                        //wrtr.Dispose();
                    }
                }
            }
        }

        private void ProcessRequest(string serviceApplicationUrl, string topicmapName, string searchString)
        {
            // First construct the URL. We start with the path to the application
            // directory provided by the user. Expand this by adding the operation
            // ASPX page address (with a slash separator if needed).
            string requestUrl = serviceApplicationUrl;
            if (!requestUrl.EndsWith("/"))
            {
                requestUrl += "/";
            }
            requestUrl += "GetTopicsByName.aspx";

            Hashtable parameters = new Hashtable();
            parameters["topicmap"] = topicmapName;
            parameters["name"] = searchString;

            XmlDocument responseDoc = new XmlDocument();

            try
            {
                HttpStatusCode statusCode = GetResponse(requestUrl, parameters, responseDoc);
                if (statusCode == HttpStatusCode.OK)
                {
                    System.Console.WriteLine("Search request was processed successfully. Results follow.");
                }
                else
                {
                    System.Console.WriteLine("Search request failed: " + statusCode.ToString() + ". Details follow.");
                }
                XmlTextWriter writer = new XmlTextWriter(System.Console.Out);
                writer.Formatting = Formatting.Indented;
                responseDoc.WriteTo(writer);
            }
            catch (System.Net.WebException webex)
            {
                System.Console.Error.WriteLine("Error encountered in sending request. Please check the service application URL and try again.");
                System.Console.Error.WriteLine("  Error detail: " + webex.Message);
            }
        }

        /// <summary>
        /// Attempts to contact a NetworkedPlanet webservice, passing in the specified parameters.
        /// </summary>
        /// <param name="requestUrl">The URL of the service to contact</param>
        /// <param name="parameters">The parameters to pass to the service.</param>
        /// <param name="responseDoc">The response XML received from the web service</param>
        /// <returns>The HTTP status code of the response</returns>
        /// <exception cref="System.Net.WebException">Raised if the service could not be reached.</exception>
        /// <remarks>The <c>parameters</c> hashtable must use string keys and the value for each key must be either
        /// a string or an IList of string.</remarks>
        private HttpStatusCode GetResponse(string requestUrl, Hashtable parameters, XmlDocument responseDoc)
        {
            // Construct the request XML
            XmlDocument requestDoc = new XmlDocument();
            XmlElement requestEl = requestDoc.CreateElement("request");
            requestDoc.AppendChild(requestEl);
            // Parameters should be either strings or lists of strings
            foreach (string key in parameters.Keys)
            {
                if (parameters[key] is string)
                {
                    XmlElement param = requestDoc.CreateElement("param");
                    param.SetAttribute("name", key);
                    param.InnerXml = parameters[key] as string;
                    requestEl.AppendChild(param);
                }
                else if (parameters[key] is IList)
                {
                    // If the parameter is a list of strings, write a separate
                    // param element for each item in the list.
                    foreach (string item in (parameters[key] as IList))
                    {
                        XmlElement param = requestDoc.CreateElement("param");
                        param.SetAttribute("name", "key");
                        param.InnerXml = item;
                        requestEl.AppendChild(param);
                    }
                }
            }

            // Perform an ASCII encoding of the request xml
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] encodedBody = encoding.GetBytes(requestDoc.OuterXml);

            // Construct the request object
            HttpWebRequest webRequest = HttpWebRequest.Create(requestUrl) as HttpWebRequest;
            webRequest.ContentType = "text/xml";
            webRequest.ContentLength = encodedBody.Length;
            webRequest.Method = "POST";
            Stream bodyStream = webRequest.GetRequestStream();
            bodyStream.Write(encodedBody, 0, encodedBody.Length);
            bodyStream.Close();

            HttpWebResponse webResponse = null;
            try
            {
                webResponse = webRequest.GetResponse() as HttpWebResponse;
            }
            catch (System.Net.WebException webEx)
            {
                webResponse = webEx.Response as HttpWebResponse;
            }
            // NOTE: this will throw an exception out to the caller if the
            // response is not an XML document.
            responseDoc.Load(webResponse.GetResponseStream());
            return webResponse.StatusCode;

        }
}