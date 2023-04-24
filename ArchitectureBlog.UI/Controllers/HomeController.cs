using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using ArchitectureBlog.Entities;
using ArchitectureBlog.Business;
using ArchitectureBlog.DataAccess.Repositories;
using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.UI.Models;
using ArchitectureBlog.Core.Services;

namespace ArchitectureBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private IProjectService _projectService;

        public HomeController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(string contact_name, string contact_email, string contact_message)
        {
            List<InternetAddress> a = new List<InternetAddress>
            {
                MailboxAddress.Parse("emir.balci@hangikredi.com"),
                MailboxAddress.Parse("muhammedyucedagg@gmail.com")
            };

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("emirbalcii96@gmail.com"));
            email.To.AddRange(a);
            email.Subject = "Mail Var !!!!";
            email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>{contact_email} - {contact_name}</h1></br><p>{contact_message}</p>" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("emirbalcii96@gmail.com", "rttbytlreqzqxqix");
            smtp.Send(email);
            smtp.Disconnect(true);

            return RedirectToAction("Index");
        }

        // buraya projelerin listelenmesi yapılacaktır.
        public async Task<IActionResult> ArchitectureBlog()
        {
            var projects = await _projectService.GetAll(x => x.IsActive && x.IsDeleted == false);
            HomePageProjectModel model = new HomePageProjectModel();
            model.Projects = projects.OrderByDescending(x => x.CreationTime).Take(5).ToList();
            return View(model);
        }

        public IActionResult ArchitectureBlogDetail(Guid id)
        {
            var project = _projectService.GetBlogById(id);
            HomePageProjectDetailModel model = new HomePageProjectDetailModel();
            model.Project = project;
            return View(model);
        }
    }
}
