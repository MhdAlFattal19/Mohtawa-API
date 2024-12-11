﻿using Mohtawa.Domain.Enums;

namespace Mohtawa.Domain.DTOs
{
    public class MessageDTO
    {
        public string Message { get; set; }
        public List<string> Parameters { get; set; } = new();
        public MessageTypeEnum Type { get; set; }
    }
}