using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models.DTO
{
    public class SorteioDTO
    {
        public int? Id { get; set; }

        public int IdTipo { get; set; }

        public int NumSorteio { get; set; }

        public DateTime DhCriacao { get; set; }

        public DateTime DhSorteio { get; set; }

        public int CodStatus { get; set; }

        public int QtdApostas { get; set; }

        public int[] Numeros { get; set; }
    }
}