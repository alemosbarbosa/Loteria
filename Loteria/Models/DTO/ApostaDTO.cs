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

        // Parâmetro só utilizado entre o cliente Angularjs e o Web API
        public bool ApostaAutomatica { get; set; } = false;

        public static explicit operator Aposta(ApostaDTO apostaDTO)
        {
            var itemAposta = apostaDTO.Numeros.Select(x => new ItemAposta() { Numero = x }).ToArray();
            var aposta = new Aposta() {
                Id = apostaDTO.Id.HasValue ? apostaDTO.Id.Value : -1,
                IdApostador = apostaDTO.IdApostador,
                IdSorteio = apostaDTO.IdSorteio,
                DhAposta = apostaDTO.DhAposta.HasValue ? apostaDTO.DhAposta.Value : DateTime.MinValue,
                IdTipoAcerto = apostaDTO.IdApostador,
                ItemAposta = itemAposta
            };
            return aposta;
        }

        public static explicit operator ApostaDTO(Aposta aposta)
        {
            var numeros = aposta.ItemAposta .Select(x => x.Numero).ToArray();
            var apostaDTO = new ApostaDTO()
            {
                Id = aposta.Id,
                IdApostador = aposta.IdApostador,
                IdSorteio = aposta.IdSorteio,
                DhAposta = aposta.DhAposta,
                IdTipoAcerto = aposta.IdApostador,
                Numeros = numeros
            };
            return apostaDTO;
        }
    }
}