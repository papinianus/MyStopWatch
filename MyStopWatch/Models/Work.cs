using System.ComponentModel.DataAnnotations.Schema;

namespace MyStopWatch.Models
{
    public class Work
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Title { get; set; }
    }
}
