using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models.DTO
{
    public class TipoSorteioDTO
    {
        public int? Id { get; set; }

        public string Descricao { get; set; }

        public int? NumSorteioCorrente { get; set; }

        public int MinNumerosPorJogo { get; set; }

        public int MaxNumerosPorJogo { get; set; }

        public int MinValorNumero { get; set; }

        public int MaxValorNumero { get; set; }

        public static explicit operator TipoSorteio(TipoSorteioDTO tipoSorteioDTO)
        {
            var tipoSorteio = new TipoSorteio()
            {
                Id = tipoSorteioDTO.Id.HasValue ? tipoSorteioDTO.Id.Value : -1,
                Descricao = tipoSorteioDTO.Descricao,
                NumSorteioCorrente = tipoSorteioDTO.NumSorteioCorrente.HasValue ? tipoSorteioDTO.NumSorteioCorrente.Value : -1,
                MinNumerosPorJogo = tipoSorteioDTO.MinNumerosPorJogo,
                MaxNumerosPorJogo = tipoSorteioDTO.MaxNumerosPorJogo,
                MinValorNumero = tipoSorteioDTO.MinValorNumero,
                MaxValorNumero = tipoSorteioDTO.MaxValorNumero,
            };
            return tipoSorteio;
        }

        public static explicit operator TipoSorteioDTO(TipoSorteio tipoSorteio)
        {
            var tipoSorteioDTO = new TipoSorteioDTO()
            {
                Id = tipoSorteio.Id,
                Descricao = tipoSorteio.Descricao,
                NumSorteioCorrente = tipoSorteio.NumSorteioCorrente,
                MinNumerosPorJogo = tipoSorteio.MinNumerosPorJogo,
                MaxNumerosPorJogo = tipoSorteio.MaxNumerosPorJogo,
                MinValorNumero = tipoSorteio.MinValorNumero,
                MaxValorNumero = tipoSorteio.MaxValorNumero,
            };
            return tipoSorteioDTO;
        }
    }
}