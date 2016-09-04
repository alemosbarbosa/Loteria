using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models
{
    public class ApostaDTO
    {
        public int? Id { get; set; }

        public int IdApostador { get; set; }

        public int IdSorteio { get; set; }

        public DateTime? DhAposta { get; set; }

        public int? IdTipoAcerto { get; set; }

        public int[] Numeros { get; set; }

        public static explicit operator Aposta(ApostaDTO apostaDTO)
        {
            var itemAposta = apostaDTO.Numeros.Select(x => new ItemAposta() { Id = -1, IdAposta = -1, Numero = x }).ToArray();
            var aposta = new Aposta() {
                Id = apostaDTO.Id.HasValue ? apostaDTO.Id.Value : -1,
                IdApostador = apostaDTO.IdApostador,
                IdSorteio = apostaDTO.IdSorteio,
                DhAposta = apostaDTO.DhAposta.HasValue ? apostaDTO.DhAposta.Value : DateTime.MinValue,
                IdTipoAcerto = apostaDTO.IdApostador,
                ItemAposta = itemAposta

            };
            // code to convert from int to SampleClass...

            return aposta;
        }
    }
}