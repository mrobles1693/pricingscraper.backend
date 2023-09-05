using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.repository.Interfaces
{
    public interface IBotRepository
    {
        Task<IList<SimilarDTO>> getListSimilar();
    }
}
