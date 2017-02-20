namespace Shinetechchina.Employee.Repository.Shared
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public class EmployeeEntity
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

        public string Gender { get; set; }

        public bool? Married { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }

    public static class EmployeeEntryExtensions
    {
        public static EmployeeEntry ToEntry(this EmployeeEntity entity)
        {
            EmployeeEntry entry = new EmployeeEntry()
            {
                Email = entity.Email,
                EmployeeID = entity.EmployeeID,
                FirstName = entity.FirstName,
                Gender = entity.Gender,
                Id = entity.Id,
                LastName = entity.LastName,
                Married = entity.Married,
                Phone = entity.Phone,
                Modified = entity.Modified,
                Created = entity.Created
            };
            return entry;
        }
    }
}
