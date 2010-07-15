namespace Volrath.Migration {
  using ActiveRecord.net.Migrate;

  public class _20100711162112_CreateUserActivities : Migration {
    public override void Up() {
      using (var t = CreateTable("user_activities")) {
        t.Integer("user_id");
        t.Integer("activity");
        t.DateTime("occurrence_date");
        t.String("ip");
      }
    }

    public override void Down() {
      DropTable("user_activities");
    }
  }
}
