using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models.DTO
{
    public class TipoSorteio
    {
        public int? Id { get; set; }

        public string Descricao { get; set; }

        public int? NumSorteioCorrente { get; set; }
    }
}