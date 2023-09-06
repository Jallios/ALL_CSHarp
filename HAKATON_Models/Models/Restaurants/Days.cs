﻿using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Restaurants
{
    [BsonIgnoreExtraElements]
    public class Days
    {
        public Mon? Mon { get; set; }
        public Tue? Tue { get; set; }
        public Wed? Wed { get; set; }
        public Thu? Thu { get; set; }
        public Fri? Fri { get; set; }
        public Sat? Sat { get; set; }
        public Sun? Sun { get; set; }
    }
}
