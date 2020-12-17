using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.Data;

namespace CivicHub.Repositories
{
    public class IssueStatePhotoRepository : GenericRepository<IssueStatePhoto>, IIssueStatePhotoRepository
    {
        public IssueStatePhotoRepository(Context context) : base(context)
        {

        }
    }
}