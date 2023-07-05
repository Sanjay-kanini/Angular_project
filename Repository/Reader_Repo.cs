using API_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace API_Project.Repository
{
    public class Reader_Repo : IReader
    {
        private ARContext con;
        public Reader_Repo(ARContext con)
        {
            this.con = con;
        }
        public IEnumerable<Reader> Get()
        {
           
                return con.Readers.Include(x => x.Article).ToList();
           
            
        }
        public Reader Get_byId(int id)
        {

            var reader = con.Readers.FirstOrDefault(x => x.Reader_id == id);
                 //return con.Articles.FirstOrDefault(x => x.Article_id == id);
            return reader;
        }
        public void Delete(int id)
        {
            Reader r = con.Readers.FirstOrDefault(x => x.Reader_id == id);
            con.Remove(r);
            con.SaveChanges();
            
        }
        public Reader Post(Reader reader)
        {
           
            con.Readers.Add(reader);
            con.SaveChanges();
            return reader;
        }
        public  Reader Put(int id,Reader reader) 
        {
            //Reader read = con.Readers.FirstOrDefault(x=>x.Reader_id == id);
            con.Entry(reader).State = EntityState.Modified;
             con.SaveChangesAsync();
            return reader;
        }
        
        public Reader Get_Details(int id)                       
        {
            return  con.Readers.FirstOrDefault(n => n.Reader_id == id);
        }

    }
}
