using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class BotExecutionDTO
    {
        public long nIdBotExecution { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public string? sFechaIni { get; set; }
        public string? sFechaFin { get; set; }
        public int? nMinutos { get; set; }
    }
}
