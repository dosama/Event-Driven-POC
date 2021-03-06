﻿using System;
using System.Collections.Generic;

namespace OrderServiceApi.Data
{
    public partial class MessageLogs
    {
        public string Message { get; set; }
        public long? Offset { get; set; }
        public string Topic { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Id { get; set; }
    }
}
