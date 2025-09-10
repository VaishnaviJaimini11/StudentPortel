using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortel.Data;
using StudentPortel.Models;
using StudentPortel.Models.Entity;

namespace StudentPortel.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext dbContext;

        public StudentsController(ApplicationDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Add(AddStudentsViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Subscribed = viewModel.Subscribed
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewmodel)
        {
            var student = await dbContext.Students.FindAsync(viewmodel.Id);

            if (student is not null)
            {
                student.Name = viewmodel.Name;
                student.Email = viewmodel.Email;
                student.PhoneNumber = viewmodel.PhoneNumber;
                student.Subscribed = viewmodel.Subscribed;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewmodel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewmodel.Id);

            if(student is not null)
            {
                dbContext.Students.Remove(viewmodel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }
    }
}
