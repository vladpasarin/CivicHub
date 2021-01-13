using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Entities
{
    public class PrizeGiven : BaseEntity
    {
        public Guid PrizeId { get; set; }
        public Prize Prize { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime DateGiven { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public int DeliveryState { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
