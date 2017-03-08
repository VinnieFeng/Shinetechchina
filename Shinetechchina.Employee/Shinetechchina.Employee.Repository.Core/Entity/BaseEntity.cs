using System.ComponentModel.DataAnnotations;

namespace Shinetechchina.Employee.Repository.Core
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
