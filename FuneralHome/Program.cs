using FuneralHome.Queries;
using FuneralHome.Utils;

namespace FuneralHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var firstQuery = new FirstQuery();
            firstQuery.GetResult(Configuration.GetCollection());
            
            var secondQuery = new SecondQuery();
            secondQuery.GetResult(Configuration.GetCollection());
            
            var thirdQuery = new ThirdQuery();
            thirdQuery.GetResult(Configuration.GetCollection());
        }
    }
}