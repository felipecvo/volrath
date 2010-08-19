namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using ActiveRecord.net;

  public class RolePermission : ActiveRecordBase<RolePermission> {
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}
