using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Day3.Task.Models.Domain;
using MVC.Day3.Task.Models.View;
using System.Diagnostics.Metrics;

namespace MVC.Day3.Task.Controllers
{
    public class TicketsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Ticket> Tickets = Ticket.GetTickets();

            List<TicketReadVM> ticketReadVM = Tickets.Select(t => new TicketReadVM
            {
                Id = t.Id,
                CreatedDate = t.CreatedDate,
                IsClosed = t.IsClosed,
                Severity = t.Severity,
                DepartmentId = t.Department!.Id,
                Description = t.Description,
            }).ToList();

            return View(ticketReadVM);
        }

        [HttpGet]
        public IActionResult TicketDetails(Guid id)
        {
            Ticket ticket = Ticket.GetTickets().First(t => t.Id == id);

            TicketReadVM ticketVM = new TicketReadVM
            {
                Id = ticket.Id,
                CreatedDate = ticket.CreatedDate,
                IsClosed = ticket.IsClosed,
                Severity = ticket.Severity,
                DepartmentId = ticket.Department!.Id,
                Description = ticket.Description,
                DevelopersId = ticket.Assignee.Select(d => d.Id).ToList()
            };

            return View(ticketVM);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData[Constants.Department] = Functions.ViewDepts();
            ViewData[Constants.Developers] = Functions.ViewDevelopers();

            return View();
        }

        [HttpPost]
        public IActionResult Add(TicketAddVM ticketVM) 
        {

            if (!ModelState.IsValid)
            {
                ViewData[Constants.Department] = Functions.ViewDepts();
                ViewData[Constants.Developers] = Functions.ViewDevelopers();

                return View();
            }

            var selectedDepartment = Department.GetDepartments()
                .FirstOrDefault(d=> d.Id == ticketVM.DepartmentId);

            var selectedDevelopers = Developer.GetDevelopers()
                .Where(d => ticketVM.DevelopersId.Contains(d.Id))
                .ToList();

            Ticket ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                CreatedDate = ticketVM.CreatedDate,
                IsClosed = ticketVM.IsClosed,
                Severity = ticketVM.Severity,
                Department = selectedDepartment,
                Description = ticketVM.Description,
                Assignee = selectedDevelopers
            };

            Ticket._tickets.Add(ticket);

            TempData[Constants.Operation] = Constants.Add;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid id) 
        {
            Ticket ticket = Ticket.GetTickets().First(d => d.Id == id);

            TicketEditVM ticketEditVM = new()
            {
                Id = ticket.Id,
                CreatedDate = ticket.CreatedDate,
                IsClosed = ticket.IsClosed,
                Severity = ticket.Severity,
                DepartmentId = ticket.Department!.Id,
                Description = ticket.Description,
                DevelopersId = ticket.Assignee.Select(d => d.Id).ToList()
            };

            ViewData[Constants.Department] = Functions.ViewDepts();
            ViewData[Constants.Developers] = Functions.ViewDevelopers();

            return View(ticketEditVM);
        }

        [HttpPost]
        public IActionResult Edit(TicketEditVM ticketVM)
        {

            if (!ModelState.IsValid)
            {
                ViewData[Constants.Department] = Functions.ViewDepts();
                ViewData[Constants.Developers] = Functions.ViewDevelopers();

                return View();
            }

            var selectedDepartment = Department.GetDepartments()
                .FirstOrDefault(d => d.Id == ticketVM.DepartmentId);

            var selectedDevelopers = Developer.GetDevelopers()
                .Where(d => ticketVM.DevelopersId.Contains(d.Id))
                .ToList();

            var ticket = Ticket.GetTickets().First(d => d.Id == ticketVM.Id);

            ticket.CreatedDate = ticketVM.CreatedDate;
            ticket.IsClosed = ticketVM.IsClosed;
            ticket.Severity = ticketVM.Severity;
            ticket.Department = selectedDepartment;
            ticket.Description = ticketVM.Description;
            ticket.Assignee = selectedDevelopers;

            TempData[Constants.Operation] = Constants.Edit;

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var ticket = Ticket.GetTickets().First(t => t.Id == id);

            Ticket._tickets.Remove(ticket);

            TempData[Constants.Operation] = Constants.Delete;

            return RedirectToAction(nameof(Index));
        }

    }
}
