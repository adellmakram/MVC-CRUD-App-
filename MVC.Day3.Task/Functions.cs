using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Day3.Task.Models.Domain;

namespace MVC.Day3.Task
{
    public static class Functions
    {
       
        public static List<SelectListItem> ViewDepts()
        {
            var dept = Department.GetDepartments()
                .Select(d => new SelectListItem(d.Name, d.Id.ToString()))
                .ToList();

            return dept;
        }

        public static List<SelectListItem> ViewDevelopers()
        {
            var developers = Developer.GetDevelopers()
            .Select(a => new SelectListItem((a.FirstName + " " + a.LastName), a.Id.ToString()))
            .ToList();

            return developers;
        }

    }
}
