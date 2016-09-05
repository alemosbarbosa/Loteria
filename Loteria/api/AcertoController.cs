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
    public class AcertoController : ApiController
    {
        private LoteriaEntity entity = new LoteriaEntity();
        private DbSet<Acerto> MyAcerto { get { return entity.Acerto; } }
        private LoteriaDAL dal = new LoteriaDAL();

        // GET api/acerto
        public IHttpActionResult Get()
        {
            var acertoDTOs = MyAcerto.ToArray().Select(x => (AcertoDTO)x).ToArray();
            return Ok(acertoDTOs);
        }

        // GET api/acerto/5
        public IHttpActionResult Get(int id)
        {
            var acerto = MyAcerto.FirstOrDefault(p => p.Id == id);

            if (acerto != null)
            {
                return Ok((AcertoDTO)acerto);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/porsorteio/portipo
        [Route("api/acerto/porsorteio/{idSorteio}")]
        [HttpGet]
        public IHttpActionResult AcertosPSorteio(int idSorteio)
        {
            var acertoDTOs = dal.BuscaAcertos(idSorteio);
            return Ok(acertoDTOs);
        }
    }
}