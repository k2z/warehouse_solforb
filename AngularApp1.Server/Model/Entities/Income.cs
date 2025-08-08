using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApp1.Server.Model.Entities
{
    public class Income
    {
        public int Id { get; set; }

        // [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public required string Number { get; set; }
        public DateOnly Date { get; set; }

        public ICollection<IncomeResource> IncomeResources { get; set; } = new List<IncomeResource>();
    }
}
