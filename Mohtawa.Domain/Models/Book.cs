using Mohtawa.Domain.Models.CustomModels;

namespace Mohtawa.Domain.Models
{
    public class Book : GenericModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}