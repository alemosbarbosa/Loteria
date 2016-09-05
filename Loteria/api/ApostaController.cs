using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Loteria.Models;
using System.Data.Entity;

namespace Loteria.api
{
    public class ApostaController : ApiController
    {
        private LoteriaEntity entity = new LoteriaEntity();
        private DbSet<Aposta> MyAposta { get { return entity.Aposta; } }
        private LoteriaDAL dal = new LoteriaDAL();

        // GET api/aposta
        public IHttpActionResult Get()
        {
            var apostaDTOs = MyAposta.ToArray().Select(x => (ApostaDTO)x).ToArray();
            return Ok(apostaDTOs);
        }

        // GET api/aposta/5
        public IHttpActionResult Get(int id)
        {
            var aposta = MyAposta.FirstOrDefault(p => p.Id == id);

            if (aposta != null)
            {
                return Ok((ApostaDTO)aposta);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/aposta
        public IHttpActionResult Post([FromBody]ApostaDTO apostaDTO)
        {
            try
            {
                var idApostador = apostaDTO.IdApostador;
                var idSorteio = apostaDTO.IdSorteio;
                var numeros = apostaDTO.Numeros;
                var apostaAutomatica = apostaDTO.ApostaAutomatica;

                var newAposta = apostaAutomatica ? dal.CriaAposta(idApostador, idSorteio)
                                : dal.CriaAposta(idApostador, idSorteio, numeros);
                return Ok((ApostaDTO)newAposta);
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                return BadRequest(msg);
            }
        }

        // GET api/aposta/porapostador
        [Route("api/aposta/porapostador/{idApostador}")]
        [HttpGet]
        public IHttpActionResult ApostasApostador(int idApostador)
        {
            var apostas = MyAposta.Where(x => x.IdApostador == idApostador).ToArray();
            var apostaDTOs = apostas.Select(x => (ApostaDTO)x).ToArray();
            return Ok(apostaDTOs);
        }

        // GET api/aposta/porapostador
        [Route("api/aposta/porapostador/{idApostador}/{idSorteio}")]
        [HttpGet]
        public IHttpActionResult ApostasApostador(int idApostador, int idSorteio)
        {
            var apostas = MyAposta.Where(x => x.IdApostador == idApostador && x.IdSorteio == idSorteio).ToArray();
            var apostaDTOs = apostas.Select(x => (ApostaDTO)x).ToArray();
            return Ok(apostaDTOs);
        }
    }
}