
using memberdem;
using memberserv;
using memshpserc;
using planservic;
using reportserv;


using System;

Console.WriteLine("Hello, World!");

// Create service objects
MemberServices memberService = new MemberServices();
PlanServices planService = new PlanServices();
MemberShipService membershipService = new MemberShipService();
ReportServices report = new ReportServices();

// Manage plans
planService.AddPlan();
planService.DisplayPlans();
planService.GetPlanById();
planService.SearchPlan();
planService.UpdatePlan();

// Display active membership count per plan
report.ActiveMembershipsPerPlan(
    membershipService.GetAll(),
    planService.GetAll());
report.ExpiringMemberships(membershipService.GetAll());
