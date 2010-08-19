namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using ActiveRecord.net;

  public class Permission : ActiveRecordBase<Permission> {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}
