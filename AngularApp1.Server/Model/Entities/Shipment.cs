using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApp1.Server.Model.Entities
{
    public enum ShipmentState
    {
        Created = 0,
        Signed = 1,
        Rejected = 2,
    }

    public class Shipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public required string Number { get; set; }
        public DateOnly Date { get; set; }
        public ShipmentState State { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public ICollection<ShipmentResource> ShipmentResources { get; set; } = new List<ShipmentResource>();
    }
}
