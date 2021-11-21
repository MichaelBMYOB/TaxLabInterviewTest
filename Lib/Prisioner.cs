using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Prisioner
    {
        public int Id { get; set; }

        protected bool HasOpportunity { get; set; }

        public virtual (bool switchA, bool switchB) Visit(bool switchA, bool switchB)
        {
            if (!HasOpportunity && !switchB)
            {
                switchB = true;
                HasOpportunity = true;
            }
            else
            {
                switchA = !switchA;
            }
            return (switchA, switchB);
        }
    }

    public class Scorekeeper : Prisioner
    {
        public int Score { get; private set; }

        public override (bool switchA, bool switchB) Visit(bool switchA, bool switchB)
        {
            if (!HasOpportunity)
            {
                HasOpportunity = true;
                Score++;
            }

            if (switchB)
            {
                switchB = false;
                Score++;
            }
            else
            {
                switchA = !switchA;
            }
            return (switchA, switchB);
        }
    }
}
