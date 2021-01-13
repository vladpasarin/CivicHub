using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class Prize: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ICollection<PrizeGiven> PrizeGivens { get; set; }
    }
}
