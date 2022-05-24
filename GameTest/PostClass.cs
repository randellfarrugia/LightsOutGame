using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameTest
{
    public class PostClass
    {
        public string PostFormReturn(string URL, string methodType = "POST", string PostData = "", string ContentType = "application/json", List<KeyValuePair<string, string>> Headers = null)
        {
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse Response;
            StreamWriter SW;
            StreamReader SR;
            string ResponseData;

            Request.Method = methodType;
            Request.ContentType = ContentType;

            Encoding encoding = Encoding.UTF8;
            byte[] postDataByte;
            if (PostData == null)
            {
                postDataByte = null;
            }
            else
            {
                postDataByte = encoding.GetBytes(PostData);
                Request.ContentLength = postDataByte.Length;
            }

            if ((Headers != null) && (Headers.Count > 0))
            {
                for (var index = 0; index <= Headers.Count - 1; index++)
                {
                    Request.Headers.Add(Headers[index].Key, Headers[index].Value);
                }
            }

            //Send Request
            try
            {
                SW = new StreamWriter(Request.GetRequestStream());
                SW.Write(PostData);
                SW.Close();
            }
            catch (Exception Ex)
            {
            }

            //Receive Response
            try
            {
                Response = (HttpWebResponse)Request.GetResponse();
                SR = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding(1251));
                ResponseData = SR.ReadToEnd();
            }
            catch (System.Net.WebException Wex)
            {
                SR = new StreamReader(Wex.Response.GetResponseStream());
                ResponseData = SR.ReadToEnd();
                throw new InvalidDataException(ResponseData);
            }


            return ResponseData;
        }

    }
}


