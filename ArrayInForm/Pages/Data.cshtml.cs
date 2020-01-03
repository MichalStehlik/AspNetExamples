using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrayInForm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArrayInForm
{
    public class DataModel : PageModel
    {
        [BindProperty]
        public DataInputModel Input { get; set; }
        public void OnGet(int width = 2, int height = 4)
        {
            Input = new DataInputModel();
            for (int i = 0; i < width; i++)
            {
                Input.Data.Add(new List<int>());
                for (int j = 0; j < height; j++)
                {
                    Input.Data[i].Add(0);
                }
            }
        }
    }
}