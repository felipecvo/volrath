namespace Volrath.Migration {
	using ActiveRecord.net.Migrate;

	public class _20100728013957_CreateRoles : Migration {
		public override void Up() {
      using (var t = CreateTable("roles")) {
        t.String("name");
        t.TimeStamps();
      }
		}

		public override void Down() {
      DropTable("roles");
		}
	}
}
