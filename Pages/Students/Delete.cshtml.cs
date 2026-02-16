using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Models;

namespace StudentRegistration.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly DatabaseContext context;
        public DeleteModel(DatabaseContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Student Students { get; set; }
        public async Task<IActionResult> OnGetAsync(int? itmeid)
        {
            if(itmeid == null)
            {
                return NotFound();
            }
            var student = await context.Students.FirstOrDefaultAsync(x => x.Id == itmeid);
            if (student == null) 
            { 
                return NotFound();
            }
            Students = student;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? itmeid)
        {
            if (itmeid == null) 
            { 
                return NotFound();
            }
            var student = await context.Students.FirstOrDefaultAsync(x => x.Id == itmeid);
            if (student == null)
            {
                return NotFound();
            }
            Students = student;

            context.Students.Remove(Students);
            await context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
