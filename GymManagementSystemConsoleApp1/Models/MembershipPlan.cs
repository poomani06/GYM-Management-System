using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystemConsoleApp1.Models
{
    public class MembershipPlan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public int DurationInDays { get; set; }
        public decimal Fee { get; set; }

        public MembershipPlan(int planId, string planName,
                              int durationInDays, decimal fee)
        {
            PlanId = planId;
            PlanName = planName;
            DurationInDays = durationInDays;
            Fee = fee;
        }
    }
}
   
