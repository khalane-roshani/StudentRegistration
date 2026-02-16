using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Models;

namespace StudentRegistration.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext context;
        public EditModel (DatabaseContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Student Students { get; set; }
        public async Task<IActionResult> OnGetAsync(int? itmeid)
        {
            if(itmeid == null || context.Students == null)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Students.Update(Students);
            await context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
