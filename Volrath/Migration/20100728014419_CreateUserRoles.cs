namespace Volrath.Migration {
	using ActiveRecord.net.Migrate;

	public class _20100728014419_CreateUserRoles : Migration {
		public override void Up() {
      using (var t = CreateTable("user_roles")) {
        t.Integer("user_id");
        t.Integer("role_id");
        t.TimeStamps();
      }
		}

		public override void Down() {
      DropTable("user_roles");
		}
	}
}
