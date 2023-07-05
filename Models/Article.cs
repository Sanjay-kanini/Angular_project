using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace API_Project.Models
{
    public class Article  //Parent class
    {
        [Key]
        public int Article_id { get; set; }
        public string? Article_name { get; set; }
        public string? Genere { get; set; }
        public string? Author_name { get; set; }
        public int?  Article_year { get; set; }

        public ICollection<Reader>? Readers { get; set; }    
    }
}
