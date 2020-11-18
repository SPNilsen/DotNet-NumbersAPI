using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace StarterWeb.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            string fileName = "c://tmp//SpecialQueueNew1.xml";
            string xmlString = System.IO.File.ReadAllText(fileName);
            return new HttpResponseMessage()
            {
                Content = new StringContent(xmlString, Encoding.UTF8, "application/xml")
            };
        }

        // GET api/values/5551112222
        public HttpResponseMessage Get(String id)
        {
            //return "value:" + id;
            String docPath = "c://tmp//SpecialQueueNew1.xml";

            XPathDocument docNav = new XPathDocument(docPath);
            XPathNavigator nav = docNav.CreateNavigator();
            String xPath = "/root/type[phone=" + id + "]/@value";
            String value = null;
            try
            {
                value = nav.SelectSingleNode(xPath).Value;
            }
            catch (Exception ex)
            {
                //not found or other error
                value = "not-found";
            }

            string retVal = "<response><result>" + value + "</result></response>";
            return new HttpResponseMessage()
            {
                Content = new StringContent(retVal, Encoding.UTF8, "application/xml")
            };
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
