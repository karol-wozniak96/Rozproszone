using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using FuneralHome.Models;
using MongoDB.Driver.Linq;

namespace FuneralHome.Queries
{
    public class ThirdQuery : AbstractQuery
    {
        public ThirdQuery() { }
        
        public override void GetResult(IMongoQueryable<Order> collection)
        {
            var timer = Stopwatch.StartNew();
            var query = collection.GroupBy(x => new
                    {
                        x.Client.FirstName,
                        x.Client.LastName,
                        x.Date
                    }
                )
                .Select(x => new
                    {
                        Client = x.Key.FirstName + " " + x.Key.LastName,
                        Employee = x.First().Employee.FirstName + " " + x.First().Employee.LastName,
                        Date = x.Key.Date,
                        FuneralPerson = x.First().Funeral.FuneralPerson,
                        Service = x.First().Service.Name,
                        ToPay = x.Sum(s => s.Service.Value) + x.Sum(f => f.Funeral.Value)
                    }
                )
                .OrderByDescending(x => x.ToPay)
                .ToList();
               
            foreach (var item in query)
            {
                Console.WriteLine($"Client: {item.Client} Employee: {item.Employee} Date: {item.Date} FuneralPerson: {item.FuneralPerson} Service: {item.Service} ToPay: {item.ToPay}");
            }
               
            timer.Stop();
            
            Console.WriteLine($"Execute time: {timer.ElapsedMilliseconds}");
            
            Thread.Sleep(5000);
        }
    }
}