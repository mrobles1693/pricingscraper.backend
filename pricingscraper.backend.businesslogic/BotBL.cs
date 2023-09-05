using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.domain;
using pricingscraper.backend.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic
{
    public class BotBL : IBotBL
    {
        IBotRepository repository;

        public BotBL(IBotRepository _repository) 
        { 
            this.repository = _repository;
        }

        public async Task<IList<SimilarDTO>> getListSimilar() => await repository.getListSimilar();
    }
}
