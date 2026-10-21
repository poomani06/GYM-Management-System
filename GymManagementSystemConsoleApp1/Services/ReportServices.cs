using GymManagementSystemConsoleApp1.Models;
using membserves;
using System;
using System.Collections.Generic;
using System.Text;


namespace reportserv
{
    public class ReportServices
    {

        // Active membership count per plan
        public void ActiveMembershipsPerPlan(
            List<MemberShip> memberships,
            List<MembershipPlan> plans)
        {
            foreach (MembershipPlan p in plans)
            {
                int count = 0;

                foreach (MemberShip m in memberships)
                {
                    if (m.PlanId == p.PlanId &&
                        m.Status == "Active" &&
                        m.StartDate <= DateTime.Today &&
                        m.EndDate >= DateTime.Today)
                    {
                        count++;
                    }
                }

                Console.WriteLine(
                    p.PlanName + " : " + count + " active memberships");
            }
        }
    
        
        public void ExpiringMemberships(List<MemberShip> memberships)
        {
            Console.WriteLine("Enter days:");
            int days = Convert.ToInt32(Console.ReadLine());

            foreach (MemberShip m in memberships)
            {
                if (m.Status == "Active" &&
                    m.EndDate >= DateTime.Today &&
                    m.EndDate <= DateTime.Today.AddDays(days))
                {
                    Console.WriteLine("Membership ID: " + m.MembershipId);
                    Console.WriteLine("Member ID: " + m.MemberId);
                    Console.WriteLine("End Date: " + m.EndDate);
                }
            }
        }

        public void TotalRevenue(List<MemberShip> memberships)
        {
            decimal total = 0;

            foreach (MemberShip m in memberships)
            {
                total = total + m.AmountPaid;
            }

            Console.WriteLine("Total Revenue: Rs." + total);
        }

    }
}

