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

        public int? NumSorteio { get; set; }

        public DateTime? DhCriacao { get; set; }

        public DateTime? DhSorteio { get; set; }

        public int? CodStatus { get; set; }

        public int? QtdApostas { get; set; }

        public int[] Numeros { get; set; }

        // Parâmetro só utilizado entre o cliente Angularjs e o Web API
        public bool SorteioAutomatico { get; set; } = true;

        public static explicit operator Sorteio(SorteioDTO sorteioDTO)
        {
            var itemSorteio = sorteioDTO.Numeros.Select(x => new ItemSorteio() { Numero = x }).ToArray();
            var sorteio = new Sorteio()
            {
                Id = sorteioDTO.Id.HasValue ? sorteioDTO.Id.Value : -1,
                IdTipo = sorteioDTO.IdTipo,
                NumSorteio = sorteioDTO.NumSorteio.HasValue ? sorteioDTO.NumSorteio.Value : -1,
                DhCriacao = sorteioDTO.DhCriacao.HasValue ? sorteioDTO.DhCriacao.Value : DateTime.MinValue,
                DhSorteio = sorteioDTO.DhSorteio,
                CodStatus = sorteioDTO.CodStatus.HasValue ? sorteioDTO.CodStatus.Value : -1,
                QtdApostas = sorteioDTO.QtdApostas.HasValue ? sorteioDTO.QtdApostas.Value : -1,
                ItemSorteio = itemSorteio

            };
            return sorteio;
        }

        public static explicit operator SorteioDTO(Sorteio sorteio)
        {
            var numeros = sorteio.ItemSorteio.Select(x => x.Numero).ToArray();
            var sorteioDTO = new SorteioDTO()
            {
                Id = sorteio.Id,
                IdTipo = sorteio.IdTipo,
                NumSorteio = sorteio.NumSorteio,
                DhCriacao = sorteio.DhCriacao,
                DhSorteio = sorteio.DhSorteio,
                CodStatus = sorteio.CodStatus,
                QtdApostas = sorteio.QtdApostas,
                Numeros = numeros
            };
            return sorteioDTO;
        }

    }
}