using API_Project.Models;

namespace API_Project.Repository
{
    public interface IReader
    {
        public IEnumerable<Reader >Get();   //get

        //public Reader Get_byId(int id);         //get_by_id
        public void Delete(int id);

        public Reader Post(Reader reader);

        public Reader Put(int id ,Reader reader);

        public Reader Get_Details (int id);

    }
}
