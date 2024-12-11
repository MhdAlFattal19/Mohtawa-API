using Mohtawa.Domain.DTOs;

namespace Mohtawa.Domain.Models.CustomModels
{
    public class APIResponse
    {
        public dynamic Data { get; set; }
        public int Status { get; set; }
        public List<MessageDTO> Messages { get; set; }
        public string ErrorMessage { get; set; }
    }
}
