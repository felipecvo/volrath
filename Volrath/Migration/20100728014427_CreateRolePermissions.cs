namespace Volrath.Migration {
	using ActiveRecord.net.Migrate;

	public class _20100728014427_CreateRolePermissions : Migration {
		public override void Up() {
      using (var t = CreateTable("role_permissions")) {
        t.Integer("role_id");
        t.Integer("permission_id");
        t.TimeStamps();
      }
		}

		public override void Down() {
      DropTable("role_permissions");
		}
	}
}
