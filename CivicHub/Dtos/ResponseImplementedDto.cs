﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class ResponseImplementedDto
    {
        public Guid IssueId { get; set; }
        public List<string> Photos { get; set; }
        public string MessageFromAuthorities { get; set; }
    }
}
