using System.ComponentModel.DataAnnotations;

namespace EventBooking.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        public string Name { get; set; } = default!;

        public List<Event> Events { get; set; } = new();
    }
}