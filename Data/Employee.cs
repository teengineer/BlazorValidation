using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorValidation.Data
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = "";

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public List<EmployeeTraining> EmployeeTrainings { get; set; } = new List<EmployeeTraining>();

        /// <summary>
        /// Validation da verilmesi istenen mesaj bu değişkene yazılır
        /// </summary>
        public string ValidationMessage { get; set; } = "Bu alan zorunludur";
    }
}
