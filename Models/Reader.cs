using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace API_Project.Models
{
    public class Reader
    {
        [Key]

        public int serial_no { get; set; }  
        public int Reader_id { get; set; }
        public string Reader_name { get; set; }
       
        public DateTime Date { get; set; }

        public string source { get; set; }

        public Article? Article { get; set; }    

    }
}
