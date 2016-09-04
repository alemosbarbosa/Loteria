using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models.DTO
{
    public class TipoAcertoDTO
    {
        public int? Id { get; set; }

        public int IdTipo { get; set; }

        public string Descricao { get; set; }

        public int QtdNumerosAcertados { get; set; }

        public static explicit operator TipoAcerto(TipoAcertoDTO tipoAcertoDTO)
        {
            var tipoAcerto = new TipoAcerto()
            {
                Id = tipoAcertoDTO.Id.HasValue ? tipoAcertoDTO.Id.Value : -1,
                IdTipo = tipoAcertoDTO.IdTipo,
                Descricao = tipoAcertoDTO.Descricao,
                QtdNumerosAcertados = tipoAcertoDTO.QtdNumerosAcertados
            };
            return tipoAcerto;
        }

        public static explicit operator TipoAcertoDTO(TipoAcerto tipoAcerto)
        {
            var tipoAcertoDTO = new TipoAcertoDTO()
            {
                Id = tipoAcerto.Id,
                IdTipo = tipoAcerto.IdTipo,
                Descricao = tipoAcerto.Descricao,
                QtdNumerosAcertados = tipoAcerto.QtdNumerosAcertados
            };
            return tipoAcertoDTO;
        }
    }
}