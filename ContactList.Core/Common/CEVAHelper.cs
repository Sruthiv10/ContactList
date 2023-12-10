using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core.Common
{
    public static class CEVAHelper
    {
        public static IConfiguration configuration;
        public static void Initialize(IConfiguration Configuration)
        {
            configuration = Configuration;
        }
        public static IReadOnlyDictionary<string, List<(string name, string value)>> LoadCevaQueryParams()
        {
            Dictionary<string, List<(string name, string value)>> collection = GetKeyValues();

            return collection;

            //var queryParams = rCollection["411695"];

            //foreach (var item in queryParams)
            //{
            //    Console.WriteLine(item.name);
            //    Console.WriteLine(item.value);
            //}
        }

        private static Dictionary<string, List<(string name, string value)>> GetKeyValues()
        {
            var collection = new Dictionary<string, List<(string name, string value)>>();
            for (int i = 1; i <= Constants.CevaKeyPairCount; i++)
            {
                collection.Add(configuration[$"AuthKey{i}Name"], new List<(string name, string value)>
                {
                    ("client_id", configuration[$"AuthKey{i}ClientId"]),
                    ("client_secret", configuration[$"AuthKey{i}ClientSecret"]),
                    ("grant_type", "client_credentials")
                });
            }
            //collection.Add(configuration["AuthKey1Name"], new List<(string name, string value)>
            //{
            //    ("client_id", configuration["AuthKey1Name"]),
            //    ("client_secret", configuration["AuthKey1ClientSecret"]),
            //    ("grant_type", "client_credentials")
            //});
            ////Vendor 
            //collection.Add("411601", new List<(string name, string value)>
            //{
            //    ("client_id", "2lDZxdGPv7s0v14yZXXuI5SLARAtRVnZ"),
            //    ("client_secret", "KWt3ed0EAa4lhBUA"),
            //    ("grant_type", "client_credentials")
            //});
            ////Vendor 
            //collection.Add("411695", new List<(string name, string value)>
            //{
            //    ("client_id", "mzhNr935MoQrRlvY7SqcT2aT9DRlQxEX"),
            //    ("client_secret", "sctxf1wGQjmvjczs"),
            //    ("grant_type", "client_credentials")
            //});
            ////Customer 
            //collection.Add("363502", new List<(string name, string value)>
            //{
            //    ("client_id", "yU0BRLEWdogfrRhbgwZxRzdpiA65wxjf"),
            //    ("client_secret", "xVSEtw8dp8UYH1J5"),
            //    ("grant_type", "client_credentials")
            //});
            return collection;
        }

        public static IReadOnlyDictionary<string, List<(string name, string value)>> LoadCevaHeaderParams(string correlationId)
        {
            var collection = new Dictionary<string, List<(string name, string value)>>();
            //PurchaseOrder 
            collection.Add(Enums.PurchaseOrderAPIEndpoint.PurchaseOrder.ToString(), new List<(string name, string value)>
            {
                ("IM-correlationID", correlationId),
                ("IM-countryCode", "US"),
                ("SystemID", "PL2"),
                ("SalesOrg", "L801")
            });
            //ProductMaster 
            collection.Add(Enums.PurchaseOrderAPIEndpoint.ProductMaster.ToString(), new List<(string name, string value)>
            {
                ("IM-correlationID", correlationId),
                ("IM-countryCode", "US"),
                ("SystemID", "PL2"),
                ("SalesOrg", "L801")
            });
            //Create Order 
            collection.Add(Enums.PurchaseOrderAPIEndpoint.CreateOrder.ToString(), new List<(string name, string value)>
            {
                ("IM-CorrelationID", correlationId),
                ("IM-CountryCode", "US"),
                ("SystemID", "PL2"),
                ("SalesOrg", "L801"),
                ("Channel", "10"),
                ("Division", "20"),
            });
            //ReturnOrder 
            collection.Add(Enums.PurchaseOrderAPIEndpoint.ReturnOrder.ToString(), new List<(string name, string value)>
            {
                ("IM-CorrelationID", correlationId),
                ("IM-CountryCode", "US"),
                ("SystemID", "PL2"),
                ("SalesOrg", "L801"),
                ("Channel", "10"),
                ("Division", "20"),
            });

            return collection;

            //var queryParams = rCollection["411695"];

            //foreach (var item in queryParams)
            //{
            //    Console.WriteLine(item.name);
            //    Console.WriteLine(item.value);
            //}
        }
    }
}
