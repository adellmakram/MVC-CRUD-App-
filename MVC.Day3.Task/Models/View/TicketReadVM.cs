using MVC.Day3.Task.Models.Domain;
using System.ComponentModel;

namespace MVC.Day3.Task.Models.View
{
    public class TicketReadVM
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsClosed { get; set; }
        public Severity Severity { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public List<int> DevelopersId { get; set; } = new();

    }
}
