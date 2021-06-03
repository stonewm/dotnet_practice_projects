using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToOData4.Models;
using RestSharp;

namespace WebApiToOData4.Services {
    public class SapGLService {
        public IList<GlBalance> GetGlBalances(string cocd, string year, string period)
        {
            IList<GlBalance> balances = null;

            string baseUrl = "http://localhost:8000/";
            var client = new RestClient(baseUrl);
            string resources = $"sap/bal?cocd={cocd}&year={year}&period={period}";
            var req = new RestRequest(resources, Method.GET);

            IRestResponse resp = client.Execute(req);
            balances = Utilities.Utils.ToList<GlBalance>(resp.Content);

            return balances;
        }
    }
}
