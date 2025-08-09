

using AngularApp1.Server.Model.Entities;

namespace AngularApp1.Server.Model.DataTransferObjects
{
  public class Resource
  {
    public int? Id { get; set; }
    public string? Name { get; set; }
    public ResourceStatus? Status { get; set; }
  }
}
