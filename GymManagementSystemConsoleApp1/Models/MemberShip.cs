
using System;

namespace membserves
{
    public class MemberShip
    {
        public int MembershipId { get; set; }
        public int MemberId { get; set; }
        public int PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public decimal AmountPaid { get; set; }

        public MemberShip(int membershipId, int memberId, int planId,
                          DateTime startDate, DateTime endDate,
                          string status, decimal amountPaid)
        {
            MembershipId = membershipId;
            MemberId = memberId;
            PlanId = planId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            AmountPaid = amountPaid;
        }
    }
}
