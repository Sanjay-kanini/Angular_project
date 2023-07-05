using API_Project.Models;
using API_Project.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class Reader_Controller : ControllerBase
    {
        private IReader reader;
        public Reader_Controller(IReader reader)
        {
            this.reader = reader;
        }
        [HttpGet]

        public IEnumerable<Reader> Get_Reader()
        {
            return reader.Get();
        }

        //[HttpGet("{id}")]
        //public Reader GetID(int id)
        //{
        //    return reader.Get_byId(id);
        //}
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            reader.Delete(id);
        }

        [HttpPost]
        public Reader Post(Reader r)
        {
            return reader.Post(r);
        }
        [HttpPut("{id}")]
        public Reader post(int id, Reader r)
        {
            return reader.Put(id, r);

        }
        [HttpGet("{id}")]
        public Reader Getting_details(int id) 
        {
            return reader.Get_Details(id);
        }


    }
}
