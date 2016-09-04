using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models.DTO
{
    public class TipoAcertoDTO
    {
        public int Id { get; set; }

        public int IdTipo { get; set; }

        public string Descricao { get; set; }

        public int QtdNumerosAcertados { get; set; }
    }
}