using System;
using System.Collections.Generic;

namespace usergate2.Models
{
    public class ApiResponses
    {
        public getShippingData getShippingData;
        public distrList distrList;
    }

    public class getShippingData
    {
        public long embeddedKey;
        public List<distrList> distrList;
        public List<keyList> keyList;
    }

[Serializable]
    public class distrList
    {
        public string key;
        public string name;
        public string value;
    }
     public class keyList
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
