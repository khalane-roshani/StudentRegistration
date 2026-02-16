using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Models;

namespace StudentRegistration.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext context;

        public IndexModel(DatabaseContext ocontext)
        {
            context = ocontext;
        }
        public List<Student> StudentsList { get; set; }
        public async Task OnGetAsync()
        {
            if (context.Students != null) 
            {
                StudentsList = await context.Students.ToListAsync();
            }
        }
    }
}
