using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Activities
    {
        public StatisticData StatisticData { get; private set; }
        private Warden _warden = new Warden(new List<int> { 2, 3, 4 });
        List<Prisioner> _prisioners = new List<Prisioner>
        {

        };
        Stopwatch _watch = new System.Diagnostics.Stopwatch();
        private List<Tuple<Prisioner, int, bool, bool>> _log = new List<Tuple<Prisioner, int, bool, bool>>();

        public Activities()
        {

        }
        public Activities(List<Prisioner> prisioners, Warden warden)
        {
            _prisioners = prisioners;
            _warden = warden;
        }
        public StatisticData RunSimulation()
        {
            _watch.Start();
            var scorekeeper = _prisioners.FirstOrDefault(f => f is Scorekeeper) as Scorekeeper;
            if (scorekeeper == null)
            {
                //present error message: must have one scorekeeper
                //stop the flow
            }
            foreach (var id in _warden.PrisionersIds)
            {
                var prisionerFound = _prisioners.FirstOrDefault(f => f.Id == id);
                if (prisionerFound != null)
                {
                    _warden.Visit(prisionerFound);
                    //log here status of switchA, switchB and the Counter
                    _log.Add(new Tuple<Prisioner, int, bool, bool>(prisionerFound,
                        scorekeeper.Score, _warden.SwictchA, _warden.SwictchB));
                }

            }
            _watch.Stop();
            return GetStatisticData();
        }

        public StatisticData GetStatisticData()
        {
            StatisticData = new StatisticData();
            StatisticData.TotalVisits = _log.Count;

            var coountLogGroup = _log.GroupBy(info => info.Item1)
                         .Select(group => new
                         {
                             Prisioner = group.Key,
                             Count = group.Count()
                         })
                         .OrderBy(x => x.Count);

            StatisticData.TopVisited = coountLogGroup.Select(s => s.Prisioner).LastOrDefault();
            StatisticData.LeastVisited = coountLogGroup.Select(s => s.Prisioner).FirstOrDefault();

            StatisticData.AvgVisits = coountLogGroup.Select(s => s.Count).Average();

            StatisticData.Top25VistedPrisioners = coountLogGroup.Select(s => s.Prisioner).Take(coountLogGroup.Count() / 4).ToList();


            StatisticData.SimulationTime = _watch.Elapsed;

            return StatisticData;
        }
    }
}
