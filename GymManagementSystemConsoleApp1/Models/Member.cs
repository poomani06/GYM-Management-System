using System;
using System.Collections.Generic;
using System.Text;

namespace memberdem

{
    public class Member
    {
        public int MemberId { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoinDate { get; set; }
        
        public Member(int id,string name,int age,string pnumber,DateTime date)
        {
            MemberId = id;
            FullName = name;
            Age = age;
            PhoneNumber = pnumber;
            JoinDate = date;
        }

    }
}
