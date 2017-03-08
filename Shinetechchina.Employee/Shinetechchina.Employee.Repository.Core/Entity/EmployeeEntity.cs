namespace Shinetechchina.Employee.Repository.Core
{
    using Shared;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public class EmployeeEntity : BaseEntity<Guid>
    {
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
        public string Gender { get; set; }

        public bool? Married { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }

    public static class EmployeeEntityExtensions
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

    public static class EmployeeEntryExtensions
    {
        public static EmployeeEntity ToEntity(this EmployeeEntry entry)
        {
            EmployeeEntity entity = new EmployeeEntity()
            {
                Email = entry.Email,
                EmployeeID = entry.EmployeeID,
                FirstName = entry.FirstName,
                Gender = entry.Gender,
                Id = entry.Id.Value,
                LastName = entry.LastName,
                Married = entry.Married,
                Phone = entry.Phone,
                Modified = entry.Modified,
                Created = entry.Created
            };
            return entity;
        }
    }
}

