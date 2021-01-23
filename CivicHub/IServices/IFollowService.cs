using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IFollowService
    {
        Follow GetById(Guid id);
        List<Follow> GetAll();
        Tuple<int, object> Create(Follow follow);
        Tuple<int, object> Update(Follow follow);
        Tuple<int, object> Delete(Guid id);
        Tuple<int, object> GetByUserId(Guid id);
        Tuple<int, object> GetByIssueId(Guid id);

    }
}
