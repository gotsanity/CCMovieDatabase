using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMovieDatabase.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey(nameof(ActingCredit))]
        public int ActingCreditId { get; set; }
        public virtual ActingCredit ActingCredit { get; set; }
    }
}
