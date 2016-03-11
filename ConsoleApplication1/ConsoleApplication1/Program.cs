using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var elemeShopListUrl = "https://m.ele.me/restapi/v4/restaurants?extras%5B%5D=restaurant_activity&extras%5B%5D=food_activity&geohash=wtw3tfwrm5g&limit=30&offset=0&type=geohash";
            //var elemeShopListStr = HttpClient.Get(elemeShopListUrl);
            //var elemeShopLists = elemeShopListStr.Str2Obj();

            //var str0 = (elemeShopLists as object).Obj2Str<object>();

            /// 
            var iwaimai_meituan_addressUrl = string.Format("http://i.waimai.meituan.com/beijing/search?address={0}", "五棵松");

            var meituanwaimaiUrl = "http://i.waimai.meituan.com/mti/home/wtw3w07tfpvr?page_index=1&apage=1";
            var meituan_geo_list = HttpClient.Get(iwaimai_meituan_addressUrl).Str2Obj();
            var meituanShoplistStr = HttpClient.Get(meituanwaimaiUrl);
            var meituanShoplists = HtmlClient.GetRestaurantsByHtml(meituanShoplistStr, "div");
            var str1 = (meituanShoplists as object).Obj2Str<object>();




            //User user = null;
            //Console.WriteLine(formatStr(user));
            //user = new User();
            ////var ss = " the user's name is :\{user.name},mobile is :\{user.mobile}";
            //var ss = $"first name is {user?.name},mobile is {user?.mobile}";
            //Console.WriteLine(ss);
            //Console.WriteLine(formatStr(user));
            //Console.WriteLine(getuserDesc(user));

            //var nameofob = nameof(User);
            //Console.WriteLine(nameofob);

            //try
            //{

            //}
            //catch (Exception ex) when (ex != null)
            //{

            //    throw;
            //}
            //catch (Exception ex) when (ex.Message == "")
            //{

            //}


            Console.ReadLine();

        }

        static string formatStr(User user) => $"the user's name is {user?.name},and the use's mobile is {user?.mobile}";

        static string getuserDesc(User user) => $"user's description is {user.userDesc}";


        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        private static bool IsConnected()
        {
            int i = 0;
            bool state = InternetGetConnectedState(out i, 0);
            return state;
        }
    }

    class User
    {
        public string name { get; set; } = "jango";
        public string mobile { get; set; } = "13000000000";

        public string userDesc => $"my name is {name},and my mobile number is {mobile}";
    }

    public struct point
    {

        public int x { get; set; }
        public int y { get; set; }
    }
}
