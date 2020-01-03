using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrayInForm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArrayInForm
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            Input = new SizeInputModel();
        }

        [BindProperty]
        public SizeInputModel Input { get; set; }
        public void OnGet()
        {
            Input.Width = 3;
            Input.Height = 3;
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("./Data", new { Width = Input.Width, Height = Input.Height });
            }
            return Page();
        }
    }
}