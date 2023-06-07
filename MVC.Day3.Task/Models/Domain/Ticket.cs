using MVC.Day3.Task.Models.View;

namespace MVC.Day3.Task.Models.Domain
{
	public class Ticket
	{
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsClosed { get; set; }
        public Severity Severity { get; set; }
        public Department? Department { get; set; }
        public string Description { get; set; }
        public List<Developer> Assignee { get; set; } = new();

        public Ticket()
        {
            Id = Guid.NewGuid();
        }

		public Ticket(
			DateTime createdDate,
			bool isClosed,
			Severity severity,
			Department department,
            string description,
            List<Developer> assignee
		){
			Id = Guid.NewGuid();
			CreatedDate = createdDate;
			IsClosed = isClosed;
			Severity = severity;
			Department = department;
            Description = description;
            Assignee = assignee;
		}

        public static List<Ticket> _tickets = new()
        {
            new Ticket(DateTime.Now.AddDays(-1), false, Severity.high, Department.GetDepartments().First(d=>d.Id == 1), "This is a high severity issue", Developer.GetDevelopers().Take(3).ToList()),
            new Ticket(DateTime.Now.AddDays(-2), true, Severity.medium, Department.GetDepartments().First(d=>d.Id == 4), "This is a medium severity issue", Developer.GetDevelopers().Take(2).ToList()),
            new Ticket(DateTime.Now.AddDays(-3), false, Severity.low, Department.GetDepartments().First(d=>d.Id == 3), "This is a low severity issue", Developer.GetDevelopers().Take(1).ToList()),
            new Ticket(DateTime.Now.AddDays(-4), true, Severity.high, Department.GetDepartments().First(d=>d.Id == 1), "This is a high severity issue", Developer.GetDevelopers().Take(4).ToList()),
            new Ticket(DateTime.Now.AddDays(-5), false, Severity.medium, Department.GetDepartments().First(d=>d.Id == 2), "This is a medium severity issue", Developer.GetDevelopers().Take(3).ToList()),
            new Ticket(DateTime.Now.AddDays(-6), true, Severity.low, Department.GetDepartments().First(d=>d.Id == 4), "This is a low severity issue", Developer.GetDevelopers().Take(3).ToList())
        };

        public static List<Ticket> GetTickets() => _tickets;
    }
}
