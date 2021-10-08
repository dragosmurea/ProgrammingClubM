using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClubM.Models
{
    public class MembershipTypeModel
    {
        public Guid IDMembershipType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubscriptionLengthToMonths { get; set; }

    }
}