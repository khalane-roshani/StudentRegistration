using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRegistration.Models;

namespace StudentRegistration.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContext context;

        public CreateModel(DatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Student Students { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid || context.Students == null || Students == null)
            {
                return Page();
            }
            context.Students.Add(Students);
            await context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
