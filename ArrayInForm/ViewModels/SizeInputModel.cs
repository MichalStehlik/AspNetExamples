using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArrayInForm.ViewModels
{
    public class SizeInputModel
    {
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
    }
}
