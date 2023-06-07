namespace MVC.Day3.Task.Models.Domain
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Department(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public static List<Department> GetDepartments() => new()
		{
			new (1, "IT"),
			new (2, "Admin"),
			new (3, "Security"),
			new (4, "Trainee")
		};

		public override string ToString() => Name;
	}
}
