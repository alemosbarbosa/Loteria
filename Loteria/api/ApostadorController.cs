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
    public class ApostadorController : ApiController
    {
        private LoteriaEntity entity = new LoteriaEntity();
        private DbSet<Apostador> MyApostador { get { return entity.Apostador; } }
        private LoteriaDAL dal = new LoteriaDAL();

        // GET api/apostador
        public IHttpActionResult Get()
        {
            var apostadorDTOs = MyApostador.ToArray().Select(x => (ApostadorDTO)x).ToArray();
            return Ok(apostadorDTOs);
        }

        // GET api/apostador/5
        public IHttpActionResult Get(int id)
        {
            var apostador = MyApostador.FirstOrDefault(p => p.Id == id);

            if (apostador != null)
            {
                return Ok((ApostadorDTO)apostador);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/apostador/pornome/<nome>
        [Route("api/apostador/pornome/{nome}")]
        public IHttpActionResult Get(string nome)
        {
            var apostador = MyApostador.FirstOrDefault(p => p.Nome == nome);

            if (apostador != null)
            {
                return Ok((ApostadorDTO)apostador);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/apostador
        public IHttpActionResult Post([FromBody]ApostadorDTO apostadorDTO)
        {
            var nome = apostadorDTO.Nome;
            var newApostador = dal.CriaApostador(nome);
            return Ok((ApostadorDTO)newApostador);
        }
    }
}