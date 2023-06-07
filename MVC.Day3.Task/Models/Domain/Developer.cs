using System;

namespace MVC.Day3.Task.Models.Domain
{
	public class Developer
	{
        public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

        public Developer(int id, string fname, string lname)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
        }

		public static List<Developer> GetDevelopers() => new()
		{
			new Developer( 1, "John", "Doe" ),
			new Developer( 2, "Jane", "Doe" ),
			new Developer( 3, "Bob", "Smith" ),
			new Developer( 4, "Alice", "Smith" ),
			new Developer( 5, "Tom", "Jones" ),
			new Developer( 6, "Alexa", "Smith" ),
			new Developer( 7, "Mathew", "William" )
		};

		public override string ToString() => FirstName+ ' ' + LastName;
	}
}
