using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models.DTO
{
    public class ApostadorDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DhCadastro { get; set; }

        public static explicit operator Apostador(ApostadorDTO apostadorDTO)
        {
            var apostador = new Apostador()
            {
                Id = apostadorDTO.Id.HasValue ? apostadorDTO.Id.Value : -1,
                Nome = apostadorDTO.Nome,
                DhCadastro = apostadorDTO.DhCadastro.HasValue ? apostadorDTO.DhCadastro.Value : DateTime.MinValue
            };
            return apostador;
        }

        public static explicit operator ApostadorDTO(Apostador apostador)
        {
            var apostadorDTO = new ApostadorDTO()
            {
                Id = apostador.Id,
                Nome = apostador.Nome,
                DhCadastro = apostador.DhCadastro
            };
            return apostadorDTO;
        }

    }
}