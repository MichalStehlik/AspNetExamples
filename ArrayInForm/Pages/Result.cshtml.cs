using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrayInForm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArrayInForm
{
    public class ResultModel : PageModel
    {
        [BindProperty]
        public DataInputModel Input { get; set; }
        public int Sum { get; set; } = 0;
        public ActionResult OnGet()
        {
            return RedirectToPage("./Index");
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                foreach(var row in Input.Data)
                {
                    foreach (var cell in row)
                    {
                        Sum = Sum + cell;
                    }
                }
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}