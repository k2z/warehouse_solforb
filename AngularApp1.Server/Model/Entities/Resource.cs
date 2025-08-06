using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApp1.Server.Model.Entities
{

    public enum ResourceStatus
    {
        Active = 0,
        Archived = 1,
        Deleted = 2,
    }

    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ResourceStatus Status { get; set; }
    }
}
