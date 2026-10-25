
using System;
using System.Collections.Generic;
using System.Linq;
using memberdem;

namespace memberserv
{
    public class MemberServices
    {
        public List<Member> mem = new List<Member>();

        // Register member
        public void Register()
        {
            Console.WriteLine("Enter Member ID");
            int id = Convert.ToInt32(Console.ReadLine());

            if (mem.Any(m => m.MemberId == id))
            {
                Console.WriteLine("ID already exists");
                return;
            }

            Console.WriteLine("Enter Full Name");
            string? name = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Full Name is required");
                return;
            }

            Console.WriteLine("Enter Age");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age < 16 || age > 100)
            {
                Console.WriteLine("Invalid age");
                return;
            }

            Console.WriteLine("Enter Phone Number");
            string? phone = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(phone) ||
                phone.Length != 10)
            {
                Console.WriteLine("Enter a valid 10-digit phone number");
                return;
            }

            Member member = new Member(id, name, age, phone, DateTime.Today);

            mem.Add(member);

            Console.WriteLine("Member registered successfully");
        }

        // Display all members
        public void Display()
        {
            if (mem.Count == 0)
            {
                Console.WriteLine("No members found");
                return;
            }

            foreach (Member member in mem)
            {
                Console.WriteLine(
                    $"ID: {member.MemberId}, " +
                    $"Name: {member.FullName}, " +
                    $"Age: {member.Age}, " +
                    $"Phone: {member.PhoneNumber}");
            }
        }

        // Search member by ID
        public void SearchById()
        {
            Console.WriteLine("Enter Member ID");
            int id = Convert.ToInt32(Console.ReadLine());

            Member? member = mem.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found");
                return;
            }

            Console.WriteLine(
                $"ID: {member.MemberId}, " +
                $"Name: {member.FullName}, " +
                $"Age: {member.Age}, " +
                $"Phone: {member.PhoneNumber}");
        }

        // Search by name or phone
        public void SearchByNameOrPhone()
        {
            Console.WriteLine("Enter name or phone number");
            string? keyword = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("Enter a search value");
                return;
            }

            foreach (Member member in mem)
            {
                if (member.FullName.ToLower().Contains(keyword.ToLower()) ||
                    member.PhoneNumber.Contains(keyword))
                {
                    Console.WriteLine("ID: " + member.MemberId);
                    Console.WriteLine("Name: " + member.FullName);
                    Console.WriteLine("Phone: " + member.PhoneNumber);
                }
            }
        }
        

        // Update phone number
        public void UpdateContact()
        {
            Console.WriteLine("Enter Member ID");
            int id = Convert.ToInt32(Console.ReadLine());

            Member? member = mem.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found");
                return;
            }

            Console.WriteLine("Enter new phone number");
            string? phone = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(phone) || phone.Length != 10)
            {
                Console.WriteLine("Enter a valid 10-digit phone number");
                return;
            }

            member.PhoneNumber = phone;

            Console.WriteLine("Phone number updated successfully");
        }

        // Delete member

        public void DeleteMember()
        {
            Console.WriteLine("Enter Member ID");
            int id = Convert.ToInt32(Console.ReadLine());

            Member? member = mem.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found");
            }
            else
            {
                mem.Remove(member);
                Console.WriteLine("Member deleted successfully");
            }
        }
    }
}
