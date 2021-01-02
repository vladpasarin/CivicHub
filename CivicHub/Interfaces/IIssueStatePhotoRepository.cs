﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;

namespace CivicHub.Interfaces
{
    public interface IIssueStatePhotoRepository : IGenericRepository<IssueStatePhoto>
    {
        List<IssueStatePhoto> GetAllWithDetails(Guid issueStateId);
    }
}
