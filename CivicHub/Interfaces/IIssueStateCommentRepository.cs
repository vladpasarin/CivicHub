﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;

namespace CivicHub.Interfaces
{
    public interface IIssueStateCommentRepository : IGenericRepository<IssueStateComment>
    {
        List<IssueStateComment> GetAllWithDetails(Guid issueStateId);
        IssueStateComment GetWithDetails(Guid id);
    }
}
