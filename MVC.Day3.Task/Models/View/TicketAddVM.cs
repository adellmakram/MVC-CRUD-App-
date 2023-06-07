using MVC.Day3.Task.Models.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Day3.Task.Models.View
{
	public class TicketAddVM
	{
		[Required]
        public DateTime CreatedDate { get; set; }
		public bool IsClosed { get; set; }
		public Severity Severity { get; set; }

		[DisplayName("Departments")]
		[Required]
        [Range(1, 300)]
        public int DepartmentId { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(30)]
		public string Description { get; set; }

		[Required]
		[DisplayName("Assignee")]
        public List<int> DevelopersId { get; set; } = new();
    }
}
