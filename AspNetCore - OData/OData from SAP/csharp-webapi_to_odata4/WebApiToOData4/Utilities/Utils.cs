using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiToOData4.Utilities {
    public class Utils {
        public static IList<T> ToList<T>(string json)
        {
            JObject generalObj = JObject.Parse(json); // json -> JObject
            IList<JToken> jsonList = generalObj["values"].Children().ToList();

            IList<T> genericList = new List<T>();
            foreach (JToken tokenItem in jsonList) {
                var item = JsonConvert.DeserializeObject<T>(tokenItem.ToString());
                genericList.Add(item);
            }

            return genericList;
        }
    }
}
