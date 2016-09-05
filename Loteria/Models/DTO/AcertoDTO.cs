using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models.DTO
{
    public class AcertoDTO
    {
        public int? Id { get; set; }

        public int IdSorteio { get; set; }

        public int IdAposta { get; set; }

        public string NomeAcertador { get; set; }

        public string DescricaoTipoAcerto { get; set; }

        public static explicit operator Acerto(AcertoDTO tipoAcertoDTO)
        {
            var tipoAcerto = new Acerto()
            {
                Id = tipoAcertoDTO.Id.HasValue ? tipoAcertoDTO.Id.Value : -1,
                IdSorteio = tipoAcertoDTO.IdSorteio,
                IdAposta = tipoAcertoDTO.IdAposta
            };
            return tipoAcerto;
        }

        public static explicit operator AcertoDTO(Acerto tipoAcerto)
        {
            var tipoAcertoDTO = new AcertoDTO()
            {
                Id = tipoAcerto.Id,
                IdSorteio = tipoAcerto.IdSorteio,
                IdAposta = tipoAcerto.IdAposta
            };
            return tipoAcertoDTO;
        }
    }
}