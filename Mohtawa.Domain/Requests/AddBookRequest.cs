using System.ComponentModel.DataAnnotations;

namespace Mohtawa.Domain.Requests
{
    public class AddBookRequest
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
