using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test_11_Prisioners_all_validate_25_percent()
        {
            var prisioners = new List<Prisioner>
            {
                new Scorekeeper
                {
                    Id=1
                },
                new Prisioner
                {
                    Id=2
                },
                new Prisioner
                {
                    Id=3
                },
                new Prisioner
                {
                    Id=4
                },
                new Prisioner
                {
                    Id=5
                },
                new Prisioner
                {
                    Id=6
                },
                new Prisioner
                {
                    Id=7
                },
                new Prisioner
                {
                    Id=8
                },
                new Prisioner
                {
                    Id=9
                },
                new Prisioner
                {
                    Id=10
                },
                new Prisioner
                {
                    Id=11
                },
            };

            List<int> prisionersIds = new List<int>
            {
                1,
                2,
                1,
                2,
                2,
                2,
                2,
                2,
                2,
                2,
                2,
                2,
                2,
                2,
                2,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                3,
                1,
                2,
                3,
                4,
                5,
                1,
                6,
                1,
                7,
                1,
                8,
                1,
                9,
                1,
                10,
                1,
                11,
                1,
            };


            var warden = new Warden(prisionersIds);
            var activity = new Activities(prisioners, warden);

            var statisticData = activity.RunSimulation();

            var avg = statisticData.AvgVisits;
            var totalVisits = statisticData.TotalVisits;
            var topVisited = statisticData.TopVisited;
            var leastVisited = statisticData.LeastVisited;
            var totalVisitsVarden = statisticData.TotalVisitsByWarden;
            var simulationTime = statisticData.SimulationTime;
            var maxRAMMB = statisticData.MaxRAMMB;
            var top25VistedPrisioners = statisticData.Top25VistedPrisioners;

            Assert.AreEqual(top25VistedPrisioners.Count, 2);
            Assert.IsTrue(top25VistedPrisioners.Where(w => w.Id == 2 || w.Id == 3).Any());

            Assert.AreEqual(totalVisits, prisionersIds.Count);
            Assert.AreEqual(topVisited.Id, 3);
            Assert.AreEqual(leastVisited.Id, 4);
            Assert.AreEqual(totalVisitsVarden, prisionersIds.Count);
        }
        [TestMethod]
        public void Test_11_Prisioners_all_visited_by_order_happy_path()
        {
            var prisioners = new List<Prisioner>
            {
                new Scorekeeper
                {
                    Id=1
                },
                new Prisioner
                {
                    Id=2
                },
                new Prisioner
                {
                    Id=3
                },
                new Prisioner
                {
                    Id=4
                },
                new Prisioner
                {
                    Id=5
                },
                new Prisioner
                {
                    Id=6
                },
                new Prisioner
                {
                    Id=7
                },
                new Prisioner
                {
                    Id=8
                },
                new Prisioner
                {
                    Id=9
                },
                new Prisioner
                {
                    Id=10
                },
                new Prisioner
                {
                    Id=11
                },
            };

            List<int> prisionersIds = new List<int>
            {
                1,
                2,
                1,
                3,
                1,
                4,
                1,
                5,
                1,
                6,
                1,
                7,
                1,
                8,
                1,
                9,
                1,
                10,
                1,
                11,
                1,
            };


            var warden = new Warden(prisionersIds);
            var activity = new Activities(prisioners, warden);

            var statisticData = activity.RunSimulation();

            var avg = statisticData.AvgVisits;
            var totalVisits = statisticData.TotalVisits;
            var topVisited = statisticData.TopVisited;
            var leastVisited = statisticData.LeastVisited;
            var totalVisitsVarden = statisticData.TotalVisitsByWarden;
            var simulationTime = statisticData.SimulationTime;
            var maxRAMMB = statisticData.MaxRAMMB;
            var top25VistedPrisioners = statisticData.Top25VistedPrisioners;

            Assert.AreEqual(totalVisits, prisionersIds.Count);
            Assert.AreEqual(topVisited.Id, 1);//Scorekeepr
            Assert.AreEqual(totalVisitsVarden, prisionersIds.Count);
        }


        [TestMethod]
        public void Test_11_Prisioners_Till_The_End()
        {
            var prisioners = new List<Prisioner>
            {
                new Scorekeeper
                {
                    Id=1
                },
                new Prisioner
                {
                    Id=2
                },
                new Prisioner
                {
                    Id=3
                },
                new Prisioner
                {
                    Id=4
                },
                new Prisioner
                {
                    Id=5
                },
                new Prisioner
                {
                    Id=6
                },
                new Prisioner
                {
                    Id=7
                },
                new Prisioner
                {
                    Id=8
                },
                new Prisioner
                {
                    Id=9
                },
                new Prisioner
                {
                    Id=10
                },
                new Prisioner
                {
                    Id=11
                },
            };

            var warden = new Warden(new List<int>());
            var activity = new Activities(prisioners, warden);

            var statisticData = activity.RunSimulationTillTheEnd();
            var totalVisits = statisticData.TotalVisits;
            Assert.AreEqual(totalVisits, prisioners.Count);
            //Assert.Pass();
        }
    }
}
