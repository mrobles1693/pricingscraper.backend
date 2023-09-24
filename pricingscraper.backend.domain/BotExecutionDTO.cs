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
        public int? nIdTurno { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public string? sFechaIni { get; set; }
        public string? sFechaFin { get; set; }
        public int? nMinutos { get; set; }
        public int? nCantProductos { get; set; }
        public int? nCantSimilar { get; set; }
        public int? nCantProductosScrap { get; set; }
        public int? nCantSimilarScrap { get; set; }
    }

    public class BotExecutionReportDTO
    {
        public string sSKU { get; set; }
        public string sDescripcion { get; set; }
        public int nIdComercio { get; set; }
        public string sComercio { get; set; }
        public decimal nPrecio { get; set; }
        public decimal? nPrecioOferta { get; set; }
        public decimal? nPrecioTarjeta { get; set; }
    }
}
