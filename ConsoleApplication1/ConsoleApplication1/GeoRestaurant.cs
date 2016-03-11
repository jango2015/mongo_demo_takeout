using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GeoRestaurant
    {
        /// <summary>
        /// Geo Id
        /// </summary>
        public long GeoId { get; set; }
        /// <summary>
        /// Geo Code
        /// </summary>
        public string GeoCode { get; set; }

        /// <summary>
        /// Restaurant Id
        /// </summary>
        public long RestaurantId { get; set; }
    }
}
