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

        // GET api/aposta
        public IHttpActionResult Get()
        {
            var aposta = MyAposta;
            return Ok(aposta);
        }

        // GET api/aposta/5
        public IHttpActionResult Get(int id)
        {
            var post = MyAposta.FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/aposta
        public IHttpActionResult Post([FromBody]ApostaDTO apostaDTO)
        {
            var aposta = MyAposta.Add((Aposta)apostaDTO);
            return Ok(aposta);
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