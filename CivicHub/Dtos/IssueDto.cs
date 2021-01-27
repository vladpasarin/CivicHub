﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Dtos
{
    public class IssueDto
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public List<IssueStateDto> IssueStates { get; set; }
        public List<byte[]> Photos { get; set; }
        public int NumberOfSignatures { get; set; }
    }
}
