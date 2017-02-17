namespace Shinetechchina.Employee.Repository.Shared.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public  class EmployeeEntity
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

        public bool Gender { get; set; }

        public bool? Married { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
