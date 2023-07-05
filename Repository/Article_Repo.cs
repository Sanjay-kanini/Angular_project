using API_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static API_Project.Repository.Article_Repo;

namespace API_Project.Repository
{
   

    public class Article_Repo : IArticle
    {
        private readonly ARContext _con;

        public Article_Repo(ARContext con)
        {
            _con = con;
        }   

        public IEnumerable<Article> GetArticles()          ///get
        {
            return _con.Articles.Include(x => x.Readers).ToList();
        }


        public Article GetArticle_Byid(int id)
        {
            return _con.Articles.FirstOrDefault(x => x.Article_id == id);

        }
        public Article PostArticle(Article article)
        {
            _con.Add(article);
            _con.SaveChanges();
            return article;
        }
        public void Delete(int id)
        {
            Article a = _con.Articles.FirstOrDefault(x => x.Article_id == id);

            if (a != null)
            {
                // Attach the entity if not being tracked
                if (_con.Entry(a).State == EntityState.Detached)
                    _con.Attach(a);

                // Set entity state to Deleted
                _con.Entry(a).State = EntityState.Deleted;

                _con.SaveChanges();
            }
        }

        public Article  Update(int id,Article article)
        {
             

                _con.Entry(article).State = EntityState.Modified;
                _con.SaveChanges(true);
                 return article;  
        }

        public IEnumerable<Article> GetArticleWithMostReaders()
        {
            var articleWithMostReaders = _con.Articles
                .GroupJoin(
                    _con.Readers,
                    article => article.Article_id,
                    reader => reader.Article.Article_id,
                    (article, readers) => new
                    {
                        Article = article,
                        ReaderCount = readers.Count()
                    }
                )
                .OrderByDescending(a => a.ReaderCount)
                .Select(a => a.Article)
                .FirstOrDefault();

            return (IEnumerable<Article>)articleWithMostReaders;
        }

        public IEnumerable<Article> GetArticles(string filter)
        {
            var query = _con.Articles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(a => a.Article_name.Contains(filter));
            }

            return query.ToList();
        }

    }


}
