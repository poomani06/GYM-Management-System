using System;
using System.Collections.Generic;
using System.Text;
using memberdem;
namespace memberserv
{
    public class MemberServices
    {
        List<Member> mem = new List<Member>();
        public void Register(Member member)
        {

            if (mem.Any(m => m.MemberId == member.MemberId))
            {
                Console.WriteLine("Id already Exist");
                return;
            }
            if (mem.Any(m => m.Age < 16 || m.Age > 100))
            {
                Console.WriteLine("Invalid age");
                return;
            }
            if (String.IsNullOrWhiteSpace(member.FullName))
            {
                Console.WriteLine("FullName is Required");
                return;

            }
            if (member.PhoneNumber.Length != 10)
            {
                Console.WriteLine("10 digit number is required");
                return;

            }
            mem.Add(member);
            Console.WriteLine("member is register");
            
        }
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

        
        public void SearchById(int id)
        {
            Member? member = mem.FirstOrDefault(
                m => m.MemberId == id);

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

        
        public void SearchByNameOrPhone(string keyword)
        {
            var result = mem.Where(m =>
                m.FullName.Contains(
                    keyword, StringComparison.OrdinalIgnoreCase)
                || m.PhoneNumber.Contains(keyword));

            if (!result.Any())
            {
                Console.WriteLine("Member not found");
                return;
            }

            foreach (Member member in result)
            {
                Console.WriteLine(
                    $"ID: {member.MemberId}, " +
                    $"Name: {member.FullName}, " +
                    $"Phone: {member.PhoneNumber}");
            }
        }

        
        public void UpdateContact(int id, string phone)
        {
            Member? member = mem.FirstOrDefault(
                m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found");
                return;
            }

            if (String.IsNullOrWhiteSpace(phone) ||
                phone.Length != 10 ||
                !phone.All(char.IsDigit))
            {
                Console.WriteLine("Enter a valid 10-digit phone number");
                return;
            }

            member.PhoneNumber = phone;
            Console.WriteLine("Phone number updated successfully");
        }

        
        public void DeleteMember(int id, bool hasMembershipHistory)
        {
            Member? member = mem.FirstOrDefault(
                m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found");
                return;
            }

            if (hasMembershipHistory)
            {
                Console.WriteLine(
                    "Cannot delete: membership history exists");
                return;
            }

            mem.Remove(member);
            Console.WriteLine("Member deleted successfully");
        }

      
        public List<Member> GetAllMembers()
        {
            return mem;
        }
    }
}
            
