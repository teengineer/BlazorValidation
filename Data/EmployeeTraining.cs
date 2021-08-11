using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorValidation.Data
{
    public class EmployeeTraining
    {
        public int Id { get; set; }
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
