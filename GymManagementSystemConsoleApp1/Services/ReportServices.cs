using GymManagementSystemConsoleApp1.Models;
using memberdem;
using memberserv;
using membserves;
using memshpserc;
using planservic;
using System;

namespace reportserv
{
    public class ReportServices
    {
        public MemberServices memberService;
        public PlanServices planService;
        public MemberShipService membershipService;

        public ReportServices(
            MemberServices member,
            PlanServices plan,
            MemberShipService membership)
        {
            memberService = member;
            planService = plan;
            membershipService = membership;
        }

        // 1. List memberships for a member
        public void ListMemberMemberships()
        {
            Console.WriteLine("Enter Member ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (MemberShip m in membershipService.memberships)
            {
                if (m.MemberId == id)
                {
                    Console.WriteLine("Membership ID: " + m.MembershipId);
                    Console.WriteLine("Plan ID: " + m.PlanId);
                    Console.WriteLine("Status: " + m.Status);
                }
            }
        }

        // 2. List active memberships
        public void ListActiveMemberships()
        {
            foreach (MemberShip m in membershipService.memberships)
            {
                if (m.Status == "Active" &&
                    m.StartDate <= DateTime.Today &&
                    m.EndDate >= DateTime.Today)
                {
                    Console.WriteLine("Membership ID: " + m.MembershipId);
                    Console.WriteLine("Member ID: " + m.MemberId);
                }
            }
        }

        // 3. List memberships expiring within given days
        public void ListExpiringMemberships()
        {
            Console.WriteLine("Enter number of days:");
            int days = Convert.ToInt32(Console.ReadLine());

            DateTime lastDate = DateTime.Today.AddDays(days);

            foreach (MemberShip m in membershipService.memberships)
            {
                if (m.Status == "Active" &&
                    m.EndDate >= DateTime.Today &&
                    m.EndDate <= lastDate)
                {
                    Console.WriteLine("Membership ID: " + m.MembershipId);
                    Console.WriteLine("Expiry Date: " + m.EndDate.ToShortDateString());
                }
            }
        }

        // 4. Group memberships by plan
        public void GroupMembershipsByPlan()
        {
            foreach (MembershipPlan p in planService.plans)
            {
                Console.WriteLine("Plan: " + p.PlanName);

                foreach (MemberShip m in membershipService.memberships)
                {
                    if (m.PlanId == p.PlanId)
                    {
                        Console.WriteLine("Membership ID: " + m.MembershipId);
                    }
                }

                Console.WriteLine("----------------");
            }
        }

        // 5. Calculate total revenue
        public void CalculateTotalRevenue()
        {
            decimal total = 0;

            foreach (MemberShip m in membershipService.memberships)
            {
                total = total + m.AmountPaid;
            }

            Console.WriteLine("Total Revenue: " + total);
        }

        // 6. Active membership count per plan
        public void ActiveMembershipCountPerPlan()
        {
            foreach (MembershipPlan p in planService.plans)
            {
                int count = 0;

                foreach (MemberShip m in membershipService.memberships)
                {
                    if (m.PlanId == p.PlanId &&
                        m.Status == "Active" &&
                        m.StartDate <= DateTime.Today &&
                        m.EndDate >= DateTime.Today)
                    {
                        count++;
                    }
                }

                Console.WriteLine(p.PlanName + ": " + count);
            }
        }

        // 7. Members without active membership
        public void MembersWithoutActiveMembership()
        {
            foreach (Member member in memberService.mem)
            {
                bool active = false;

                foreach (MemberShip m in membershipService.memberships)
                {
                    if (m.MemberId == member.MemberId &&
                        m.Status == "Active" &&
                        m.StartDate <= DateTime.Today &&
                        m.EndDate >= DateTime.Today)
                    {
                        active = true;
                    }
                }

                if (active == false)
                {
                    Console.WriteLine(
                        member.MemberId + " - " + member.FullName);
                }
            }
        }
    }
}
