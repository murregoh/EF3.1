using System.ComponentModel.DataAnnotations;

namespace SamuraiApp.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [Required]
        public Samurai Samurai { get; set; }
    }
}