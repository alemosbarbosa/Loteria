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
        private LoteriaDAL dal = new LoteriaDAL();

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

        // GET api/sorteio/corrent
        [Route("api/sorteio/processa/{idSorteio}")]
        [HttpGet]
        public IHttpActionResult ProcessaSorteio(int idSorteio)
        {
            try
            {
                var sorteio = dal.ProcessaSorteio(idSorteio);
                return Ok((SorteioDTO)sorteio);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return BadRequest(msg);
            }
        }

        // POST api/sorteio
        public IHttpActionResult Post([FromBody]SorteioDTO sorteioDTO)
        {
            try
            {
                var idTipo = sorteioDTO.IdTipo;
                var newSorteio = dal.CriaSorteio(idTipo);
                return Ok((SorteioDTO)newSorteio);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return BadRequest(msg);
            }
        }

        // PUT api/sorteio/5
        public IHttpActionResult Put(int id, [FromBody]SorteioDTO sorteioDTO)
        {
            try
            {
                var idSorteio = sorteioDTO.Id.Value;
                var sorteioAutomaticao = sorteioDTO.SorteioAutomatico;
                var numeros = sorteioDTO.Numeros;
                var newSorteio = sorteioAutomaticao ? dal.FechaSorteio(idSorteio) : dal.FechaSorteio(idSorteio, numeros);
                return Ok((SorteioDTO)newSorteio);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return BadRequest(msg);
            }
        }
    }
}