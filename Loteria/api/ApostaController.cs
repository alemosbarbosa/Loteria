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


        //// PUT api/aposta/5
        //public IHttpActionResult Put(int id, [FromBody]Post post)
        //{
        //    Post _post = DataRepository.Posts.FirstOrDefault(p => p.Id == post.Id);

        //    if (_post != null)
        //    {
        //        for (int index = 0; index < DataRepository.Posts.Count; index++)
        //        {
        //            if (DataRepository.Posts[index].Id == id)
        //            {
        //                DataRepository.Posts[index] = post;
        //                return Ok();
        //            }
        //        }
        //    }

        //    return NotFound();
        //}

        //// DELETE api/aposta/5
        //public IHttpActionResult Delete(int id)
        //{
        //    if (DataRepository.Posts.Any(p => p.Id == id))
        //    {
        //        Post _post = DataRepository.Posts.First(p => p.Id == id);
        //        DataRepository.Posts.Remove(_post);

        //        return Ok();
        //    }

        //    return NotFound();
        //}
    }
}