using API_Project.Models;
using API_Project.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;

namespace API_Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    

    public class ArticleController : ControllerBase
    {

        private readonly IArticle art;
        public ArticleController(IArticle art)
        {
            this.art = art;
        }


        [HttpGet]
        
        public IEnumerable<Article> Get()
        {
            return art.GetArticles();
        }


        [HttpGet("{id}")]
        public Article GetBy_Id(int id)
        {
            return art.GetArticle_Byid(id);
        }

        [HttpDelete("{id}")]
        public void Delete_ID(int id)
        {
            art.Delete(id);
        }
        [HttpPost]

        public Article Post_Article(Article article)
        {
            return art.PostArticle(article);

        }
        [HttpPut("{id}")]
        public Article Update_Article(int id, Article article)
        {
            return art.Update(id,article);
        }

        [HttpGet("year")]
        // [Route("countarticle/{id}")]

        public int GetCount(int year)
        {
            //int count = 0;
            SqlConnection con = new SqlConnection("data source =DESKTOP-GPOQ94V\\SQLEXPRESS ; database = API_Project; integrated security = true; trustservercertificate =true;");
            SqlCommand cmd = new SqlCommand("sp_Count", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@year", year);

            int count = (int)cmd.ExecuteScalar();

            return count;
            con.Close();
        }
        /* [HttpGet] // Get article with most readers
         [Route("api/articles/most-readers")]
         public IEnumerable<Article> GetArticleWithMostReaders()
         {
             var articleWithMostReaders = art.GetArticleWithMostReaders();

             if (articleWithMostReaders == null)
             {
                 return (IEnumerable<Article>)NotFound(); // Handle the case where there are no articles
             }

             return (IEnumerable<Article>)Ok(articleWithMostReaders);
         }*/

        [HttpGet("artilce_name")]
        //[Route("api/articles")]
        public IEnumerable<Article> Get(string filter)
        {
            return art.GetArticles(filter);
        }



    }
}
