using Loteria.Models;
using Loteria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Loteria.api
{
    public class TipoAcertoController : ApiController
    {
        private LoteriaEntity entity = new LoteriaEntity();
        private DbSet<TipoAcerto> MyTipoAcerto { get { return entity.TipoAcerto; } }

        // GET api/tipoacerto
        public IHttpActionResult Get()
        {
            var tipoAcertoDTOs = MyTipoAcerto.ToArray().Select(x => (TipoAcertoDTO)x).ToArray();
            return Ok(tipoAcertoDTOs);
        }

        // GET api/tipoacerto/5
        public IHttpActionResult Get(int id)
        {
            var tipoAcerto = MyTipoAcerto.FirstOrDefault(p => p.Id == id);

            if (tipoAcerto != null)
            {
                return Ok((TipoAcertoDTO)tipoAcerto);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/tipoacert/corrent
        [Route("api/tipoacerto/portipo/{idTipo}")]
        [HttpGet]
        public IHttpActionResult AcertosPTipo(int idTipo)
        {
            var acerto = MyTipoAcerto.FirstOrDefault(p => p.IdTipo == idTipo);

            if (acerto != null)
            {
                return Ok((TipoAcertoDTO)acerto);
            }
            else
            {
                return NotFound();
            }
        }

    }
}