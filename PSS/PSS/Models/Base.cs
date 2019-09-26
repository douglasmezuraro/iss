using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class Base
    {
        protected const int DescriptionMinLength = 2;
        protected const int DescriptionMaxLength = 100;

        [Key][ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }
    }
}