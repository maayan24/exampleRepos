using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DTO;
using ClassLibrary.EF;
namespace WebApi.Controllers
{
    public class officersController : ApiController
    {
        // GET api/<controller>
        public List<OfficerDto> Get()
        {
            bgroup51_test2TraffixDBContext db = new bgroup51_test2TraffixDBContext();
            return db.Officers.Select(x => new OfficerDto()
            {
                BadgeNum = x.BadgeNum,
                Name = x.Name
            }).ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        [Route("api/officer/{badgeNum}")]
        public void Put(int badgeNum, [FromBody] string newName)
        {
            bgroup51_test2TraffixDBContext db = new bgroup51_test2TraffixDBContext();
            Officer o = db.Officers.SingleOrDefault(x => x.BadgeNum == badgeNum);
            if (o != null)
            {
                o.Name = newName;
                db.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}