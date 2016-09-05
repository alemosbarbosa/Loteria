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
    public class SorteioController : ApiController
    {
        private LoteriaEntity entity = new LoteriaEntity();
        private DbSet<Sorteio> MySorteio { get { return entity.Sorteio; } }

        // GET api/sorteio
        public IHttpActionResult Get()
        {
            var sorteioDTOs = MySorteio.ToArray().Select(x => (SorteioDTO)x).ToArray();
            return Ok(sorteioDTOs);
        }

        // GET api/sorteio/5
        public IHttpActionResult Get(int id)
        {
            var sorteio = MySorteio.FirstOrDefault(p => p.Id == id);

            if (sorteio != null)
            {
                return Ok((SorteioDTO)sorteio);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/sorteio/corrent
        [Route("api/sorteio/corrente/{idTipo}/{numSorteio}")]
        [HttpGet]
        public IHttpActionResult SorteioCorrente(int idTipo, int numSorteio)
        {
            var sorteio = MySorteio.FirstOrDefault(p => p.IdTipo == idTipo && p.NumSorteio == numSorteio);

            if (sorteio != null)
            {
                return Ok((SorteioDTO)sorteio);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/sorteio/portipo
        [Route("api/sorteio/portipo/{idTipo}")]
        [HttpGet]
        public IHttpActionResult SorteiosPTipo(int idTipo)
        {
            var sorteios = MySorteio.Where(p => p.IdTipo == idTipo).ToArray();
            var sorteioDTOs = sorteios.Select(x => (SorteioDTO)x).ToArray();
            return Ok(sorteioDTOs);
        }
    }
}