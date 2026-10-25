
using System;
using memberdem;
using memberserv;
using memshpserc;
using planservic;
using reportserv;
using dataserv;

Console.WriteLine(" GYM MANAGEMENT SYSTEM ");

// Create service objects
MemberServices memberService = new MemberServices();

PlanServices planService = new PlanServices();

MemberShipService membershipService = new MemberShipService();

ReportServices report = new ReportServices(
    memberService, planService, membershipService);


DataService dataService = new DataService();
memberService.mem = dataService.LoadMembers();
planService.plans = dataService.LoadPlans();
membershipService.memberships = dataService.LoadMemberships();

while (true)
{
    Console.WriteLine("\n===== MAIN MENU =====");
    Console.WriteLine("1. Member Management");
    Console.WriteLine("2. Plan Management");
    Console.WriteLine("3. Membership Management");
    Console.WriteLine("4. Reports");
    Console.WriteLine("5. Save Data");
    Console.WriteLine("6. Exit");
    Console.WriteLine("Enter your choice:");

    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Please enter a valid number");
        continue;
    }

    switch (choice)
    {
        case 1:
            Console.WriteLine("\n--- MEMBER MANAGEMENT ---");
            Console.WriteLine("1. Register Member");
            Console.WriteLine("2. Display Members");
            Console.WriteLine("3. Search Member by ID");
            Console.WriteLine("4. Search by Name or Phone");
            Console.WriteLine("5. Update Contact");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("Enter your choice:");

            string? memberInput = Console.ReadLine();

            if (!int.TryParse(memberInput, out int memberChoice))
            {
                Console.WriteLine("Please enter a valid number");
                break;
            }

            switch (memberChoice)
            {
                case 1:
                    memberService.Register();
                    break;
                case 2:
                    memberService.Display();
                    break;
                case 3:
                    memberService.SearchById();
                    break;
                case 4:
                    memberService.SearchByNameOrPhone();
                    break;
                case 5:
                    memberService.UpdateContact();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            break;


        case 2:
            Console.WriteLine("\n--- PLAN MANAGEMENT ---");
            Console.WriteLine("1. Add Plan");
            Console.WriteLine("2. Display Plans");
            Console.WriteLine("3. Search Plan by ID");
            Console.WriteLine("4. Search Plan");
            Console.WriteLine("5. Update Plan");
            Console.WriteLine("6. Back to Main Menu");

            Console.WriteLine("Enter your choice:");

            string? planInput = Console.ReadLine();

            if (!int.TryParse(planInput, out int planChoice))
            {
                Console.WriteLine("Please enter a valid number");
                break;
            }


            switch (planChoice)
            {
                case 1:
                    planService.AddPlan();
                    break;

                case 2:
                    planService.DisplayPlans();
                    break;

                case 3:
                    planService.GetPlanById();
                    break;

                case 4:
                    planService.SearchPlan();
                    break;

                case 5:
                    planService.UpdatePlan();
                    break;

                case 6:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            break;



        case 3:
            Console.WriteLine("\n--- MEMBERSHIP MANAGEMENT ---");
            Console.WriteLine("1. Assign Plan");
            Console.WriteLine("2. Display Memberships");
            Console.WriteLine("3. Search Membership by ID");
            Console.WriteLine("4. Cancel Membership");
            Console.WriteLine("5. Renew Membership");
            Console.WriteLine("6. Check Active Membership");
            Console.WriteLine("7. Back to Main Menu");

            Console.WriteLine("Enter your choice:");

            string? membershipInput = Console.ReadLine();

            if (!int.TryParse(membershipInput, out int membershipChoice))
            {
                Console.WriteLine("Please enter a valid number");
                break;
            }


            switch (membershipChoice)
            {
                case 1:
                    membershipService.AssignPlan();
                    break;

                case 2:
                    membershipService.DisplayMemberships();
                    break;

                case 3:
                    membershipService.GetMembershipById();
                    break;

                case 4:
                    membershipService.CancelMembership();
                    break;

                case 5:
                    membershipService.RenewMembership(memberService, planService);
                    break;

                case 6:
                    membershipService.CheckActiveMembership();
                    break;

                case 7:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            break;



        case 4:
            Console.WriteLine("\n--- REPORTS ---");
            Console.WriteLine("1. Member Memberships");
            Console.WriteLine("2. Active Memberships");
            Console.WriteLine("3. Expiring Memberships");
            Console.WriteLine("4. Group Memberships by Plan");
            Console.WriteLine("5. Total Revenue");
            Console.WriteLine("6. Active Membership Count per Plan");
            Console.WriteLine("7. Members Without Active Membership");
            Console.WriteLine("8. Back to Main Menu");

            Console.WriteLine("Enter your choice:");

            string? reportInput = Console.ReadLine();

            if (!int.TryParse(reportInput, out int reportChoice))
            {
                Console.WriteLine("Please enter a valid number");
                break;
            }


            switch (reportChoice)
            {
                case 1:
                    report.ListMemberMemberships();
                    break;

                case 2:
                    report.ListActiveMemberships();
                    break;

                case 3:
                    report.ListExpiringMemberships();
                    break;

                case 4:
                    report.GroupMembershipsByPlan();
                    break;

                case 5:
                    report.CalculateTotalRevenue();
                    break;

                case 6:
                    report.ActiveMembershipCountPerPlan();
                    break;

                case 7:
                    report.MembersWithoutActiveMembership();
                    break;

                case 8:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            break;
        case 5:
            dataService.SaveMembers(memberService.mem);
            dataService.SavePlans(planService.plans);
            dataService.SaveMemberships(membershipService.memberships);
            break;


        case 6:
            dataService.SaveMembers(memberService.mem);
            dataService.SavePlans(planService.plans);
            dataService.SaveMemberships(membershipService.memberships);

            Console.WriteLine("Thank you!");
            return;


        default:
            Console.WriteLine("Invalid choice");
            break;

    }
}
