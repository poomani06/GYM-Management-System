using GymManagementSystemConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace planservic
{
    public class PlanServices
    {
        List<MembershipPlan> plans = new List<MembershipPlan>();

        // Add plan
        public void AddPlan()
        {
            Console.WriteLine("Enter Plan ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (MembershipPlan p in plans)
            {
                if (p.PlanId == id)
                {
                    Console.WriteLine("Plan ID already exists");
                    return;
                }
            }

            Console.WriteLine("Enter Plan Name:");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Plan name cannot be empty");
                return;
            }

            Console.WriteLine("Enter Duration in Days:");
            int duration = Convert.ToInt32(Console.ReadLine());

            if (duration <= 0)
            {
                Console.WriteLine("Duration must be positive");
                return;
            }

            Console.WriteLine("Enter Fee:");
            decimal fee = Convert.ToDecimal(Console.ReadLine());

            if (fee < 0)
            {
                Console.WriteLine("Fee cannot be negative");
                return;
            }

            MembershipPlan plan =
                new MembershipPlan(id, name, duration, fee);

            plans.Add(plan);

            Console.WriteLine("Plan added successfully");
        }

        // Display all plans
        public void DisplayPlans()
        {
            if (plans.Count == 0)
            {
                Console.WriteLine("No plans available");
                return;
            }

            foreach (MembershipPlan p in plans)
            {
                Console.WriteLine("Plan ID: " + p.PlanId);
                Console.WriteLine("Plan Name: " + p.PlanName);
                Console.WriteLine("Duration: " + p.DurationInDays + " days");
                Console.WriteLine("Fee: " + p.Fee);
                Console.WriteLine("---------------------");
            }
        }

        // Retrieve plan by ID
        public void GetPlanById()
        {
            Console.WriteLine("Enter Plan ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            MembershipPlan? plan =
                plans.FirstOrDefault(p => p.PlanId == id);

            if (plan == null)
            {
                Console.WriteLine("Plan not found");
                return;
            }

            Console.WriteLine("Plan Name: " + plan.PlanName);
            Console.WriteLine("Duration: " + plan.DurationInDays);
            Console.WriteLine("Fee: " + plan.Fee);
        }

        // Search plan by name
        public void SearchPlan()
        {
            Console.WriteLine("Enter Plan Name:");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            bool found = false;

            foreach (MembershipPlan p in plans)
            {
                if (p.PlanName.ToLower().Contains(name.ToLower()))
                {
                    Console.WriteLine(
                        p.PlanId + " - " + p.PlanName + " - " + p.Fee);

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Plan not found");
            }
        }

        // Update plan
        public void UpdatePlan()
        {
            Console.WriteLine("Enter Plan ID to update:");
            int id = Convert.ToInt32(Console.ReadLine());

            MembershipPlan? plan = plans.FirstOrDefault(p => p.PlanId == id);

            if (plan == null)
            {
                Console.WriteLine("Plan not found");
                return;
            }

            Console.WriteLine("Enter New Plan Name:");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            Console.WriteLine("Enter New Duration in Days:");
            int duration = Convert.ToInt32(Console.ReadLine());

            if (duration <= 0)
            {
                Console.WriteLine("Duration must be positive");
                return;
            }

            Console.WriteLine("Enter New Fee:");
            decimal fee = Convert.ToDecimal(Console.ReadLine());

            if (fee < 0)
            {
                Console.WriteLine("Fee cannot be negative");
                return;
            }

            plan.PlanName = name;
            plan.DurationInDays = duration;
            plan.Fee = fee;

            Console.WriteLine("Plan updated successfully");
        }

        // Return all plans
        public List<MembershipPlan> GetAll()
        {
            return plans;
        }
    }
}
