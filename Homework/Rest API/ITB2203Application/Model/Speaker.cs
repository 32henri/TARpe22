using System.ComponentModel.DataAnnotations;

namespace ITB2203Application.Model
{
    public class Speaker
    {
        [Key]
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

}
