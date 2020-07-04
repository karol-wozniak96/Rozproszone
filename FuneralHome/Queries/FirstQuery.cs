using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using FuneralHome.Models;
using MongoDB.Driver.Linq;

namespace FuneralHome.Queries
{
    public class FirstQuery : AbstractQuery
    {
        public FirstQuery() { }
        
        public override void GetResult(IMongoQueryable<Order> collection)
        {
            var timer = Stopwatch.StartNew();
            var query = collection.GroupBy(x => new
                    {
                        x.Client.FirstName,
                        x.Client.LastName
                    }
                )
                .Select(x => new
                    {
                        Client = x.Key.FirstName + " " + x.Key.LastName,
                        OrderCount = x.Count()
                    }
                )
                .OrderByDescending(x => x.OrderCount)
                .ToList();
            
            timer.Stop();

            foreach (var item in query)
            {
                Console.WriteLine($"Client: {item.Client} OrderCount: {item.OrderCount}");
            }
           
            Console.WriteLine("Execute time: " + timer.ElapsedMilliseconds);
            
            Thread.Sleep(5000);
        }
    }
}