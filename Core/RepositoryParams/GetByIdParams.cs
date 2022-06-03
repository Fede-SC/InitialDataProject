using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techpork.Core.RepositoryParams
{
    public class GetByIdParams
    {
        public long Id { get; set; }
        public bool AsNoTracking { get; set; } = false;
        public string[] Includes { get; set; }

        public GetByIdParams() {}
        public GetByIdParams(
            long id,
            bool asNoTracking = false,
            params string[] includes) 
        {
            Id = id;
            AsNoTracking = asNoTracking;
            Includes = includes;
        }
    }
}