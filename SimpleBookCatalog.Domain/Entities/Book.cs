using SimpleBookCatalog.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimpleBookCatalog.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please provide title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage ="Please provide Author name")]
        [MaxLength(100)]
        public string Author { get; set; }
        public DateTime? PublicationDate { get; set; }

        [EnumDataType(typeof(Category), ErrorMessage = "Please select a category")]
        public Category Category { get; set; }
    }
}
