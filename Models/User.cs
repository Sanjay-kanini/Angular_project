using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace APIDay3_OnetoMany.Models
{
    public class User
    {

        [System.ComponentModel.DataAnnotations.Key]
        public int user_id { get; set; }
        public string? user_name { get; set; }
        public string? user_email { get; set; }
        public string? user_password { get; set; }



    }
}
