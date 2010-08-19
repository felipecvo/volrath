namespace Volrath.Migration {
	using ActiveRecord.net.Migrate;

	public class _20100728012359_CreatePermissions : Migration {
		public override void Up() {
      using (var t = CreateTable("permissions")) {
        t.String("name");
        t.TimeStamps();
      }
		}

		public override void Down() {
      DropTable("permissions");
		}
	}
}
