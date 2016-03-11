namespace ConsoleApplication1
{
    using System.Net;
    using System.IO;
    using System.Web;
    using System.Text;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using Newtonsoft.Json;
    using HtmlAgilityPack;
    using System.Collections.Generic;

    #region HttpClient
    public static class HttpClient
    {
        public static string Get(string url)
        {
            var str = string.Empty;
            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            if (url.StartsWith("https:"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                request.ProtocolVersion = HttpVersion.Version10;
            }
            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var streamReader = new StreamReader(responseStream))
            {
                str = streamReader.ReadToEnd();
            }
            return str;
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => true;


    }
    #endregion

    #region UrlClient
    public static class UrlClient
    {
        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static string UrlDecode(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }
    }

    #endregion

    #region JsonSerializer
    public static class JsonSerializer
    {
        public static dynamic Str2Obj(this string str) => JsonConvert.DeserializeObject<dynamic>(str);

        public static string Obj2Str<T>(this T obj) => JsonConvert.SerializeObject(obj);
    }

    #endregion

    #region HtmlClient
    public static class HtmlClient
    {
        private static HtmlDocument doc = new HtmlDocument();
        private static string I_Waimai_Meituan_BaseUrl = "http://i.waimai.meituan.com";
        public static string GetHtml(string url, string xpath)
        {
            var html = HttpClient.Get(url);
            doc.LoadHtml(html);

            var collection = doc.DocumentNode.SelectNodes(xpath);
            var sb = new StringBuilder();
            foreach (HtmlNode item in collection)
            {
                sb.AppendFormat("{0},{1}", item.InnerText, item.InnerHtml);
            }

            return sb.ToString();
        }

        public static string GetObjStrByHtml(string html, string xpath)
        {
            doc.LoadHtml(html);

            var collection = doc.DocumentNode.SelectNodes(xpath);
            var sb = new StringBuilder();
            foreach (HtmlNode item in collection)
            {
                var a = item.SelectNodes("a");
            }

            return sb.ToString();
        }

        public static List<Restaurant> GetRestaurantsByHtml(string html, string xpath)
        {
            doc.LoadHtml(html);
            var list = new List<Restaurant>();
            var collection = doc.DocumentNode.SelectNodes(xpath);
            var sb = new StringBuilder();
            if (collection != null)
            {

                foreach (HtmlNode item in collection)
                {
                    var model = new Restaurant();
                    var htmlItem = item.ChildNodes.FindFirst("a");
                    var shortUrl = htmlItem.Attributes[0].Value;
                    model.Url = I_Waimai_Meituan_BaseUrl + shortUrl;
                    model.RestaurantId = long.Parse(shortUrl.Substring(shortUrl.LastIndexOf('/') + 1).ToString());

                    var childs = htmlItem.ChildNodes;
                    model.AvatarUrl = childs.FindFirst("img").Attributes["data-src-retina"].Value;

                    var content = childs[3];
                    var contentChild = content.ChildNodes;
                    model.ShopTitle = contentChild[1].ChildNodes[1].ChildNodes[0].InnerText;
                    model.SoldStatus = contentChild[3].ChildNodes[3].ChildNodes[0].InnerText;
                    try
                    {
                        var zhuansongImg = contentChild[3].ChildNodes[5].ChildNodes[0].Attributes[0];
                        model.IsMeituanZhuanSong = zhuansongImg == null ? false : true;
                    }
                    catch
                    {
                        model.IsMeituanZhuanSong = false;
                    }
                    model.QisongPriceStr = contentChild[5].ChildNodes[1].ChildNodes[1].InnerText;
                    model.PeisongPriceStr = contentChild[5].ChildNodes[3].ChildNodes[2].InnerText;
                    model.PeisongTime = int.Parse(contentChild[5].ChildNodes[5].ChildNodes[1].InnerText);

                    list.Add(model);
                }
            }

            return list;
        }
    }
    #endregion

}
