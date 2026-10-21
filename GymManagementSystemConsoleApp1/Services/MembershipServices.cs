
using GymManagementSystemConsoleApp1.Models;

using memberserv;
using planservic;
using System;
using System.Collections.Generic;
using System.Linq;
using membserves;

namespace memshpserc
{
    public class MemberShipService
    {
        List<MemberShip> memberships = new List<MemberShip>();

        // Assign plan to member
        public void AssignPlan(MemberShipService memberService, PlanServices planService)
        {
            Console.WriteLine("Enter Membership ID:");
            int membershipId = Convert.ToInt32(Console.ReadLine());

            foreach (MemberShip m in memberships)
            {
                if (m.MembershipId == membershipId)
                {
                    Console.WriteLine("Membership ID already exists");
                    return;
                }
            }

            Console.WriteLine("Enter Member ID:");
            int memberId = Convert.ToInt32(Console.ReadLine());

            if (memberService.GetAll().FirstOrDefault(m => m.MemberId == memberId) == null)
            {
                Console.WriteLine("Member not found");
                return;
            }

            Console.WriteLine("Enter Plan ID:");
            int planId = Convert.ToInt32(Console.ReadLine());

            MembershipPlan? plan = planService.GetAll()
                .FirstOrDefault(p => p.PlanId == planId);

            if (plan == null)
            {
                Console.WriteLine("Plan not found");
                return;
            }

            Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            DateTime endDate = startDate.AddDays(plan.DurationInDays);

            Console.WriteLine("Enter Amount Paid:");
            decimal amountPaid = Convert.ToDecimal(Console.ReadLine());

            if (amountPaid < 0)
            {
                Console.WriteLine("Amount cannot be negative");
                return;
            }

            MemberShip membership = new MemberShip(
                membershipId, memberId, planId,
                startDate, endDate, "Active", amountPaid);

            memberships.Add(membership);

            Console.WriteLine("Membership assigned successfully");
            Console.WriteLine("End Date: " + endDate.ToShortDateString());
        }

        // Display all memberships
        public void DisplayMemberships()
        {
            if (memberships.Count == 0)
            {
                Console.WriteLine("No memberships available");
                return;
            }

            foreach (MemberShip m in memberships)
            {
                UpdateStatus(m);

                Console.WriteLine("Membership ID: " + m.MembershipId);
                Console.WriteLine("Member ID: " + m.MemberId);
                Console.WriteLine("Plan ID: " + m.PlanId);
                Console.WriteLine("Start Date: " + m.StartDate.ToShortDateString());
                Console.WriteLine("End Date: " + m.EndDate.ToShortDateString());
                Console.WriteLine("Status: " + m.Status);
                Console.WriteLine("Amount Paid: " + m.AmountPaid);
                Console.WriteLine("-------------------------");
            }
        }

        // Get membership by ID
        public void GetMembershipById()
        {
            Console.WriteLine("Enter Membership ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            MemberShip? m = memberships.FirstOrDefault(x => x.MembershipId == id);

            if (m == null)
            {
                Console.WriteLine("Membership not found");
                return;
            }

            UpdateStatus(m);

            Console.WriteLine("Member ID: " + m.MemberId);
            Console.WriteLine("Plan ID: " + m.PlanId);
            Console.WriteLine("Start Date: " + m.StartDate.ToShortDateString());
            Console.WriteLine("End Date: " + m.EndDate.ToShortDateString());
            Console.WriteLine("Status: " + m.Status);
            Console.WriteLine("Amount Paid: " + m.AmountPaid);
        }

        // Update expired status
        private void UpdateStatus(MemberShip m)
        {
            if (m.Status != "Cancelled" && DateTime.Today > m.EndDate)
            {
                m.Status = "Expired";
            }
        }

        // Cancel membership
        public void CancelMembership()
        {
            Console.WriteLine("Enter Membership ID to cancel:");
            int id = Convert.ToInt32(Console.ReadLine());

            MemberShip? m = memberships.FirstOrDefault(x => x.MembershipId == id);

            if (m == null)
            {
                Console.WriteLine("Membership not found");
                return;
            }

            UpdateStatus(m);

            if (m.Status != "Active")
            {
                Console.WriteLine("Only active memberships can be cancelled");
                return;
            }

            m.Status = "Cancelled";
            Console.WriteLine("Membership cancelled successfully");
        }

        // Renew membership by creating a new record
        public void RenewMembership(MemberShipService memberService, PlanServices planService)
        {
            Console.WriteLine("Enter old Membership ID:");
            int oldId = Convert.ToInt32(Console.ReadLine());

            MemberShip? old = memberships.FirstOrDefault(m => m.MembershipId == oldId);

            if (old == null)
            {
                Console.WriteLine("Membership not found");
                return;
            }

            UpdateStatus(old);

            if (old.Status != "Expired")
            {
                Console.WriteLine("Only expired memberships can be renewed");
                return;
            }

            Console.WriteLine("Enter new Membership ID:");
            int newId = Convert.ToInt32(Console.ReadLine());

            foreach (MemberShip m in memberships)
            {
                if (m.MembershipId == newId)
                {
                    Console.WriteLine("Membership ID already exists");
                    return;
                }
            }

            MembershipPlan? plan = planService.GetAll()
                .FirstOrDefault(p => p.PlanId == old.PlanId);

            if (plan == null)
            {
                Console.WriteLine("Plan not found");
                return;
            }

            Console.WriteLine("Enter Amount Paid:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount < 0)
            {
                Console.WriteLine("Amount cannot be negative");
                return;
            }

            DateTime start = DateTime.Today;
            DateTime end = start.AddDays(plan.DurationInDays);

            MemberShip renewed = new MemberShip(
                newId, old.MemberId, old.PlanId,
                start, end, "Active", amount);

            memberships.Add(renewed);

            Console.WriteLine("Membership renewed successfully");
        }

        // Return all memberships
        public List<MemberShip> GetAll()
        {
            return memberships;
        }

        // Check active membership on a given date
        public void CheckActiveMembership()
        {
            Console.WriteLine("Enter Member ID:");
            int memberId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Date (yyyy-MM-dd):");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            foreach (MemberShip m in memberships)
            {
                if (m.MemberId == memberId &&
                    m.Status != "Cancelled" &&
                    m.StartDate <= date &&
                    m.EndDate >= date)
                {
                    Console.WriteLine("Member has an active membership");
                    return;
                }
            }

            Console.WriteLine("No active membership on this date");
        }
    }
}
