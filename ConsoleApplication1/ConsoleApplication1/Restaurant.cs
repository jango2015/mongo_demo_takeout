using MongoDB.Bson;

namespace ConsoleApplication1
{
    public class Restaurant
    {

        public ObjectId _id { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public long RestaurantId { get; set; }

        public string Url { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 餐厅名称
        /// </summary>
        public string ShopTitle { get; set; }

        /// <summary>
        /// 月售情况
        /// </summary>
        public string SoldStatus { get; set; }

        /// <summary>
        /// 起送价
        /// </summary>
        public string QisongPriceStr { get; set; }
        public decimal QisongPrice { get { return decimal.Parse(QisongPriceStr.Trim('￥')); } }


        /// <summary>
        /// 配送费
        /// </summary>
        public string PeisongPriceStr { get; set; }
        public decimal PeisongPrice { get { return decimal.Parse(PeisongPriceStr.Trim('￥')); } }

        /// <summary>
        /// 是否美团专送
        /// </summary>
        public bool IsMeituanZhuanSong { get; set; }

        /// <summary>
        /// 配送时间（分钟）
        /// </summary>
        public int PeisongTime { get; set; }
    }
}
