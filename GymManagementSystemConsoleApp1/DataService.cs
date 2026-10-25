
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using memberdem;
using GymManagementSystemConsoleApp1.Models;
using membserves;

namespace dataserv
{
    public class DataService
    {
        public void SaveMembers(List<Member> members)
        {
            string json = JsonSerializer.Serialize(members);
            File.WriteAllText("Members.json", json);

            Console.WriteLine("Members saved");
        }

        public void SavePlans(List<MembershipPlan> plans)
        {
            string json = JsonSerializer.Serialize(plans);
            File.WriteAllText("Plans.json", json);

            Console.WriteLine("Plans saved");
        }

        public void SaveMemberships(List<MemberShip> memberships)
        {
            string json = JsonSerializer.Serialize(memberships);
            File.WriteAllText("Memberships.json", json);

            Console.WriteLine("Memberships saved");
        }

        public List<Member> LoadMembers()
        {
            if (File.Exists("Members.json"))
            {
                string json = File.ReadAllText("Members.json");

                if (!String.IsNullOrWhiteSpace(json))
                {
                    return JsonSerializer.Deserialize<List<Member>>(json)
                           ?? new List<Member>();
                }
            }

            return new List<Member>();
        }

        public List<MembershipPlan> LoadPlans()
        {
            if (File.Exists("Plans.json"))
            {
                string json = File.ReadAllText("Plans.json");

                if (!String.IsNullOrWhiteSpace(json))
                {
                    return JsonSerializer.Deserialize<List<MembershipPlan>>(json)
                           ?? new List<MembershipPlan>();
                }
            }

            return new List<MembershipPlan>();
        }

        public List<MemberShip> LoadMemberships()
        {
            if (File.Exists("Memberships.json"))
            {
                string json = File.ReadAllText("Memberships.json");

                if (!String.IsNullOrWhiteSpace(json))
                {
                    return JsonSerializer.Deserialize<List<MemberShip>>(json)
                           ?? new List<MemberShip>();
                }
            }

            return new List<MemberShip>();
        }

    }
}
