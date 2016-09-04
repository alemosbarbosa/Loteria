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
    public class StatusSorteioController : ApiController
    {
        private LoteriaEntity entity = new LoteriaEntity();
        private DbSet<StatusSorteio> MyStatusSorteio { get { return entity.StatusSorteio; } }

        // GET api/statussorteio
        public IHttpActionResult Get()
        {
            var statusSorteioDTOs = MyStatusSorteio.ToArray().Select(x => (StatusSorteioDTO)x).ToArray();
            return Ok(statusSorteioDTOs);
        }

        // GET api/statussorteio/5
        public IHttpActionResult Get(int id)
        {
            var statusSorteio = MyStatusSorteio.FirstOrDefault(p => p.CodStatus == id);

            if (statusSorteio != null)
            {
                return Ok((StatusSorteioDTO)statusSorteio);
            }
            else
            {
                return NotFound();
            }
        }
    }
}