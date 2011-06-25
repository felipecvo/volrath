namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using Boycott;

  public class UserActivity : Base<UserActivity> {
    public int Id { get; set; }
    public int Activity { get; set; }
    public int UserId { get; set; }
    public DateTime OccurrenceDate { get; set; }
    public string Ip { get; set; }
  }
}
