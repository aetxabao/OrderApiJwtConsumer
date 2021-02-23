using System;
using System.Collections.Generic;
using OrderApiJwtConsumer.Items;
using RestSharp; //dotnet add package RestSharp

namespace OrderApiJwtConsumer
{
    class Program
    {
        private const string BASEURL = "https://localhost:5001/api";

        static void Main(string[] args)
        {
            LoginRequest loginReq = new LoginRequest { UserName = "aetxabao", Password = "P4t4t4s!" };
            var loginResp = PostLogin(loginReq);
            Console.WriteLine("\nTOKEN:\n" + loginResp.Token);

            if (loginResp.UserName != "aetxabao")
            {
                Console.WriteLine("\nFIN");
                return;
            }

            List<Order> list = GetOrders(loginResp.Token);

            Console.WriteLine("\nLIST:");
            foreach (var o in list)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("\nFin.");
        }

        private static LoginResponse PostLogin(LoginRequest login)
        {
            var client = new RestClient(BASEURL);
            var request = new RestRequest("customers/login", Method.POST);
            //request.AddParameter("data", data);
            request.AddJsonBody(login.ToJson());
            var response = client.Execute(request);
            //Console.WriteLine(response.Content);
            //Console.WriteLine(response.StatusCode);//NotFound|Created|BadRequest
            if (response.StatusCode.ToString().Contains("BadRequest"))
            {
                return new LoginResponse { Token = response.Content };
            }
            return LoginResponse.FromJson(response.Content);
        }

        private static List<Order> GetOrders(string token)
        {
            var client = new RestClient(BASEURL);
            var request = new RestRequest("orders", Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);
            var response = client.Execute(request);
            Console.WriteLine("\nGetOrders:");
            Console.WriteLine(response.Content);
            if (response.Content == "Invalid customer" || response.Content == "No order was found" || response.Content.Trim().Length == 0)
            {
                return new List<Order>();
            }
            return Order.ListFromJson(response.Content);
        }

    }
}
