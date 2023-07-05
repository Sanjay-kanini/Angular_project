using API_Project.Models;

namespace API_Project.Repository
{
    public interface IArticle
    {
        public IEnumerable<Article> GetArticles();

        public Article GetArticle_Byid(int id);
        public Article  PostArticle(Article article);

        public void Delete(int id);

        public Article  Update(int id , Article article);
        public IEnumerable<Article> GetArticles(string filter);


        public IEnumerable<Article> GetArticleWithMostReaders();
 

    }
}
