using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.Data;

namespace CivicHub.Repositories
{
    public class IssueStateCommentPhotoRepository : GenericRepository<IssueStateCommentPhoto>, IIssueStateCommentPhotoRepository
    {
        public IssueStateCommentPhotoRepository(Context context) : base(context)
        {

        }
    }
}
