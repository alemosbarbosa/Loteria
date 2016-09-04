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
    public class TipoSorteioController : ApiController
    {
        private LoteriaEntity entity = new LoteriaEntity();
        private DbSet<TipoSorteio> MyTipoSorteio { get { return entity.TipoSorteio; } }

        // GET api/tiposorteio
        public IHttpActionResult Get()
        {
            var tipoSorteioDTOs = MyTipoSorteio.ToArray().Select(x => (TipoSorteioDTO)x).ToArray();
            return Ok(tipoSorteioDTOs);
        }

        // GET api/tiposorteio/5
        public IHttpActionResult Get(int id)
        {
            var tipoSorteio = MyTipoSorteio.FirstOrDefault(p => p.Id == id);

            if (tipoSorteio != null)
            {
                return Ok((TipoSorteioDTO)tipoSorteio);
            }
            else
            {
                return NotFound();
            }
        }
    }
}