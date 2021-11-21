using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class StatisticData
    {
        public int TotalVisits { get;  set; }
        public Prisioner TopVisited { get; set; }
        public Prisioner LeastVisited { get; set; }
        public double AvgVisits { get; set; }
        public int TotalVisitsByWarden { get; set; }
        public TimeSpan SimulationTime { get; set; }
        public int MaxRAMMB { get; set; }
        public List<Prisioner> Top25VistedPrisioners { get; set; }
    }
}
