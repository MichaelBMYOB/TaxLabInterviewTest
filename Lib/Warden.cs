using System;
using System.Collections.Generic;

namespace Lib
{
    public class Warden
    {
        public Warden(List<int> prisionersIds)
        {
            PrisionersIds = prisionersIds;
        }
        public bool SwictchA { get; private set; }
        public bool SwictchB { get; private set; }
        public List<int> PrisionersIds { get; private set; }

        public void Visit(Prisioner prisioner)
        {
            var res = prisioner.Visit(SwictchA, SwictchB);
            SwictchA = res.switchA;
            SwictchB = res.switchB;
        }
    }
}
