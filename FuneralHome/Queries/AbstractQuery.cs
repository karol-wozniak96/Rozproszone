using FuneralHome.Models;
using MongoDB.Driver.Linq;

namespace FuneralHome.Queries
{
    public abstract class AbstractQuery
    {
        protected AbstractQuery() { }
        public abstract void GetResult(IMongoQueryable<Order> collection);
    }
}