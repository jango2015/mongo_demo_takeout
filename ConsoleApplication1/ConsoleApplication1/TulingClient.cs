namespace ConsoleApplication1
{
    public static class TulingClient
    {
        private static readonly string ApiUrl = "http://www.tuling123.com/openapi/api";
        private static readonly string Key = "02d800135314d5d35e604313386b2ba8";
        private static string getApi = string.Format(ApiUrl + "?key={0}", Key);
        public static string Get(string info)
        {
            var str = HttpClient.Get(string.Format(getApi + "&info={0}", info));
            return str;
        }

        public static string GetResultType(int code)
        {
            var str = string.Empty;
            switch (code)
            {

                case 100000:
                    str = "Text_Response";//文本类
                    break;
                case 200000:
                    str = "Link_Response";//链接类
                    break;
                case 302000:
                    str = "News_Response";//新闻类
                    break;
                case 308000:
                    str = "BillOfFare_Response";/*菜谱类*/
                    break;
                case 313000:
                    str = "ChildSong_Response"; /*儿歌类*/
                    break;
                case 314000:
                    str = "ChildPoetry_Response";//诗词类
                    break;
                case 40001:
                    str = "Error"; /*参数key错误*/
                    break;
                case 40002:
                    str = "Error"; /*请求内容info为空*/
                    break;
                case 40004:
                    str = "Error"; /*当天请求次数已使用完*/
                    break;
                case 40007:
                    str = "Error"; /*数据格式异常*/
                    break;
            }
            return str;
        }
    }














    public class TulingResponseBase
    {
        public int Code { get; set; }

        public string ErrMsg { get; set; }
    }

    public class Text_Response : TulingResponseBase
    {
        public string Text { get; set; }
    }

    public class Link_Response : TulingResponseBase
    {
        public string Text { get; set; }
        public string Url { get; set; }
    }

    public class News_Response : TulingResponseBase
    {
        public string Text { get; set; }
        public NewsItem[] List { get; set; }
        public class NewsItem
        {
            public string Article { get; set; }
            public string Source { get; set; }
            public string Icon { get; set; }
            public string DetailUrl { get; set; }
        }
    }

    public class BillOfFare_Response : TulingResponseBase
    {
        public string Text { get; set; }
        public BillOfFare[] List { get; set; }
        public class BillOfFare
        {
            public string Name { get; set; }
            public string Icon { get; set; }
            public string Info { get; set; }
            public string DetailUrl { get; set; }
        }
    }

    public class ChildSong_Response : TulingResponseBase
    {
        public string Text { get; set; }

        public SongItem[] Function { get; set; }

        public class SongItem
        {
            public string Song { get; set; }
            public string Singer { get; set; }
        }
    }


    public class ChildPoetry_Response : TulingResponseBase
    {
        public string Text { get; set; }

        public PoetryItem[] Function { get; set; }

        public class PoetryItem
        {
            public string Author { get; set; }
            public string name { get; set; }
        }
    }
}

