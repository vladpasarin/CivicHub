using CivicHub.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IIssueStatePhotoService
    {
        List<IssueStatePhotoDto> GetAll(Guid IssueStateId);
        bool Create(IssueStatePhotoDto issueDTO);
        bool Update(IssueStatePhotoDto issueDTO);
        int Delete(Guid issueStatePhotoId);
    }
}
