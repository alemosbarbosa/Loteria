using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models.DTO
{
    public class StatusSorteioDTO
    {
        public int CodStatus { get; set; }
        public string Descricao { get; set; }

        public static explicit operator StatusSorteio(StatusSorteioDTO statusSorteioDTO)
        {
            var statusSorteio = new StatusSorteio()
            {
                CodStatus = statusSorteioDTO.CodStatus,
                Descricao = statusSorteioDTO.Descricao,
            };
            return statusSorteio;
        }

        public static explicit operator StatusSorteioDTO(StatusSorteio statusSorteio)
        {
            var statusSorteioDTO = new StatusSorteioDTO()
            {
                CodStatus = statusSorteio.CodStatus,
                Descricao = statusSorteio.Descricao,
            };
            return statusSorteioDTO;
        }
    }
}