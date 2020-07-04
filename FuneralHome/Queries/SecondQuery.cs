using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using FuneralHome.Models;
using MongoDB.Driver.Linq;

namespace FuneralHome.Queries
{
    public class SecondQuery : AbstractQuery
    {
        public SecondQuery() { }
        
        public override void GetResult(IMongoQueryable<Order> collection)
        {
            var timer = Stopwatch.StartNew();
            var query = collection.GroupBy(x => x.Service.Name)
                .Select(x => new
                    {
                        Service = x.Key,
                        OrderCount = x.Count()
                    }
                )
                .OrderByDescending(x => x.OrderCount)
                .ToList();
           
            timer.Stop();
           
            foreach (var item in query)
            {
                Console.WriteLine($"Service: {item.Service} OrderCount: {item.OrderCount}");
            }
           
            Console.WriteLine($"Execute time: {timer.ElapsedMilliseconds}");
            
            Thread.Sleep(5000);
        }
    }
}