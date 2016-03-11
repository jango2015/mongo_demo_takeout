using System;
using System.Runtime.InteropServices;
using DataProvider;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Tuling

            var info = "上海今天的天气";
            var st = TulingClient.Get(info);
            var result = st.Str2Obj();
            var responseType = TulingClient.GetResultType((int)result.code);



            Console.WriteLine(st);

            #endregion

            #region takeOut
            //var elemeShopListUrl = "https://m.ele.me/restapi/v4/restaurants?extras%5B%5D=restaurant_activity&extras%5B%5D=food_activity&geohash=wtw3tfwrm5g&limit=30&offset=0&type=geohash";
            //var elemeShopListStr = HttpClient.Get(elemeShopListUrl);
            //var elemeShopLists = elemeShopListStr.Str2Obj();

            //var str0 = (elemeShopLists as object).Obj2Str<object>();

            /// 
            //var iwaimai_meituan_addressUrl = string.Format("http://i.waimai.meituan.com/beijing/search?address={0}", "五棵松");

            //var mongo = new MongoDataProvider();
            //var meituanShoplists = new List<Restaurant>();
            //for (int i = 3; i < 50; i++)
            //{
            //    var meituanwaimaiUrl = "http://i.waimai.meituan.com/mti/home/wtw3w07tfpvr?page_index=" + i + "&apage=1";
            //    //var meituan_geo_list = HttpClient.Get(iwaimai_meituan_addressUrl).Str2Obj();
            //    var meituanShoplistStr = HttpClient.Get(meituanwaimaiUrl);
            //    var meituanShoplist = HtmlClient.GetRestaurantsByHtml(meituanShoplistStr, "div");
            //    meituanShoplists.AddRange(meituanShoplist);
            //}
            //mongo.InsertMany<Restaurant>(meituanShoplists);


            //var b = mongo.GetAll<Restaurant>();

            ////var str1 = (meituanShoplists as object).Obj2Str<object>();

            //#region insert one
            ////var model = new meituanJsons()
            ////{
            ////    Name = "Meituan_Waimai_ShopList",
            ////    JsonStr = str1
            ////};
            ////mongo.Insert<meituanJsons>(model);

            ////var o = mongo.GetAll<meituanJsons>();
            //#endregion

            //Console.WriteLine(b.Obj2Str());

            #endregion


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
