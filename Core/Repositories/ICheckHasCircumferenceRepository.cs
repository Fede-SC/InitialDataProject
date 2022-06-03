using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techpork.Core.Entities;
using Techpork.Core.Repositories.Base;

namespace Techpork.Core.Repositories
{
    public interface ICheckHasCircumferenceRepository : IRepository<ChecksHasCircumference>
    {
        ChecksHasCircumference Get(long checkId, long circumferenceId, bool noTracking = false);
        Task<ChecksHasCircumference> GetAsync(long checkId, long circumferenceId, bool noTracking = false);
    }
}
