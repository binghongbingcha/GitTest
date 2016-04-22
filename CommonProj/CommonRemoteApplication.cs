using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommonProj
{
    public class CommonRemoteApplication
    {
        // REST @POST 方法
        public static T DoPostMethodToObj<T>(string metodUrl, string jsonBody)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(metodUrl);
                request.Method = "post";
                request.Accept = "application/json;";
                request.ContentType = "application/json;charset=utf-8";
                request.Headers.Add("Authorization", "bearer " + ConfigHelper.Cvur.access_token);
                var stream = request.GetRequestStream();
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(jsonBody);
                    writer.Flush();
                }
                var response = (HttpWebResponse)request.GetResponse();
                string json = GetResponseString(response);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }
        }

        // 将 HttpWebResponse 返回结果转换成 string
        public static string GetResponseString(HttpWebResponse response)
        {
            string json = null;
            if (response != null)
            {

                using (
                    var reader = new StreamReader(response.GetResponseStream(),
                        Encoding.GetEncoding("UTF-8")))
                {
                    json = reader.ReadToEnd();
                }
            }
            return json;
        }

    }
}
