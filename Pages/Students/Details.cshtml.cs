using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Models;

namespace StudentRegistration.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext context;
        public DetailsModel (DatabaseContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Student Students { get; set; }
        public async Task<IActionResult> OnGetAsync(int? itmeid)
        {
            if (itmeid == null)
            {
                return NotFound();
            }
            var student = await context.Students.FirstOrDefaultAsync (x => x.Id == itmeid);
            if (student == null) 
            {
                return NotFound();
            }
            Students = student;
            return Page();
        }
    }
}
