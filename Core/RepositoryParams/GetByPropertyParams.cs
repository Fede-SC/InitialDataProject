using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techpork.Core.RepositoryParams
{
    public class GetByPropertyParams
    {
        public string Property { get; set; }
        public object SearchItem { get; set; }
        public bool AsNoTracking { get; set; } = false;
        public string[] Includes { get; set; }

        public GetByPropertyParams() {}

        public GetByPropertyParams(
            string property,
            object searchItem,
            bool asNoTracking = false,
            params string[] includes
        )
        {
            Property = property;
            SearchItem = searchItem;
            AsNoTracking = asNoTracking;
            Includes = includes;
        }
    }
}