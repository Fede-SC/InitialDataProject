using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techpork.Core.Entities;
using Techpork.Core.Repositories;
using Techpork.Core.Repositories.Base;

namespace Techpork.Infrastructure.Persistance.Data.Repositories
{
    public class CheckHasCircumferenceRepository : 
        Repository<ChecksHasCircumference>, ICheckHasCircumferenceRepository
    {
        private readonly TechPorkContext _connContext;
        private readonly ILogger<CheckHasCircumferenceRepository> _logger;
        public CheckHasCircumferenceRepository(
            TechPorkContext connContext, 
            ILogger<CheckHasCircumferenceRepository> logger) : base(connContext, logger)
        {
            _connContext = connContext;
            _logger = logger;
        }

        public ChecksHasCircumference Get(long checkId, long circumferenceId, bool noTracking = false)
        {
            var query = _connContext.ChecksHasCircumferences
               .Where(c => c.CheckId == checkId && c.CircumferenceId == circumferenceId);

            if (noTracking)
                return query.AsNoTracking().FirstOrDefault();
            else
                return query.FirstOrDefault();
        }

        public async Task<ChecksHasCircumference> GetAsync(
            long checkId, long circumferenceId, bool noTracking = false)
        {
            var query = _connContext.ChecksHasCircumferences
                .Where(c => c.CheckId == checkId && c.CircumferenceId == circumferenceId);

            if (noTracking)
                return await query.AsNoTracking().FirstOrDefaultAsync();
            else
                return await query.FirstOrDefaultAsync();
        }
    }
}
