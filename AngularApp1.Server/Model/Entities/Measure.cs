using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApp1.Server.Model.Entities
{
    public enum MeasureStatus
    {
        Active = 0,
        Archived = 1,
        Deleted = 2,
    }

    public class Measure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public MeasureStatus Status { get; set; }
    }
}
