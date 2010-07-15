namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using ActiveRecord.net;

  public class UserActivity : ActiveRecordBase<UserActivity> {
    public int Id { get; set; }
    public int Activity { get; set; }
    public int UserId { get; set; }
    public DateTime OccurrenceDate { get; set; }
    public string Ip { get; set; }
  }
}
