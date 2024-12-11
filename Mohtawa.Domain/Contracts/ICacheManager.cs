using Mohtawa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohtawa.Domain.Contracts
{
    public interface ICacheManager
    {
        void SetCacheItem<T>(string key, T value);
        T GetCacheItem<T>(string key);
        string GetLocalizedMessage(string key, string languageCode);
        string GetLocalizedMessages(string keys, string languageCode, string separator);
        string GetLocalizedMessages(List<MessageDTO> messageDTOs, string languageCode, string separator);
    }
}
