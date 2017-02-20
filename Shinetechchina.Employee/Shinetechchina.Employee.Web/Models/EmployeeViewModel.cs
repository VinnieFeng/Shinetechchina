using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Shinetechchina.Employee.Business.Shared;

namespace Shinetechchina.Employee.Web.Models
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

    }
    public static class EmployeeViewModelExtensions
    {
        public static EmployeeModel ToModel(this EmployeeViewModel vm)
        {
            EmployeeModel entry = new EmployeeModel()
            {
                Email = vm.Email,
                EmployeeID = vm.EmployeeID,
                FirstName = vm.FirstName,
                Id = vm.Id,
                LastName = vm.LastName,
                Phone = vm.Phone,
            };
            return entry;
        }
    }

}