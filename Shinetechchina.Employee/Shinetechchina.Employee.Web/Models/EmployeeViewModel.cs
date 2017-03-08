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
        public EmployeeViewModel()
        {
        }

        public EmployeeViewModel(EmployeeModel model)
        {
            Email = model.Email;
            EmployeeID = model.EmployeeID;
            FirstName = model.FirstName;
            Id = model.Id;
            LastName = model.LastName;
            Phone = model.Phone;
        }

        public Guid? Id { get; set; }

        public string EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

    }
    public static class EmployeeViewModelExtensions
    {
        public static EmployeeModel ToModel(this EmployeeViewModel vm)
        {
            EmployeeModel entry = new EmployeeModel()
            {
                Email = vm.Email?.Trim(),
                EmployeeID = vm.EmployeeID?.Trim(),
                FirstName = vm.FirstName?.Trim(),
                Id = vm.Id,
                LastName = vm.LastName?.Trim(),
                Phone = vm.Phone?.Trim(),
            };
            return entry;
        }
    }

}